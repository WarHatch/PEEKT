using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data.Repositories
{
    public class TravelerRepository : IRepository<Traveler>
    {
        private readonly Func<AppDbContext> appDbContextFunc;

        public TravelerRepository(Func<AppDbContext> contextFunc)
        {
            appDbContextFunc = contextFunc;
        }

        public async Task<Traveler> Create(Traveler entity)
        {
            using (var appDbContext = appDbContextFunc())
            {

                appDbContext.Travelers.Add(entity);
                await appDbContext.SaveChangesAsync();

                return entity;
            }
        }

        public async Task Delete(Traveler entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var traveler = appDbContext.Travelers.Single(x => x.Id == entity.Id);
                appDbContext.Travelers.Remove(traveler);

                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Traveler> FindById(int id)
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Travelers.SingleAsync(x => x.Id == id);
            }
        }

        public async Task<IEnumerable<Traveler>> GetAll()
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Travelers.ToArrayAsync();
            }
        }

        public async Task Update(Traveler entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var traveler = appDbContext.Travelers.Single(x => x.Id == entity.Id);

                traveler.ArrivalTime = entity.ArrivalTime;
                traveler.Travel = entity.Travel;
                traveler.Apartment = entity.Apartment;
                traveler.TravelTransports = entity.TravelTransports;
                traveler.ConfirmedByEmployee = entity.ConfirmedByEmployee;

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
