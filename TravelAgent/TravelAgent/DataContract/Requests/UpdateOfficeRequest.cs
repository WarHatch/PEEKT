using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.DataContract.Requests
{
    public class UpdateOfficeRequest
    {
        public int OfficeApartmentId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
    }
}
