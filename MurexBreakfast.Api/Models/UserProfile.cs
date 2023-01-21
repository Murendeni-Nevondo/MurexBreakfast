namespace MurexBreakfast.Api.Models 
{
    public class UserProfile {
        public int Id { get; set; }
        public string? HighestQualification { get; set; }
        public string? Company { get; set; }
        public string? Position { get; set; }
        public byte? Age { get; set; }
        public string? Bio { get; set; }
        public string? Quote { get; set; }
        public AppUser? User { get; set; }
        public string UserId { get; set; }
        public List<string> Personalities { get; set; } = new();
    }
}