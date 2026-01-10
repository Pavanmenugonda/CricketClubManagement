using CricketClubManagement.Application.Common;
using CricketClubManagement.Application.DTOs;
using CricketClubManagement.Application.Interfaces;
using CricketClubManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace CricketClubManagement.Api.Controllers
{

  [ApiController]
  [Route("api/players")]
  public class PlayersController : ControllerBase
  {
    private readonly IPlayerService _service;

    public PlayersController(IPlayerService service)
    {
        _service = service;
    }

        [HttpGet]
        public async Task<IActionResult> GetPlayers(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] int? roleId = null)
        {
            var result = await _service.GetAllAsync(page, pageSize, roleId);
            return Ok(result);
        }


        [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var player = await _service.GetByIdAsync(id);

        if (player == null) return NotFound();
         return Ok(ApiResponse<PlayerDto>.Ok(player));
        }
      [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlayerDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, ApiResponse<int>.Ok(id));
        }

     [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdatePlayerDto dto)
    {
            await _service.UpdateAsync(id, dto);
            return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
  }
}
