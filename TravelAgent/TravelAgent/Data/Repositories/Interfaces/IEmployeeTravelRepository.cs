using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data.Repositories.Interfaces
{
    public interface IEmployeeTravelRepository : IRepository<EmployeeTravel>
    {
        Task<IEnumerable<EmployeeTravel>> FindByEmployeeId(int id);
        Task<IEnumerable<EmployeeTravel>> FindByTravelId(int id);
    }
}
