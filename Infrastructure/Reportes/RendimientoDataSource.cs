using Infrastructure.ViewModels;
using System.Collections.Generic;

namespace Infrastructure.Reportes
{
    public class RendimientoDataSource
    {
        public string NombreCurso { get; set; }

        public List<AlumnoInscripcionViewModel> Alumnos { get; set; }

        public byte[] GraficoBytes { get; set; }
    }
}