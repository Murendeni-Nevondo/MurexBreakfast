using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurexBreakfast.Contracts.User
{
    public class CreateUserResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool Succeded { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
