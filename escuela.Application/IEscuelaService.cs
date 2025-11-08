using escuela.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace escuelaServices.Interfaces
{
    public interface IEscuelaService
    {
        Task<IEnumerable<Escuela>> GetAllAsync();
        Task<Escuela> GetByIdAsync(int id);
        Task AddAsync(Escuela escuela);
        Task UpdateAsync(Escuela escuela);
        Task DeleteAsync(int id);
    }
}