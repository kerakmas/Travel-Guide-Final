using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Commons;
using TravelGuide.Domain.Enums;

namespace TravelGuide.Domain.Entities
{
    public class Review : Auditable
    {
        public TypePlace PlacceType { get; set; }
        public string Comment { get; set; }
        public Status Rating { get; set; }
    }
}
