using Infrastructure.ViewModels;

namespace Infrastructure.Reportes
{
    public class RendimientoDataSource
    {
        public string NombreCurso { get; set; }

        public List<AlumnoInscripcionViewModel> Alumnos { get; set; }

        public byte[] GraficoBytes { get; set; }
    }
}