using Application.Common.Models;
using Application.Repository.Common;
using Application.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<int> AddAsync(EmployeeDTO entity)
        {
            return await employeeRepository.AddAsync(entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            return await employeeRepository.GetAllAsync();
        }

        public async Task<EmployeeDTO> GetAsync(int id)
        {
            return await employeeRepository.GetAsync(id);
        }

        public async Task<int> UpdateAsync(EmployeeDTO entity)
        {
            return await employeeRepository.UpdateAsync(entity);
        }
    }
}
