using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly Func<AppDbContext> appDbContextFunc;

        public EmployeeRepository(Func<AppDbContext> contextFunc)
        {
            appDbContextFunc = contextFunc;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Employees.ToArrayAsync();
            }
        }

        public async Task<Employee> Create(Employee entity)
        {
            using (var appDbContext = appDbContextFunc())
            {

                var employee = new Employee
                {
                    UserName = entity.UserName,
                    Email = entity.Email,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    ProfilePhoto = entity.ProfilePhoto,
                    RegisteredOffice = entity.RegisteredOffice,
                    Available = entity.Available
                };

                appDbContext.Employees.Add(employee);
                await appDbContext.SaveChangesAsync();

                return employee;
            }
        }

        public async Task Delete(Employee entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var employee = appDbContext.Employees.Single(x => x.Id == entity.Id);
                appDbContext.Employees.Remove(employee);

                await appDbContext.SaveChangesAsync();
            }
        }


        public async Task<Employee> FindById(int id)
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Employees.Select(item => new Employee
                {
                    // čia kuriu naują, dėl security, kad hashinto password nepaimtų.
                    Id = item.Id,
                    UserName = item.UserName,
                    Email = item.Email,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    ProfilePhoto = item.ProfilePhoto,
                    RegisteredOffice = item.RegisteredOffice,
                    Available = item.Available
                    
                })
                .SingleAsync(task => task.Id == id);
            }
        }

        public async Task Update(Employee entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var employee = appDbContext.Employees.Single(x => x.Id == entity.Id);

                employee.UserName = entity.UserName;
                employee.Email = entity.UserName;

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
