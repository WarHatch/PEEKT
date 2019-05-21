using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.DataContract.Requests
{
    public class UpdateTravelRequest
    {
        public int TravelToId { get; set; }
        public int TravelFromId { get; set; }

    }
}
