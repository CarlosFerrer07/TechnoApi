using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiApplication.DTOs;
using TechnoApiDomain.Entities;

namespace TechnoApiApplication.Interfaces
{
    public interface IAuthService
    {
        LoginResponse Login(LoginRequest request);
        RegisterResponse Register(RegisterRequest request);
    }
}
