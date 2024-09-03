using Cnoel.XyzBoutique.Models;

namespace Cnoel.XyzBoutique.Repositories.Interfaces
{
    public interface IEstadoPedido
    {
        void Manejo(Pedido pedido);
        bool EsCorrectaLaTransicion(EstadoPedido estadoActual);
    }
}
