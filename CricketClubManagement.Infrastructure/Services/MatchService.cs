using CricketClubManagement.Application.Interfaces;
using CricketClubManagement.Application.DTOs;
using CricketClubManagement.Domain.Entities;
using CricketClubManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CricketClubManagement.Infrastructure.Services
{
    public class MatchService : IMatchService
    {
        private readonly CricketClubManagementDbContext _context;

        public MatchService(CricketClubManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchDto>> GetMatches()
        {
            return await _context.Matches
                .Select(m => new MatchDto
                {
                    MatchId = m.MatchId,
                    MatchDate = m.MatchDate,
                    MatchName = m.MatchName,
                    SeasonId = m.SeasonId
                })
                .ToListAsync();
        }

        public async Task<MatchDto?> GetMatch(int id)
        {
            return await _context.Matches
                .Where(m => m.MatchId == id)
                .Select(m => new MatchDto
                {
                    MatchId = m.MatchId,
                    MatchDate = m.MatchDate,
                    MatchName = m.MatchName,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateMatch(CreateMatchDto dto)
        {
           var seasonExists = await _context.Seasons.AnyAsync(s => s.SeasonId == dto.SeasonId);
            if (!seasonExists) 
                throw new ValidationException($"Season does not exist.");
            var match = new Match
            {
                MatchName = dto.MatchName,
                MatchDate = dto.MatchDate,
                SeasonId = dto.SeasonId
            };
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return match.MatchId;
        }
        public async Task<bool> UpdateMatch(int id, UpdateMatchDto dto)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return false;

            var seasonExists = await _context.Seasons.AnyAsync(s => s.SeasonId == dto.SeasonId);
            if (!seasonExists)
                throw new ValidationException($"Season with ID {dto.SeasonId} does not exist.");

            match.MatchName = dto.MatchName;
            match.MatchDate = dto.MatchDate;
            match.SeasonId = dto.SeasonId;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task DeleteMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match != null)
            {
                _context.Matches.Remove(match);
                await _context.SaveChangesAsync();
            }
        }
       
    }
}
