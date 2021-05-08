using Application.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service.Common
{
    public interface IRegistrationService
    {
        Task<int> AddAsync(RegistrationDTO entity);
        Task<IEnumerable<RegistrationDTO>> GetAllAsync();
        Task<RegistrationDTO> GetAsync(int id);
        Task<int> UpdateAsync(RegistrationDTO entity);
        Task<int> DeleteAsync(int id);
    }
}
