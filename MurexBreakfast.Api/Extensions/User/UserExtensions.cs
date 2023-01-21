using MurexBreakfast.Api.Models;
using MurexBreakfast.Contracts.User;

namespace MurexBreakfast.Api.Extensions.User
{
    public static class UserExtensions
    {
        public static UserResponse AsDto(this AppUser user, List<string> roles, UserProfileResponse userProfileResponse)
        {
            return new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ProfileImgUrl = user.ProfileImgUrl,
                Roles = roles,
                UserProfile = userProfileResponse
            };
        }

        public static IEnumerable<UserResponse> AsDto(this IEnumerable<AppUser> users)
        {
            return users.Select(user => new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                ProfileImgUrl = user.ProfileImgUrl,
                //TODO: Add each user's roles
            });
        }
    }
}
