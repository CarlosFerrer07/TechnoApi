﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiApplication.DTOs.Categoria;
using TechnoApiApplication.Interfaces.categoria;
using TechnoApiDomain.Entities;

namespace TechnoApiApplication.Services.Categorias
{
    public class CategoriaService: ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public List<CategoriaDTO> ObtenerCategorias()
        {
            var categorias = _categoriaRepository.ObtenerCategorias();

            return categorias.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                Codigo = c.Codigo,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
            }).ToList();

        }
    }
}
