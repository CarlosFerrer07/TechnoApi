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

        public Usuario ObtenerUsuario(string email, string password)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Contraseña == password);
        }

    }
}
