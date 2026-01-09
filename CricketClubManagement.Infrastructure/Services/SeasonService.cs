using CricketClubManagement.Application.Interfaces;
using CricketClubManagement.Application.DTOs;
using CricketClubManagement.Domain.Entities;
using CricketClubManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CricketClubManagement.Infrastructure.Services
{
    public class SeasonService : ISeasonService
    {

     private readonly CricketClubManagementDbContext _context;

     public SeasonService(CricketClubManagementDbContext context)
     {
         _context = context;  
     }
        public async Task<IEnumerable<SeasonDto>> GetAllAsync()
        {
            return await _context.Seasons
                .Select(s => new SeasonDto
                {
                    SeasonId = s.SeasonId,
                    SeasonTitle = s.SeasonTitle,
                    SeasonStartDate = s.SeasonStartDate,
                    SeasonEndDate = s.SeasonEndDate
                })
                .ToListAsync();
        }

        public async Task<SeasonDto?> GetByIdAsync(int id)
        {
            return await _context.Seasons
                .Where(s => s.SeasonId == id)
                .Select(s => new SeasonDto
                {
                    SeasonId = s.SeasonId,
                    SeasonTitle = s.SeasonTitle,
                    SeasonStartDate = s.SeasonStartDate,
                    SeasonEndDate = s.SeasonEndDate
                })
                .FirstOrDefaultAsync();
        }
        public async Task<int> CreateAsync(CreateSeasonDto dto)
        {
            if(dto.SeasonStartDate >= dto.SeasonEndDate)
            {
                throw new ArgumentException("Season start date must be earlier than end date.");
            }
            if(string.IsNullOrWhiteSpace(dto.SeasonTitle))
            {
                throw new ArgumentException("Season title cannot be empty.");
            }
            if(dto == null)
            {
                throw new ArgumentNullException(nameof(dto), "CreateSeasonDto cannot be null.");
            }
            var season = new Season
            {
                SeasonTitle = dto.SeasonTitle,
                SeasonStartDate = dto.SeasonStartDate,
                SeasonEndDate = dto.SeasonEndDate
            };
            _context.Seasons.Add(season);
            await _context.SaveChangesAsync();
            return season.SeasonId;
        }
        
        public async Task<bool> UpdateAsync(int id, UpdateSeasonDto dto)
        {
            var season = await _context.Seasons.FindAsync(id);
            if (season == null) return false;

            if(dto.SeasonStartDate >= dto.SeasonEndDate)
            {
                throw new ArgumentException("Season start date must be earlier than end date.");
            }
            if(string.IsNullOrWhiteSpace(dto.SeasonTitle))
            {
                throw new ArgumentException("Season title cannot be empty.");
            }

            season.SeasonTitle = dto.SeasonTitle;
            season.SeasonStartDate = dto.SeasonStartDate;
            season.SeasonEndDate = dto.SeasonEndDate;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var season = await _context.Seasons.FindAsync(id);
            if (season == null) return false;
            _context.Seasons.Remove(season);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
