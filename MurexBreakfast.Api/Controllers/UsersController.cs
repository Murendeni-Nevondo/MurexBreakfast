using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MurexBreakfast.Api.Services.User;
using MurexBreakfast.Contracts.User;

namespace MurexBreakfast.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    // [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var userResponse = await _userService.GetUserAsync(id);

            if (userResponse == null) return NotFound("User not found");

            return Ok(userResponse);
        }

        // [HttpGet, Authorize(Roles ="admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost()]
        public async Task<IActionResult> Register(CreateUserRequest request)
        {
            var result = await _userService.RegisterUserAsync(request);

            if(!result.Succeded) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("{id}/profile/update")]
        public async Task<IActionResult> UpdateProfile(UpdateUserProfileRequest request, string id)
        {
            var result = await _userService.UpdateUserProfileAsync(request,id);
            if(result is null) return BadRequest("Unable to update user profile");

            return Ok(result);
        }
    }
}
