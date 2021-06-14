using Application.Repository.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DAL.Models;
using Application.Common.Models;
using AutoMapper;
using System;
using System.Linq;
using System.Linq.Expressions;
using Application.Common.Interface;

namespace Application.Repository
{
    public class UserIdentityRepository : IUserIdentityRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;

        public UserIdentityRepository(IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }

        public async Task<int> AddAsync(UserIdentityDTO entity)
        {
            entity.Id = Guid.NewGuid();
            return await genericRepository.AddAsync(mapper.Map<UserIdentity>(entity));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<UserIdentity>(id);
        }

        public async Task<int> DeleteAsync(UserIdentityDTO entity)
        {
            return await genericRepository.DeleteAsync(mapper.Map<UserIdentity>(entity));
        }

        public async Task<IEnumerable<UserIdentityDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging)
        {
            var result = await genericRepository.GetAllAsync<UserIdentity>(CreateFilterExpression(filtering.Search, filtering.SearchBy), CreateOrderByExpression(sorting.SortBy), paging.PageSize, paging.Skip, sorting.SortOrder);
            paging.TotalItemsCount = result.Item2;
            return mapper.Map<IEnumerable<UserIdentityDTO>>(result.Item1);
        }
        private static Expression<Func<UserIdentity, bool>> CreateFilterExpression(string search, string searchBy)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return v => searchBy == "Name" ?
                v.FirstName.IndexOf(search) > -1 :
                v.LastName.IndexOf(search) > -1;
            }
            return x => x.FirstName.StartsWith(String.Empty);
        }
        private static Expression<Func<UserIdentity, string>> CreateOrderByExpression(string sortBy)
        {
            if (sortBy == "Name" || sortBy == null)
            {
                return v => v.FirstName;
            }
            else
            {
                return v => v.LastName;
            }
        }

        public async Task<UserIdentityDTO> GetAsync(Guid id)
        {
            return mapper.Map<UserIdentityDTO>(await genericRepository.GetUserAsync<UserIdentity>(id.ToString()));
        }

        public async Task<int> UpdateAsync(UserIdentityDTO entity)
        {
            return await genericRepository.UpdateAsync(mapper.Map<UserIdentity>(entity));
        }
    }
}
