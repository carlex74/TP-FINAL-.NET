using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;

namespace WindowsForms
{
    public partial class ComisionLista : Form
    {
        private readonly IAPIComisionClient _comisionClient;
        private readonly IAPIPlanClients _planClient;

        public ComisionLista(IAPIComisionClient comisionClient, IAPIPlanClients planClient)
        {
            InitializeComponent();
            _comisionClient = comisionClient;
            _planClient = planClient;
        }

        private void ComisionLista_Load(object sender, EventArgs e)
        {
            GetAllAndLoad();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            using (var detalleForm = new ComisionDetalle(_comisionClient, _planClient))
            {
                detalleForm.Mode = FormMode.Add;
                detalleForm.Comision = new ComisionDTO();
                if (detalleForm.ShowDialog() == DialogResult.OK)
                {
                    GetAllAndLoad();
                }
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (comisionDataGridView.SelectedRows.Count == 0) return;
            try
            {
                int id = SelectedItem().Nro;
                ComisionDTO comision = await _comisionClient.GetById(id);
                if (comision == null)
                {
                    MessageBox.Show("Error al cargar comisión.");
                    GetAllAndLoad();
                    return;
                }

                using (var detalleForm = new ComisionDetalle(_comisionClient, _planClient))
                {
                    detalleForm.Mode = FormMode.Update;
                    detalleForm.Comision = comision;
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
            if (comisionDataGridView.SelectedRows.Count == 0) return;
            try
            {
                int id = SelectedItem().Nro;
                var result = MessageBox.Show($"¿Seguro que desea eliminar la comisión {SelectedItem().Descripcion}?", "Confirmar", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    await _comisionClient.Delete(id);
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
                comisionDataGridView.DataSource = null;
                comisionDataGridView.DataSource = await _comisionClient.GetAll();
                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private ComisionDTO SelectedItem()
        {
            return (ComisionDTO)comisionDataGridView.SelectedRows[0].DataBoundItem;
        }

        private void UpdateButtonsState()
        {
            bool hasRows = comisionDataGridView.Rows.Count > 0;
            modificarButton.Enabled = hasRows;
            eliminarButton.Enabled = hasRows;
        }
    }
}