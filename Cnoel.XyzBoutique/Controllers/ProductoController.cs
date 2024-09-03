using Cnoel.XyzBoutique.Models;
using Cnoel.XyzBoutique.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cnoel.XyzBoutique.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
            => _productoService = productoService;

        [HttpGet]
        [Route("ObtenerProductoById")]
        public async Task<IActionResult> ObtenerProductoById(int sku)
        {
            var resultado = await _productoService.ObtenerProductoById(sku);

            return Ok(resultado);
        }

        [HttpPost]
        [Route("CrearProducto")]
        public async Task<IActionResult> CrearProducto([FromBody] Producto producto)
        {
            var resultado = await _productoService.CrearProducto(producto);
            return Ok(resultado);
        }

        [HttpPost]
        [Route("ActualizarProducto")]
        public async Task<IActionResult> ActualizarProducto([FromBody] Producto producto)
        {
            var resultado = await _productoService.ActualizarProducto(producto);
            return Ok(resultado);
        }
    }
}
