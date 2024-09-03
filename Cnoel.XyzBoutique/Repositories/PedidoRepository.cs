using Cnoel.XyzBoutique.Data;
using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Repositories.Interfaces;

namespace Cnoel.XyzBoutique.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly MainDbContext _context;

        public PedidoRepository(MainDbContext context)
            => _context = context;

        public async Task<Pedido> ActualizarPedido(Pedido pedido)
        {
            _context.Pedido.Update(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> AgregarPedido(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> ObtenerPedidoById(int id)
            => await _context.Pedido.FindAsync(id);
    }
}
