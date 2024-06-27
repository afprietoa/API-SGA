using API_SGA.Data;
using API_SGA.Models;
using API_SGA.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_SGA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollutantController : ControllerBase
    {
        IPollutantService _service;

        public PollutantController(IPollutantService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Pollutant>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pollutant = await _service.GetById(id);
            if (pollutant == null) return NotFound();
            return Ok(pollutant);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pollutant pollutant)
        {
            if (pollutant == null) return NotFound();

            if (pollutant.Measures == null || pollutant.Emergencies == null)
                return BadRequest("Pollutant should have registered at least one measure or at least one emergency");

            await _service.Post(pollutant);

            return CreatedAtAction("Post", pollutant.Id, pollutant);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Pollutant pollutant)
        {
            if (pollutant == null) return NotFound();
            if (pollutant.Id <= 0) return NotFound();

            var exisgingPollutant = await _service.GetById(pollutant.Id);
            if (exisgingPollutant == null) return NotFound();

            await _service.Put(pollutant);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Pollutant pollutant)
        {
            if (pollutant == null) return NotFound();

            var exisgingPollutant = await _service.GetById(pollutant.Id);
            if (exisgingPollutant == null) return NotFound();

            await _service.Delete(pollutant);
            return NoContent();
        }
    }
}
