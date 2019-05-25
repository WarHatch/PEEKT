﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Entities
{
    public class Office
    {
        public int Id { get; set; }
        public int OfficeApartmentId { get; set; }
        [ForeignKey("OfficeApartmentId")]
        public Apartment OfficeApartment { get; set; }
        [Required]
        public string Title { get; set; }
        public string Address { get; set; }
    }
}
