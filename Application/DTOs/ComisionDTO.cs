namespace ApplicationClean.DTOs
{
    public class ComisionDTO
    {
        public int Nro { get; set; }
        public int AnioEspecialidad { get; set; }
        public string Descripcion { get; set; }
        public List<PlanDTO> Planes { get; set; } = new List<PlanDTO>();
    }
}
