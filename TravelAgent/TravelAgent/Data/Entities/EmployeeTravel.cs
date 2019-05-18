using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    public class EmployeeTravel
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Travel Travel { get; set; }
        public Apartment Apartment { get; set; }
        public bool Confirm { get; set; }
    }
}
