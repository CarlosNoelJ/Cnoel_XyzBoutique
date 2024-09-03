using Cnoel.XyzBoutique.Models;

namespace Cnoel.XyzBoutique.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido> CrearPedido(Pedido pedido);
        Task<Pedido> CambiarEstadoDelPedido(int numeroPedido, EstadoPedido nuevoEstado);
    }
}
