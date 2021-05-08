using Application.Common.Models;
using Application.DAL.Models;
using Application.Repository.Common;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<int> AddAsync(RegistrationDTO entity)
        {
            return await genericRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await genericRepository.DeleteAsync<Registration>(id);
        }

        public async Task<IEnumerable<RegistrationDTO>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<RegistrationDTO>>(await genericRepository.GetAllAsync<Registration>());
        }

        public async Task<RegistrationDTO> GetAsync(int id)
        {
            return mapper.Map<RegistrationDTO>(await genericRepository.GetAsync<Registration>(id));
        }

        public async Task<int> UpdateAsync(RegistrationDTO entity)
        {
            return await genericRepository.UpdateAsync(entity);
        }
    }
}
