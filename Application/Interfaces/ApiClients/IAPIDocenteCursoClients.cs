using ApplicationClean.DTOs;

public interface IAPIDocenteCursoClient
{
    Task<IEnumerable<DocenteCursoDTO>> GetAllAsync();

    Task<DocenteCursoDTO> GetByIdAsync(int idCurso, string legajoDocente);

    Task AddAsync(DocenteCursoDTO docenteCurso);

    Task UpdateAsync(DocenteCursoDTO docenteCurso);

    // A FUTURO: Se puede reactivar la llamada al endpoint de borrado.
    //Task DeleteAsync(int idCurso, string legajoDocente);
}