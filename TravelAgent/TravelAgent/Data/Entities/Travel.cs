using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public List<Hotel> Hotels { get; set; }
        public List<Transport> Transports { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }
        public Employee OrganizedBy { get; set; }
    }
}
