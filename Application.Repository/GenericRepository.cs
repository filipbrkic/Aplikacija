using Application.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DAL.Data.DbContext dbContext;

        public GenericRepository(DAL.Data.DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<(IEnumerable<T>, int)> GetAllAsync<T>(Expression<Func<T, bool>> match, Expression<Func<T, string>> orderByExpression, int take, int skip, string sortOrder) where T : class
        {
            var seminar = sortOrder == "asc" ?
                await dbContext.Set<T>().AsNoTracking().Where(match).OrderBy(orderByExpression).Skip(skip).Take(take).ToListAsync() :
                await dbContext.Set<T>().AsNoTracking().Where(match).OrderByDescending(orderByExpression).Skip(skip).Take(take).ToListAsync();
            var seminarsCount = dbContext.Set<T>().Where(match).AsNoTracking().Count();
            return (seminar, seminarsCount);
        }

        /// <summary>
        /// Create entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> AddAsync<T>(T entity) where T : class
        {
            dbContext.Set<T>().Add(entity);
            return await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// GET single entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(Guid id) where T : class
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// GET user single entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetUserAsync<T>(string id) where T : class
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            dbContext.Set<T>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            var entity = await GetAsync<T>(id);
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }
    }
}
