using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurexBreakfast.Contracts.User
{
    public class UpdateUserProfileRequest
    {
        public string? Bio { get; set; }
        public string? Quote { get; set; }
        public string? HighestQualification { get; set; }
        public string? Company { get; set; }
        public string? Position { get; set; }
        public byte? Age { get; set; }
        public List<string> Personalities { get; set; } = new();
    }
}
