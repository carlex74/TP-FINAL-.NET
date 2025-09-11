namespace ApplicationClean.DTOs
{
    public class PlanDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdEspecialidad { get; set; }

        public string EspecialidadDescripcion { get; set; }
        public string DescripcionCompleta => $"{Descripcion} ({EspecialidadDescripcion})";
    }
}
