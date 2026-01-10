using CricketClubManagement.Application.Interfaces;
using CricketClubManagement.Application.DTOs;
using CricketClubManagement.Domain.Entities;
using CricketClubManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using CricketClubManagement.Application.Common;

namespace CricketClubManagement.Infrastructure.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly CricketClubManagementDbContext _context;

        public PlayerService(CricketClubManagementDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<PlayerDto>> GetAllAsync(
             int page,
             int pageSize,
             int? roleId)
        {
            if (page <= 0) page = 1;
            if (pageSize <= 0 || pageSize > 100) pageSize = 10;

            var query = _context.Players.AsQueryable();

            // Filtering
            if (roleId.HasValue)
            {
                query = query.Where(p => p.RoleId == roleId.Value);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(p => p.PlayerName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PlayerDto
                {
                    PlayerId = p.PlayerId,
                    PlayerName = p.PlayerName,
                    PlayerAge = p.PlayerAge,
                    PlayerContact = p.PlayerContact,
                    RoleId = p.RoleId
                })
                .ToListAsync();

            return new PagedResult<PlayerDto>
            {
                Items = items,
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };
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
