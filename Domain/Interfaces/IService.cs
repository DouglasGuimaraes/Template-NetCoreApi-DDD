using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IService<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        List<T> GetByFilter(Func<T, bool> predicate);
        Task<T> Get(int id);
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        Task<T> Delete(int id);
    }
}
