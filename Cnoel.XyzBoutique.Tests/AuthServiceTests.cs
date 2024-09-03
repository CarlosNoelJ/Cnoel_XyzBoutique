using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Repositories.Interfaces;
using Cnoel.XyzBoutique.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace Cnoel.XyzBoutique.Tests
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<IUsuarioRepository> _usuarioRepository;

        public AuthServiceTests()
        {
            _configurationMock = new Mock<IConfiguration>();

            _configurationMock.Setup(c => c ["JwtSettings:SecretKey"]).Returns("ClaveDelTokenClaveDelTokenClaveDelToken");
            _configurationMock.Setup(c => c["JwtSettings:Issuer"]).Returns("ApplicationIssuer");
            _configurationMock.Setup(c => c["JwtSettings:Audience"]).Returns("Audiencia");

            _usuarioRepository = new Mock<IUsuarioRepository>();

            _authService = new AuthService(_configurationMock.Object, _usuarioRepository.Object);
        }

        [Fact]
        public async Task Login_Con_Usuario_Registrado_ReturnsToken()
        {
            var userDto = new Usuario { 
                Email = "test@mail.com",
                Celular = "923471834",
                CodTraba = 12,
                Nombre = "Test",
                Puesto = "Vendedor",
                Rol = RolUsuario.Vendedor
            };

            _usuarioRepository.Setup(repo => repo.ObtenerUsuarioByEmail(userDto.Email))
                .ReturnsAsync(userDto);

            var result = await _authService.Login(userDto.Email, "password123");

            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }


        [Fact]
        public async Task Login_CredenciailesInvalidas_RetornaNull()
        {
            var result = await _authService.Login("asdv@mail.com","pass123");

            Assert.Null(result);
        }
    }
}