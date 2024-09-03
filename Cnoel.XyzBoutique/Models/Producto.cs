using System.ComponentModel.DataAnnotations;

namespace Cnoel.XyzBoutique.Models
{
    public class Producto
    {
        [Key]
        public int Sku { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public string Etiquetas { get; set; }
        public decimal Precio { get; set; }
        public UnidadDeMedida UnidadDeMedida { get; set; }

    }

    public enum UnidadDeMedida
    {
        un,
        kg
    }
}
