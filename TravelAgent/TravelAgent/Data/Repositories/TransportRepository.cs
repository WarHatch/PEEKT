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
        private readonly AppDbContext appDbContext;

        public TransportRepository(AppDbContext context)
        {
            appDbContext = context;
        }
        public async Task<Transport> Create(Transport entity)
        {

            appDbContext.Transports.Add(entity);
            await appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Transport entity)
        {

            var transports = appDbContext.Transports.Single(x => x.Id == entity.Id);
            appDbContext.Transports.Remove(transports);

            await appDbContext.SaveChangesAsync();
        }

        public async Task<Transport> FindById(int id)
        {
            try
            {
                return await appDbContext.Transports.SingleAsync(x => x.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("There isn't any transport with this id");
            }
        }

        public async Task<IEnumerable<Transport>> GetAll()
        {
            return await appDbContext.Transports.ToArrayAsync();
        }

        public async Task Update(Transport entity)
        {

            var transport = appDbContext.Transports.Single(x => x.Id == entity.Id);

            transport.Description = entity.Description;
            transport.TypeOfTransport = entity.TypeOfTransport;

            await appDbContext.SaveChangesAsync();

        }
    }
}
