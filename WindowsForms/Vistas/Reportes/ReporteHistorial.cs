using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Domain.Entities.Usuario;

namespace WindowsForms
{
    public partial class ReporteHistorialForm : Form
    {
        private readonly IAPIUsuarioClients _usuarioClient;
        private readonly IAlumnoInscripcionClients _inscripcionClient;
        private readonly IAPICursoClient _cursoClient;
        private readonly IAPIMateriaClient _materiaClient;
        private readonly IAPIComisionClient _comisionClient;

        public ReporteHistorialForm(IAPIUsuarioClients usuarioClient, IAlumnoInscripcionClients inscripcionClient, IAPICursoClient cursoClient, IAPIMateriaClient materiaClient, IAPIComisionClient comisionClient)
        {
            InitializeComponent();
            _usuarioClient = usuarioClient;
            _inscripcionClient = inscripcionClient;
            _cursoClient = cursoClient;
            _materiaClient = materiaClient;
            _comisionClient = comisionClient;
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
                MessageBox.Show($"Error al cargar alumnos: {ex.Message}", "Error");
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

                var inscripcionesTask = _inscripcionClient.GetAll();
                var cursosTask = _cursoClient.GetAll();
                var materiasTask = _materiaClient.GetAll();
                var comisionesTask = _comisionClient.GetAll();

                await Task.WhenAll(inscripcionesTask, cursosTask, materiasTask, comisionesTask);

                var inscripciones = inscripcionesTask.Result.Where(i => i.LegajoAlumno == legajoAlumno).ToList();
                var cursos = cursosTask.Result;
                var materias = materiasTask.Result;
                var comisiones = comisionesTask.Result;

                var reporteData = (from insc in inscripciones
                                   join curso in cursos on insc.IdCurso equals curso.Id
                                   join materia in materias on curso.IdMateria equals materia.Id
                                   join comision in comisiones on curso.IdComision equals comision.Nro
                                   select new
                                   {
                                       Materia = materia.Nombre,
                                       Comision = comision.Descripcion,
                                       Anio = curso.AnioCalendario,
                                       Condicion = insc.Condicion,
                                       Nota = insc.Nota
                                   }).ToList();

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
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}