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
    public class ResourceController : ControllerBase
    {
        IResourceService _service;

        public ResourceController(IResourceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Resource>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resource = await _service.GetById(id);
            if (resource == null) return NotFound();
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Resource resource)
        {
            if (resource == null) return NotFound();

            if (resource.Measures == null || resource.Emergencies == null)
                return BadRequest("Resource should have registered at least one measure or at least one emergency");

            await _service.Post(resource);

            return CreatedAtAction("Post", resource.Id, resource);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Resource resource)
        {
            if (resource == null) return NotFound();
            if (resource.Id <= 0) return NotFound();            
            
            var exisgingResource = await _service.GetById(resource.Id);
            if (exisgingResource == null) return NotFound();

            await _service.Put(resource);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Resource resource)
        {
            if (resource == null) return NotFound();

            var exisgingResource = await _service.GetById(resource.Id);
            if (exisgingResource == null) return NotFound();

            await _service.Delete(resource);
            return NoContent();
        }
    }
}
