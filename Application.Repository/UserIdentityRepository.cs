using Application.Repository.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DAL.Models;
using Application.Common.Models;
using AutoMapper;
using System;

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

        public async Task<IEnumerable<UserIdentityDTO>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<UserIdentityDTO>>(await genericRepository.GetAllAsync<UserIdentity>());
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
