using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data.Repositories.Interfaces
{
    public class EmployeeDisposeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeDisposeRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            using (var context = appDbContext)
            {
                return await context.Employees.Include(x => x.RegisteredOffice).ToArrayAsync();
            }
        }

        public async Task<Employee> Create(Employee entity)
        {
            using (var context = appDbContext)
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

                context.Employees.Add(employee);
                await context.SaveChangesAsync();

                return employee;
            }
        }

        public async Task Delete(Employee entity)
        {
            using (var context = appDbContext)
            {
                var employee = context.Employees.Single(x => x.Id == entity.Id);
                context.Employees.Remove(employee);

                await context.SaveChangesAsync();
            }
        }


        public async Task<Employee> FindById(int id)
        {
            using (var context = appDbContext)
            {
                try
                {

                    return await context.Employees.Include(x => x.RegisteredOffice).Select(item => new Employee
                    {
                        Id = item.Id,
                        UserName = item.UserName,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        ProfilePhoto = item.ProfilePhoto,
                        RegisteredOffice = item.RegisteredOffice,
                        Available = item.Available

                    }).SingleAsync(task => task.Id == id);

                }
                catch (InvalidOperationException)
                {
                    throw new ArgumentException("There isn't any employee with this id");
                }

            }
        }

        public async Task Update(Employee entity)
        {
            using (var context = appDbContext)
            {
                var employee = appDbContext.Employees.Single(x => x.Id == entity.Id);

                employee.UserName = entity.UserName;
                employee.Email = entity.UserName;

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
