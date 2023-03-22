using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Commons;
using TravelGuide.Domain.Enums;

namespace TravelGuide.Domain.Entities
{
    public class Menu : Auditable
    {
        
        public long RestarauntId { get; set; }
        public Restaraunt Restaraunt { get; set; }
        public string MealName { get; set; }
        public decimal Price { get; set; }
        public MealType TypeMeal { get; set; }
    }
}
