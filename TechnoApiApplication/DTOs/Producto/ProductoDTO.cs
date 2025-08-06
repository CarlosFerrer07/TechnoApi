using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiApplication.DTOs.Categoria;
using TechnoApiDomain.Entities;

namespace TechnoApiApplication.DTOs.Producto
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string? ImagenUrl { get; set; }

        public int CategoriaId { get; set; }

        public CategoriaDTO? Categoria { get; set; }
    }
}
