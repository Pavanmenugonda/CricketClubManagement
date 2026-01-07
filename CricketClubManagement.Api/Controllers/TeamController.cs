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
    public class TeamController : ControllerBase
    {
        // Injecting DbContext
        private readonly CricketClubManagementDbContext _context;

        public TeamController(CricketClubManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet] // Get all teams
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
        {
            return await _context.Teams
                .Select(t => new TeamDto
                {
                    TeamId = t.TeamId,
                    TeamName = t.TeamName
                })
                .ToListAsync();
        }

        [HttpGet("{id}")] // Get team by ID
        public async Task<ActionResult<TeamDto>> GetTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            return  new TeamDto
                {
                TeamId = team.TeamId,
                TeamName = team.TeamName
            };

        }

        [HttpPost] // Create a new team
        public async Task<ActionResult<TeamDto>> CreateTeam(CreateTeamDto team)
        {
           var newTeam = new Team
            {
                TeamName = team.TeamName
            };
            _context.Teams.Add(newTeam);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeam), new { id = newTeam.TeamId }, 
                new TeamDto
                {
                    TeamId = newTeam.TeamId,
                    TeamName = newTeam.TeamName
                });
        }

        [HttpPut("{id}")] // Update an existing team
        public async Task<IActionResult> UpdateTeam(int id, UpdateTeamDto dto)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null) return NotFound();

            team.TeamName = dto.TeamName;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")] // Delete a team
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
