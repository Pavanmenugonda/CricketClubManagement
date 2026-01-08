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
    public class PlayerService : IPlayerService
    {
        private readonly CricketClubManagementDbContext _context;

        public PlayerService(CricketClubManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerDto>> GetAllAsync()
        {
            return await _context.Players
                .Select(p => new PlayerDto
                {
                    PlayerId = p.PlayerId,
                    PlayerName = p.PlayerName,
                    PlayerAge = p.PlayerAge
                })
                .ToListAsync();
        }

        public async Task<PlayerDto?> GetByIdAsync(int id)
        {
            return await _context.Players
                .Where(p => p.PlayerId == id)
                .Select(p => new PlayerDto
                {
                    PlayerId = p.PlayerId,
                    PlayerName = p.PlayerName,
                    PlayerAge = p.PlayerAge
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreatePlayerDto dto)
        {
            var player = new Player
            {
                PlayerName = dto.PlayerName,
                PlayerAge = dto.PlayerAge,
                RoleId = dto.RoleId
            };

            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return player.PlayerId;
        }

        public async Task<bool> UpdateAsync(int id, UpdatePlayerDto dto)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return false;

            player.PlayerName = dto.PlayerName;
            player.PlayerAge = dto.PlayerAge;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return false;

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
