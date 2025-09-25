using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.Vistas.Alumno
{
    public partial class PortalAlumno : Form
    {
        private readonly IAPICursoClient _cursoClient;
        private readonly IAPIMateriaClient _materiaClient;
        private readonly IAPIComisionClient _comisionClient;
        private readonly IAlumnoInscripcionClients _inscripcionClient;
        private readonly UsuarioDTO _alumnoActual;

        private List<CursoDTO> _todosLosCursos;
        private List<MateriaDTO> _todasLasMaterias;
        private List<ComisionDTO> _todasLasComisiones;
        private List<AlumnoInscripcionDTO> _misInscripciones;

        public PortalAlumno(IAPICursoClient cursoClient, IAlumnoInscripcionClients inscripcionClient, IAPIMateriaClient materiaClient, IAPIComisionClient comisionClient)
        {
            InitializeComponent();
            _cursoClient = cursoClient;
            _inscripcionClient = inscripcionClient;
            _materiaClient = materiaClient;
            _comisionClient = comisionClient;
            _alumnoActual = UserSession.GetCurrentUser();
        }

        private async void PortalAlumno_Load(object sender, EventArgs e)
        {
            if (_alumnoActual == null || _alumnoActual.IdPlan == null)
            {
                MessageBox.Show("No se pudo recuperar la sesión del alumno o el alumno no tiene un plan asignado.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblBienvenida.Text = $"Bienvenido, {_alumnoActual.PersonaNombreCompleto} (Legajo: {_alumnoActual.Legajo})";
            await CargarDatos();
        }

        private async Task CargarDatos()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnInscribirse.Enabled = false;
                btnAnular.Enabled = false;

                _todosLosCursos = (await _cursoClient.GetAll()).ToList();
                _todasLasMaterias = (await _materiaClient.GetAll()).ToList();
                _todasLasComisiones = (await _comisionClient.GetAll()).ToList();
                var todasLasInscripciones = (await _inscripcionClient.GetAll()).ToList();

                _misInscripciones = todasLasInscripciones
                    .Where(i => i.LegajoAlumno == _alumnoActual.Legajo)
                    .ToList();

                var idsCursosInscripto = _misInscripciones.Select(i => i.IdCurso).ToHashSet();

                var materiasDelPlan = _todasLasMaterias.Where(m => m.Planes.Any(p => p.Id == _alumnoActual.IdPlan)).ToList();

                var materiasDisponibles = materiasDelPlan
                    .Where(materia => _todosLosCursos.Any(curso => curso.IdMateria == materia.Id && !idsCursosInscripto.Contains(curso.Id)))
                    .ToList();

                materiasDisponiblesListBox.DataSource = materiasDisponibles;
                materiasDisponiblesListBox.DisplayMember = "Nombre";
                materiasDisponiblesListBox.ValueMember = "Id";

                var inscripcionesParaMostrar = from insc in _misInscripciones
                                               join curso in _todosLosCursos on insc.IdCurso equals curso.Id
                                               join materia in _todasLasMaterias on curso.IdMateria equals materia.Id
                                               join comision in _todasLasComisiones on curso.IdComision equals comision.Nro
                                               select new
                                               {
                                                   CursoId = curso.Id,
                                                   Materia = materia.Nombre,
                                                   Comision = comision.Descripcion,
                                                   Condicion = insc.Condicion,
                                                   Nota = insc.Nota
                                               };

                misInscripcionesDataGridView.DataSource = inscripcionesParaMostrar.ToList();

                comisionesListBox.DataSource = null;
                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fatal al cargar los datos: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void materiasDisponiblesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materiasDisponiblesListBox.SelectedItem is MateriaDTO materiaSeleccionada)
            {
                var idsCursosInscripto = _misInscripciones.Select(i => i.IdCurso).ToHashSet();

                var cursosDisponiblesParaMateria = from curso in _todosLosCursos
                                                   where curso.IdMateria == materiaSeleccionada.Id && !idsCursosInscripto.Contains(curso.Id)
                                                   join comision in _todasLasComisiones on curso.IdComision equals comision.Nro
                                                   select new
                                                   {
                                                       IdCurso = curso.Id,
                                                       DescripcionComision = comision.Descripcion
                                                   };

                comisionesListBox.DataSource = cursosDisponiblesParaMateria.ToList();
                comisionesListBox.DisplayMember = "DescripcionComision";
                comisionesListBox.ValueMember = "IdCurso";
            }
            else
            {
                comisionesListBox.DataSource = null;
            }
            UpdateButtonsState();
        }

        private async void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (comisionesListBox.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione una comisión para inscribirse.", "Selección requerida");
                return;
            }

            var idCursoSeleccionado = (int)comisionesListBox.SelectedValue;
            var curso = _todosLosCursos.First(c => c.Id == idCursoSeleccionado);
            var materia = _todasLasMaterias.First(m => m.Id == curso.IdMateria);

            var confirmacion = MessageBox.Show($"¿Confirma la inscripción a la materia '{materia.Nombre}' en la comisión '{comisionesListBox.Text}'?", "Confirmar Inscripción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    var nuevaInscripcion = new AlumnoInscripcionDTO
                    {
                        LegajoAlumno = _alumnoActual.Legajo,
                        IdCurso = idCursoSeleccionado,
                        Condicion = "Inscripto",
                        Nota = 0
                    };
                    await _inscripcionClient.Add(nuevaInscripcion);
                    MessageBox.Show("¡Inscripción exitosa!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al procesar la inscripción: " + ex.Message, "Error");
                }
            }
        }

        private async void btnAnular_Click(object sender, EventArgs e)
        {
            if (misInscripcionesDataGridView.SelectedRows.Count == 0) return;

            var filaSeleccionada = misInscripcionesDataGridView.SelectedRows[0];

            int idCursoAnular = (int)filaSeleccionada.Cells["CursoIdColumn"].Value;
            string nombreMateria = filaSeleccionada.Cells["MateriaColumn"].Value.ToString();

            var confirmacion = MessageBox.Show($"¿Está seguro de que desea ANULAR su inscripción a la materia '{nombreMateria}'?", "Anular Inscripción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    await _inscripcionClient.Delete(_alumnoActual.Legajo, idCursoAnular);
                    MessageBox.Show("Inscripción anulada correctamente.", "Éxito");
                    await CargarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al anular la inscripción: " + ex.Message, "Error");
                }
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButtonsState()
        {
            btnInscribirse.Enabled = materiasDisponiblesListBox.SelectedItem != null && comisionesListBox.SelectedItem != null;
            btnAnular.Enabled = misInscripcionesDataGridView.SelectedRows.Count > 0;
        }
    }
}