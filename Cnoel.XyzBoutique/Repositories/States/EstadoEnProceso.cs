using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Repositories.Interfaces;

namespace Cnoel.XyzBoutique.Repositories.States
{
    public class EstadoEnProceso : IEstadoPedido
    {
        public bool EsCorrectaLaTransicion(EstadoPedido estadoActual)
            => estadoActual != EstadoPedido.PorAtender;

        public void Manejo(Pedido pedido)
            => pedido.FechaRecepcion = DateTime.UtcNow;
    }
}
