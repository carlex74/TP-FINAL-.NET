using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEspecialidadRepository
    {

        void Add(Especialidad especialidad);
        void Update(Especialidad especialidad);
        void Delete(Especialidad especialidad);
        Especialidad GetById(int id);
        IEnumerable<Especialidad> GetAll();
        Especialidad GetByName(string name);
    }
}
