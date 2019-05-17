using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.DataContract.Enums;

namespace TravelAgent.Data.Entities
{
    public class Travel
    {
        public int Id { get; set; }   
        public string GroupName { get; set; }
        [Required]
        public Office TravelTo { get; set; }
        public Office TravelFrom { get; set; }  
        public DateTime DepartureTime { get; set; }
        public DateTime ExpectedTime { get; set; }
        public Status Status { get; set; }
        public Employee OrganizedBy { get; set; }
    }
}
