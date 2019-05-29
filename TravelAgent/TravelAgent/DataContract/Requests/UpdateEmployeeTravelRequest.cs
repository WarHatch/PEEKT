using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.DataContract.Requests
{
    public class UpdateEmployeeTravelRequest
    {
        public int EmployeeId { set; get; }
        public int TravelId { set; get; }
        public bool Confirm { set; get; }
        public bool NeedApartment { get; set; }
    }
}
