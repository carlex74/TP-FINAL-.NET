using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DocenteCursoRepository : IDocenteCursoRepository
    {
        private readonly TPIContext _context;

        public DocenteCursoRepository(TPIContext context) { _context = context; }


        public async Task<DocenteCurso> GetByIdAsync(int idCurso, string legajo)
        {
            return await _context.DocentesCurso.FindAsync(idCurso, legajo);

        }

        public async Task AddAsync(DocenteCurso docenteCurso)
        {
            await _context.DocentesCurso.AddAsync(docenteCurso);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DocenteCurso docenteCurso)
        {
            _context.DocentesCurso.Update(docenteCurso);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DocenteCurso>> GetAllAsync()
        {
            return await _context.DocentesCurso
                                 .Include(u => u.Curso)
                                 .ToListAsync();
        }

        /*
        A FUTURO: Implementación del borrado físico.
        public async Task DeleteAsync(DocenteCurso docenteCurso)
        {
            _context.DocentesCurso.Remove(docenteCurso);

            await _context.SaveChangesAsync();
        }
        */
    }
}
