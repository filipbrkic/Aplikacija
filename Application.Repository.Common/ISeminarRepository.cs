using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Common
{
    public interface ISeminarRepository
    {
        Task<int> AddAsync(SeminarDTO entity);
        Task<IEnumerable<SeminarDTO>> GetAllAsync();
        Task<SeminarDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(SeminarDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(SeminarDTO entity);
    }
}
