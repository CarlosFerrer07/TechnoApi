using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiApplication.Interfaces.producto;
using TechnoApiDomain.Entities;
using TechnoApiInfrastructure.Data;

namespace TechnoApiInfrastructure.Repositories.Productos
{
    public class ProductoRepository: IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Producto> ObtenerProductos()
        {
            return _context.Productos.Include(p => p.Categoria).ToList();
        }
    }
}
