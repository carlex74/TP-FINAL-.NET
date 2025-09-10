using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
    public interface IMateriaService
    {
        Task<MateriaDTO> GetByIdAsync(int id);
        Task<IEnumerable<MateriaDTO>> GetAllAsync();
        Task<MateriaDTO> AddAsync(MateriaDTO materiaDto);
        Task<MateriaDTO> UpdateAsync(MateriaDTO materiaDto);
        Task<bool> DeleteAsync(int id);
    }
}
