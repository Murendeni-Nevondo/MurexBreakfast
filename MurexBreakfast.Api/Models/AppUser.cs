using Microsoft.AspNetCore.Identity;

namespace MurexBreakfast.Api.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfileImgUrl { get; set; }
    }
}
