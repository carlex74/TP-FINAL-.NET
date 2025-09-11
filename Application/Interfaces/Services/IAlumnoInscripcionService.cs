using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
    public interface IAlumnoInscripcionService
    {
        Task<AlumnoInscripcionDTO> AddAsync(AlumnoInscripcionDTO inscripcion);
        Task<AlumnoInscripcionDTO> UpdateAsync(AlumnoInscripcionDTO inscripcion);
        Task<AlumnoInscripcionDTO> GetByIdAsync(string legajo, int idCurso);
        Task<IEnumerable<AlumnoInscripcionDTO>> GetAllAsync();
    }
}
