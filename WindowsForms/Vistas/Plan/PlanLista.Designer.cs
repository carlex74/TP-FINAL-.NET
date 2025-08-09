namespace WindowsForms.Vistas
{
    partial class PlanLista
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
            eliminarButton = new Button();
            modificarButton = new Button();
            agregarButton = new Button();
            planesDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)planesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(243, 295);
            eliminarButton.Margin = new Padding(3, 2, 3, 2);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(130, 34);
            eliminarButton.TabIndex = 8;
            eliminarButton.Text = "Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(402, 295);
            modificarButton.Margin = new Padding(3, 2, 3, 2);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(130, 34);
            modificarButton.TabIndex = 7;
            modificarButton.Text = "Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // agregarButton
            // 
            agregarButton.Location = new Point(560, 295);
            agregarButton.Margin = new Padding(3, 2, 3, 2);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(130, 34);
            agregarButton.TabIndex = 6;
            agregarButton.Text = "Agregar";
            agregarButton.UseVisualStyleBackColor = true;
            agregarButton.Click += agregarButton_Click;
            // 
            // planesDataGridView
            // 
            planesDataGridView.AllowUserToOrderColumns = true;
            planesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            planesDataGridView.Location = new Point(10, 9);
            planesDataGridView.Margin = new Padding(3, 2, 3, 2);
            planesDataGridView.Name = "planesDataGridView";
            planesDataGridView.ReadOnly = true;
            planesDataGridView.RowHeadersWidth = 51;
            planesDataGridView.Size = new Size(679, 268);
            planesDataGridView.TabIndex = 5;
            planesDataGridView.CellContentClick += planesDataGridView_CellContentClick;
            // 
            // PlanLista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(eliminarButton);
            Controls.Add(modificarButton);
            Controls.Add(agregarButton);
            Controls.Add(planesDataGridView);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PlanLista";
            Text = "PlanLista";
            Load += Plan_Load;
            ((System.ComponentModel.ISupportInitialize)planesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button eliminarButton;
        private Button modificarButton;
        private Button agregarButton;
        private DataGridView planesDataGridView;
    }
}