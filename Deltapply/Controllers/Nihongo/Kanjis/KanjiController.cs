﻿using Deltapply.DTO.Nihongo.Kanjis;
using Deltapply.Models.Nihongo.Kanjis;
using Microsoft.AspNetCore.Mvc;
using Deltapply.Services.Nihongo;

namespace Deltapply.Controllers.Nihongo.Kanjis
{
    [Route("api/nihongo/[controller]")]
    [ApiController]
    public class KanjiController : ControllerBase
    {
        private readonly KanjiService _kanjiService;

        public KanjiController(KanjiService kanjiService)
        {
            _kanjiService = kanjiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _kanjiService.GetAll();

            if (response.Count == 0)
                return NoContent();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _kanjiService.GetById(id);

            if(response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(KanjiDTO objectDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _kanjiService.Post(objectDTO);

                if (response == null)
                    return BadRequest($"El kanji {objectDTO.Text} ya existe");

                //var uri = new Uri($"{Request.Scheme}://{Request.Host}:{{Port}}/knjis/{response.Id}"); // Falta mostrar el puerto
                //return Created(uri, response);
                return Ok(response.Id);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Kanji objectDTO)
        {
            if (ModelState.IsValid)
            {
                var response = await _kanjiService.Put(objectDTO);

                if (response == null)
                    return NotFound();
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _kanjiService.Delete(id);

            if (!response)
                return NotFound();

            return NoContent();
        }
    }
}
