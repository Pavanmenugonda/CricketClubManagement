using CricketClubManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace CricketClubManagement.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<IEnumerable<PlayerDto>> GetAllAsync();
        Task<PlayerDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreatePlayerDto dto);
        Task<bool> UpdateAsync(int id, UpdatePlayerDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
