using escuela.Domain;
using escuelaServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace escuelaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscuelaController : ControllerBase
    {
        private readonly IEscuelaService _service;

        public EscuelaController(IEscuelaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Escuela>> Get() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Escuela>> Get(int id)
        {
            var escuela = await _service.GetByIdAsync(id);
            if (escuela == null) return NotFound();
            return escuela;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Escuela escuela)
        {
            await _service.AddAsync(escuela);
            return CreatedAtAction(nameof(Get), new { id = escuela.Id }, escuela);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Escuela escuela)
        {
            if (id != escuela.Id) return BadRequest();
            await _service.UpdateAsync(escuela);
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