using Application.Common.Interface;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Common
{
    public interface IRegistrationRepository
    {
        Task<int> AddAsync(RegistrationDTO entity);
        Task<IEnumerable<RegistrationDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging);
        Task<RegistrationDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(RegistrationDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(RegistrationDTO entity);
    }
}
