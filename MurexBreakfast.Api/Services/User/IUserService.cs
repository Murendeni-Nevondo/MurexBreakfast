using MurexBreakfast.Contracts.User;

namespace MurexBreakfast.Api.Services.User
{
    public interface IUserService
    {
        Task<UserResponse> GetUserAsync(string Id);
        Task<IEnumerable<UserResponse>> GetUsersAsync();
        Task<CreateUserResponse> RegisterUserAsync(CreateUserRequest request);
        Task<UpdateUserProfileResponse> UpdateUserProfileAsync(UpdateUserProfileRequest request, string userId);
    }
}
