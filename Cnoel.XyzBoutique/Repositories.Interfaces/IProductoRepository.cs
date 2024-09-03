using Cnoel.XyzBoutique.Models;

namespace Cnoel.XyzBoutique.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<Producto> AgregarProducto(Producto producto);
        Task<Producto> ObtenerProductoById(int sku);
        Task<Producto> ActualizarProducto(Producto producto);
    }
}
