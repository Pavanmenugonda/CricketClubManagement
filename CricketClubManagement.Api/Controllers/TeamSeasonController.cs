using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CricketClubManagement.Infrastructure;
using CricketClubManagement.Domain.Entities;
using CricketClubManagement.Api.DTOs;
namespace CricketClubManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamSeasonController : ControllerBase
    {
        private readonly CricketClubManagementDbContext _context;

        public TeamSeasonController(CricketClubManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet] // GET: api/TeamSeason
        public async Task<ActionResult<IEnumerable<TeamSeasonDto>>> GetTeamSeasons()
        {
            return await _context.TeamSeasons
                .Select(ts => new TeamSeasonDto
                {
                 SeasonId = ts.SeasonId,
                    TeamSeasonId = ts.TeamId,
                })
                .ToListAsync();
        }

        [HttpPost] // POST: api/TeamSeason
        public async Task<ActionResult<TeamSeasonDto>> CreateTeamSeason(CreateTeamSeasonDto dto)
        {
            var teamSeason = new TeamSeason
            {
                SeasonId = dto.SeasonId,
                TeamId = dto.TeamSeasonId,
            };
            _context.TeamSeasons.Add(teamSeason);
            await _context.SaveChangesAsync();
            var teamSeasonDto = new TeamSeasonDto
            {
                SeasonId = teamSeason.SeasonId,
                TeamSeasonId = teamSeason.TeamId,
            };
            return CreatedAtAction(nameof(GetTeamSeasons), new { id = teamSeason.TeamId }, teamSeasonDto);
        }

        [HttpPut] // PUT: api/TeamSeason/5
        public async Task<IActionResult> UpdateTeamSeason(int id, CreateTeamSeasonDto dto)
        {
            var teamSeason = await _context.TeamSeasons.FindAsync(id);
            if (teamSeason == null)
            {
                return NotFound();
            }
            teamSeason.SeasonId = dto.SeasonId;
            teamSeason.TeamId = dto.TeamSeasonId;
            _context.Entry(teamSeason).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete] // DELETE: api/TeamSeason/5
        public async Task<IActionResult> DeleteTeamSeason(int id)
        {
            var teamSeason = await _context.TeamSeasons.FindAsync(id);
            if (teamSeason == null)
            {
                return NotFound();
            }
            _context.TeamSeasons.Remove(teamSeason);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
