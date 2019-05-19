using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;

namespace TravelAgent.Data.Repositories
{
    public class TransportRepository : ITransportRepository
    {
        private readonly Func<AppDbContext> appDbContextFunc;

        public TransportRepository(Func<AppDbContext> contextFunc)
        {
            appDbContextFunc = contextFunc;
        }
        public async Task<Transport> Create(Transport entity)
        {
            using (var appDbContext = appDbContextFunc())
            {

                appDbContext.Transports.Add(entity);
                await appDbContext.SaveChangesAsync();

                return entity;
            }
        }

        public async Task Delete(Transport entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var transports = appDbContext.Transports.Single(x => x.Id == entity.Id);
                appDbContext.Transports.Remove(transports);

                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Transport> FindById(int id)
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Transports.SingleAsync(x => x.Id == id);
            }
        }

        public async Task<IEnumerable<Transport>> GetAll()
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Transports.ToArrayAsync();
            }
        }

        public async Task Update(Transport entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var transport = appDbContext.Transports.Single(x => x.Id == entity.Id);

                transport.Description = entity.Description;
                transport.TypeOfTransport = entity.TypeOfTransport;

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
