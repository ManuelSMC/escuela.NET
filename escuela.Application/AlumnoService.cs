using escuela.Domain;
using Project.Infrastructure.Data;
using Project.Infrastructure.Repositories;
using escuelaServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Data;
using Project.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace escuelaServices
{
    public class AlumnoService : IAlumnoService
    {
        private readonly IRepository<Alumno> _repository;
        private readonly AppDbContext _context;

        public AlumnoService(IRepository<Alumno> repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IEnumerable<Alumno>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Alumno> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(Alumno alumno)
        {
            // Validar que los IDs existan
            if (!await _context.Padres.AnyAsync(p => p.Id == alumno.PadreId))
                throw new ArgumentException("El PadreId proporcionado no existe.");
            if (!await _context.Padres.AnyAsync(p => p.Id == alumno.MadreId))
                throw new ArgumentException("El MadreId proporcionado no existe.");
            if (!await _context.Escuelas.AnyAsync(e => e.Id == alumno.EscuelaId))
                throw new ArgumentException("El EscuelaId proporcionado no existe.");

            _context.Alumnos.Add(alumno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Alumno alumno) => await _repository.UpdateAsync(alumno);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<object>> GetAlumnosWithParentsAndSchoolAsync()
        {
            return await _context.Alumnos
                .Include(a => a.Padre)
                .Include(a => a.Madre)
                .Include(a => a.Escuela)
                .Select(a => new
                {
                    AlumnoNombre = a.Nombre,
                    PapaNombre = a.Padre.Nombre,
                    MamaNombre = a.Madre.Nombre,
                    EscuelaNombre = a.Escuela.Nombre
                })
                .ToListAsync();
        }
    }
}