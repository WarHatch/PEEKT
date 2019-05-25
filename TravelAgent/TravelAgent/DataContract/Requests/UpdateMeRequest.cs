using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.DataContract.Requests
{
    public class UpdateMeRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }
        public int RegisteredOfficeId { get; set; }
    }
}
