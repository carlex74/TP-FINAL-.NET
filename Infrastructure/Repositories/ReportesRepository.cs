using Application.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace Infrastructure.Repositories
{
    public class ReportesRepository : IReportesRepository
    {
        private readonly string _connectionString;

        public ReportesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("MySqlConnection");
        }

        public async Task<IEnumerable<RendimientoCursoDto>> GetRendimientoCursoAsync(int cursoId)
        {
            var listaAlumnos = new List<RendimientoCursoDto>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"
                    SELECT i.LegajoAlumno, CONCAT(p.Apellido, ', ', p.Nombre) AS NombreCompleto, i.Condicion, i.Nota
                    FROM Inscripciones i
                    JOIN Usuarios u ON i.LegajoAlumno = u.Legajo
                    JOIN Personas p ON u.IdPersona = p.Id
                    WHERE i.IdCurso = @CursoId
                    ORDER BY p.Apellido, p.Nombre;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CursoId", cursoId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            listaAlumnos.Add(new RendimientoCursoDto
                            {
                                LegajoAlumno = reader["LegajoAlumno"].ToString(),
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                                Condicion = reader["Condicion"].ToString(),
                                Nota = Convert.ToInt32(reader["Nota"])
                            });
                        }
                    }
                }
            }
            return listaAlumnos;
        }

        public async Task<IEnumerable<HistorialAlumnoDto>> GetHistorialAlumnoAsync(string legajo)
        {
            var listaCursadas = new List<HistorialAlumnoDto>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = @"
                    SELECT m.Nombre AS Materia, co.Descripcion AS Comision, c.AnioCalendario AS Anio, i.Condicion, i.Nota
                    FROM Inscripciones i
                    JOIN Cursos c ON i.IdCurso = c.Id
                    JOIN Materias m ON c.IdMateria = m.Id
                    JOIN Comisiones co ON c.IdComision = co.Nro
                    WHERE i.LegajoAlumno = @Legajo
                    ORDER BY c.AnioCalendario, m.Nombre;";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Legajo", legajo);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            listaCursadas.Add(new HistorialAlumnoDto
                            {
                                Materia = reader["Materia"].ToString(),
                                Comision = reader["Comision"].ToString(),
                                Anio = Convert.ToInt32(reader["Anio"]),
                                Condicion = reader["Condicion"].ToString(),
                                Nota = Convert.ToInt32(reader["Nota"])
                            });
                        }
                    }
                }
            }
            return listaCursadas;
        }
    }
}