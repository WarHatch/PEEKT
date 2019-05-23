using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.DataContract.Requests
{
    public class CreateOfficeRequest
    {
        [Required]
        public int OfficeApartmentId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Address { get; set; }
    }
}
