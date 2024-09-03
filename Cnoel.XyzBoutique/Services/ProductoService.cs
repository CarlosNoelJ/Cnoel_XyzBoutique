using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Repositories.Interfaces;
using Cnoel.XyzBoutique.Services.Interfaces;

namespace Cnoel.XyzBoutique.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
            => _productoRepository = productoRepository;

        public async Task<Producto> ActualizarProducto(Producto producto)
        {
            var productoActualizar = await _productoRepository.ObtenerProductoById(producto.Sku);

            if (productoActualizar == null)
                throw new Exception("Producto no existe");

            return await _productoRepository.ActualizarProducto(producto);
        }

        public async Task<Producto> CrearProducto(Producto producto)
            => await _productoRepository.AgregarProducto(producto);

        public async Task<Producto> ObtenerProductoById(int sku)
            => await _productoRepository.ObtenerProductoById(sku);
    }
}
