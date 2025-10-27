namespace WindowsForms
{
    partial class PersonaLista
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            topPanel = new Panel();
            titleLabel = new Label();
            personaDataGridView = new DataGridView();
            agregarButton = new Button();
            modificarButton = new Button();
            eliminarButton = new Button();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)personaDataGridView).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(0, 122, 204);
            topPanel.Controls.Add(titleLabel);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(3, 4, 3, 4);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(750, 75);
            topPanel.TabIndex = 4;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(25, 19);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(223, 31);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Gestión de Personas";
            // 
            // personaDataGridView
            // 
            personaDataGridView.AllowUserToAddRows = false;
            personaDataGridView.AllowUserToDeleteRows = false;
            personaDataGridView.AllowUserToResizeRows = false;
            personaDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            personaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            personaDataGridView.BackgroundColor = Color.White;
            personaDataGridView.BorderStyle = BorderStyle.None;
            personaDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            personaDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            personaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            personaDataGridView.ColumnHeadersHeight = 40;
            personaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            personaDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            personaDataGridView.EnableHeadersVisualStyles = false;
            personaDataGridView.GridColor = Color.FromArgb(238, 238, 238);
            personaDataGridView.Location = new Point(28, 175);
            personaDataGridView.Margin = new Padding(3, 4, 3, 4);
            personaDataGridView.MultiSelect = false;
            personaDataGridView.Name = "personaDataGridView";
            personaDataGridView.ReadOnly = true;
            personaDataGridView.RowHeadersVisible = false;
            personaDataGridView.RowHeadersWidth = 51;
            personaDataGridView.RowTemplate.Height = 40;
            personaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            personaDataGridView.Size = new Size(694, 536);
            personaDataGridView.TabIndex = 3;
            // 
            // agregarButton
            // 
            agregarButton.BackColor = Color.FromArgb(0, 122, 204);
            agregarButton.Cursor = Cursors.Hand;
            agregarButton.FlatAppearance.BorderSize = 0;
            agregarButton.FlatStyle = FlatStyle.Flat;
            agregarButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            agregarButton.ForeColor = Color.White;
            agregarButton.Location = new Point(28, 106);
            agregarButton.Margin = new Padding(3, 4, 3, 4);
            agregarButton.Name = "agregarButton";
            agregarButton.Size = new Size(120, 40);
            agregarButton.TabIndex = 1;
            agregarButton.Text = "AGREGAR";
            agregarButton.UseVisualStyleBackColor = false;
            agregarButton.Click += agregarButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.BackColor = Color.FromArgb(108, 117, 125);
            modificarButton.Cursor = Cursors.Hand;
            modificarButton.FlatAppearance.BorderSize = 0;
            modificarButton.FlatStyle = FlatStyle.Flat;
            modificarButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            modificarButton.ForeColor = Color.White;
            modificarButton.Location = new Point(154, 106);
            modificarButton.Margin = new Padding(3, 4, 3, 4);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(120, 40);
            modificarButton.TabIndex = 2;
            modificarButton.Text = "MODIFICAR";
            modificarButton.UseVisualStyleBackColor = false;
            modificarButton.Click += modificarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.BackColor = Color.FromArgb(220, 53, 69);
            eliminarButton.Cursor = Cursors.Hand;
            eliminarButton.FlatAppearance.BorderSize = 0;
            eliminarButton.FlatStyle = FlatStyle.Flat;
            eliminarButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            eliminarButton.ForeColor = Color.White;
            eliminarButton.Location = new Point(280, 106);
            eliminarButton.Margin = new Padding(3, 4, 3, 4);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(120, 40);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "ELIMINAR";
            eliminarButton.UseVisualStyleBackColor = false;
            eliminarButton.Visible = false;
            // 
            // PersonaLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(750, 750);
            Controls.Add(eliminarButton);
            Controls.Add(modificarButton);
            Controls.Add(agregarButton);
            Controls.Add(personaDataGridView);
            Controls.Add(topPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "PersonaLista";
            Text = "PersonaLista";
            Load += PersonaLista_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)personaDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button agregarButton;
        private System.Windows.Forms.DataGridView personaDataGridView;
    }
}