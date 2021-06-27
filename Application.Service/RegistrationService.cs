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
        private readonly ISeminarRepository seminarRepository;

        public RegistrationService(IRegistrationRepository registrationRepository, ISeminarRepository seminarRepository)
        {
            this.registrationRepository = registrationRepository;
            this.seminarRepository = seminarRepository;
        }
        public async Task<IEnumerable<RegistrationDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging)
        {
            var models = await registrationRepository.GetAllAsync(sorting, filtering, paging);
            return models;
        }

        public async Task<int> AddAsync(RegistrationDTO entity)
        {
            //if(entity.Status)
            //{
            //    var seminar = await seminarRepository.GetAsync(entity.SeminarId);
            //    seminar.ParticipantsCount++;
            //    await seminarRepository.UpdateAsync(seminar);
            //}
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
            //var registration = await registrationRepository.GetAsync(entity.Id);
            ////if(entity.Status != registration.Status)
            ////{
            ////    if(entity.Status)
            ////    {
            ////        var seminar = await seminarRepository.GetAsync(entity.SeminarId);
            ////        seminar.ParticipantsCount++;
            ////        await seminarRepository.UpdateAsync(seminar);
            ////    }
            ////    else
            ////    {
            ////        var seminar = await seminarRepository.GetAsync(entity.SeminarId);
            ////        seminar.ParticipantsCount--;
            ////        await seminarRepository.UpdateAsync(seminar);
            ////    }
            ////}
            //return await registrationRepository.UpdateAsync(entity);
            return await registrationRepository.UpdateAsync(entity);
        }
    }
}
