using Application.Common.Interface;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service.Common
{
    public interface IRegistrationService
    {
        Task<IEnumerable<RegistrationDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging);
        Task<int> AddAsync(RegistrationDTO entity);
        Task<RegistrationDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(RegistrationDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(RegistrationDTO entity);
    }
}
