using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MurexBreakfast.Api.Services.Authentication;
using MurexBreakfast.Contracts.Authentication;

namespace MurexBreakfast.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);

            if (!result.Succeded) return BadRequest("Invalid Username or Password");

            return Ok(result);
        }
    }
}
