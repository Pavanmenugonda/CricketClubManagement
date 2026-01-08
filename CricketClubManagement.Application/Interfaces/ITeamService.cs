using System;
using System.Collections.Generic;
using System.Text;
using CricketClubManagement.Application.DTOs;

namespace CricketClubManagement.Application.Interfaces
{
    public interface ITeamService
    {
        // Define methods for team management here
        Task<IEnumerable<TeamDto>> GetAllAsync();
        Task<TeamDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateTeamDto dto);
        Task<bool> UpdateAsync(int id, UpdateTeamDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
