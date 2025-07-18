using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiDomain.Entities;

namespace TechnoApiApplication.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario? ObtenerUsuario(string email);
        bool RegistrarUsuario(Usuario usuario);
    }
}
