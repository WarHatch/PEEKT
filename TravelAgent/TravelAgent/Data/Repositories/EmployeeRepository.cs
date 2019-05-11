using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public Task<IEnumerable<Employee>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> FindAsync(Func<Employee, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> FirstAsync(Func<Employee, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
