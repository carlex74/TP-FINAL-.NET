using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IAlumnoInscripcionRepository
    {
        Task<AlumnoInscripcion> GetByIdAsync(string legajo,int idCurso);
        Task<IEnumerable<AlumnoInscripcion>> GetAllAsync();
        Task AddAsync(AlumnoInscripcion inscripcion);
        Task UpdateAsync(AlumnoInscripcion inscripcion);
        Task DeleteAsync(AlumnoInscripcion inscripcion);
        Task<IEnumerable<AlumnoInscripcion>> GetInscripcionesPorCursoAsync(int idCurso);
    }
}
