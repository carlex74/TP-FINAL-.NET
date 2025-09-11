using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAlumnoInscripcionClients
    {
        Task<AlumnoInscripcionDTO> GetById(string legajo, int idCurso);
        Task<IEnumerable<AlumnoInscripcionDTO>> GetAll();

        Task Add(AlumnoInscripcionDTO inscripcion);

        Task Update(AlumnoInscripcionDTO inscripcion);
    }
}
