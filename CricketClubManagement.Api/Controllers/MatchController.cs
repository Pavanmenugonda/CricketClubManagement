using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CricketClubManagement.Infrastructure;
using CricketClubManagement.Domain.Entities;
using CricketClubManagement.Api.DTOs;
namespace CricketClubManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly CricketClubManagementDbContext _context;

        public MatchController(CricketClubManagementDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatches()
        {
            return await _context.Matches
                .Select(m => new MatchDto
                {
                    MatchId = m.MatchId,
                    MatchDate = m.MatchDate,
                    MatchName = m.MatchName,
                })
                .ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchDto>> GetMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return NotFound();
            return new MatchDto
            {
                MatchId = match.MatchId,
                MatchDate = match.MatchDate,
                MatchName = match.MatchName,
            };
        }
        [HttpPost]
        public async Task<ActionResult<MatchDto>> CreateMatch(CreateMatchDto dto)
        {
            var match = new Match
            {
                MatchName = dto.MatchName,
                MatchDate = dto.MatchDate,
            };
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            var matchDto = new MatchDto
            {
                MatchId = match.MatchId,
                MatchDate = match.MatchDate,
                MatchName = match.MatchName,
            };
            return CreatedAtAction(nameof(GetMatch), new { id = match.MatchId }, matchDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatch(int id, UpdateMatchDto dto)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return NotFound();
            match.MatchName = dto.MatchName;
            match.MatchDate = dto.MatchDate;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return NotFound();
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
