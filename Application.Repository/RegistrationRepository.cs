using Application.Common.Models;
using Application.DAL.Models;
using Application.Repository.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Application.Common.Interface;

namespace Application.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;

        public RegistrationRepository(IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }

        public async Task<IEnumerable<RegistrationDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging)
        {
            var result = await genericRepository.GetAllAsync<Registration>(CreateFilterExpression(filtering.Search, filtering.SearchBy), CreateOrderByExpression(sorting.SortBy), paging.PageSize, paging.Skip, sorting.SortOrder);
            paging.TotalItemsCount = result.Item2;
            return mapper.Map<IEnumerable<RegistrationDTO>>(result.Item1);
        }
        private static Expression<Func<Registration, bool>> CreateFilterExpression(string search, string searchBy)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return v => searchBy == "Name" ?
                v.FirstName.IndexOf(search) > -1 :
                v.LastName.IndexOf(search) > -1;
            }
            return x => x.FirstName.StartsWith(String.Empty);
        }
        private static Expression<Func<Registration, string>> CreateOrderByExpression(string sortBy)
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

        public async Task<int> AddAsync(RegistrationDTO entity)
        {
            entity.Id = Guid.NewGuid();
            return await genericRepository.AddAsync(mapper.Map<Registration>(entity));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<Registration>(id);
        }
        public async Task<int> DeleteAsync(RegistrationDTO entity)
        {
            return await genericRepository.DeleteAsync(mapper.Map<Registration>(entity));
        }

        public async Task<RegistrationDTO> GetAsync(Guid id)
        {
            return mapper.Map<RegistrationDTO>(await genericRepository.GetAsync<Registration>(id));
        }

        public async Task<int> UpdateAsync(RegistrationDTO entity)
        {
            return await genericRepository.UpdateAsync(mapper.Map<Registration>(entity));
        }
    }
}
