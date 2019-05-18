using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    public class Employee : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }
        public Office RegisteredOffice { get; set; }
        public bool Available { get; set; }
    }
}
