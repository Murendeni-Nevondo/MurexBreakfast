using MurexBreakfast.Api.Models;
using MurexBreakfast.Contracts.Authentication;

namespace MurexBreakfast.Api.Services.Authentication
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<string> GenerateJwtTokenAsync(AppUser user);
    }
}
