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

        public async Task DeleteAsync(AlumnoInscripcion inscripcion)
        {
            _context.Inscripciones.Remove(inscripcion);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AlumnoInscripcion>> GetInscripcionesPorCursoAsync(int idCurso)
        {
            return await _context.Inscripciones
                                 .Where(i => i.IdCurso == idCurso)
                                 .Include(i => i.Alumno) 
                                    .ThenInclude(a => a.Persona)
                                 .ToListAsync();
        }

        public async Task<AlumnoInscripcion> GetWithDetailsByIdAsync(string legajo, int idCurso)
        {
           
     
            return await _context.Inscripciones
                                 .IgnoreQueryFilters() // Desactiva el borrado lógico para esta operación
                                 .Include(i => i.Curso)
                                     .ThenInclude(c => c.Materia) // Incluimos la materia del curso
                                 .Include(i => i.Alumno)
                                     .ThenInclude(a => a.Persona) // Incluimos la persona del alumno
                                 .FirstOrDefaultAsync(i => i.LegajoAlumno == legajo && i.IdCurso == idCurso);
        }

    }
}
