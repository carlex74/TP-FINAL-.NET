using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly TPIContext _context;

        public MateriaRepository(TPIContext context)
        {
            _context = context;
        }

        public async Task<Materia> GetByIdAsync(int id)
        {
            return await _context.Materias.FindAsync(id);
        }

        public async Task<IEnumerable<Materia>> GetAllAsync()
        {
            return await _context.Materias
                                 .Include(m => m.Planes)
                                 .ToListAsync();
        }

        public async Task AddAsync(Materia materia)
        {
            await _context.Materias.AddAsync(materia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Materia materia)
        {
            _context.Materias.Update(materia);
            await _context.SaveChangesAsync();
        }

        /*
        A FUTURO: Implementación del borrado físico.
        public async Task DeleteAsync(Materia materia)
        {
            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();
        }
        */

        public async Task<Materia> GetByIdWithPlanesAsync(int id)
        {
            return await _context.Materias
                                 .Include(m => m.Planes)
                                    .ThenInclude(p => p.Especialidad)
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<bool> NombreExistsAsync(string nombre, int? excludeId = null)
        {
            var query = _context.Materias.AsQueryable();
            if (excludeId.HasValue)
            {
                query = query.Where(m => m.Id != excludeId.Value);
            }
            return await query.AnyAsync(m => m.Nombre.ToLower() == nombre.ToLower());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            // Esto asegura que no se pueda asignar una materia borrada a un nuevo curso.
            return await _context.Materias.AnyAsync(m => m.Id == id);
        }
    }
}