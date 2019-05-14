using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    public class Travel
    {
        public int Id { get; set; }
        [Required]
        public Office TravelTo { get; set; }
        public Office TravelFrom { get; set; }  
        public DateTime DepartureTime { get; set; }
        public DateTime ExpectedTime { get; set; }
        public bool Status { get; set; }
        public Employee OrganizedBy { get; set; }
    }
}
