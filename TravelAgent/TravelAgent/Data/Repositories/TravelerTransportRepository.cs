using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data.Repositories
{
    public class TravelerTransportRepository : IRepository<TravelerTransport>
    {
        private readonly Func<AppDbContext> appDbContextFunc;

        public TravelerTransportRepository(Func<AppDbContext> contextFunc)
        {
            appDbContextFunc = contextFunc;
        }
        public async Task<TravelerTransport> Create(TravelerTransport entity)
        {
            using (var appDbContext = appDbContextFunc())
            {

                appDbContext.TravelerTransports.Add(entity);
                await appDbContext.SaveChangesAsync();

                return entity;
            }
        }

        public async Task Delete(TravelerTransport entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var apartment = appDbContext.TravelerTransports.Single(x => x.Id == entity.Id);
                appDbContext.TravelerTransports.Remove(apartment);

                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<TravelerTransport> FindById(int id)
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.TravelerTransports.SingleAsync(x => x.Id == id);
            }
        }

        public async Task<IEnumerable<TravelerTransport>> GetAll()
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.TravelerTransports.ToArrayAsync();
            }
        }

        public async Task Update(TravelerTransport entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var travelerTransport = appDbContext.TravelerTransports.Single(x => x.Id == entity.Id);

                travelerTransport.Traveler = entity.Traveler;
                travelerTransport.Transport = entity.Transport;
                travelerTransport.DepartureTime = entity.DepartureTime;
                travelerTransport.ArrivalTime = entity.ArrivalTime;

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
