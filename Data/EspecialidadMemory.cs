using Domain.Model;

namespace Data
{
    public class EspecialidadMemory
    {
        public static List<Especialidad> Especialidades = new List<Especialidad>
        {
            new Especialidad(1, "Cardiología"),
            new Especialidad(2, "Neurología"),
            new Especialidad(3, "Pediatría")
        };

    }
}
