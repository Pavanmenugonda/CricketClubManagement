using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CricketClubManagement.Infrastructure;
using CricketClubManagement.Domain.Entities;
using CricketClubManagement.Api.DTOs;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly CricketClubManagementDbContext _context;

    public PlayersController(CricketClubManagementDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayers()
    {
        return await _context.Players
            .Select(p => new PlayerDto
            {
                PlayerId = p.PlayerId,
                PlayerName = p.PlayerName,
                PlayerAge = p.PlayerAge,
                PlayerContact = p.PlayerContact,
                RoleId = p.RoleId
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlayerDto>> GetPlayer(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null) return NotFound();

        return new PlayerDto
        {
            PlayerId = player.PlayerId,
            PlayerName = player.PlayerName,
            PlayerAge = player.PlayerAge,
            PlayerContact = player.PlayerContact,
            RoleId = player.RoleId
        };
    }

    [HttpPost]
    public async Task<ActionResult<PlayerDto>> CreatePlayer(CreatePlayerDto dto)
    {
        var player = new Player
        {
            PlayerName = dto.PlayerName,
            PlayerAge = dto.PlayerAge,
            PlayerContact = dto.PlayerContact,
            RoleId = dto.RoleId
        };

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPlayer), new { id = player.PlayerId }, new PlayerDto
        {
            PlayerId = player.PlayerId,
            PlayerName = player.PlayerName,
            PlayerAge = player.PlayerAge,
            PlayerContact = player.PlayerContact,
            RoleId = player.RoleId
        });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlayer(int id, UpdatePlayerDto dto)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null) return NotFound();

        player.PlayerName = dto.PlayerName;
        player.PlayerAge = dto.PlayerAge;
        player.PlayerContact = dto.PlayerContact;
        player.RoleId = dto.RoleId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null) return NotFound();

        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
