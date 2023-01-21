using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MurexBreakfast.Api.Models;
using MurexBreakfast.Contracts.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MurexBreakfast.Api.Services.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> GenerateJwtTokenAsync(AppUser user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var claims = await GetClaimsAsync(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("Secret").Value));
            var SiginCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("ValidIssuer").Value,
                audience: jwtSettings.GetSection("ValidAudiance").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: SiginCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
            {
                return new LoginResponse
                {
                    Succeded = false,
                    Token = null
                };
            }

            var validPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!validPassword)
            {
                return new LoginResponse
                {
                    Succeded = false,
                    Token = null
                };
            }

            return new LoginResponse
            {
                Succeded = true,
                Token = await GenerateJwtTokenAsync(user) //TODO: Add actual token here
            };
        }

        private async Task<List<Claim>> GetClaimsAsync(AppUser user)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim("Id", user.Id));
            claims.Add(new Claim("FullName", user.FirstName+" "+user.LastName));

            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
    }
}
