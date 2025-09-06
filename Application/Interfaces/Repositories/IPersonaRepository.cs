using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IPersonaRepository
    {
        Task<Persona> GetByIdAsync(int id);
        Task<IEnumerable<Persona>> GetAllAsync();
        Task AddAsync(Persona persona);
        Task UpdateAsync(Persona persona);
        Task DeleteAsync(Persona persona);
        Task<Persona> GetByEmailAsync(string email);
        Task<Persona> GetByDniAsync(string dni);
    }
}