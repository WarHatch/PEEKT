using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data.Repositories
{
    public class ApartmentRepository : IRepository<Apartment>
    {
        private readonly Func<AppDbContext> appDbContextFunc;

        public ApartmentRepository(Func<AppDbContext> contextFunc)
        {
            appDbContextFunc = contextFunc;
        }
        public async Task<Apartment> Create(Apartment entity)
        {
            using (var appDbContext = appDbContextFunc())
            {

                appDbContext.Apartments.Add(entity);
                await appDbContext.SaveChangesAsync();

                return entity;
            }
        }

        public async Task Delete(Apartment entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var apartment = appDbContext.Apartments.Single(x => x.Id == entity.Id);
                appDbContext.Apartments.Remove(apartment);

                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Apartment> FindById(int id)
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Apartments.SingleAsync(x => x.Id == id);
            }
        }

        public async Task<IEnumerable<Apartment>> GetAll()
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Apartments.ToArrayAsync();
            }
        }

        public async Task Update(Apartment entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var apartment = appDbContext.Apartments.Single(x => x.Id == entity.Id);

                apartment.Title = entity.Title;
                apartment.Address = entity.Address;
                apartment.FitsPeople = entity.FitsPeople;

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
