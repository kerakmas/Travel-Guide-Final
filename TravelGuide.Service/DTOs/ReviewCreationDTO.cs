using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Domain.Enums;

namespace TravelGuide.Service.DTOs
{
    public class ReviewCreationDTO
    {
        public TypePlace PlacceType { get; set; }
        public string Comment { get; set; }
        public Status Rating { get; set; }
    }
}
