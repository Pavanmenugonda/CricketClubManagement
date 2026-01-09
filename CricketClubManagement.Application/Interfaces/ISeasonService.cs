using System;
using System.Collections.Generic;
using System.Text;
using CricketClubManagement.Application.DTOs;

namespace CricketClubManagement.Application.Interfaces
{
    public interface ISeasonService
    {
        Task<IEnumerable<SeasonDto>> GetAllAsync();
        Task<SeasonDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreateSeasonDto dto);
        Task<bool> UpdateAsync(int id, UpdateSeasonDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
