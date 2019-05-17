using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.DataContract.Enums;

namespace TravelAgent.Data.Entities
{
    public class Transport
    {
        public int Id { get; set; }
        [Required]
        public string CarNumber { get; set; }
        public string Model { get; set; }
        public int FitsPeople { get; set; }
        public decimal Cost { get; set; }
        [Required]
        public Vehicle TypeOfTransport { get; set; }
    }
}
