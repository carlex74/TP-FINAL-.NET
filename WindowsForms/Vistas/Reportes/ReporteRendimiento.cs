// Archivo: WindowsForms/Vistas/Reportes/ReporteRendimientoForm.cs (VERSIÓN FINAL)

using Application.Interfaces.ApiClients;
using Application.Interfaces.Repositories;
using ApplicationClean.Interfaces.ApiClients;
using Infrastructure.Reportes;
using Infrastructure.ViewModels;
using QuestPDF.Fluent;
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
    public partial class ReporteRendimientoForm : Form
    {
        private readonly IAPICursoClient _cursoClient;
        private readonly IAPIReportesClient _reportesClient;

        public ReporteRendimientoForm(IAPICursoClient cursoClient, IAPIReportesClient reportesClient)
        {
            InitializeComponent();
            _cursoClient = cursoClient;
            _reportesClient = reportesClient;
        }

        private async void ReporteRendimientoForm_Load(object sender, EventArgs e)
        {
            await CargarCursos();
            ConfigurarGrid();
            ConfigurarChart();
        }

        private async Task CargarCursos()
        {
            try
            {
                var cursos = await _cursoClient.GetAll();
                cursosComboBox.DataSource = cursos.ToList();
                cursosComboBox.DisplayMember = "Descripcion";
                cursosComboBox.ValueMember = "Id";
                cursosComboBox.SelectedIndex = -1;
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
            reporteDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LegajoAlumno", HeaderText = "Legajo", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            reporteDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NombreCompleto", HeaderText = "Nombre Completo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            reporteDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Condicion", HeaderText = "Condición", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            reporteDataGridView.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nota", HeaderText = "Nota", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
        }

        private void ConfigurarChart()
        {
            rendimientoChart.Series.Clear();
            rendimientoChart.ChartAreas.Clear();
            rendimientoChart.Legends.Clear();
            WinFormsChart.ChartArea chartArea = new WinFormsChart.ChartArea("MainChartArea");
            rendimientoChart.ChartAreas.Add(chartArea);
            WinFormsChart.Series series = new WinFormsChart.Series("Rendimiento")
            {
                ChartType = WinFormsChart.SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#AXISLABEL (#PERCENT{P0})",
                LegendText = "#AXISLABEL"
            };
            rendimientoChart.Series.Add(series);
            WinFormsChart.Legend legend = new WinFormsChart.Legend("DefaultLegend")
            {
                Docking = Docking.Bottom,
                Alignment = System.Drawing.StringAlignment.Center
            };
            rendimientoChart.Legends.Add(legend);
        }

        private async void generarButton_Click(object sender, EventArgs e)
        {
            if (cursosComboBox.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un curso.", "Validación");
                return;
            }
            int cursoId = (int)cursosComboBox.SelectedValue;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var reporteData = (await _reportesClient.GetRendimientoCursoAsync(cursoId)).ToList();

                reporteDataGridView.DataSource = reporteData;

                var chartData = reporteData
                    .GroupBy(r => r.Condicion)
                    .Select(g => new { Condicion = g.Key, Cantidad = g.Count() })
                    .ToList();

                rendimientoChart.Series["Rendimiento"].Points.Clear();
                foreach (var dataPoint in chartData)
                {
                    WinFormsChart.DataPoint point = new WinFormsChart.DataPoint();
                    point.SetValueY(dataPoint.Cantidad);
                    point.AxisLabel = dataPoint.Condicion;
                    point.LegendText = dataPoint.Condicion;
                    rendimientoChart.Series["Rendimiento"].Points.Add(point);
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
                var alumnosDto = (List<RendimientoCursoDto>)reporteDataGridView.DataSource;

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
                    NombreCurso = cursosComboBox.Text,
                    Alumnos = alumnosViewModel,
                    GraficoBytes = graficoBytes
                };

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.Title = "Guardar Reporte de Rendimiento";
                    saveFileDialog.FileName = $"Rendimiento_{dataSource.NombreCurso.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd}.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
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
            plt.Legend.Location = Alignment.LowerRight;

            return plt.GetImageBytes(400, 250);
        }
    }
}