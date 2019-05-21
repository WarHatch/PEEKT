using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    public class Transport
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string TypeOfTransport { get; set; }
    }
}
