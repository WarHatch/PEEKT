﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data.Repositories.Interfaces
{
    public interface IApartmentRepository : IRepository<Apartment>
    {
        Task<Apartment> AddGuest(Apartment apartment, EmployeeTravel employeeTravel);
        Task<Apartment> RemoveGuest(Apartment apartment, EmployeeTravel employeeTravel);
    }
}
