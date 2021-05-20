using Application.Common.Models;
using Application.Repository.Common;
using Application.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly IUserIdentityRepository userIdentityRepository;

        public UserIdentityService(IUserIdentityRepository userIdentityRepository)
        {
            this.userIdentityRepository = userIdentityRepository;
        }

        public async Task<int> AddAsync(UserIdentityDTO entity)
        {
            return await userIdentityRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await userIdentityRepository.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(UserIdentityDTO entity)
        {
            return await userIdentityRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<UserIdentityDTO>> GetAllAsync(Sorting sorting)
        {
            return await userIdentityRepository.GetAllAsync(sorting);
        }

        public async Task<UserIdentityDTO> GetAsync(Guid id)
        {
            return await userIdentityRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(UserIdentityDTO entity)
        {
            return await userIdentityRepository.UpdateAsync(entity);
        }
    }
}
