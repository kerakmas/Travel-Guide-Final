using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Commons;

namespace TravelGuide.Domain.Entities
{
    public class City : Auditable
    {
       public string Name { get; set; }
       public string Location { get; set; }
       public string CountryName { get; set; }
       public string Language { get; set; }
       public List<Attraction> Attractions { get; set; }
       public List<Restaraunt> Restaraunts { get; set; }
       public List<TravelTip> TravelTips { get; set; }

    }
}
