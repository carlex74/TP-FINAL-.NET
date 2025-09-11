using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    internal interface IAPIDocenteCursoClients
    {
        Task<DocenteCursoDTO> GetById(int idCurso, string legajoDocente);
        Task<IEnumerable<DocenteCursoDTO>> GetAll();

        Task Add(DocenteCursoDTO docenteCurso);

        Task Update(DocenteCursoDTO docenteCurso);

    }
}
