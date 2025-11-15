using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiDomain.Entities;

namespace TechnoApiApplication.Interfaces.categoria
{
    public interface ICategoriaRepository
    {
        List<Categoria> ObtenerCategorias();

        Task<Categoria> ObtenerCategoriasPorCodigoDeCategoria(string codigoCategoria);
    }
}
