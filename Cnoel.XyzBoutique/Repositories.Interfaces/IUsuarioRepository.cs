using Cnoel.XyzBoutique.Models;

namespace Cnoel.XyzBoutique.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObtenerUsuarioByEmail(string email);
    }
}
