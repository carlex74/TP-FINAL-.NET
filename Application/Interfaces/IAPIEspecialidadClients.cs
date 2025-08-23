using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces
{
        public interface IAPIEspecialidadClients
        {
            Task<EspecialidadDTO> GetById(int id);
            Task<IEnumerable<EspecialidadDTO>> GetAll();

            Task Add(EspecialidadDTO especialidad);

            Task Delete(int id);

            Task Update(EspecialidadDTO especialidad);

        }
}
