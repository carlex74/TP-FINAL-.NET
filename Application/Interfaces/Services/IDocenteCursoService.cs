using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
    public interface IDocenteCursoService
    {
        Task<DocenteCursoDTO> AddAsync(DocenteCursoDTO docenteCursoDTO);
        Task<DocenteCursoDTO> UpdateAsync(DocenteCursoDTO docenteCursoDTO);
        Task<DocenteCursoDTO> GetByIdAsync(int idCurso,string legajoDocente);
        Task<IEnumerable<DocenteCursoDTO>> GetAllAsync();
        Task DeleteAsync(int idCurso, string legajoDocente);
    }
}
