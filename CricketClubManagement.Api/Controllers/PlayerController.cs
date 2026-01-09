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
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var player = await _service.GetByIdAsync(id);
        if (player == null) return NotFound();

        return Ok(player);
    }
      [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlayerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // returns 400 if validation fails

            try
            {
                var id = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id }, null);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

     [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdatePlayerDto dto)
    {
           if (!ModelState.IsValid)
            return BadRequest(ModelState); // returns 400 if validation fails

            try
            {
                var updated = await _service.UpdateAsync(id, dto);
                if (!updated) return NotFound();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }

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
