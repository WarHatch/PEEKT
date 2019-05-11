using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data.Repositories
{
    public class TravelRepository : IRepository<Travel>
    {
        private readonly AppDbContext appDbContext;

        public TravelRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public Task<IEnumerable<Travel>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Travel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Travel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Travel>> FindAsync(Func<Travel, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Travel> FirstAsync(Func<Travel, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Travel entity)
        {
            throw new NotImplementedException();
        }
    }
}
