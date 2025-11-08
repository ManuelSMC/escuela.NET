using escuela.Domain;
using Project.Infrastructure.Data;
using Project.Infrastructure.Repositories;
using escuelaServices.Interfaces;
using Project.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace escuelaServices
{
    public class EscuelaService : IEscuelaService
    {
        private readonly IRepository<Escuela> _repository;

        public EscuelaService(IRepository<Escuela> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Escuela>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Escuela> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(Escuela escuela) => await _repository.AddAsync(escuela);

        public async Task UpdateAsync(Escuela escuela) => await _repository.UpdateAsync(escuela);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}