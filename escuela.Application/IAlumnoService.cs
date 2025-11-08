using escuela.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace escuelaServices.Interfaces
{
    public interface IAlumnoService
    {
        Task<IEnumerable<Alumno>> GetAllAsync();
        Task<Alumno> GetByIdAsync(int id);
        Task AddAsync(Alumno alumno);
        Task UpdateAsync(Alumno alumno);
        Task DeleteAsync(int id);

        Task<IEnumerable<object>> GetAlumnosWithParentsAndSchoolAsync();
    }
}