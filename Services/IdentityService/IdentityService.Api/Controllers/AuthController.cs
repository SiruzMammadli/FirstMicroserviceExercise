using IdentityService.Business.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using static IdentityService.Entities.DTOs.UserDto;

namespace IdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto request)
        {
            var result = _authService.Register(request);
            if (result.Success) return Ok(new { status = 200, message = result.Message });

            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto request)
        {
            var result = _authService.Login(request);
            if (result.Success)
                return Ok(new { status = 200, message = result.Message });
            return BadRequest(result.Message);
        }
    }
}
