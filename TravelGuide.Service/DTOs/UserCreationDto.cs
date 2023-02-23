﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGuide.Service.DTOs
{
    public class UserCreationDto
    {
        public string CityName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CountOfDays { get; set; }
        public int CountOfMembers { get; set; }
    }
}
