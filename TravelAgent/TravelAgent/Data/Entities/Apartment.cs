using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    [Owned]
    public class Apartment 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int FitsPeople { get; set; }
        //public Office Office { get; set; }
        public List<EmployeeTravel> EmployeeTravels { get; set; }
    }
}
