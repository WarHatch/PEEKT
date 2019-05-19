using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;

namespace TravelAgent.Data.Repositories
{
    public class EmployeeTravelRepository : IEmployeeTravelRepository
    {
        private readonly AppDbContext appDbContextFunc;

        public EmployeeTravelRepository(AppDbContext contextFunc)
        {
            appDbContextFunc = contextFunc;
        }

        public async Task<EmployeeTravel> Create(EmployeeTravel entity)
        {
            using (var appDbContext = appDbContextFunc)
            {

                appDbContext.EmployeeTravel.Add(entity);
                await appDbContext.SaveChangesAsync();

                return entity;
            }
        }

        public async Task Delete(EmployeeTravel entity)
        {
            using (var appDbContext = appDbContextFunc)
            {
                var traveler = appDbContext.EmployeeTravel.Single(x => x.Id == entity.Id);
                appDbContext.EmployeeTravel.Remove(traveler);

                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<EmployeeTravel> FindById(int id)
        {
            using (var appDbContext = appDbContextFunc)
            {
                return await appDbContext.EmployeeTravel.SingleAsync(x => x.Id == id);
            }
        }

        public async Task<IEnumerable<EmployeeTravel>> GetAll()
        {
            using (var appDbContext = appDbContextFunc)
            {
                return await appDbContext.EmployeeTravel.ToArrayAsync();
            }
        }

        public async Task Update(EmployeeTravel entity)
        {
            using (var appDbContext = appDbContextFunc)
            {
                var traveler = appDbContext.EmployeeTravel.Single(x => x.Id == entity.Id);

                traveler.Travel = entity.Travel;
                traveler.Apartment = entity.Apartment;
                traveler.Confirm = entity.Confirm;

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
