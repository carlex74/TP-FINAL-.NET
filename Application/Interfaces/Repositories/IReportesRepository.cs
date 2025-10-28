namespace Application.Interfaces.Repositories
{
    public class RendimientoCursoDto
    {
        public string LegajoAlumno { get; set; }
        public string NombreCompleto { get; set; }
        public string Condicion { get; set; }
        public int Nota { get; set; }
    }

    public class HistorialAlumnoDto
    {
        public string Materia { get; set; }
        public string Comision { get; set; }
        public int Anio { get; set; }
        public string Condicion { get; set; }
        public int Nota { get; set; }
    }

    public interface IReportesRepository
    {
        Task<IEnumerable<RendimientoCursoDto>> GetRendimientoCursoAsync(int cursoId);
        Task<IEnumerable<HistorialAlumnoDto>> GetHistorialAlumnoAsync(string legajo);
    }
}