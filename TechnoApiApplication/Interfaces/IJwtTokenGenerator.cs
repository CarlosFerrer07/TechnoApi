using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoApiApplication.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerarToken(string Nombre, string Email);
    }
}
