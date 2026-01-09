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
            var roleExists = await _context.Roles.AnyAsync(r => r.RoleId == dto.RoleId);
            if (!roleExists)
                throw new ValidationException($"Role does not exist");

            var player = new Player
             {
                PlayerName = dto.PlayerName,
                PlayerAge = dto.PlayerAge,
                PlayerContact = dto.PlayerContact,
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

            var roleExists = await _context.Roles.AnyAsync(r => r.RoleId == dto.RoleId);
            if (!roleExists)
                throw new ValidationException($"Role with ID {dto.RoleId} does not exist");

            player.PlayerName = dto.PlayerName;
            player.PlayerAge = dto.PlayerAge;
            player.PlayerContact = dto.PlayerContact;
            player.RoleId = dto.RoleId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ValidationException("Invalid player ID");

            var player = await _context.Players.FindAsync(id);
            if (player == null) return false;

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
