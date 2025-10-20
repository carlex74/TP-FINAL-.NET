using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
        private List<CursoDTO> _misCursosCompletos = new List<CursoDTO>(); // Guardamos los cursos para el reporte

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

            ConfigurarGridReporte();
            ConfigurarChartReporte();
            await CargarMisCursosAsync();
        }

        private async Task CargarMisCursosAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var todasLasAsignaciones = (await _docenteCursoClient.GetAllAsync()).ToList();
                var misAsignaciones = todasLasAsignaciones.Where(a => a.LegajoDocente == _docenteActual.Legajo).ToList();
                var misCursosIds = misAsignaciones.Select(a => a.IdCurso).ToHashSet();

                var todosLosCursos = (await _cursoClient.GetAll()).ToList();
                var todasLasMaterias = (await _materiaClient.GetAll()).ToList();
                var todasLasComisiones = (await _comisionClient.GetAll()).ToList();

                _misCursosCompletos = todosLosCursos.Where(c => misCursosIds.Contains(c.Id)).ToList();

                var cursosParaMostrar = from asig in misAsignaciones
                                        join curso in _misCursosCompletos on asig.IdCurso equals curso.Id
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

                // Cargar el ComboBox de la pestaña de reportes
                cmbCursosReporte.DataSource = _misCursosCompletos;
                cmbCursosReporte.DisplayMember = "Descripcion";
                cmbCursosReporte.ValueMember = "Id";
                cmbCursosReporte.SelectedIndex = -1;
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
                btnGuardarCambios.Enabled = false;
                dgvAlumnosInscriptos.DataSource = null;
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
            // (Tu lógica existente para guardar cambios no necesita ser modificada)
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- MÉTODOS PARA LA PESTAÑA DE REPORTES ---

        private void ConfigurarGridReporte()
        {
            dgvReporteAlumnos.AutoGenerateColumns = false;
            dgvReporteAlumnos.Columns.Clear();
            dgvReporteAlumnos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LegajoAlumno", HeaderText = "Legajo", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvReporteAlumnos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreCompleto", HeaderText = "Nombre Completo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvReporteAlumnos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Condicion", HeaderText = "Condición", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvReporteAlumnos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nota", HeaderText = "Nota", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        }

        private void ConfigurarChartReporte()
        {
            chartRendimiento.Series.Clear();
            chartRendimiento.ChartAreas.Clear();
            chartRendimiento.Legends.Clear();

            ChartArea chartArea = new ChartArea("MainChartArea");
            chartRendimiento.ChartAreas.Add(chartArea);

            Series series = new Series("Rendimiento")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#AXISLABEL (#PERCENT{P0})",
                LegendText = "#AXISLABEL"
            };
            chartRendimiento.Series.Add(series);

            Legend legend = new Legend("DefaultLegend")
            {
                Docking = Docking.Bottom,
                Alignment = System.Drawing.StringAlignment.Center
            };
            chartRendimiento.Legends.Add(legend);
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (cmbCursosReporte.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un curso.", "Validación");
                return;
            }

            int cursoId = (int)cmbCursosReporte.SelectedValue;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                var inscripciones = (await _inscripcionClient.GetAll()).Where(i => i.IdCurso == cursoId).ToList();
                var usuarios = await _usuarioClient.GetAll();

                var reporteData = (from insc in inscripciones
                                   join user in usuarios on insc.LegajoAlumno equals user.Legajo
                                   select new
                                   {
                                       LegajoAlumno = insc.LegajoAlumno,
                                       NombreCompleto = user.PersonaNombreCompleto,
                                       Condicion = insc.Condicion,
                                       Nota = insc.Nota
                                   }).ToList();

                dgvReporteAlumnos.DataSource = reporteData;

                var chartData = reporteData
                    .GroupBy(r => r.Condicion)
                    .Select(g => new { Condicion = g.Key, Cantidad = g.Count() })
                    .ToList();

                chartRendimiento.Series["Rendimiento"].Points.Clear();
                foreach (var dataPoint in chartData)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueY(dataPoint.Cantidad);
                    point.AxisLabel = dataPoint.Condicion;
                    point.LegendText = dataPoint.Condicion;
                    chartRendimiento.Series["Rendimiento"].Points.Add(point);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}