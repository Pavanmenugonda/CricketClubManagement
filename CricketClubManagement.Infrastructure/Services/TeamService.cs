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
    public class TeamService :ITeamService
    {
        private readonly CricketClubManagementDbContext _context;

        public TeamService(CricketClubManagementDbContext context)
        {
            _context = context;
        }

 
        public async Task<IEnumerable<TeamDto>> GetAllAsync()
        {
            return await _context.Teams
                .Select(t => new TeamDto
                {
                    TeamId = t.TeamId,
                    TeamName = t.TeamName
                })
                .ToListAsync();
        }
        public async Task<TeamDto?> GetByIdAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return null;
            }
            return new TeamDto
            {
                TeamId = team.TeamId,
                TeamName = team.TeamName
            };
        }
        public async Task<int> CreateAsync(CreateTeamDto dto)
        {
            var team = new Team
            {
                TeamName = dto.TeamName
            };
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return team.TeamId;
        }

        public async Task<bool> UpdateAsync(int id, UpdateTeamDto dto)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return false;
            }
            team.TeamName = dto.TeamName;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return false;
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
