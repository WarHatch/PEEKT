﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.DataContract.Responses
{
    public class UserResponse
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }
        public Office RegisteredOffice { get; set; }
    }
}
