using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MurexBreakfast.Api.Data;
using MurexBreakfast.Api.Extensions.User;
using MurexBreakfast.Api.Models;
using MurexBreakfast.Contracts.User;

namespace MurexBreakfast.Api.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MurexBreakfastContext _context;

        public UserService(UserManager<AppUser> userManager, MurexBreakfastContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<UserResponse> GetUserAsync(string id)
        {
            var userProfileResponse = new UserProfileResponse();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return null;

            var userProfile = await _context.UserProfiles.SingleOrDefaultAsync(p => p.UserId == user.Id);

            if(userProfile != null){
                userProfileResponse.Quote = userProfile.Quote;
                userProfileResponse.Bio = userProfile.Bio;
                userProfileResponse.Company = userProfile.Company;
                userProfileResponse.Position = userProfile.Position;
                userProfileResponse.Age = userProfile.Age;
                userProfileResponse.HighestQualification = userProfile.HighestQualification;
                userProfileResponse.Personalities = userProfile.Personalities;
            }
           
            var roles = await _userManager.GetRolesAsync(user);
            return user.AsDto(roles.ToList(), userProfileResponse); 
        }   

        public async Task<IEnumerable<UserResponse>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            
            return users.AsDto();
        }

        public async Task<CreateUserResponse> RegisterUserAsync(CreateUserRequest request)
        {
            var user = new AppUser
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                NormalizedEmail = request.Email.ToUpper(),
                NormalizedUserName = request.UserName.ToUpper(),
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                var createdUser = await _userManager.FindByNameAsync(request.UserName);
                // Create user profile
                var userProfile = new UserProfile
                {
                    UserId = createdUser.Id.ToString()
                };
                await _context.UserProfiles.AddAsync(userProfile);
                await _context.SaveChangesAsync();

                return new CreateUserResponse
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Succeded = true
                };
            }

            return new CreateUserResponse
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Succeded = false,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        public async Task<UpdateUserProfileResponse> UpdateUserProfileAsync(UpdateUserProfileRequest request, string userId)
        {
            var userProfile = await _context.UserProfiles.SingleOrDefaultAsync(user => user.UserId == userId);
            if (userProfile == null)
            {
                //Add to profiles
                var user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    var profile = new UserProfile
                    {
                        Bio = request.Bio,
                        Age = request.Age,
                        Company = request.Company,
                        Position = request.Position,
                        HighestQualification = request.HighestQualification,
                        Quote = request.Quote,
                        Personalities = request.Personalities,
                        UserId = user.Id
                    };

                    await _context.UserProfiles.AddAsync(profile);
                    await _context.SaveChangesAsync();
                    return new UpdateUserProfileResponse
                    {
                        Bio = profile.Bio,
                        Quote = profile.Quote,
                        UserId = userId,
                        Personalities = profile.Personalities,
                    };
                }
                else
                {
                    return null;
                }
            }

            userProfile.Quote = request.Quote;
            userProfile.Bio = request.Bio;
            userProfile.Personalities.AddRange(request.Personalities);
            userProfile.Age = request.Age;
            userProfile.Company = request.Company;
            userProfile.Position = request.Position;
            userProfile.HighestQualification = request.HighestQualification;

            await _context.SaveChangesAsync();

            return new UpdateUserProfileResponse
            {
                Bio = userProfile.Bio,
                Quote = request.Quote,
                Company = request.Company,
                Age = request.Age,
                HighestQualification = request.HighestQualification,
                Position = request.Position,
                UserId = userId,
                Personalities = userProfile.Personalities,
            };
        }
    }
}
