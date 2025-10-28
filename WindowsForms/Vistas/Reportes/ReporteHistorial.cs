// Archivo: WindowsForms/Vistas/Reportes/ReporteHistorialForm.cs (VERSIÓN FINAL CON API)

using System.Data;
using Application.Interfaces.ApiClients;
using Application.Interfaces.Repositories;
using ApplicationClean.Interfaces.ApiClients;
using Infrastructure.Reportes;
using Infrastructure.ViewModels;
using QuestPDF.Fluent;
using static Domain.Entities.Usuario;

namespace WindowsForms
{
    public partial class ReporteHistorialForm : Form
    {
        private readonly IAPIUsuarioClients _usuarioClient;
        private readonly IAPIReportesClient _reportesClient;

        public ReporteHistorialForm(IAPIUsuarioClients usuarioClient, IAPIReportesClient reportesClient)
        {
            InitializeComponent();
            _usuarioClient = usuarioClient;
            _reportesClient = reportesClient;
        }

        private async void ReporteHistorialForm_Load(object sender, EventArgs e)
        {
            await CargarAlumnos();
            ConfigurarGrid();
        }

        private async Task CargarAlumnos()
        {
            try
            {
                var usuarios = await _usuarioClient.GetAll();
                var alumnos = usuarios.Where(u => u.Tipo == TipoUsuario.Alumno).ToList();

                alumnosComboBox.DataSource = alumnos;
                alumnosComboBox.DisplayMember = "PersonaNombreCompleto";
                alumnosComboBox.ValueMember = "Legajo";
                alumnosComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private void ConfigurarGrid()
        {
            reporteDataGridView.AutoGenerateColumns = false;
            reporteDataGridView.Columns.Clear();
            reporteDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Materia", HeaderText = "Materia", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            reporteDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Comision", HeaderText = "Comisión", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            reporteDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Anio", HeaderText = "Año", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            reporteDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Condicion", HeaderText = "Condición", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            reporteDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nota", HeaderText = "Nota", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        }

        private async void generarButton_Click(object sender, EventArgs e)
        {
            if (alumnosComboBox.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un alumno.", "Validación");
                return;
            }

            string legajoAlumno = alumnosComboBox.SelectedValue.ToString();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                reporteDataGridView.DataSource = null;
                promedioLabel.Text = "Promedio General: -";

                var reporteData = (await _reportesClient.GetHistorialAlumnoAsync(legajoAlumno)).ToList();

                reporteDataGridView.DataSource = reporteData;

                var materiasAprobadas = reporteData
                    .Where(r => !string.IsNullOrWhiteSpace(r.Condicion) &&
                                r.Condicion.Trim().Equals("Aprobado", StringComparison.OrdinalIgnoreCase) &&
                                r.Nota >= 4)
                    .ToList();

                if (materiasAprobadas.Any())
                {
                    double promedio = materiasAprobadas.Average(r => r.Nota);
                    promedioLabel.Text = $"Promedio General (Aprobadas): {promedio:F2}";
                }
                else
                {
                    promedioLabel.Text = "Promedio General: N/A (sin materias aprobadas)";
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
            if (reporteDataGridView.DataSource == null)
            {
                MessageBox.Show("Primero debe generar un reporte para poder exportarlo a PDF.", "Información");
                return;
            }
            try
            {
                var cursadasDto = (List<HistorialAlumnoDto>)reporteDataGridView.DataSource;

                var cursadasViewModel = cursadasDto.Select(c => new HistorialCursadaViewModel
                {
                    Materia = c.Materia,
                    Comision = c.Comision,
                    Anio = c.Anio,
                    Condicion = c.Condicion,
                    Nota = c.Nota
                }).ToList();

                var dataSource = new HistorialAcademicoDataSource
                {
                    NombreCompletoAlumno = alumnosComboBox.Text,
                    Legajo = alumnosComboBox.SelectedValue.ToString(),
                    PromedioGeneral = promedioLabel.Text,
                    Cursadas = cursadasViewModel
                };

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Guardar Historial Académico";
                    saveFileDialog.FileName = $"Historial_{dataSource.Legajo}_{DateTime.Now:yyyyMMdd}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
                        var report = new HistorialAcademicoReport(dataSource);
                        report.GeneratePdf(saveFileDialog.FileName);
                        this.Cursor = Cursors.Default;
                        MessageBox.Show($"El historial se ha guardado exitosamente en:\n{saveFileDialog.FileName}", "PDF Generado");
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                ErrorHandler.HandleError(ex);
            }
        }
    }
}