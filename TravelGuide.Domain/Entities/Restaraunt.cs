using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Commons;

namespace TravelGuide.Domain.Entities
{
    public class Restaraunt : Auditable
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public long CityId { get; set; }
        public City City { get; set; }
        public int ContactNumber { get; set; }

    }
}
