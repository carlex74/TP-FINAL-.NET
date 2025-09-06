using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.Services
{
   public interface IEspecialidadService
    {
        Task<EspecialidadDTO> AddAsync(EspecialidadDTO especialidadDTO);

        Task<EspecialidadDTO> UpdateAsync(EspecialidadDTO especialidadDTO);

        Task<bool> DeleteAsync(int id);

        Task<EspecialidadDTO> GetByIdAsync(int id);

        Task<IEnumerable<EspecialidadDTO>> GetAllAsync();
    }
}
