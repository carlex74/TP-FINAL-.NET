using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly TPIContext _context;

        public CursoRepository(TPIContext context)
        {
            _context = context;
        }

        public async Task<Curso> GetByIdAsync(int id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task AddAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Curso curso)
        {
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Curso curso)
        {
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
        }
    }
}