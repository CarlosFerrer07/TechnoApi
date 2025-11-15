using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiApplication.Interfaces.categoria;
using TechnoApiDomain.Entities;
using TechnoApiInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TechnoApiInfrastructure.Repositories.Categorias
{
    public class CategoriaRepository: ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Categoria> ObtenerCategorias() {
            return _context.Categorias.ToList();
        }

        public async Task<Categoria> ObtenerCategoriasPorCodigoDeCategoria(string codigoCategoria)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Codigo == codigoCategoria);
        }

    }
}
