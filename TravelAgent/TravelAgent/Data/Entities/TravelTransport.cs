using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    public class TravelTransport
    {
        public int Id { get; set; }
        [Required]
        public Traveler Traveler { get; set; }
        [Required]
        public Transport Transport { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
