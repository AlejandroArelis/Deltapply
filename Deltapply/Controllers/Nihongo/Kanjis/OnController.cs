using Deltapply.DTO.Nihongo.Kanjis;
using Deltapply.Models.Nihongo.Kanjis;
using Deltapply.Services.Nihongo;
using Microsoft.AspNetCore.Mvc;

namespace Deltapply.Controllers.Nihongo.Kanjis
{
    [Route("api/nihongo/[controller]")]
    [ApiController]
    public class OnController : ControllerBase
    {
        private readonly OnService _service;

        public OnController(OnService service) => _service = service;

        [HttpGet("kanji/{parentId}")]
        public async Task<IActionResult> GetAll(int parentId)
        {
            var response = await _service.GetAll(parentId);

            if (response.Count == 0)
                return NoContent();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetById(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OnDTO obj)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.Post(obj);

                if (response == null)
                    return BadRequest($"La llectura on'yomi {obj.Text} ya existe");
                return Ok(response.Id);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put(On obj)
        {
            if (ModelState.IsValid)
            {
                var response = await _service.Put(obj);

                if (response == null)
                    return NotFound();
                return Ok(response);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.Delete(id);

            if (!response)
                return NotFound();

            return NoContent();
        }
    }
}
