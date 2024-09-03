using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Repositories.Interfaces;

namespace Cnoel.XyzBoutique.Repositories.States
{
    public class EstadoPorAtender : IEstadoPedido
    {
        public bool EsCorrectaLaTransicion(EstadoPedido estadoActual)
        {
            return estadoActual == EstadoPedido.PorAtender;
        }

        public void Manejo(Pedido pedido)
            => pedido.FechaPedido = DateTime.UtcNow;
    }
}
