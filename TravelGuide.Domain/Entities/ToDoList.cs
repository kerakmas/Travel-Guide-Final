using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Commons;
using TravelGuide.Domain.Enums;

namespace TravelGuide.Domain.Entities
{
    public class ToDoList : Auditable
    {
        public string CityName { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public TypePlace PlaceType { get; set; }
        public int NumberOfDay { get; set; }
        public  WeekDays DayOfWeek { get; set; }
        public int HoursSpend { get; set; }
        public StausOfTrip TripStatus { get; set; }
        public string Comment { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }
        public Status Rating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
