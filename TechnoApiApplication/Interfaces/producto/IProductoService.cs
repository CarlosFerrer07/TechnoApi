using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiApplication.DTOs.Producto;

namespace TechnoApiApplication.Interfaces.producto
{
    public interface IProductoService
    {
        List<ProductoDTO> ObtenerTodosLosProductos();
    }
}
