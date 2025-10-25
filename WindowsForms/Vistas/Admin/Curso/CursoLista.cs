using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;
using System;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class CursoLista : Form
    {
        private readonly IAPICursoClient _cursoClient;
        private readonly IAPIMateriaClient _materiaClient;
        private readonly IAPIComisionClient _comisionClient;

        public CursoLista(IAPICursoClient cursoClient, IAPIMateriaClient materiaClient, IAPIComisionClient comisionClient)
        {
            InitializeComponent();
            _cursoClient = cursoClient;
            _materiaClient = materiaClient;
            _comisionClient = comisionClient;
        }

        private void CursoLista_Load(object sender, EventArgs e)
        {
            GetAllAndLoad();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            using (var detalleForm = new CursoDetalle(_cursoClient, _materiaClient, _comisionClient))
            {
                detalleForm.Mode = FormMode.Add;
                detalleForm.Curso = new CursoDTO();
                if (detalleForm.ShowDialog() == DialogResult.OK)
                {
                    GetAllAndLoad();
                }
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (cursoDataGridView.SelectedRows.Count == 0) return;
            try
            {
                int id = SelectedItem().Id;
                CursoDTO curso = await _cursoClient.GetById(id);
                if (curso == null)
                {
                    MessageBox.Show("Error al cargar curso.");
                    GetAllAndLoad();
                    return;
                }

                using (var detalleForm = new CursoDetalle(_cursoClient, _materiaClient, _comisionClient))
                {
                    detalleForm.Mode = FormMode.Update;
                    detalleForm.Curso = curso;
                    if (detalleForm.ShowDialog() == DialogResult.OK)
                    {
                        GetAllAndLoad();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (cursoDataGridView.SelectedRows.Count == 0) return;
            try
            {
                int id = SelectedItem().Id;
                var result = MessageBox.Show($"¿Seguro que desea eliminar el curso {SelectedItem().Descripcion}?", "Confirmar", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    await _cursoClient.Delete(id);
                    GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private async void GetAllAndLoad()
        {
            try
            {
                cursoDataGridView.DataSource = null;
                cursoDataGridView.DataSource = await _cursoClient.GetAll();
                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private CursoDTO SelectedItem()
        {
            return (CursoDTO)cursoDataGridView.SelectedRows[0].DataBoundItem;
        }

        private void UpdateButtonsState()
        {
            bool hasRows = cursoDataGridView.Rows.Count > 0;
            modificarButton.Enabled = hasRows;
            eliminarButton.Enabled = hasRows;
        }
    }
}