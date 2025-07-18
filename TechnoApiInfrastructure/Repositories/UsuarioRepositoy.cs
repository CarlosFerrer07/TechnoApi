using System.Linq;
using TechnoApiApplication.Interfaces;
using TechnoApiDomain.Entities;
using TechnoApiInfrastructure.Data;

namespace TechnoApiInfrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public Usuario ObtenerUsuario(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public bool RegistrarUsuario(Usuario usuario) { 
            _context.Usuarios.Add(usuario);
            return _context.SaveChanges() > 0;
        }
    }
}
