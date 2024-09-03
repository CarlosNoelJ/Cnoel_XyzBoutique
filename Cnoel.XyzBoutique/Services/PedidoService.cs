using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Repositories.Interfaces;
using Cnoel.XyzBoutique.Repositories.States;
using Cnoel.XyzBoutique.Services.Interfaces;

namespace Cnoel.XyzBoutique.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly Dictionary<EstadoPedido, IEstadoPedido> _estados;

        public PedidoService(IPedidoRepository pedidoRepository, Dictionary<EstadoPedido, IEstadoPedido> estados)
        {
            _pedidoRepository = pedidoRepository;
            _estados = estados;
        }

        public async Task<Pedido> CambiarEstadoDelPedido(int numeroPedido, EstadoPedido nuevoEstado)
        {
            var pedido = await _pedidoRepository.ObtenerPedidoById(numeroPedido);

            if (pedido == null)
                throw new Exception("Pedido no encontrado");

            if (_estados[nuevoEstado].EsCorrectaLaTransicion(pedido.Estado))
                throw new Exception("No se puede cambiar a este estado");

            _estados[nuevoEstado].Manejo(pedido);
            pedido.Estado = nuevoEstado;

            return await _pedidoRepository.ActualizarPedido(pedido);
        }

        public async Task<Pedido> CrearPedido(Pedido pedido)
            => await _pedidoRepository.AgregarPedido(pedido);
    }
}
