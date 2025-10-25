using ApplicationClean.Interfaces;
using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly TPIContext _context;

        public PlanRepository(TPIContext context)
        {
            _context = context;
        }

        public async Task<Plan> GetByIdAsync(int id)
        {
            return await _context.Planes
                                 .Include(p => p.Especialidad)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Plan>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Planes
                                 .Where(p => ids.Contains(p.Id))
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Plan>> GetAllAsync()
        {
            return await _context.Planes
                                 .Include(p => p.Especialidad)
                                 .ToListAsync();
        }

        public async Task AddAsync(Plan plan)
        {
            await _context.Planes.AddAsync(plan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Plan plan)
        {
            _context.Planes.Update(plan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Plan plan)
        {
            _context.Planes.Remove(plan);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DescripcionExistsAsync(string descripcion, int? excludeId = null)
        {
            // Se ignora el filtro de borrado logico.
            var query = _context.Planes.IgnoreQueryFilters();

            // Si se proporciona un ID para excluir (caso de 'Update'), lo añadimos a la consulta.
            if (excludeId.HasValue)
            {
                query = query.Where(p => p.Id != excludeId.Value);
            }

              return await query.AnyAsync(p => p.Descripcion.ToLower() == descripcion.ToLower());
        }

    }
}