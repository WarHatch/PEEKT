using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.DataContract.Requests
{
    public class CreateApartmentRequest
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public int FitsPeople { get; set; }
        public List<int> EmployeeTravelsId { get; set; }
        public byte[] Version { get; set; }
    }
}
