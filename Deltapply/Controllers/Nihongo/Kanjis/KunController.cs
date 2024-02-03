using Deltapply.Data;
using Deltapply.Models;
using Deltapply.Models.Nihongo.Kanjis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deltapply.Controllers.Nihongo.Kanjis
{
    [Route("api/nihongo/kanji/kuns")]
    [ApiController]
    public class KunController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public KunController(ApplicationDBContext dbContext) => _dbContext = dbContext;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _dbContext.Kuns
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
        public async Task<IActionResult> Post([FromBody] Kun obj)
        {
            if (ModelState.IsValid)
            {
                bool exists = await _dbContext.Kuns.AnyAsync(item => item.Name == obj.Name && item.KanjiId == obj.KanjiId);

                if (!exists)
                {
                    _dbContext.Kuns.Add(obj);
                    await _dbContext.SaveChangesAsync();
                    return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
                }
                else
                {
                    return BadRequest($"{obj.Name} ya se encuentra registrado");
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kun = await _dbContext.Kuns.FindAsync(id);

            if (kun == null)
            {
                return NotFound();
            }

            _dbContext.Kuns.Remove(kun);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
