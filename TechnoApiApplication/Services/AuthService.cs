using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiApplication.DTOs;
using TechnoApiApplication.Interfaces;

namespace TechnoApiApplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public AuthService(IUsuarioRepository userRepository, IJwtTokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public LoginResponse Login(LoginRequest request) { 
            var usuario = _userRepository.ObtenerUsuario(request.Email, request.Password);

            if (usuario == null) {
                throw new UnauthorizedAccessException("Credenciales incorrectas");
            }

            var token = _tokenGenerator.GenerarToken(usuario.Nombre, usuario.Email);

            return new LoginResponse
            {
                Token = token,
                Nombre = usuario.Nombre,
                Email = usuario.Email
            };
        }
    }
}
