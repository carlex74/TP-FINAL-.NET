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
