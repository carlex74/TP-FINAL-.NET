using Application.Interfaces.ApiClients;
using Application.Interfaces.Repositories;
using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using Infrastructure.Reportes;
using Infrastructure.ViewModels;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinFormsChart = System.Windows.Forms.DataVisualization.Charting;

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
        private readonly IAPIReportesClient _reportesClient;
        private readonly UsuarioDTO _docenteActual;

        private bool _isLoadingAlumnos = false;
        private List<CursoDTO> _misCursosCompletos = new List<CursoDTO>();

        public PortalDocente(
            IAPIDocenteCursoClient docenteCursoClient,
            IAPICursoClient cursoClient,
            IAPIMateriaClient materiaClient,
            IAPIComisionClient comisionClient,
            IAlumnoInscripcionClients inscripcionClient,
            IAPIUsuarioClients usuarioClient,
            IAPIReportesClient reportesClient)
        {
            InitializeComponent();
            _docenteCursoClient = docenteCursoClient;
            _cursoClient = cursoClient;
            _materiaClient = materiaClient;
            _comisionClient = comisionClient;
            _inscripcionClient = inscripcionClient;
            _usuarioClient = usuarioClient;
            _reportesClient = reportesClient;
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
            btnGenerarPdf.Enabled = false;
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
                cmbCursosReporte.DataSource = _misCursosCompletos.Select(c => new { c.Id, Descripcion = $"{todasLasMaterias.FirstOrDefault(m => m.Id == c.IdMateria)?.Nombre} - {todasLasComisiones.FirstOrDefault(com => com.Nro == c.IdComision)?.Descripcion} ({c.AnioCalendario})" }).ToList();
                cmbCursosReporte.DisplayMember = "Descripcion";
                cmbCursosReporte.ValueMember = "Id";
                cmbCursosReporte.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
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
                ErrorHandler.HandleError(ex);
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
                }
                await Task.WhenAll(tareasDeActualizacion);
                MessageBox.Show($"{tareasDeActualizacion.Count} registros de alumnos actualizados correctamente.", "Éxito");
                await CargarAlumnosDelCursoAsync(idCurso);
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, asegúrese de que todas las notas ingresadas sean números válidos.", "Error de Formato");
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
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
            WinFormsChart.ChartArea chartArea = new WinFormsChart.ChartArea("MainChartArea");
            chartRendimiento.ChartAreas.Add(chartArea);
            WinFormsChart.Series series = new WinFormsChart.Series("Rendimiento")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#AXISLABEL (#PERCENT{P0})",
                LegendText = "#AXISLABEL"
            };
            chartRendimiento.Series.Add(series);
            WinFormsChart.Legend legend = new WinFormsChart.Legend("DefaultLegend")
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
            btnGenerarPdf.Enabled = false;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var reporteData = (await _reportesClient.GetRendimientoCursoAsync(cursoId)).ToList();
                dgvReporteAlumnos.DataSource = reporteData;
                var chartData = reporteData.GroupBy(r => r.Condicion).Select(g => new { Condicion = g.Key, Cantidad = g.Count() }).ToList();
                chartRendimiento.Series["Rendimiento"].Points.Clear();
                if (chartData.Any())
                {
                    foreach (var dataPoint in chartData)
                    {
                        WinFormsChart.DataPoint point = new WinFormsChart.DataPoint();
                        point.SetValueY(dataPoint.Cantidad);
                        point.AxisLabel = dataPoint.Condicion;
                        point.LegendText = dataPoint.Condicion;
                        chartRendimiento.Series["Rendimiento"].Points.Add(point);
                    }
                    btnGenerarPdf.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnGenerarPdf_Click(object sender, EventArgs e)
        {
            if (dgvReporteAlumnos.DataSource == null)
            {
                MessageBox.Show("Primero debe generar un reporte para poder exportarlo a PDF.", "Información");
                return;
            }

            try
            {
                var alumnosDto = (List<RendimientoCursoDto>)dgvReporteAlumnos.DataSource;

                var alumnosViewModel = alumnosDto.Select(a => new AlumnoInscripcionViewModel
                {
                    LegajoAlumno = a.LegajoAlumno,
                    NombreCompleto = a.NombreCompleto,
                    Condicion = a.Condicion,
                    Nota = a.Nota
                }).ToList();

                var resumenCondiciones = alumnosViewModel
                    .GroupBy(a => a.Condicion)
                    .ToDictionary(g => g.Key, g => g.Count());

                byte[] graficoBytes = GenerarGraficoTortaBytes(resumenCondiciones);

                var dataSource = new RendimientoDataSource
                {
                    NombreCurso = cmbCursosReporte.Text,
                    Alumnos = alumnosViewModel,
                    GraficoBytes = graficoBytes
                };

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Guardar Reporte de Rendimiento";
                    saveFileDialog.FileName = $"Rendimiento_{dataSource.NombreCurso.Replace(" ", "_").Replace("-", "")}_{DateTime.Now:yyyyMMdd}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        QuestPDF.Settings.License = LicenseType.Community;
                        var report = new RendimientoReport(dataSource);
                        report.GeneratePdf(saveFileDialog.FileName);
                        this.Cursor = Cursors.Default;
                        MessageBox.Show($"El reporte se ha guardado exitosamente en:\n{saveFileDialog.FileName}", "PDF Generado");
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                ErrorHandler.HandleError(ex);
            }
        }

        private byte[] GenerarGraficoTortaBytes(Dictionary<string, int> data)
        {
            if (data == null || !data.Any()) return null;

            var plt = new Plot();
            plt.Title("Distribución de Condiciones");

            List<PieSlice> slices = data.Select(entry => new PieSlice
            {
                Value = entry.Value,
                Label = entry.Key
            }).ToList();

            var pie = plt.Add.Pie(slices);

            double total = slices.Sum(s => s.Value);
            foreach (var slice in pie.Slices)
            {
                slice.Label += $" ({slice.Value / total:P1})";
            }

            plt.Legend.IsVisible = true;
            plt.Legend.Alignment = Alignment.LowerRight;

            return plt.GetImageBytes(400, 250);
        }
    }
}