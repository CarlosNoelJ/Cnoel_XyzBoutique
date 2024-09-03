using Cnoel.XyzBoutique.Models;
using Microsoft.EntityFrameworkCore;

namespace Cnoel.XyzBoutique.Data
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Pedido>().HasKey(x => new { x.NumeroPedido });

            modelBuilder.Entity<Producto>().HasKey(x => new { x.Sku });

            modelBuilder.Entity<Usuario>().HasKey(x => new { x.CodTraba });
        }
    }
}
