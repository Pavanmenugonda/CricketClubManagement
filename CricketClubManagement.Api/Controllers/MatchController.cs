using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CricketClubManagement.Infrastructure;
using CricketClubManagement.Domain.Entities;
using CricketClubManagement.Application.DTOs;
using CricketClubManagement.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CricketClubManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _service;

        public MatchController(IMatchService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetMatches());

        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var match = await _service.GetMatch(id);
            if (match == null) return NotFound();
            return Ok(match);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMatchDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var id = await _service.CreateMatch(dto);
            }

            catch (ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            return CreatedAtAction(nameof(GetById), new { id = dto }, dto);

        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateMatchDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var updated = await _service.UpdateMatch(id, dto);
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
            await _service.DeleteMatch(id);
            return NoContent();
        }
    }
}
