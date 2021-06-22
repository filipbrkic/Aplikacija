using Application.Common.Interface;
using Application.Common.Models;
using Application.DAL.Models;
using Application.Repository.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class SeminarRepository : ISeminarRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;

        public SeminarRepository(IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }
        public async Task<IEnumerable<SeminarDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging)
        {
            var result = await genericRepository.GetAllAsync<Seminar>(CreateFilterExpression(filtering.Search, filtering.SearchBy), CreateOrderByExpression(sorting.SortBy), paging.PageSize, paging.Skip, sorting.SortOrder);
            paging.TotalItemsCount = result.Item2;
            return mapper.Map<IEnumerable<SeminarDTO>>(result.Item1);
        }
        private static Expression<Func<Seminar, bool>> CreateFilterExpression(string search, string searchBy)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return v => searchBy == "Name" ?
                v.Name.IndexOf(search) > -1 :
                v.Description.IndexOf(search) > -1;
            }
            return x => x.Name.StartsWith(String.Empty);
        }
        private static Expression<Func<Seminar, string>> CreateOrderByExpression(string sortBy)
        {
            if (sortBy == "Name" || sortBy == null)
            {
                return v => v.Name;
            }
            else
            {
                return v => v.Description;
            }
        }

        public async Task<int> AddAsync(SeminarDTO entity)
        {
            entity.Id = Guid.NewGuid();
            return await genericRepository.AddAsync(mapper.Map<Seminar>(entity));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<Seminar>(id);
        }
        public async Task<int> DeleteAsync(SeminarDTO entity)
        {
            return await genericRepository.DeleteAsync(mapper.Map<Seminar>(entity));
        }

        public async Task<SeminarDTO> GetAsync(Guid id)
        {
            return mapper.Map<SeminarDTO>(await genericRepository.GetAsync<Seminar>(id));
        }

        public async Task<int> UpdateAsync(SeminarDTO entity)
        {
            Expression<Func<Seminar, Guid>> test = x => entity.Id;
            return await genericRepository.UpdateAsync(mapper.Map<Seminar>(entity));
        }
    }
}
