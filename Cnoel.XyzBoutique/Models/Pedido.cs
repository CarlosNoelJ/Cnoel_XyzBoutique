using System.ComponentModel.DataAnnotations;

namespace Cnoel.XyzBoutique.Models
{
    public class Pedido
    {
        [Key]
        public int NumeroPedido { get; set; }
        public string? ListaProductos { get; set; }
        public DateTime? FechaPedido { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public DateTime? FechaDespacho { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int VendedorId { get; set; }
        public int RepartidorId { get; set; }
        public EstadoPedido Estado { get; set; }
    }

    public enum EstadoPedido
    {
        PorAtender,
        EnProceso,
        EnDelivery,
        Recibido
    }
}
