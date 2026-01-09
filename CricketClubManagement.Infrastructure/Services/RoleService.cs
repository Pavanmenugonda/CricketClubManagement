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
    public class RoleService :IRoleService
    {
        private readonly CricketClubManagementDbContext _context;
        public RoleService(CricketClubManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            return await _context.Roles
                .Select(r => new RoleDto
                {
                    RoleId = r.RoleId,
                    RoleName = r.RoleName
                })
                .ToListAsync();
        }

        public  async Task<RoleDto?> GetByIdAsync(int id)
        {
            return await _context.Roles
                .Where(r => r.RoleId == id)
                .Select(r => new RoleDto
                {
                    RoleId = r.RoleId,
                    RoleName = r.RoleName
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(CreateRoleDto dto)
        {
            if(dto.RoleName == null)
            {
                throw new ArgumentException("RoleName cannot be null");
            }
            if(await _context.Roles.AnyAsync(r => r.RoleName == dto.RoleName))
            {
                throw new InvalidOperationException("Role with the same name already exists");
            }
            
            var role = new Role
            {
                RoleName = dto.RoleName
            };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role.RoleId;
        }

        public async Task<bool> UpdateAsync(int id, UpdateRoleDto dto)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;

            if (dto.RoleName == null) {
                throw new ArgumentException("RoleName cannot be null");
            }
            if (await _context.Roles.AnyAsync(r => r.RoleName == dto.RoleName && r.RoleId != id))
            {
                throw new InvalidOperationException("Role with the same name already exists");
            }
            role.RoleName = dto.RoleName;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return false;
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
