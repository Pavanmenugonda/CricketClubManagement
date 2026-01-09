using System;
using System.Collections.Generic;
using System.Text;
using CricketClubManagement.Application.DTOs;

namespace CricketClubManagement.Application.Interfaces
{
    public interface IMatchService
    {

        Task<IEnumerable<MatchDto>> GetMatches();
        Task<MatchDto?> GetMatch(int id);
        Task<int> CreateMatch(CreateMatchDto dto);
        Task DeleteMatch(int id);
        Task<bool> UpdateMatch(int id, UpdateMatchDto dto);
    }
}
