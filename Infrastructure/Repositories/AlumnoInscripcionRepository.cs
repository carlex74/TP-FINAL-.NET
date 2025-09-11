using ApplicationClean.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AlumnoInscripcionRepository:IAlumnoInscripcionRepository
    {
        private readonly TPIContext _context;

        public AlumnoInscripcionRepository(TPIContext context) { _context = context; }


        public async Task<AlumnoInscripcion> GetByIdAsync(string legajo, int idCurso)
        {
            return await _context.Inscripciones.FindAsync(idCurso, legajo);

        }

        public async Task AddAsync(AlumnoInscripcion inscripcion)
        {
            await _context.Inscripciones.AddAsync(inscripcion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AlumnoInscripcion inscripcion)
        {
            _context.Inscripciones.Update(inscripcion);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AlumnoInscripcion>> GetAllAsync()
        {
            return await _context.Inscripciones
                                 .Include(u => u.Curso)
                                 .ToListAsync();
        }


    }
}
