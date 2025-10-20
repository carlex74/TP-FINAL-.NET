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
    public partial class ReporteRendimientoForm : Form
    {
        private readonly IAPICursoClient _cursoClient;
        private readonly IAlumnoInscripcionClients _inscripcionClient;
        private readonly IAPIUsuarioClients _usuarioClient;

        public ReporteRendimientoForm(IAPICursoClient cursoClient, IAlumnoInscripcionClients inscripcionClient, IAPIUsuarioClients usuarioClient)
        {
            InitializeComponent();
            _cursoClient = cursoClient;
            _inscripcionClient = inscripcionClient;
            _usuarioClient = usuarioClient;
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
                MessageBox.Show($"Error al cargar cursos: {ex.Message}", "Error");
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

            ChartArea chartArea = new ChartArea("MainChartArea");
            rendimientoChart.ChartAreas.Add(chartArea);

            Series series = new Series("Rendimiento")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,

                // --- CAMBIO CLAVE 1: MEJORAR LA ETIQUETA DE LA PORCIÓN ---
                // Ahora mostrará "Condición (XX%)", por ejemplo: "Aprobado (33%)"
                Label = "#AXISLABEL (#PERCENT{P0})",

                // --- CAMBIO CLAVE 2: CORREGIR EL TEXTO DE LA LEYENDA ---
                // Le decimos que use la etiqueta del eje (que definiremos luego) como texto.
                LegendText = "#AXISLABEL"
            };
            rendimientoChart.Series.Add(series);

            Legend legend = new Legend("DefaultLegend")
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

                // ... (el código para obtener 'reporteData' no cambia) ...
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
                reporteDataGridView.DataSource = reporteData;
                var chartData = reporteData
                    .GroupBy(r => r.Condicion)
                    .Select(g => new { Condicion = g.Key, Cantidad = g.Count() })
                    .ToList();

                // --- INICIO DE LA SECCIÓN CORREGIDA ---
                rendimientoChart.Series["Rendimiento"].Points.Clear();
                foreach (var dataPoint in chartData)
                {
                    // Creamos un punto de datos explícitamente
                    DataPoint point = new DataPoint();

                    // Establecemos el valor numérico (la cantidad de alumnos)
                    point.SetValueY(dataPoint.Cantidad);

                    // Le decimos al punto cuál es su etiqueta de texto.
                    // Esto es lo que usará `#AXISLABEL` en la configuración.
                    point.AxisLabel = dataPoint.Condicion;

                    // También podemos asignar el texto de la leyenda aquí directamente por si acaso
                    point.LegendText = dataPoint.Condicion;

                    rendimientoChart.Series["Rendimiento"].Points.Add(point);
                }
                // --- FIN DE LA SECCIÓN CORREGIDA ---
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