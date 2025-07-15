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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}
