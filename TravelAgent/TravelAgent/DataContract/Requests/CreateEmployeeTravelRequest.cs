using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.DataContract.Requests
{
    public class CreateEmployeeTravelRequest
    {
        [Required]
        public int EmployeeId { set; get; }
        public int TravelId { set; get; }
        public bool Confirm { set; get; }
        public bool NeedApartment { get; set; }
    }
}
