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
        private readonly AppDbContext appDbContext;

        public EmployeeTravelRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public async Task<bool> CheckTravelsByEmployeeId(int id, int travelId)
        {   
            try
            { 
                foreach(var employeeTravel in await FindByEmployeeId(id))
                {
                    if (employeeTravel.Travel.Id == travelId) return false;
                }
                return true;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        public async Task<EmployeeTravel> Create(EmployeeTravel entity)
        {
            appDbContext.Entry(entity.Employee).State = EntityState.Unchanged;
            appDbContext.EmployeeTravel.Add(entity);
            await appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(EmployeeTravel entity)
        {

            var traveler = appDbContext.EmployeeTravel.Single(x => x.Id == entity.Id);
            appDbContext.EmployeeTravel.Remove(traveler);

            await appDbContext.SaveChangesAsync();

        }

        public async Task<IEnumerable<EmployeeTravel>> FindByEmployeeId(int id)
        {
            try
            {
                return await appDbContext.EmployeeTravel.Include(x => x.Travel).Where(x => x.Employee.Id == id).ToArrayAsync(); 
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("There isn't any employeeTravel with this id");
            }
        }

        public async Task<EmployeeTravel> FindById(int id)
        {
            try
            {
                return await appDbContext.EmployeeTravel
                    .Include(x => x.Employee)
                    .Include(x => x.Travel)
                    .Include(x => x.Travel.OrganizedBy)
                    .Include(x => x.Travel.TravelTo)
                    .Include(x => x.Travel.TravelFrom)
                    .SingleAsync(x => x.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("There isn't any employeeTravel for Employee with this id");
            }
        }

        public async Task<IEnumerable<EmployeeTravel>> GetAll()
        {
            return await appDbContext.EmployeeTravel
                .Include(x => x.Employee)
                .Include(x => x.Travel)
                .Include(x => x.Travel.OrganizedBy)
                .Include(x => x.Travel.TravelTo)
                .Include(x => x.Travel.TravelFrom)
                .ToArrayAsync();
        }

        public async Task Update(EmployeeTravel entity)
        {

            var traveler = appDbContext.EmployeeTravel.Single(x => x.Id == entity.Id);

            traveler.Travel = entity.Travel;
            traveler.Confirm = entity.Confirm;

            await appDbContext.SaveChangesAsync();
        }
    }
}
