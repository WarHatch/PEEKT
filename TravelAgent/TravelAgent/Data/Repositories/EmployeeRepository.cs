using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;

namespace TravelAgent.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await appDbContext.Employees.Include(x => x.RegisteredOffice).ToArrayAsync();
        }

        public async Task<Employee> Create(Employee entity)
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

        public async Task Delete(Employee entity)
        {
            var employee = appDbContext.Employees.Single(x => x.Id == entity.Id);
            appDbContext.Employees.Remove(employee);

            await appDbContext.SaveChangesAsync();
        }


        public async Task<Employee> FindById(int id)
        {
            try
            {
                return await appDbContext.Employees.Include(x => x.RegisteredOffice).Select(item => new Employee
                {
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
            catch (InvalidOperationException)
            {
                throw new ArgumentException("There isn't any employee with this id");
            }


        }

        public async Task Update(Employee entity)
        {


            var employee = appDbContext.Employees.Single(x => x.Id == entity.Id);

            employee.UserName = entity.UserName;
            employee.Email = entity.UserName;

            await appDbContext.SaveChangesAsync();

        }
    }
}
