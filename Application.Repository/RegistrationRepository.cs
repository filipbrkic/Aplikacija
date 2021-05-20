using Application.Common.Models;
using Application.DAL.Models;
using Application.Repository.Common;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;

        public RegistrationRepository(IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }

        public async Task<int> AddAsync(RegistrationDTO entity)
        {
            entity.Id = Guid.NewGuid();
            return await genericRepository.AddAsync(mapper.Map<Registration>(entity));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await genericRepository.DeleteAsync<Registration>(id);
        }
        public async Task<int> DeleteAsync(RegistrationDTO entity)
        {
            return await genericRepository.DeleteAsync(mapper.Map<Registration>(entity));
        }

        public async Task<IEnumerable<RegistrationDTO>> GetAllAsync(Sorting sorting)
        {
           var result = mapper.Map<IEnumerable<RegistrationDTO>>(await genericRepository.GetAllAsync<Registration>());
            switch(sorting.SortBy)
            {
                case nameof(RegistrationDTO.DateTime):
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.DateTime) : result.OrderByDescending(item => item.DateTime);
                    break;
                case nameof(RegistrationDTO.FirstName):
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.FirstName) : result.OrderByDescending(item => item.FirstName);
                    break;
                case nameof(RegistrationDTO.LastName):
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.LastName) : result.OrderByDescending(item => item.LastName);
                    break;
                case nameof(RegistrationDTO.Address):
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.Address) : result.OrderByDescending(item => item.Address);
                    break;
                case nameof(RegistrationDTO.Email):
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.Email) : result.OrderByDescending(item => item.Email);
                    break;
                case nameof(RegistrationDTO.Phone):
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.Phone) : result.OrderByDescending(item => item.Phone);
                    break;
                case nameof(RegistrationDTO.Status):
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.Status) : result.OrderByDescending(item => item.Status);
                    break;
                default:
                    result = sorting.SortOrder.Equals("asc") ? result.OrderBy(item => item.FirstName) : result.OrderByDescending(item => item.FirstName);
                    break;
            }

           return result;
        }

        public async Task<RegistrationDTO> GetAsync(Guid id)
        {
            return mapper.Map<RegistrationDTO>(await genericRepository.GetAsync<Registration>(id));
        }

        public async Task<int> UpdateAsync(RegistrationDTO entity)
        {
            return await genericRepository.UpdateAsync(entity);
        }
    }
}
