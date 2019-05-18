using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public Travel Travel { get; set; }
        [Required]
        public string Title { get; set; }
        public string Address { get; set; }
    }
}
