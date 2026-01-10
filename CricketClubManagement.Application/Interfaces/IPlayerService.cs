using CricketClubManagement.Application.Common;
using CricketClubManagement.Application.DTOs;
using System;
using System.Collections.Generic;

namespace CricketClubManagement.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<PagedResult<PlayerDto>> GetAllAsync(int page, int pageSize, int? roleId);

        Task<PlayerDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(CreatePlayerDto dto);
        Task<bool> UpdateAsync(int id, UpdatePlayerDto dto);
        Task<bool> DeleteAsync(int id);
    }

}
