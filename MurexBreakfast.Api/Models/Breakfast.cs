namespace MurexBreakfast.Api.Models
{
    public class Breakfast
    {
        public Breakfast()
        {
            Savory = new();
            Sweet = new();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public DateTime DateAdded { get; set; }
        public AppUser Host { get; set; }
        public string? HostId { get; set; }
        public List<string> Savory { get; set; }
        public List<string> Sweet { get; set; }
    }
}
