using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return await _context.Comisiones.FindAsync(id);
        }

        public async Task<IEnumerable<Comision>> GetAllAsync()
        {
            return await _context.Comisiones.ToListAsync();
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

        public async Task DeleteAsync(Comision comision)
        {
            _context.Comisiones.Remove(comision);
            await _context.SaveChangesAsync();
        }
    }
}