using Microsoft.AspNetCore.Mvc;
using TechnoApiApplication.DTOs;
using TechnoApiApplication.Interfaces;

namespace TechnoApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IAuthService _authService;

        public AuthController(IUsuarioRepository usuarioRepository, IJwtTokenGenerator jwtTokenGenerator, IAuthService authService)
        {
            _usuarioRepository = usuarioRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
            _authService = authService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {

                var response = _authService.Login(request);

                return Ok(response);

        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterRequest request) 
        {
            var response = _authService.Register(request);

            return Ok(response);
        }
    }

}
