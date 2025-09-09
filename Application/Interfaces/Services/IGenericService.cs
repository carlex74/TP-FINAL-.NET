using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationClean.Interfaces.Services
{
    internal interface IGenericService
    {
        // Tipos de datos genericos
        Task<T> AddAsync<T>(T entity);
        Task<T> UpdateAsync<T>(T entity);
        Task<T> DeleteAsync<T>(int id);
        Task<T> GetByIdAsync<T>(int id);
        Task<T> GetAllAsync<T>();
    }
}
