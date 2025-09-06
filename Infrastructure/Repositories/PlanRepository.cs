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
    }
}