using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;
using TravelAgent.Data.Repositories.Interfaces;
using TravelAgent.DataContract.Requests;

namespace TravelAgent.Data.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly AppDbContext appDbContext;

        public TravelRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public async Task<IEnumerable<Travel>> GetAll()
        {


            return await appDbContext.Travels.ToArrayAsync();

        }

        public async Task<Travel> Create(Travel entity)
        {
            appDbContext.Entry(entity.OrganizedBy).State = EntityState.Unchanged;
            appDbContext.Travels.Add(entity);
            await appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Travel entity)
        {
            var travel = appDbContext.Travels.Single(x => x.Id == entity.Id);
            appDbContext.Travels.Remove(travel);

            await appDbContext.SaveChangesAsync();
        }

        public async Task<Travel> FindById(int id)
        {
            return await appDbContext.Travels.SingleAsync(x => x.Id == id);
        }

        public async Task Update(Travel entity)
        {

            var travel = appDbContext.Travels.Single(x => x.Id == entity.Id);

            travel.Name = entity.Name;
            travel.TravelTo = entity.TravelTo;
            travel.TravelFrom = entity.TravelFrom;
            travel.OrganizedBy = entity.OrganizedBy;
            travel.StartTime = entity.StartTime;
            travel.Cost = entity.Cost;
            travel.OrganizedBy = entity.OrganizedBy;

            await appDbContext.SaveChangesAsync();

        }


    }
}
