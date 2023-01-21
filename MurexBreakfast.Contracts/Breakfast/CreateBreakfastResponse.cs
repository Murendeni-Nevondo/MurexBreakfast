using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MurexBreakfast.Contracts.Breakfast
{
    public class CreateBreakfastResponse
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime DateAdded { get; set; }
        public string? HostId { get; set; }
        public List<string> Savory { get; set; }
        public List<string> Sweet { get; set; }
    }
}
