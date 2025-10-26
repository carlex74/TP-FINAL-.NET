using System.Data;
using ApplicationClean.DTOs;

namespace WindowsForms
{
    public partial class PlanAsignacion : Form
    {
        public List<int> PlanesSeleccionadosIds { get; private set; }

        public PlanAsignacion(List<PlanDTO> todosLosPlanes, List<int> planesAsignadosIds)
        {
            InitializeComponent();

            var planesDisponibles = todosLosPlanes.Where(p => !planesAsignadosIds.Contains(p.Id)).ToList();
            var planesAsignados = todosLosPlanes.Where(p => planesAsignadosIds.Contains(p.Id)).ToList();

            disponiblesListBox.DataSource = planesDisponibles;
            disponiblesListBox.DisplayMember = "DescripcionCompleta";
            disponiblesListBox.ValueMember = "Id";

            asignadosListBox.DataSource = planesAsignados;
            asignadosListBox.DisplayMember = "DescripcionCompleta";
            asignadosListBox.ValueMember = "Id";

            PlanesSeleccionadosIds = new List<int>();
        }

        private void MoverItems(ListBox origen, ListBox destino, bool moverTodos = false)
        {
            var listaOrigen = (List<PlanDTO>)origen.DataSource ?? new List<PlanDTO>();
            var listaDestino = (List<PlanDTO>)destino.DataSource ?? new List<PlanDTO>();
            var itemsAMover = moverTodos ? listaOrigen.ToList() : origen.SelectedItems.OfType<PlanDTO>().ToList();

            if (!itemsAMover.Any()) return;

            foreach (var item in itemsAMover)
            {
                listaOrigen.Remove(item);
                listaDestino.Add(item);
            }

            origen.DataSource = null;
            origen.DataSource = listaOrigen.OrderBy(p => p.Descripcion).ToList();
            origen.DisplayMember = "DescripcionCompleta";
            origen.ValueMember = "Id";

            destino.DataSource = null;
            destino.DataSource = listaDestino.OrderBy(p => p.Descripcion).ToList();
            destino.DisplayMember = "DescripcionCompleta";
            destino.ValueMember = "Id";
        }

        private void agregarButton_Click(object sender, EventArgs e) => MoverItems(disponiblesListBox, asignadosListBox);
        private void quitarButton_Click(object sender, EventArgs e) => MoverItems(asignadosListBox, disponiblesListBox);
        private void agregarTodoButton_Click(object sender, EventArgs e) => MoverItems(disponiblesListBox, asignadosListBox, true);
        private void quitarTodoButton_Click(object sender, EventArgs e) => MoverItems(asignadosListBox, disponiblesListBox, true);

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            PlanesSeleccionadosIds = ((List<PlanDTO>)asignadosListBox.DataSource).Select(p => p.Id).ToList();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}