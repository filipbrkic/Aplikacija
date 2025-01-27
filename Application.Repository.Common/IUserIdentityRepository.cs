﻿using Application.Common.Interface;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Common
{
    public interface IUserIdentityRepository
    {
        Task<int> AddAsync(UserIdentityDTO entity);
        Task<IEnumerable<UserIdentityDTO>> GetAllAsync(ISorting sorting, IFiltering filtering, IPaging paging);
        Task<UserIdentityDTO> GetAsync(Guid id);
        Task<int> UpdateAsync(UserIdentityDTO entity);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(UserIdentityDTO entity);
    }
}
