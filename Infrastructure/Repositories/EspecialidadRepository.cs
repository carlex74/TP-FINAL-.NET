using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EspecialidadRepository : IEspecialidadRepository
    {
        private readonly TPIContext _context;

        public EspecialidadRepository(TPIContext context)
        {
            _context = context;
        }

        public async Task<Especialidad> GetByIdAsync(int id)
        {
            return await _context.Especialidades.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Especialidad>> GetAllAsync()
        {
            return await _context.Especialidades.ToListAsync();
        }

        public async Task AddAsync(Especialidad especialidad)
        {
            await _context.Especialidades.AddAsync(especialidad);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Especialidad especialidad)
        {
            _context.Especialidades.Update(especialidad);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Especialidad especialidad)
        {
            _context.Especialidades.Remove(especialidad);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DescripcionExistsAsync(string descripcion, int? excludeId = null)
        {
            var query = _context.Especialidades.IgnoreQueryFilters(); // Ignora el filtro
            if (excludeId.HasValue)
            {
                query = query.Where(e => e.Id != excludeId.Value);
            }

            return await query.AnyAsync(e => e.Descripcion.ToLower() == descripcion.ToLower());
        }

        public async Task<bool> ExistsAsync(int id)
        {

            return await _context.Especialidades.AnyAsync(e => e.Id == id);
        }
    }
}