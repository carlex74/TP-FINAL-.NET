using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ComisionRepository : IComisionRepository
    {
        private readonly TPIContext _context;

        public ComisionRepository(TPIContext context)
        {
            _context = context;
        }

        public async Task<Comision> GetByIdAsync(int id)
        {
            return await _context.Comisiones
                                 .Include(c => c.Planes)
                                    .ThenInclude(p => p.Especialidad)
                                 .FirstOrDefaultAsync(c => c.Nro == id);
        }

        public async Task<IEnumerable<Comision>> GetAllAsync()
        {
            return await _context.Comisiones
                                 .Include(c => c.Planes)
                                    .ThenInclude(p => p.Especialidad)
                                 .ToListAsync();
        }

        public async Task AddAsync(Comision comision)
        {
            await _context.Comisiones.AddAsync(comision);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comision comision)
        {
            _context.Comisiones.Update(comision);
            await _context.SaveChangesAsync();
        }

        /*
        A FUTURO: Implementación del borrado físico.
        public async Task DeleteAsync(Comision comision)
        {
            _context.Comisiones.Remove(comision);
            await _context.SaveChangesAsync();
        }
        */

        public async Task<Comision> GetByIdWithPlanesAsync(int id)
        {
            return await GetByIdAsync(id);
        }
        public async Task<bool> DescripcionExistsAsync(string descripcion, int? excludeId = null)
        {
            var query = _context.Comisiones.AsQueryable();
            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Nro != excludeId.Value);
            }
            return await query.AnyAsync(c => c.Descripcion.ToLower() == descripcion.ToLower());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            // Esto asegura que no se pueda asignar una comisión borrada a un nuevo curso.
            return await _context.Comisiones.AnyAsync(c => c.Nro == id);
        }
    }
}