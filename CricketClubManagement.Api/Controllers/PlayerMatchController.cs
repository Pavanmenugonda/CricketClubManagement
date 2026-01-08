using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CricketClubManagement.Infrastructure;
using CricketClubManagement.Domain.Entities;
using CricketClubManagement.Api.DTOs;

namespace CricketClubManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerMatchController : ControllerBase
    {
        private readonly CricketClubManagementDbContext _context;
        public PlayerMatchController(CricketClubManagementDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerMatchDto>>> GetPlayerMatches()
        {
            return await _context.PlayerMatches
                .Select(pm => new PlayerMatchDto
                {
                    PlayerId = pm.PlayerId,
                    MatchId = pm.MatchId,
                    RunsScored = pm.RunsScored,
                    WicketsTaken = pm.WicketsTaken,
                    Catches = pm.Catches
                })
                .ToListAsync();
        }
        [HttpGet("{id}")] // Get a specific PlayerMatch by PlayerId and MatchId
        public async Task<ActionResult<PlayerMatchDto>> GetPlayerMatch(int playerId, int matchId)
        {
            var playerMatch = await _context.PlayerMatches
                .FirstOrDefaultAsync(pm => pm.PlayerId == playerId && pm.MatchId == matchId);
            if (playerMatch == null) return NotFound();
            return new PlayerMatchDto
            {
                PlayerId = playerMatch.PlayerId,
                MatchId = playerMatch.MatchId,
                RunsScored = playerMatch.RunsScored,
                WicketsTaken = playerMatch.WicketsTaken,
                Catches = playerMatch.Catches
            };
        }
        [HttpPost]
        public async Task<ActionResult<PlayerMatchDto>> CreatePlayerMatch(CreatePlayerMatchDto dto)
        {
            var playerMatch = new PlayerMatch
            {
                PlayerId = dto.PlayerId,
                MatchId = dto.MatchId,
                RunsScored = dto.RunsScored,
                WicketsTaken = dto.WicketsTaken,
                Catches = dto.Catches
            };
            _context.PlayerMatches.Add(playerMatch);
            await _context.SaveChangesAsync();
            var playerMatchDto = new PlayerMatchDto
            {
                PlayerId = playerMatch.PlayerId,
                MatchId = playerMatch.MatchId,
                RunsScored = playerMatch.RunsScored,
                WicketsTaken = playerMatch.WicketsTaken,
                Catches = playerMatch.Catches
            };
            return CreatedAtAction(nameof(GetPlayerMatch), new { playerId = playerMatch.PlayerId, matchId = playerMatch.MatchId }, playerMatchDto);
        }
        [HttpPut] // Update an existing PlayerMatch
        public async Task<IActionResult> UpdatePlayerMatch(UpdatePlayerMatchDto dto)
        {
            var playerMatch = await _context.PlayerMatches
                .FirstOrDefaultAsync(pm => pm.PlayerId == dto.PlayerId && pm.MatchId == dto.MatchId);
            if (playerMatch == null) return NotFound();
            playerMatch.RunsScored = dto.RunsScored;
            playerMatch.WicketsTaken = dto.WicketsTaken;
            playerMatch.Catches = dto.Catches;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete] // Delete a PlayerMatch
        public async Task<IActionResult> DeletePlayerMatch(DeletePlayerMatchDto dto)
        {
            var playerMatch = await _context.PlayerMatches
                .FirstOrDefaultAsync(pm => pm.PlayerId == dto.PlayerId && pm.MatchId == dto.PlayerMatchId);
            if (playerMatch == null) return NotFound();
            _context.PlayerMatches.Remove(playerMatch);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}