using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Service.Helpers
{
    public class Responce<Tentity>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public Tentity Value { get; set; }
    }
}
