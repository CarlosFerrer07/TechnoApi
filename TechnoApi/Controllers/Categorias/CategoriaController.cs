using Microsoft.AspNetCore.Mvc;
using TechnoApiApplication.DTOs.Categoria;
using TechnoApiApplication.Interfaces;
using TechnoApiApplication.Interfaces.categoria;

namespace TechnoApi.Controllers.Categorias
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CategoriaController: ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService) { 
            _categoriaService = categoriaService;
        }

        [HttpGet("Categorias")]
        public ActionResult<List<CategoriaDTO>> Get()
        {
            var Categorias = _categoriaService.ObtenerCategorias();

            return Ok(Categorias);
        }
    }
}