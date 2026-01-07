using CricketClubManagement.Domain.Entities;
using CricketClubManagement.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CricketClubManagement.Api.DTOs;

namespace CricketClubManagement.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly CricketClubManagementDbContext _context;

        public RoleController(CricketClubManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet] // Get all roles
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetRoles()
        {
            return await _context.Roles
                .Select(r => new RoleDto
                {
                    RoleId = r.RoleId,
                    RoleName = r.RoleName
                })
                .ToListAsync();
        }
        [HttpGet("{id}")] // Get role by ID
        public async Task<ActionResult<RoleDto>> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return new RoleDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            };
        }
        [HttpPost] // Create a new role
        public async Task<ActionResult<RoleDto>> CreateRole(CreateRoleDto dto)
        {
            var role = new Role
            {
                RoleName = dto.RoleName
            };
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRole), new { id = role.RoleId }, new RoleDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            });
        }
        [HttpPut("{id}")] // Update an existing role
        public async Task<IActionResult> UpdateRole(int id, UpdateRoleDto dto)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            role.RoleName = dto.RoleName;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")] // Delete a role
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
