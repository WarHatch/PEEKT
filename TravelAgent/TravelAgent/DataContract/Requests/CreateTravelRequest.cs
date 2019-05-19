using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.DataContract.Requests
{
    public class CreateTravelRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int TravelToId { get; set; }
        [Required]
        public int TravelFromId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int OrganizedById { get; set; }
    }
}
