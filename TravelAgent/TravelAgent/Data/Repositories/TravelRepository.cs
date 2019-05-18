using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data.Repositories
{
    public class TravelRepository : IRepository<Travel>
    {
        private readonly Func<AppDbContext> appDbContextFunc;

        public TravelRepository(Func<AppDbContext> contextFunc)
        {
            appDbContextFunc = contextFunc;
        }

        public async Task<IEnumerable<Travel>> GetAll()
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Travels.ToArrayAsync();
            }
        }

        public async Task<Travel> Create(Travel entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                appDbContext.Travels.Add(entity);
                await appDbContext.SaveChangesAsync();

                return entity;
            }
        }

        public async Task Delete(Travel entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var travel = appDbContext.Travels.Single(x => x.Id == entity.Id);
                appDbContext.Travels.Remove(travel);

                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Travel> FindById(int id)
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Travels.SingleAsync(x => x.Id == id);
            }
        }

        public async Task Update(Travel entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var travel = appDbContext.Travels.Single(x => x.Id == entity.Id);

                travel.Name = entity.Name;
                travel.TravelTo = entity.TravelTo;
                travel.TravelFrom = entity.TravelFrom;
                travel.OrganizedBy = entity.OrganizedBy;
                travel.StartTime = entity.StartTime;
                travel.Status = entity.Status;
                travel.OrganizedBy = entity.OrganizedBy;

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
