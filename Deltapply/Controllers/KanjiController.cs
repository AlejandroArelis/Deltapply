﻿using Deltapply.Data;
using Deltapply.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deltapply.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KanjiController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public KanjiController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<KanjiController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _dbContext.Kanjis.ToListAsync();
            return Ok(data);
        }

        // GET api/<KanjiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var kanji = await _dbContext.Kanjis.FindAsync(id);

            if (kanji == null)
            {
                return NotFound();
            }

            return Ok(kanji);
        }

        // POST api/<KanjiController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Kanji kanji)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Kanjis.Add(kanji);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = kanji.Id }, kanji);
            }

            return BadRequest(ModelState);
        }

        // PUT api/<KanjiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Kanji updatedKanji)
        {
            if (id != updatedKanji.Id)
            {
                return BadRequest();
            }

            var existingKanji = await _dbContext.Kanjis.FindAsync(id);
            if (existingKanji == null)
            {
                return NotFound();
            }

            _dbContext.Entry(existingKanji).CurrentValues.SetValues(updatedKanji);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Error al actualizar la entidad.");
            }

            return NoContent();
        }

        // DELETE api/<KanjiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kanji = await _dbContext.Kanjis.FindAsync(id);

            if (kanji == null)
            {
                return NotFound();
            }

            _dbContext.Kanjis.Remove(kanji);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // Ejemplo de manejo global de excepciones
        //[Route("error")]
        //public IActionResult Error() => Problem();
    }
}
