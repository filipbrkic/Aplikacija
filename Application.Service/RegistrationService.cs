using Application.Common.Interface;
using Application.Common.Models;
using Application.Repository.Common;
using Application.Service.Common;
using System;
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
        public async Task<IEnumerable<RegistrationDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging)
        {
            var models = await registrationRepository.GetAllAsync(sorting, filtering, paging);
            return models;
        }

        public async Task<int> AddAsync(RegistrationDTO entity)
        {
            return await registrationRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await registrationRepository.DeleteAsync(id);
        }
        public async Task<int> DeleteAsync(RegistrationDTO entity)
        {
            return await registrationRepository.DeleteAsync(entity);
        }

        public async Task<RegistrationDTO> GetAsync(Guid id)
        {
            return await registrationRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(RegistrationDTO entity)
        {
            return await registrationRepository.UpdateAsync(entity);
        }
    }
}
