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
        private readonly IUserIdentityRepository UserIdentityRepository;

        public UserIdentityService(IUserIdentityRepository UserIdentityRepository)
        {
            this.UserIdentityRepository = UserIdentityRepository;
        }

        public async Task<int> AddAsync(UserIdentityDTO entity)
        {
            return await UserIdentityRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await UserIdentityRepository.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(UserIdentityDTO entity)
        {
            return await UserIdentityRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<UserIdentityDTO>> GetAllAsync()
        {
            return await UserIdentityRepository.GetAllAsync();
        }

        public async Task<UserIdentityDTO> GetAsync(Guid id)
        {
            return await UserIdentityRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(UserIdentityDTO entity)
        {
            return await UserIdentityRepository.UpdateAsync(entity);
        }
    }
}
