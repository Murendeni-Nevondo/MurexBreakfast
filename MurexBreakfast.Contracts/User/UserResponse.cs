using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurexBreakfast.Contracts.User
{
    public class UserResponse
    {
        public UserResponse()
        {
            Roles = new();
        }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? ProfileImgUrl { get; set; }
        public List<string> Roles { get; set; }
        public UserProfileResponse UserProfile { get; set; }
    }
}
