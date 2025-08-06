using Microsoft.AspNetCore.Mvc;
using TechnoApiApplication.DTOs.Producto;
using TechnoApiApplication.Interfaces.producto;

namespace TechnoApi.Controllers.Productos
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductoController: ControllerBase
    {
        private IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }


        [HttpGet("Productos")]
        public ActionResult<List<ProductoDTO>> get()
        {
            var Productos = _productoService.ObtenerTodosLosProductos();

            return Ok(Productos);
        }
    }
}
