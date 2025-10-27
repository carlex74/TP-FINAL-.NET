using ApplicationClean.DTOs;
using ApplicationClean.Interfaces.ApiClients;

namespace WindowsForms
{
    public partial class MateriaLista : Form
    {
        private readonly IAPIMateriaClient _materiaClient;
        private readonly IAPIPlanClients _planClient;

        public MateriaLista(IAPIMateriaClient materiaClient, IAPIPlanClients planClient)
        {
            InitializeComponent();
            _materiaClient = materiaClient;
            _planClient = planClient;
        }

        private void MateriaLista_Load(object sender, EventArgs e)
        {
            GetAllAndLoad();
        }

        private void agregarButton_Click(object sender, EventArgs e)
        {
            using (var materiaDetalle = new MateriaDetalle(_materiaClient, _planClient))
            {
                materiaDetalle.Mode = FormMode.Add;
                materiaDetalle.Materia = new MateriaDTO();
                if (materiaDetalle.ShowDialog() == DialogResult.OK)
                {
                    GetAllAndLoad();
                }
            }
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (materiaDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una materia para modificar.", "Info");
                return;
            }

            try
            {
                int id = SelectedItem().Id;
                MateriaDTO materia = await _materiaClient.GetById(id);
                if (materia == null)
                {
                    MessageBox.Show("Error al cargar la materia.", "Error");
                    GetAllAndLoad();
                    return;
                }

                using (var materiaDetalle = new MateriaDetalle(_materiaClient, _planClient))
                {
                    materiaDetalle.Mode = FormMode.Update;
                    materiaDetalle.Materia = materia;
                    if (materiaDetalle.ShowDialog() == DialogResult.OK)
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

        /*
        A FUTURO: Funcionalidad de borrado.
        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (materiaDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una materia para eliminar.", "Info");
                return;
            }

            try
            {
                int id = SelectedItem().Id;
                var result = MessageBox.Show($"¿Seguro que desea eliminar la materia {SelectedItem().Nombre}?", "Confirmar", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    await _materiaClient.Delete(id);
                    GetAllAndLoad();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }
        */

        private async void GetAllAndLoad()
        {
            try
            {
                materiaDataGridView.DataSource = null;
                materiaDataGridView.DataSource = await _materiaClient.GetAll();
                UpdateButtonsState();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private MateriaDTO SelectedItem()
        {
            if (materiaDataGridView.SelectedRows.Count > 0)
            {
                return (MateriaDTO)materiaDataGridView.SelectedRows[0].DataBoundItem;
            }
            return null;
        }

        private void UpdateButtonsState()
        {
            bool hasRows = materiaDataGridView.Rows.Count > 0;
            modificarButton.Enabled = hasRows;
            eliminarButton.Enabled = hasRows;
        }
    }
}