using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiApplication.DTOs.Categoria;
using TechnoApiApplication.DTOs.Producto;
using TechnoApiApplication.Interfaces.categoria;
using TechnoApiApplication.Interfaces.producto;

namespace TechnoApiApplication.Services.Productos
{
    public class ProductoService: IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public List<ProductoDTO> ObtenerTodosLosProductos()
        {
            var productos = _productoRepository.ObtenerProductos();

            return productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock,
                ImagenUrl = p.ImagenUrl,
                CategoriaId = p.CategoriaId,
                Categoria = new CategoriaDTO
                {
                    Id = p.Categoria.Id,
                    Codigo = p.Categoria.Codigo,
                    Nombre = p.Categoria.Nombre,
                    Descripcion = p.Categoria.Descripcion
                }
            }).ToList();
        }
    }
}
