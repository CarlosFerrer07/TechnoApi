using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiDomain.Entities;

namespace TechnoApiApplication.Interfaces.producto
{
    public interface IProductoRepository
    {
        List<Producto> ObtenerProductos();
    }
}
