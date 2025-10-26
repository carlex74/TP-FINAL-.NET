using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using ApplicationClean.Interfaces.ApiClients;

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

            ChartArea chartArea = new ChartArea("MainChartArea");
            rendimientoChart.ChartAreas.Add(chartArea);

            Series series = new Series("Rendimiento")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#AXISLABEL (#PERCENT{P0})",
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

                rendimientoChart.Series["Rendimiento"].Points.Clear();
                foreach (var dataPoint in chartData)
                {
                    DataPoint point = new DataPoint();

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
    }
}