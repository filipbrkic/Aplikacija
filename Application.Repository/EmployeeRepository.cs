using Application.Repository.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DAL.Models;
using Application.Common.Models;
using AutoMapper;

namespace Application.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository genericRepository;

        public EmployeeRepository(IMapper mapper, IGenericRepository genericRepository)
        {
            this.mapper = mapper;
            this.genericRepository = genericRepository;
        }

        public async Task<int> AddAsync(EmployeeDTO entity)
        {
            return await genericRepository.AddAsync(mapper.Map<Employee>(entity));
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await genericRepository.DeleteAsync<Employee>(id);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<EmployeeDTO>>(await genericRepository.GetAllAsync<Employee>());
        }

        public async Task<EmployeeDTO> GetAsync(int id)
        {
            return mapper.Map<EmployeeDTO>(await genericRepository.GetAsync<Employee>(id));
        }

        public async Task<int> UpdateAsync(EmployeeDTO entity)
        {
            return await genericRepository.UpdateAsync(mapper.Map<Employee>(entity));
        }
    }
}
