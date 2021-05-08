using Application.Common.Models;
using Application.DAL.Models;
using Application.Repository.Common;
using AutoMapper;
using System.Collections.Generic;
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
            return await genericRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await genericRepository.DeleteAsync<Seminar>(id);
        }

        public async Task<IEnumerable<SeminarDTO>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<SeminarDTO>>(await genericRepository.GetAllAsync<Seminar>());
        }

        public async Task<SeminarDTO> GetAsync(int id)
        {
            return mapper.Map<SeminarDTO>(await genericRepository.GetAsync<Seminar>(id));
        }

        public async Task<int> UpdateAsync(SeminarDTO entity)
        {
            return await genericRepository.UpdateAsync(entity);
        }
    }
}
