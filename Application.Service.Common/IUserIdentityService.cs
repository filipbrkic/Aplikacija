using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service.Common
{
    public interface IUserIdentityService
    {
        Task<int> AddAsync(UserIdentityDTO entity);
        Task<IEnumerable<UserIdentityDTO>> GetAllAsync();
        Task<UserIdentityDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(UserIdentityDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(UserIdentityDTO entity);
    }
}
