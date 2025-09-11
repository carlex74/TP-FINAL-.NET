using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationClean.DTOs;
using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    public interface IMateriaRepository
    {
        Task<Materia> GetByIdAsync(int id);
        Task<IEnumerable<Materia>> GetAllAsync();
        Task AddAsync(Materia materia);
        Task UpdateAsync(Materia materia);
        Task DeleteAsync(Materia materia);
        Task<Materia> GetByIdWithPlanesAsync(int id);
    }
}
