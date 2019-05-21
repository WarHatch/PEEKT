using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;

namespace TravelAgent.Data.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly AppDbContext appDbContext;

        public OfficeRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public async Task<IEnumerable<Office>> GetAll()
        {
            return await appDbContext.Offices.ToArrayAsync();
        }

        public async Task<Office> Create(Office entity)
        {

            appDbContext.Offices.Add(entity);
            await appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Office entity)
        {

            var office = appDbContext.Offices.Single(x => x.Id == entity.Id);
            appDbContext.Offices.Remove(office);

            await appDbContext.SaveChangesAsync();

        }


        public async Task<Office> FindById(int id)
        {
            return await appDbContext.Offices.SingleAsync(x => x.Id == id);
        }


        public async Task Update(Office entity)
        {
            var office = appDbContext.Offices.Single(x => x.Id == entity.Id);

            office.Title = entity.Title;
            office.Address = entity.Address;

            await appDbContext.SaveChangesAsync();
        }
    }
}
