using Application.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Common
{
    public interface ISeminarRepository
    {
        Task<int> AddAsync(SeminarDTO entity);
        Task<IEnumerable<SeminarDTO>> GetAllAsync();
        Task<SeminarDTO> GetAsync(int id);
        Task<int> UpdateAsync(SeminarDTO entity);
        Task<int> DeleteAsync(int id);
    }
}
