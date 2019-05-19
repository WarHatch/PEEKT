using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;

namespace TravelAgent.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly Func<AppDbContext> appDbContextFunc;

        public HotelRepository(Func<AppDbContext> contextFunc)
        {
            appDbContextFunc = contextFunc;
        }
        public async Task<Hotel> Create(Hotel entity)
        {
            using (var appDbContext = appDbContextFunc())
            {

                appDbContext.Hotels.Add(entity);
                await appDbContext.SaveChangesAsync();

                return entity;
            }
        }

        public async Task Delete(Hotel entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var apartment = appDbContext.Hotels.Single(x => x.Id == entity.Id);
                appDbContext.Hotels.Remove(apartment);

                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Hotel> FindById(int id)
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Hotels.SingleAsync(x => x.Id == id);
            }
        }

        public async Task<IEnumerable<Hotel>> GetAll()
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Hotels.ToArrayAsync();
            }
        }

        public async Task Update(Hotel entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var hotel = appDbContext.Hotels.Single(x => x.Id == entity.Id);

                hotel.Travel = entity.Travel;
                hotel.Title = entity.Title;
                hotel.Address = entity.Address;

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
