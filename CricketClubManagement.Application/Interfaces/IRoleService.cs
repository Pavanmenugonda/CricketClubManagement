using System;
using System.Collections.Generic;
using System.Text;
using CricketClubManagement.Application.DTOs;

namespace CricketClubManagement.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateRoleDto dto);
        Task<bool> UpdateAsync(int id, UpdateRoleDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
