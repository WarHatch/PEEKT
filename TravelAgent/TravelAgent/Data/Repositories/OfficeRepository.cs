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
        private readonly Func<AppDbContext> appDbContextFunc;

        public OfficeRepository(Func<AppDbContext> contextFunc)
        {
            appDbContextFunc = contextFunc;
        }

        public async Task<IEnumerable<Office>> GetAll()
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await appDbContext.Offices.ToArrayAsync();
            }
        }

        public async Task<Office> Create(Office entity)
        {
            using (var appDbContext = appDbContextFunc())
            {

                var office = new Office
                {
                    Title = entity.Title,
                    Address = entity.Address
                };

                appDbContext.Offices.Add(office);
                await appDbContext.SaveChangesAsync();

                return office;
            }
        }

        public async Task Delete(Office entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var office = appDbContext.Offices.Single(x => x.Id == entity.Id);
                appDbContext.Offices.Remove(office);

                await appDbContext.SaveChangesAsync();
            }
        }


        public async Task<Office> FindById(int id)
        {
            using (var appDbContext = appDbContextFunc())
            {
                return await  appDbContext.Offices.SingleAsync(x => x.Id == id); 
            }
        }


        public async Task Update(Office entity)
        {
            using (var appDbContext = appDbContextFunc())
            {
                var office = appDbContext.Offices.Single(x => x.Id == entity.Id);

                office.Title = entity.Title;
                office.Address = entity.Address;

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
