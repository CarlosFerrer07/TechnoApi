using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiApplication.DTOs.Categoria;
using TechnoApiDomain.Entities;

namespace TechnoApiApplication.Interfaces.categoria
{
    public interface ICategoriaService
    {
        List<CategoriaDTO> ObtenerCategorias();
    }
}
