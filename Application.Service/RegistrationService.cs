using Application.Common.Models;
using Application.Repository.Common;
using Application.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

        public async Task<int> AddAsync(RegistrationDTO entity)
        {
            return await registrationRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await registrationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<RegistrationDTO>> GetAllAsync()
        {
            return await registrationRepository.GetAllAsync();
        }

        public async Task<RegistrationDTO> GetAsync(int id)
        {
            return await registrationRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(RegistrationDTO entity)
        {
            return await registrationRepository.UpdateAsync(entity);
        }
    }
}
