using Application.Common.Interface;
using Application.Common.Models;
using Application.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Common
{
    public interface ISeminarRepository
    {
        Task<IEnumerable<SeminarDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging);
        Task<int> AddAsync(SeminarDTO entity);
        Task<SeminarDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(SeminarDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(SeminarDTO entity);
    }
}
