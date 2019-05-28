using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.DataContract.Responses
{
    public class EmployeeTravelResponse
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Travel Travel { get; set; }
        public bool Confirm { get; set; }
    }
}
