using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cnoel.XyzBoutique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoServicio;

        public PedidosController(IPedidoService pedidoServicio)
            => _pedidoServicio = pedidoServicio;

        [HttpPost]
        public async Task<IActionResult> CrearPedido([FromBody] Pedido pedido)
        {
            var resultado = await _pedidoServicio.CrearPedido(pedido);

            return Ok(resultado);
        }

        [HttpPut("{id}/cambiarEstado")]
        public async Task<IActionResult> CambiarEstadoDelPedido(int id, [FromBody] EstadoPedido nuevoEstado)
        {
            var resultado = await _pedidoServicio.CambiarEstadoDelPedido(id, nuevoEstado);
            return Ok(resultado);
        }
    }
}
