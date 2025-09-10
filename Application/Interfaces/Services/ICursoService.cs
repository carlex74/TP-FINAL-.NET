using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
    public interface ICursoService
    {
        Task<CursoDTO> AddAsync(CursoDTO cursoDTO);
        Task<CursoDTO> UpdateAsync(CursoDTO cursoDTO);
        Task<bool> DeleteAsync(int id);
        Task<CursoDTO> GetByIdAsync(int id);
        Task<IEnumerable<CursoDTO>> GetAllAsync();
    }
}
