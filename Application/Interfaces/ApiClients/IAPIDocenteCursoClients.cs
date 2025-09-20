using ApplicationClean.DTOs;


public interface IAPIDocenteCursoClient
{
    /// <summary>
    /// Obtiene todas las asignaciones de docentes a cursos.
    /// </summary>
    Task<IEnumerable<DocenteCursoDTO>> GetAllAsync();

    /// <summary>
    /// Obtiene una asignación específica por el ID del curso y el legajo del docente.
    /// </summary>
    Task<DocenteCursoDTO> GetByIdAsync(int idCurso, string legajoDocente);

    /// <summary>
    /// Crea una nueva asignación de un docente a un curso.
    /// </summary>
    Task AddAsync(DocenteCursoDTO docenteCurso);

    /// <summary>
    /// Actualiza una asignación existente.
    /// </summary>
    Task UpdateAsync(DocenteCursoDTO docenteCurso);

    /// <summary>
    /// Elimina una asignación por su clave compuesta.
    /// </summary>
    Task DeleteAsync(int idCurso, string legajoDocente);
}