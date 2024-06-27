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
    public class EmergencyController : ControllerBase
    {
        IEmergencyService _service;

        public EmergencyController(IEmergencyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Emergency>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emergency = await _service.GetById(id);
            if (emergency == null) return NotFound();
            return Ok(emergency);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Emergency emergency)
        {
            await _service.Post(emergency);
            return CreatedAtAction("Post", emergency.Id, emergency);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Emergency emergency)
        {
            await _service.Put(emergency);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Emergency emergency)
        {
            if (emergency == null) return NotFound();
            await _service.Delete(emergency);
            return NoContent();
        }


    }
}
