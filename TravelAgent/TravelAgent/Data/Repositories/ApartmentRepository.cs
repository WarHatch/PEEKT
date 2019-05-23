using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;

namespace TravelAgent.Data.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly AppDbContext appDbContext;

        public ApartmentRepository(AppDbContext context)
        {
            appDbContext = context;
        }
        public async Task<Apartment> Create(Apartment entity)
        {

            appDbContext.Apartments.Add(entity);
            await appDbContext.SaveChangesAsync();

            return entity;

        }

        public async Task Delete(Apartment entity)
        {
            try
            {
                var apartment = appDbContext.Apartments.Single(x => x.Id == entity.Id);
                appDbContext.Apartments.Remove(apartment);

                await appDbContext.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("Can't delete Apartment, cause it has Guest!", ex);
            }
        }

        public async Task<Apartment> FindById(int id)
        {
            try
            {
                return await appDbContext.Apartments.SingleAsync(x => x.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("There isn't any apartment with this id");
            }

        }

        public async Task<IEnumerable<Apartment>> GetAll()
        {
            return await appDbContext.Apartments.ToArrayAsync();
        }

        public async Task Update(Apartment entity)
        {

            var apartment = appDbContext.Apartments.Single(x => x.Id == entity.Id);

            apartment.Title = entity.Title;
            apartment.Address = entity.Address;
            apartment.FitsPeople = entity.FitsPeople;

            await appDbContext.SaveChangesAsync();

        }
    }
}
