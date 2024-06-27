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
    public class SignalController : ControllerBase
    {
        ISignalService _service;

        public SignalController(ISignalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Signal>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var signal = await _service.GetById(id);
            if (signal == null) return NotFound();
            return Ok(signal);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Signal signal)
        {
            await _service.Post(signal);
            return CreatedAtAction("Post", signal.Id, signal);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Signal signal)
        {
            await _service.Put(signal);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Signal signal)
        {
            if (signal == null) return NotFound();
            await _service.Delete(signal);
            return NoContent();
        }
    }
}
