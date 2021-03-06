﻿using Microsoft.EntityFrameworkCore;
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


            return await appDbContext.Travels.Include(x => x.OrganizedBy).Include(x => x.TravelTo).Include(x => x.TravelFrom).Include(x => x.Hotels).Include(x => x.Transports).ToArrayAsync();

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
            try
            {
                return await appDbContext.Travels.Include(x => x.OrganizedBy).Include(x => x.TravelTo).Include(x => x.TravelFrom).Include(x => x.Hotels).Include(x => x.Transports).SingleAsync(x => x.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("There isn't any travels with this id");
            }
        }
        public async Task<Travel> FindByIdWithOrganizedBy(int id)
        {
            try
            {
                return await appDbContext.Travels.Include(x => x.TravelTo).Include(x => x.TravelFrom).Include(x => x.Hotels).Include(x => x.Transports).SingleAsync(x => x.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException("There isn't any travels with this id");
            }
        }

        public async Task Update(Travel entity)
        {

            var travel = appDbContext.Travels.Single(x => x.Id == entity.Id);

            travel.Name = entity.Name;
            travel.TravelTo = entity.TravelTo;
            travel.TravelFrom = entity.TravelFrom;
            travel.StartTime = entity.StartTime;
            travel.EndTime = entity.EndTime;
            travel.Cost = entity.Cost;
            travel.OrganizedBy = entity.OrganizedBy;

            await appDbContext.SaveChangesAsync();

        }


    }
}
