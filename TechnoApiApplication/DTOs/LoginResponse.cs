using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoApiApplication.DTOs
{
    public class LoginResponse
    {
        public string Token {  get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}
