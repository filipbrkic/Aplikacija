using Application.Common.Interface;
using Application.Common.Models;
using Application.Repository.Common;
using Application.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service
{
    public class SeminarService : ISeminarService
    {
        private readonly ISeminarRepository seminarRepository;

        public SeminarService(ISeminarRepository seminarRepository)
        {
            this.seminarRepository = seminarRepository;
        }
        public async Task<IEnumerable<SeminarDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging)
        {
            var models = await seminarRepository.GetAllAsync(sorting, filtering, paging);
            return models;
        }

        public async Task<int> AddAsync(SeminarDTO entity)
        {
            return await seminarRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await seminarRepository.DeleteAsync(id);
        }

        public async Task<int> DeleteAsync(SeminarDTO entity)
        {
            return await seminarRepository.DeleteAsync(entity);
        }

        public async Task<SeminarDTO> GetAsync(Guid id)
        {
            return await seminarRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(SeminarDTO entity)
        {
            return await seminarRepository.UpdateAsync(entity);
        }
    }
}
