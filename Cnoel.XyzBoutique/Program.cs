using Cnoel.XyzBoutique.Data;
using Cnoel.XyzBoutique.Repositories.Interfaces;
using Cnoel.XyzBoutique.Repositories.States;
using Cnoel.XyzBoutique.Repositories;
using Cnoel.XyzBoutique.Services.Interfaces;
using Cnoel.XyzBoutique.Services;
using Microsoft.EntityFrameworkCore;
using Cnoel.XyzBoutique.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MainDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
                     ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")))
);

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<EstadoPorAtender>();
builder.Services.AddScoped<EstadoEnProceso>();
builder.Services.AddScoped<EstadoEnDelivery>();
builder.Services.AddScoped<EstadoRecibido>();

builder.Services.AddScoped<Dictionary<EstadoPedido, IEstadoPedido>>(provider =>
{
    return new Dictionary<EstadoPedido, IEstadoPedido>
    {
        { EstadoPedido.PorAtender, provider.GetRequiredService<EstadoPorAtender>() },
        { EstadoPedido.EnProceso, provider.GetRequiredService<EstadoEnProceso>() },
        { EstadoPedido.EnDelivery, provider.GetRequiredService<EstadoEnDelivery>() },
        { EstadoPedido.Recibido, provider.GetRequiredService<EstadoRecibido>() }
    };
});

var issuer = builder.Configuration["JwtSettings:Issuer"];
var audience = builder.Configuration["JwtSettings:Audience"];
var secretKey = builder.Configuration["JwtSettings:SecretKey"];

if (string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience) || string.IsNullOrEmpty(secretKey))
{
    throw new Exception("JWT settings are not properly configured in appsettings.json.");
}

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

