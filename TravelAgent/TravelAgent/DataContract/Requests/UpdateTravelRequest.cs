using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.DataContract.Requests
{
    public class UpdateTravelRequest
    {
        public string Name { get; set; }
        public int TravelToId { get; set; }
        public int TravelFromId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Cost { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Transport> Transports { get; set; }

    }
}
