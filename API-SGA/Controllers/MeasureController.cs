using API_SGA.Data;
using API_SGA.Models;
using API_SGA.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_SGA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasureController : ControllerBase
    {
        IMeasureService _service;

        public MeasureController(IMeasureService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Measure>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var measure = await _service.GetById(id);
            if (measure == null) return NotFound();
            return Ok(measure);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Measure measure)
        {
            await _service.Post(measure);
            return CreatedAtAction("Post", measure.Id, measure);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Measure measure)
        {
            await _service.Put(measure);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Measure measure)
        {
            if (measure == null) return NotFound();
            await _service.Delete(measure);
            return NoContent();
        }
    }
}
