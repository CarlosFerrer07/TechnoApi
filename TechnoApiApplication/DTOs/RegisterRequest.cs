using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoApiApplication.DTOs
{
    public class RegisterRequest
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
    }
}
