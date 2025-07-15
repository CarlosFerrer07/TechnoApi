
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechnoApiApplication.DTOs;
using TechnoApiApplication.Interfaces;
using TechnoApiDomain.Entities;

namespace TechnoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthController(IUsuarioRepository usuarioRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _usuarioRepository = usuarioRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // 1. Validar el usuario con el repositorio
            var usuario = _usuarioRepository.ObtenerUsuario(request.Email, request.Password);

            if (usuario == null)
            {
                // Si no existe, devolvemos 401 Unauthorized
                return Unauthorized(new { mensaje = "Credenciales incorrectas" });
            }

            // 2. Generar el token JWT
            var token = _jwtTokenGenerator.GenerarToken(usuario.Nombre, request.Email);

            // 3. Crear la respuesta con el token y datos del usuario
            var response = new LoginResponse
            {
                Token = token,
                Nombre = usuario.Nombre,
                Email = usuario.Email
            };

            // 4. Devolver OK con la respuesta
            return Ok(response);
        }
    }

}
