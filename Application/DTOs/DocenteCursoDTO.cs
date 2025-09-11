using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Entities.DocenteCurso;

namespace ApplicationClean.DTOs
{
    public class DocenteCursoDTO
    {
        public TipoCargos Cargo { get; private set; }
        public int IdCurso { get; private set; }
        public string LegajoDocente { get; private set; }
    }
}
