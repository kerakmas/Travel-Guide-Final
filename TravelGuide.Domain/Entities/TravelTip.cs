using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Commons;

namespace TravelGuide.Domain.Entities
{
    public class TravelTip : Auditable
    {
        public string Name { get; set; }
        public  long CityId { get; set; }
        public  string Description { get; set; }
    }
}
