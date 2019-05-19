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
        private readonly AppDbContext appDbContext;

        public HotelRepository(AppDbContext context)
        {
            appDbContext = context;
        }
        public async Task<Hotel> Create(Hotel entity)
        {

            appDbContext.Hotels.Add(entity);
            await appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Hotel entity)
        {

            var apartment = appDbContext.Hotels.Single(x => x.Id == entity.Id);
            appDbContext.Hotels.Remove(apartment);

            await appDbContext.SaveChangesAsync();
        }

        public async Task<Hotel> FindById(int id)
        {
            return await appDbContext.Hotels.SingleAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Hotel>> GetAll()
        {

            return await appDbContext.Hotels.ToArrayAsync();

        }

        public async Task Update(Hotel entity)
        {

            var hotel = appDbContext.Hotels.Single(x => x.Id == entity.Id);

            hotel.Travel = entity.Travel;
            hotel.Title = entity.Title;
            hotel.Address = entity.Address;

            await appDbContext.SaveChangesAsync();

        }
    }
}
