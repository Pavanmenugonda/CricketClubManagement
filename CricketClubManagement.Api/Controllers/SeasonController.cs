using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CricketClubManagement.Infrastructure;
using CricketClubManagement.Domain.Entities;
using CricketClubManagement.Application.DTOs;

namespace CricketClubManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly CricketClubManagementDbContext _context;
        public SeasonController(CricketClubManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet] // GET: api/Season
        public async Task<ActionResult<IEnumerable<SeasonDto>>> GetSeasons()
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
        [HttpGet("{id}")]
        public async Task<ActionResult<SeasonDto>> GetSeason(int id)
        {
            var season = await _context.Seasons.FindAsync(id);
            if (season == null) return NotFound();
            var seasonDto = new SeasonDto
            {
                SeasonId = season.SeasonId,
                SeasonTitle = season.SeasonTitle,
                SeasonStartDate = season.SeasonStartDate,
                SeasonEndDate = season.SeasonEndDate
            };
            return seasonDto;
        }

        [HttpPost] // POST: api/Season
        public async Task<ActionResult<SeasonDto>> CreateSeason(CreateSeasonDto dto)
        {
            var season = new Season
            {
                SeasonTitle = dto.SeasonTitle,
                SeasonStartDate = dto.SeasonStartDate,
                SeasonEndDate = dto.SeasonEndDate
            };
            _context.Seasons.Add(season);
            await _context.SaveChangesAsync();
            var seasonDto = new SeasonDto
            {
                SeasonId = season.SeasonId,
                SeasonTitle = season.SeasonTitle,
                SeasonStartDate = season.SeasonStartDate,
                SeasonEndDate = season.SeasonEndDate
            };
            return CreatedAtAction(nameof(GetSeason), new { id = season.SeasonId }, seasonDto);
        }
        [HttpPut] // PUT: api/Season/5
        public async Task<ActionResult<SeasonDto>> UpdateSeason(int id, CreateSeasonDto dto)
        {
            var season = await _context.Seasons.FindAsync(id);
            if (season == null) return NotFound();
            season.SeasonTitle = dto.SeasonTitle;
            season.SeasonStartDate = dto.SeasonStartDate;
            season.SeasonEndDate = dto.SeasonEndDate;
            await _context.SaveChangesAsync();
            var seasonDto = new SeasonDto
            {
                SeasonId = season.SeasonId,
                SeasonTitle = season.SeasonTitle,
                SeasonStartDate = season.SeasonStartDate,
                SeasonEndDate = season.SeasonEndDate
            };
            return Ok(seasonDto);

        }
        [HttpDelete] // delete: api/Season/5
        public async Task<IActionResult> DeleteSeason(int id)
        {
            var season = await _context.Seasons.FindAsync(id);
            if (season == null) return NotFound();

            _context.Seasons.Remove(season);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
