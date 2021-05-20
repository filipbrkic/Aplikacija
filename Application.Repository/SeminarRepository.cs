using Application.Common.Models;
using Application.DAL.Models;
using Application.Repository.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<SeminarDTO>> GetAllAsync(Sorting sorting, Filtering filtering, Paging paging)
        {
            var result = mapper.Map<IEnumerable<SeminarDTO>>(await genericRepository.GetAllAsync<Seminar>());

            if (!String.IsNullOrEmpty(filtering.SearchString))
            {
                result = result.Where(s => s.Name.ToLower().Contains(filtering.SearchString.ToLower()));
            }

            if (string.IsNullOrEmpty(sorting.SortBy))
            {
                sorting.SortBy = nameof(SeminarDTO.Name);
            }
            switch (sorting.SortBy)
            {
                case nameof(SeminarDTO.Name):
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.Name) : result.OrderByDescending(item => item.Name);
                    break;
                case nameof(SeminarDTO.Description):
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.Description) : result.OrderByDescending(item => item.Description);
                    break;
                case nameof(SeminarDTO.DateTime):
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.DateTime) : result.OrderByDescending(item => item.DateTime);
                    break;
                case nameof(SeminarDTO.ParticipantsCount):
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.ParticipantsCount) : result.OrderByDescending(item => item.ParticipantsCount);
                    break;
            }
            return result;
        }

        public async Task<SeminarDTO> GetAsync(Guid id)
        {
            return mapper.Map<SeminarDTO>(await genericRepository.GetAsync<Seminar>(id));
        }

        public async Task<int> UpdateAsync(SeminarDTO entity)
        {
            return await genericRepository.UpdateAsync(mapper.Map<Seminar>(entity));
        }
    }
}
