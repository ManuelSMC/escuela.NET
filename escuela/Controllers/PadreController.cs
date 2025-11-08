using escuela.Domain;
using escuelaServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace escuelaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PadreController : ControllerBase
    {
        private readonly IPadreService _service;

        public PadreController(IPadreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Padre>> Get() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Padre>> Get(int id)
        {
            var padre = await _service.GetByIdAsync(id);
            if (padre == null) return NotFound();
            return padre;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Padre padre)
        {
            await _service.AddAsync(padre);
            return CreatedAtAction(nameof(Get), new { id = padre.Id }, padre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Padre padre)
        {
            if (id != padre.Id) return BadRequest();
            await _service.UpdateAsync(padre);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}