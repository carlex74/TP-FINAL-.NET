using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class PortalDocente : Form
    {
        private readonly IAPIDocenteCursoClient _docenteCursoClient;
        private readonly IAPICursoClient _cursoClient;
        private readonly IAPIMateriaClient _materiaClient;
        private readonly IAPIComisionClient _comisionClient;
        private readonly IAlumnoInscripcionClients _inscripcionClient;
        private readonly IAPIUsuarioClients _usuarioClient;
        private readonly UsuarioDTO _docenteActual;

        private bool _isLoadingAlumnos = false;

        public PortalDocente(
            IAPIDocenteCursoClient docenteCursoClient,
            IAPICursoClient cursoClient,
            IAPIMateriaClient materiaClient,
            IAPIComisionClient comisionClient,
            IAlumnoInscripcionClients inscripcionClient,
            IAPIUsuarioClients usuarioClient)
        {
            InitializeComponent();
            _docenteCursoClient = docenteCursoClient;
            _cursoClient = cursoClient;
            _materiaClient = materiaClient;
            _comisionClient = comisionClient;
            _inscripcionClient = inscripcionClient;
            _usuarioClient = usuarioClient;
            _docenteActual = UserSession.GetCurrentUser();
        }

        private async void PortalDocente_Load(object sender, EventArgs e)
        {
            if (_docenteActual == null)
            {
                MessageBox.Show("No se pudo recuperar la sesión del docente.", "Error de Sesión");
                this.Close();
                return;
            }

            lblBienvenida.Text = $"Bienvenido, {_docenteActual.PersonaNombreCompleto} (Legajo: {_docenteActual.Legajo})";
            await CargarMisCursosAsync();
        }

        private async Task CargarMisCursosAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var todasLasAsignaciones = (await _docenteCursoClient.GetAllAsync()).ToList();
                var misAsignaciones = todasLasAsignaciones.Where(a => a.LegajoDocente == _docenteActual.Legajo).ToList();
                var todosLosCursos = (await _cursoClient.GetAll()).ToList();
                var todasLasMaterias = (await _materiaClient.GetAll()).ToList();
                var todasLasComisiones = (await _comisionClient.GetAll()).ToList();

                var cursosParaMostrar = from asig in misAsignaciones
                                        join curso in todosLosCursos on asig.IdCurso equals curso.Id
                                        join materia in todasLasMaterias on curso.IdMateria equals materia.Id
                                        join comision in todasLasComisiones on curso.IdComision equals comision.Nro
                                        select new
                                        {
                                            IdCurso = curso.Id,
                                            Materia = materia.Nombre,
                                            Comision = comision.Descripcion,
                                            Año = curso.AnioCalendario,
                                            Cargo = asig.Cargo.ToString()
                                        };

                dgvMisCursos.DataSource = cursosParaMostrar.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar sus cursos: {ex.Message}", "Error de Conexión");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void dgvMisCursos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMisCursos.SelectedRows.Count == 0 || _isLoadingAlumnos)
            {
                return;
            }

            _isLoadingAlumnos = true;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                dynamic selectedCourse = dgvMisCursos.SelectedRows[0].DataBoundItem;
                int idCurso = selectedCourse.IdCurso;
                await CargarAlumnosDelCursoAsync(idCurso);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los alumnos del curso: {ex.Message}", "Error");
                dgvAlumnosInscriptos.DataSource = null;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                _isLoadingAlumnos = false;
            }
        }

        private async Task CargarAlumnosDelCursoAsync(int idCurso)
        {
            var todasLasInscripciones = (await _inscripcionClient.GetAll()).ToList();
            var inscripcionesDelCurso = todasLasInscripciones.Where(i => i.IdCurso == idCurso).ToList();

            if (!inscripcionesDelCurso.Any())
            {
                dgvAlumnosInscriptos.DataSource = null;
                btnGuardarCambios.Enabled = false;
                return;
            }

            var todosLosUsuarios = (await _usuarioClient.GetAll()).ToList();

            var alumnosParaMostrar = from insc in inscripcionesDelCurso
                                     join usuario in todosLosUsuarios on insc.LegajoAlumno equals usuario.Legajo
                                     select new AlumnoInscripcionViewModel
                                     {
                                         LegajoAlumno = insc.LegajoAlumno,
                                         NombreCompleto = usuario.PersonaNombreCompleto,
                                         Condicion = insc.Condicion,
                                         Nota = insc.Nota
                                     };

            dgvAlumnosInscriptos.DataSource = alumnosParaMostrar.ToList();
            btnGuardarCambios.Enabled = true;
        }

        private async void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (dgvAlumnosInscriptos.Rows.Count == 0 || dgvMisCursos.SelectedRows.Count == 0) return;

            this.dgvAlumnosInscriptos.EndEdit();

            this.Cursor = Cursors.WaitCursor;
            btnGuardarCambios.Enabled = false;

            try
            {
                dynamic selectedCourse = dgvMisCursos.SelectedRows[0].DataBoundItem;
                int idCurso = selectedCourse.IdCurso;

                int cambiosRealizados = 0;
                var tareasDeActualizacion = new List<Task>();

                var listaAlumnos = (List<AlumnoInscripcionViewModel>)dgvAlumnosInscriptos.DataSource;

                foreach (var alumno in listaAlumnos)
                {
                    if (alumno.Nota < 0 || alumno.Nota > 10)
                    {
                        MessageBox.Show($"La nota '{alumno.Nota}' para el alumno con legajo '{alumno.LegajoAlumno}' no es válida. Debe estar entre 0 y 10.", "Error de Validación");
                        return;
                    }

                    var dto = new AlumnoInscripcionDTO
                    {
                        LegajoAlumno = alumno.LegajoAlumno,
                        IdCurso = idCurso,
                        Condicion = alumno.Condicion,
                        Nota = alumno.Nota
                    };

                    tareasDeActualizacion.Add(_inscripcionClient.Update(dto));
                    cambiosRealizados++;
                }

                await Task.WhenAll(tareasDeActualizacion);

                MessageBox.Show($"{cambiosRealizados} registros de alumnos actualizados correctamente.", "Éxito");
                await CargarAlumnosDelCursoAsync(idCurso);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, asegúrese de que todas las notas ingresadas sean números válidos.", "Error de Formato");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los cambios: {ex.Message}", "Error");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnGuardarCambios.Enabled = true;
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}