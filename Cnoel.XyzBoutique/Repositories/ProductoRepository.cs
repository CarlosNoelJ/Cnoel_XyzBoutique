using Cnoel.XyzBoutique.Data;
using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Repositories.Interfaces;

namespace Cnoel.XyzBoutique.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MainDbContext _context;

        public ProductoRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> ActualizarProducto(Producto producto)
        {
            _context.Producto.Update(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto> AgregarProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto> ObtenerProductoById(int id)
            => await _context.Producto.FindAsync(id);
    }
}
