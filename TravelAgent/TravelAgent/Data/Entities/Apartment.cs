using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    public class Apartment 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int FitsPeople { get; set; }
        public List<Traveler> Travelers { get; set; }
        public decimal Cost { get; set; }
        public bool IsOffice { get; set; }
    }
}
