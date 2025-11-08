using escuela.Domain;
using escuelaServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace escuelaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoService _service;

        public AlumnoController(IAlumnoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Alumno>> Get() => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> Get(int id)
        {
            var alumno = await _service.GetByIdAsync(id);
            if (alumno == null) return NotFound();
            return alumno;
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AlumnoCreate alumnoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alumno = new Alumno
            {
                Nombre = alumnoDto.Nombre,
                PadreId = alumnoDto.PadreId,
                MadreId = alumnoDto.MadreId,
                EscuelaId = alumnoDto.EscuelaId
            };

            await _service.AddAsync(alumno);
            return CreatedAtAction(nameof(Get), new { id = alumno.Id }, alumno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id) return BadRequest();
            await _service.UpdateAsync(alumno);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("listado")]
        public async Task<IEnumerable<object>> GetListado() => await _service.GetAlumnosWithParentsAndSchoolAsync();
    }
}