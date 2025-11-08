using escuela.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace escuelaServices.Interfaces
{
    public interface IPadreService
    {
        Task<IEnumerable<Padre>> GetAllAsync();
        Task<Padre> GetByIdAsync(int id);
        Task AddAsync(Padre padre);
        Task UpdateAsync(Padre padre);
        Task DeleteAsync(int id);
    }
}