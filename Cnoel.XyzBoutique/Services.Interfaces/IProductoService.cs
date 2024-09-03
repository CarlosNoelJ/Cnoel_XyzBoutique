using Cnoel.XyzBoutique.Models;

namespace Cnoel.XyzBoutique.Services.Interfaces
{
    public interface IProductoService
    {
        Task<Producto> CrearProducto(Producto producto);
        Task<Producto> ObtenerProductoById(int sku);
        Task<Producto> ActualizarProducto(Producto producto);
    }
}
