using Deltapply.Data;
using Deltapply.Models.Nihongo.Kanjis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Deltapply.Controllers.Nihongo.Kanjis
{
    [Route("api/nihongo/kanji/names")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public NameController(ApplicationDBContext dbContext) => _dbContext = dbContext;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var data = await _dbContext.Names
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
                bool exists = await _dbContext.Names.AnyAsync(item => item.Name == obj.Name && item.KanjiId == obj.KanjiId);

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
            var obj = await _dbContext.Names.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.Names.Remove(obj);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
