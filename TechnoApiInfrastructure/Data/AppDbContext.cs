using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechnoApiDomain.Entities;

namespace TechnoApiInfrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Nombre).IsRequired();
                entity.Property(e => e.Apellido1).IsRequired();
                entity.Property(e => e.Apellido2).IsRequired(false);
                entity.Property(e => e.Dni).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Contraseña).IsRequired();
            });

            //Categoria
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Codigo);
                entity.Property(e => e.Nombre);
                entity.Property(e => e.Descripcion);
            });

            //Producto
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre);
                entity.Property(e => e.Precio);
                entity.Property(e => e.Stock);
                entity.Property(e => e.ImagenUrl);
                entity.Property(e => e.CategoriaId);

                entity.HasOne(e => e.Categoria).WithMany().HasForeignKey(e=>e.CategoriaId).OnDelete(DeleteBehavior.Cascade);

            });

        }
    }
}
