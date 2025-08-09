using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
   public interface IEspecialidadService
    {
        EspecialidadDTO Add(EspecialidadDTO especialidadDTO);
        EspecialidadDTO Update(EspecialidadDTO especialidadDTO);

        bool Delete(int id);
        EspecialidadDTO GetById(int id);
        IEnumerable<EspecialidadDTO> GetAll();
    }
}
