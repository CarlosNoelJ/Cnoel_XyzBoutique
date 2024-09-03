using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Repositories.Interfaces;
using Cnoel.XyzBoutique.Services;
using Moq;

namespace Cnoel.XyzBoutique.Tests
{
    public class PedidoServiceTests
    {
        private readonly PedidoService _pedidoService;
        private readonly Mock<IPedidoRepository> _pedidoRepositoryMock;
        private readonly Mock<IEstadoPedido> _estadoPorAtenderMock;
        private readonly Mock<IEstadoPedido> _estadoEnProcesoMock;
        private readonly Mock<IEstadoPedido> _estadoEnDeliveryMock;
        private readonly Mock<IEstadoPedido> _estadoRecibidoMock;

        public PedidoServiceTests()
        {
            _estadoPorAtenderMock = new Mock<IEstadoPedido>();
            _estadoEnProcesoMock = new Mock<IEstadoPedido>();
            _estadoEnDeliveryMock = new Mock<IEstadoPedido>();
            _estadoRecibidoMock = new Mock<IEstadoPedido>();

            var estados = new Dictionary<EstadoPedido, IEstadoPedido>
            {
                { EstadoPedido.PorAtender, _estadoPorAtenderMock.Object },
                { EstadoPedido.EnProceso, _estadoEnProcesoMock.Object },
                { EstadoPedido.EnDelivery, _estadoEnDeliveryMock.Object },
                { EstadoPedido.Recibido, _estadoRecibidoMock.Object }
            };

            _pedidoRepositoryMock = new Mock<IPedidoRepository>();

            _pedidoService = new PedidoService(_pedidoRepositoryMock.Object, estados);
        }

        [Fact]
        public async Task CambiarEstadoDelPedido_DeberiaCambiarEstado_CuandoTransicionEsValida()
        {
            var pedidoDto = new Pedido { NumeroPedido = 1, Estado = EstadoPedido.PorAtender };

            _pedidoRepositoryMock.Setup(repo => repo.ObtenerPedidoById(pedidoDto.NumeroPedido))
                .ReturnsAsync(pedidoDto);

            _estadoEnProcesoMock.Setup(e => e.EsCorrectaLaTransicion(EstadoPedido.PorAtender))
                .Returns(false); 

            _pedidoRepositoryMock.Setup(repo => repo.ActualizarPedido(It.IsAny<Pedido>()))
                .ReturnsAsync(pedidoDto);
            
            var result = await _pedidoService.CambiarEstadoDelPedido(pedidoDto.NumeroPedido, EstadoPedido.EnProceso);

            Assert.NotNull(result);
            Assert.Equal(EstadoPedido.EnProceso, result.Estado);
            _estadoEnProcesoMock.Verify(e => e.Manejo(pedidoDto), Times.Once);
            _pedidoRepositoryMock.Verify(repo => repo.ActualizarPedido(pedidoDto), Times.Once);
        }


        [Fact]
        public async Task CambiarEstadoDelPedido_DeberiaLanzarExcepcion_CuandoTransicionEsInvalida()
        {
            var pedido = new Pedido { NumeroPedido = 1, Estado = EstadoPedido.EnProceso };

            _pedidoRepositoryMock.Setup(repo => repo.ObtenerPedidoById(pedido.NumeroPedido))
                .ReturnsAsync(pedido);

            _estadoRecibidoMock.Setup(e => e.EsCorrectaLaTransicion(EstadoPedido.EnProceso))
                .Returns(true); 

            await Assert.ThrowsAsync<Exception>(() => _pedidoService.CambiarEstadoDelPedido(pedido.NumeroPedido, EstadoPedido.Recibido));
        }
    }
}
