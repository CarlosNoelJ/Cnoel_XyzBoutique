using Cnoel.XyzBoutique.Data;
using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cnoel.XyzBoutique.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MainDbContext _context;

        public UsuarioRepository(MainDbContext context)
            => _context = context;

        public async Task<Usuario> ObtenerUsuarioByEmail(string email)
            => await _context.Usuarios.FirstAsync(x => x.Email.Equals(email));
    }
}
