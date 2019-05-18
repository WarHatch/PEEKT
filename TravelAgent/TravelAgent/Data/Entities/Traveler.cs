using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    public class Traveler
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Travel Travel { get; set; }
        public Apartment Apartment { get; set; }
        public List<TravelerTransport> TravelTransports { get; set; }
        public bool ConfirmedByEmployee { get; set; }
    }
}
