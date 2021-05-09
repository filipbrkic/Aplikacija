using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Common
{
    public interface IGenericRepository
    {
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<T> GetAsync<T>(Guid id) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;

    }
}
