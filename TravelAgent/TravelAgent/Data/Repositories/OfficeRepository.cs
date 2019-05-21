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
            return await appDbContext.Offices.Include(x => x.OfficeApartment).ToArrayAsync();
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
            try
            {
                Office office = await appDbContext.Offices.SingleAsync(x => x.Id == id);
                Console.WriteLine(office.OfficeApartment.Id);
                return await appDbContext.Offices.Include(x => x.OfficeApartment).SingleAsync(x => x.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("There isn't any office with this id");
            }

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
