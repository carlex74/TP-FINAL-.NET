using Infrastructure.ViewModels;

namespace Infrastructure.Reportes
{
    public class HistorialAcademicoDataSource
    {
        public string NombreCompletoAlumno { get; set; }
        public string Legajo { get; set; }
        public string PromedioGeneral { get; set; }
        public List<HistorialCursadaViewModel> Cursadas { get; set; }
    }
}