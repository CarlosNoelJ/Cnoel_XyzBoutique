using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Repositories.Interfaces;
using Cnoel.XyzBoutique.Services;
using Moq;

namespace Cnoel.XyzBoutique.Tests
{
    public class ProductoServiceTest
    {
        private readonly ProductoService _productoService;
        private readonly Mock<IProductoRepository> _productoRepositoryMock;
        
        public ProductoServiceTest()
        {
            _productoRepositoryMock = new Mock<IProductoRepository>();

            _productoService = new ProductoService(_productoRepositoryMock.Object);
        }

        [Fact]
        public async Task CrearProducto_Exitosamente()
        {
            var productoDto = new Producto
            {
                Sku = 1,
                Nombre = "Agua Mineral",
                Tipo = "Liquido",
                Etiquetas = "San Carlos",
                Precio = 12.0M,
                UnidadDeMedida = UnidadDeMedida.un
            };

            _productoRepositoryMock.Setup(repo => repo.AgregarProducto(productoDto)).ReturnsAsync(productoDto);

            var result = await _productoService.CrearProducto(productoDto);

            Assert.NotNull(result);
            Assert.Equal(productoDto.Sku, result.Sku);
        }

        [Fact]
        public async Task ObtenerProductoBySku_Exitosamente()
        {
            var productoDto = new Producto
            {
                Sku = 1,
                Nombre = "Agua Mineral",
                Tipo = "Liquido",
                Etiquetas = "San Carlos",
                Precio = 12.0M,
                UnidadDeMedida = UnidadDeMedida.un
            };

            _productoRepositoryMock.Setup(repo => repo.ObtenerProductoById(productoDto.Sku)).ReturnsAsync(productoDto);

            var result = await _productoService.ObtenerProductoById(productoDto.Sku);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ActualizarProducto()
        {
            var productoDto = new Producto
            {
                Sku = 1,
                Nombre = "Agua Mineral",
                Tipo = "Liquido",
                Etiquetas = "San Carlos",
                Precio = 12.0M,
                UnidadDeMedida = UnidadDeMedida.un
            };

            _productoRepositoryMock.Setup(repo => repo.AgregarProducto(productoDto)).ReturnsAsync(productoDto);
            _productoRepositoryMock.Setup(repo => repo.ObtenerProductoById(productoDto.Sku)).ReturnsAsync(productoDto);

            var producto = await _productoService.ObtenerProductoById(productoDto.Sku);

            Assert.Equal(productoDto.Precio, producto.Precio);

            productoDto.Precio = 8.0M;

            _productoRepositoryMock.Setup(repo => repo.ActualizarProducto(productoDto)).ReturnsAsync(productoDto);

            var result = await _productoService.ObtenerProductoById(productoDto.Sku);

            Assert.Equal(8.0M, result.Precio);
        }
    }
}
