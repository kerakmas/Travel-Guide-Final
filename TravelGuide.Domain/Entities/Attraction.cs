
using TravelGuide.Domain.Commons;

namespace TravelGuide.Domain.Entities
{
    public class Attraction : Auditable
    {
        public string Name { get; set; }
        public long Cityid { get; set; }
        public City City { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string OpeningHours { get; set; }
        public string Contact { get; set; }
        public decimal TicketPrice { get; set; }

    }
}
