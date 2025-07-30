namespace WindowsForms
{
    partial class EspecialidadLista
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            especialidadesDataGridView = new DataGridView();
            agregarButton = new Button();
            modificarButton = new Button();
            eliminarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)especialidadesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // especialidadesDataGridView
            // 
            especialidadesDataGridView.AllowUserToOrderColumns = true;
            especialidadesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            especialidadesDataGridView.Location = new Point(12, 12);
            especialidadesDataGridView.Name = "especialidadesDataGridView";
            especialidadesDataGridView.ReadOnly = true;
            especialidadesDataGridView.RowHeadersWidth = 51;
            especialidadesDataGridView.Size = new Size(776, 357);
            especialidadesDataGridView.TabIndex = 0;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(639, 393);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(149, 45);
            agregarButton.TabIndex = 2;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(459, 393);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(149, 45);
            modificarButton.TabIndex = 3;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(277, 393);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(149, 45);
            eliminarButton.TabIndex = 4;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            // 
            // EspecialidadLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(eliminarButton);
            Controls.Add(modificarButton);
            Controls.Add(agregarButton);
            Controls.Add(especialidadesDataGridView);
            Name = "EspecialidadLista";
            Text = "EspecialidadLista";
            Load += Especialidad_Load;
            ((System.ComponentModel.ISupportInitialize)especialidadesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView especialidadesDataGridView;
        private Button agregarButton;
        private Button modificarButton;
        private Button eliminarButton;
    }
}