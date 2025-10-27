using Domain.Entities;
namespace ApplicationClean.Interfaces.Repositories
{
    public interface IPersonaRepository
    {
        Task<Persona> GetByIdAsync(int id);
        Task<IEnumerable<Persona>> GetAllAsync();
        Task AddAsync(Persona persona);
        Task UpdateAsync(Persona persona);
        // A FUTURO: Se puede reactivar el borrado físico o lógico.
        // Task DeleteAsync(Persona persona);
        Task<Persona> GetByEmailAsync(string email);
        Task<Persona> GetByDniAsync(string dni);

        Task<bool> DniExistsAsync(string dni, int? excludeId = null);
        Task<bool> EmailExistsAsync(string email, int? excludeId = null);

        Task<bool> ExistsAsync(int id);
    }
}