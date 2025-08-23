using ApplicationClean.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.Vistas
{
    public partial class Menu : Form
    {
        private readonly PlanLista _planLista;
        private readonly EspecialidadLista _especialidadLista;

        public Menu(PlanLista planLista, EspecialidadLista especialidadLista)
        {
            InitializeComponent();
            _especialidadLista = especialidadLista;
            _planLista = planLista;
        }

        private void planButton_Click(object sender, EventArgs e)
        {
          
            _planLista.ShowDialog();
        }

        private void especialidadButton_Click(object sender, EventArgs e)
        {
           
            _especialidadLista.ShowDialog();
        }
    }
}
