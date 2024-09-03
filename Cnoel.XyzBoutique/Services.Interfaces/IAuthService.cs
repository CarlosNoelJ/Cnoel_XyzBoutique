namespace Cnoel.XyzBoutique.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(string email, string password);
        bool ValidarToken(string token);
    }
}
