using ApplicationClean.DTOs;

public interface IAPIDocenteCursoClient
{
    Task<IEnumerable<DocenteCursoDTO>> GetAllAsync();

    Task<DocenteCursoDTO> GetByIdAsync(int idCurso, string legajoDocente);

    Task AddAsync(DocenteCursoDTO docenteCurso);

    Task UpdateAsync(DocenteCursoDTO docenteCurso);

    Task DeleteAsync(int idCurso, string legajoDocente);
}