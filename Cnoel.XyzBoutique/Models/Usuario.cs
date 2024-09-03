using System.ComponentModel.DataAnnotations;

namespace Cnoel.XyzBoutique.Models
{
    public class Usuario
    {
        [Key]
        public int CodTraba { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Puesto { get; set; }
        public RolUsuario Rol { get; set; }
    }

    public enum RolUsuario
    {
        Encargado,
        Vendedor,
        Delivery,
        Repartidor
    }
}
