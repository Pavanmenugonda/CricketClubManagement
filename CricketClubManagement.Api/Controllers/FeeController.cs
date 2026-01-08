using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CricketClubManagement.Infrastructure;
using CricketClubManagement.Domain.Entities;
using CricketClubManagement.Api.DTOs;

namespace CricketClubManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeController : ControllerBase
    {
        private readonly CricketClubManagementDbContext _context;

        public FeeController(CricketClubManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet] // GET: api/Fee
        public async Task<ActionResult<IEnumerable<FeeDto>>> GetFees()
        {
            return await _context.Fees
                .Select(f => new FeeDto
                {
                    FeeId = f.FeeId,
                    Amount = f.Amount,
                    FeeDate = f.FeeDate,
                    PlayerId = f.PlayerId
                })
                .ToListAsync();
        }
        [HttpGet("{id}")] // GET: api/Fee/5
        public ActionResult <FeeDto> GetFee(int id)
        {
            var fee =  _context.Fees.Find(id);
            if (fee == null) return NotFound();
            return new FeeDto
            {
                FeeId = fee.FeeId,
                Amount = fee.Amount,
                FeeDate = fee.FeeDate,
                PlayerId = fee.PlayerId
            };
        }
        [HttpPost] // POST: api/Fee
        public async Task<ActionResult<FeeDto>> CreateFee(CreateFeeDto dto)
        {
            var fee = new Fee
            {
                Amount = dto.Amount,
                FeeDate = dto.FeeDate,
                PlayerId = dto.PlayerId
            };
            _context.Fees.Add(fee);
            await _context.SaveChangesAsync();
            var feeDto = new FeeDto
            {
                FeeId = fee.FeeId,
                Amount = fee.Amount,
                FeeDate = fee.FeeDate,
                PlayerId = fee.PlayerId
            };
            return CreatedAtAction(nameof(GetFee), new { id = fee.FeeId }, feeDto);
        }

        [HttpDelete("{id}")]

       public async Task<IActionResult> DeleteFee(int id)
        {
            var fee = await _context.Fees.FindAsync(id);
            if (fee == null) return NotFound();
            _context.Fees.Remove(fee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
