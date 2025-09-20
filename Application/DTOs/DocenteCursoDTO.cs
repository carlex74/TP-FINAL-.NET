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
        public TipoCargos Cargo { get; set; }
        public int IdCurso { get; set; }
        public string LegajoDocente { get; set; }
    }
}
