using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    public class TravelerTransport
    {
        public int Id { get; set; }
        [Required]
        public Traveler Traveler { get; set; }
        [Required]
        public Transport Transport { get; set; }
        [Required]
        public DateTime DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }
    }
}
