using Cnoel.XyzBoutique.Models;

namespace Cnoel.XyzBoutique.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Task<Pedido> AgregarPedido(Pedido pedido);
        Task<Pedido> ObtenerPedidoById(int id);
        Task<Pedido> ActualizarPedido(Pedido pedido);
    }
}
