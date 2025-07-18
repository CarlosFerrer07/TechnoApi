using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoApiApplication.DTOs;
using TechnoApiApplication.Interfaces;
using TechnoApiDomain.Entities;
using Microsoft.AspNetCore.Identity;

namespace TechnoApiApplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly PasswordHasher<Usuario> _passwordHasher;

        public AuthService(IUsuarioRepository userRepository, IJwtTokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _passwordHasher = new PasswordHasher<Usuario>();
        }

        public LoginResponse Login(LoginRequest request) { 
            var usuario = _userRepository.ObtenerUsuario(request.Email);

            if (usuario == null) {
                throw new UnauthorizedAccessException("Credenciales incorrectas");
            }

            var resultadoVerificacionContrasenya = _passwordHasher.VerifyHashedPassword(usuario, usuario.Contraseña, request.Password);

            if (resultadoVerificacionContrasenya == PasswordVerificationResult.Failed)
            {
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

        public RegisterResponse Register(RegisterRequest request) 
        {
            Usuario existeUsuario = _userRepository.ObtenerUsuario(request.Email);

            if (existeUsuario != null)
            {
                throw new InvalidOperationException("El usuario ya está registrado");
            }

            Usuario nuevoUsuario = new Usuario
            {
                Nombre = request.Nombre,
                Apellido1 = request.Apellido1,
                Apellido2 = request.Apellido2,
                Dni = request.Dni,
                Email = request.Email,
                Contraseña = request.Contraseña
            };

            nuevoUsuario.Contraseña = _passwordHasher.HashPassword(nuevoUsuario, request.Contraseña);

            bool guardado = _userRepository.RegistrarUsuario(nuevoUsuario);

            if (guardado)
            {

                return new RegisterResponse
                {
                    Mensaje = "Usuario creado con éxito",
                    Email = nuevoUsuario.Email,
                };

            }else
            {
                throw new Exception("No se pudo registrar el usuario");
            }
        }   
    }
}
