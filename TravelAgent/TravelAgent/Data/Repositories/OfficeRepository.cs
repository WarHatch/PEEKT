using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgent.Data.Entities;

namespace TravelAgent.Data.Repositories
{
    public class OfficeRepository : IRepository<Office>
    {
        private readonly AppDbContext appDbContext;

        public OfficeRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public Task<IEnumerable<Office>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Office entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Office entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Office>> FindAsync(Func<Office, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Office> FirstAsync(Func<Office, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Office entity)
        {
            throw new NotImplementedException();
        }
    }
}
