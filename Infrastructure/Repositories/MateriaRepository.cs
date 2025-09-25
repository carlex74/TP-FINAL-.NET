using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task DeleteAsync(Materia materia)
        {
            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();
        }

        public async Task<Materia> GetByIdWithPlanesAsync(int id)
        {
            return await _context.Materias
                                 .Include(m => m.Planes)
                                    .ThenInclude(p => p.Especialidad)
                                 .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}