using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace ApplicationClean.Interfaces.Repositories
{
    internal interface ICursoRepository
    {
        Task AddAsync(Curso curso);
        Task UpdateAsync(Curso curso);
        Task DeleteAsync(Curso curso);

        Task<Curso> GetByIdAsync(int id);
        Task<IEnumerable<Curso>> GetAllAsync();
    }
}
