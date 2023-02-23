using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Enums;

namespace TravelGuide.Service.DTOs
{
    public class ToDoListCreationDto
    {
        public string CityName { get; set; }
        public long UserId { get; set; }
        public TypePlace PlaceType { get; set; }
        public int NumberOfDay { get; set; }
        public WeekDays DayOfWeek { get; set; }
        public int HoursSpend { get; set; }
        public StausOfTrip TripStatus { get; set; }
        public string Comment { get; set; }
    }
}
