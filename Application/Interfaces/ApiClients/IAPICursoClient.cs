using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPICursoClient
    {
        Task<CursoDTO> GetById(int id);
        Task<IEnumerable<CursoDTO>> GetAll();

        Task Add(CursoDTO curso);

        Task Delete(int id);

        Task Update(CursoDTO curso);
    }
}
