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
        [Required]  
        public string Name { get; set; }
        public Office TravelTo { get; set; }
        public Office TravelFrom { get; set; }  
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Employee OrganizedBy { get; set; }
    }
}
