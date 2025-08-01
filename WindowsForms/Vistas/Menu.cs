﻿using DTOs;
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
        public Menu()
        {
            InitializeComponent();
        }

        private void planButton_Click(object sender, EventArgs e)
        {
            PlanLista planLista = new PlanLista();

            planLista.ShowDialog();
        }

        private void especialidadButton_Click(object sender, EventArgs e)
        {
            EspecialidadLista especialidadLista = new EspecialidadLista();

            especialidadLista.ShowDialog();
        }
    }
}
