using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAgent.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> FindById(int id);
        Task<T> Create(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}
