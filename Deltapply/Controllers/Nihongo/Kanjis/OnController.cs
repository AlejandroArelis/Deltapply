using Deltapply.Data;
using Deltapply.Models;
using Deltapply.Models.Nihongo.Kanjis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Deltapply.Controllers.Nihongo.Kanjis
{
    [Route("api/nihongo/kanji/ons")]
    [ApiController]
    public class OnController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public OnController(ApplicationDBContext dbContext) => _dbContext = dbContext;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _dbContext.Ons
                    .Where(obj => obj.KanjiId == id)
                    .ToListAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] On obj)
        {
            if (ModelState.IsValid)
            {
                bool exists = await _dbContext.Ons.AnyAsync(item => item.Name == obj.Name && item.KanjiId == obj.KanjiId);

                if(!exists)
                {
                    _dbContext.Ons.Add(obj);
                    await _dbContext.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
                } else
                {
                    return BadRequest($"{obj.Name} ya se encuentra registrado");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = await _dbContext.Ons.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.Ons.Remove(obj);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
