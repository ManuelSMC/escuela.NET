using escuela.Domain;
using Project.Infrastructure.Data;
using Project.Infrastructure.Repositories;
using escuelaServices.Interfaces;
using Project.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace escuelaServices
{
    public class PadreService : IPadreService
    {
        private readonly IRepository<Padre> _repository;

        public PadreService(IRepository<Padre> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Padre>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<Padre> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

        public async Task AddAsync(Padre padre) => await _repository.AddAsync(padre);

        public async Task UpdateAsync(Padre padre) => await _repository.UpdateAsync(padre);

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }
}