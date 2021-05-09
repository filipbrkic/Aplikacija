using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Common
{
    public interface IEmployeeRepository
    {
        Task<int> AddAsync(EmployeeDTO entity);
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();
        Task<EmployeeDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(EmployeeDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(EmployeeDTO entity);
    }
}
