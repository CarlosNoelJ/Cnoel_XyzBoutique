using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Repositories.Interfaces;

namespace Cnoel.XyzBoutique.Repositories.States
{
    public class EstadoEnDelivery : IEstadoPedido
    {
        public bool EsCorrectaLaTransicion(EstadoPedido estadoActual)
            => estadoActual != EstadoPedido.PorAtender && estadoActual != EstadoPedido.EnProceso;

        public void Manejo(Pedido pedido)
            => pedido.FechaDespacho = DateTime.UtcNow;
    }
}
