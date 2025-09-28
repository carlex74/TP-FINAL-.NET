using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationClean.DTOs;

namespace ApplicationClean.Interfaces.ApiClients
{
    public interface IAPIPlanClients
    {
        Task<PlanDTO> GetById(int id);
        Task<IEnumerable<PlanDTO>> GetAll();
        Task Add(CrearPlanDTO plan);
        Task Delete(int id);
        Task Update(PlanDTO plan);
    }
}
