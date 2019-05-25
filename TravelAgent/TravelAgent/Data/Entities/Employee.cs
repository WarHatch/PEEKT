using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    public class Employee : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }

        [ForeignKey("RegisteredOffice")]
        public int RegisteredOfficeId { get; set; }
        
        public Office RegisteredOffice { get; set; }
        public bool Available { get; set; }
    }
}
