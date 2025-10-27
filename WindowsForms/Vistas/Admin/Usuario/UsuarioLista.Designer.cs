namespace WindowsForms
{
    partial class UsuarioLista
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
            usuarioDataGridView = new DataGridView();
            agregarButton = new Button();
            modificarButton = new Button();
            eliminarButton = new Button();
            panelFiltros = new Panel();
            btnLimpiarFiltros = new Button();
            cmbFiltroTipo = new ComboBox();
            lblFiltroTipo = new Label();
            txtFiltroLegajo = new TextBox();
            lblFiltroLegajo = new Label();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usuarioDataGridView).BeginInit();
            panelFiltros.SuspendLayout();
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
            titleLabel.Size = new Size(221, 31);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Gestión de Usuarios";
            // 
            // usuarioDataGridView
            // 
            usuarioDataGridView.AllowUserToAddRows = false;
            usuarioDataGridView.AllowUserToDeleteRows = false;
            usuarioDataGridView.AllowUserToResizeRows = false;
            usuarioDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            usuarioDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usuarioDataGridView.BackgroundColor = Color.White;
            usuarioDataGridView.BorderStyle = BorderStyle.None;
            usuarioDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            usuarioDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            usuarioDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            usuarioDataGridView.ColumnHeadersHeight = 40;
            usuarioDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            usuarioDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            usuarioDataGridView.EnableHeadersVisualStyles = false;
            usuarioDataGridView.GridColor = Color.FromArgb(238, 238, 238);
            usuarioDataGridView.Location = new Point(28, 238);
            usuarioDataGridView.Margin = new Padding(3, 4, 3, 4);
            usuarioDataGridView.MultiSelect = false;
            usuarioDataGridView.Name = "usuarioDataGridView";
            usuarioDataGridView.ReadOnly = true;
            usuarioDataGridView.RowHeadersVisible = false;
            usuarioDataGridView.RowHeadersWidth = 51;
            usuarioDataGridView.RowTemplate.Height = 40;
            usuarioDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usuarioDataGridView.Size = new Size(694, 474);
            usuarioDataGridView.TabIndex = 3;
            // 
            // agregarButton
            // 
            agregarButton.BackColor = Color.FromArgb(0, 122, 204);
            agregarButton.Cursor = Cursors.Hand;
            agregarButton.FlatAppearance.BorderSize = 0;
            agregarButton.FlatStyle = FlatStyle.Flat;
            agregarButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            agregarButton.ForeColor = Color.White;
            agregarButton.Location = new Point(28, 94);
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
            modificarButton.Location = new Point(154, 94);
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
            eliminarButton.Location = new Point(280, 94);
            eliminarButton.Margin = new Padding(3, 4, 3, 4);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(120, 40);
            eliminarButton.TabIndex = 3;
            eliminarButton.Text = "ELIMINAR";
            eliminarButton.UseVisualStyleBackColor = false;
            eliminarButton.Visible = false;
            // 
            // panelFiltros
            // 
            panelFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelFiltros.BackColor = Color.WhiteSmoke;
            panelFiltros.Controls.Add(btnLimpiarFiltros);
            panelFiltros.Controls.Add(cmbFiltroTipo);
            panelFiltros.Controls.Add(lblFiltroTipo);
            panelFiltros.Controls.Add(txtFiltroLegajo);
            panelFiltros.Controls.Add(lblFiltroLegajo);
            panelFiltros.Location = new Point(28, 150);
            panelFiltros.Margin = new Padding(3, 4, 3, 4);
            panelFiltros.Name = "panelFiltros";
            panelFiltros.Size = new Size(694, 69);
            panelFiltros.TabIndex = 5;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.BackColor = Color.Gray;
            btnLimpiarFiltros.Cursor = Cursors.Hand;
            btnLimpiarFiltros.FlatAppearance.BorderSize = 0;
            btnLimpiarFiltros.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltros.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            btnLimpiarFiltros.ForeColor = Color.White;
            btnLimpiarFiltros.Location = new Point(580, 19);
            btnLimpiarFiltros.Margin = new Padding(3, 4, 3, 4);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(90, 32);
            btnLimpiarFiltros.TabIndex = 4;
            btnLimpiarFiltros.Text = "LIMPIAR";
            btnLimpiarFiltros.UseVisualStyleBackColor = false;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // cmbFiltroTipo
            // 
            cmbFiltroTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroTipo.FormattingEnabled = true;
            cmbFiltroTipo.Location = new Point(402, 19);
            cmbFiltroTipo.Margin = new Padding(3, 4, 3, 4);
            cmbFiltroTipo.Name = "cmbFiltroTipo";
            cmbFiltroTipo.Size = new Size(156, 28);
            cmbFiltroTipo.TabIndex = 3;
            cmbFiltroTipo.SelectedIndexChanged += AplicarFiltros;
            // 
            // lblFiltroTipo
            // 
            lblFiltroTipo.AutoSize = true;
            lblFiltroTipo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFiltroTipo.Location = new Point(304, 22);
            lblFiltroTipo.Name = "lblFiltroTipo";
            lblFiltroTipo.Size = new Size(92, 20);
            lblFiltroTipo.TabIndex = 2;
            lblFiltroTipo.Text = "Filtrar x Rol:";
            // 
            // txtFiltroLegajo
            // 
            txtFiltroLegajo.Location = new Point(131, 20);
            txtFiltroLegajo.Margin = new Padding(3, 4, 3, 4);
            txtFiltroLegajo.Name = "txtFiltroLegajo";
            txtFiltroLegajo.Size = new Size(167, 27);
            txtFiltroLegajo.TabIndex = 1;
            txtFiltroLegajo.TextChanged += AplicarFiltros;
            // 
            // lblFiltroLegajo
            // 
            lblFiltroLegajo.AutoSize = true;
            lblFiltroLegajo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFiltroLegajo.Location = new Point(10, 22);
            lblFiltroLegajo.Name = "lblFiltroLegajo";
            lblFiltroLegajo.Size = new Size(115, 20);
            lblFiltroLegajo.TabIndex = 0;
            lblFiltroLegajo.Text = "Filtrar x Legajo:";
            // 
            // UsuarioLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(750, 750);
            Controls.Add(panelFiltros);
            Controls.Add(eliminarButton);
            Controls.Add(modificarButton);
            Controls.Add(agregarButton);
            Controls.Add(usuarioDataGridView);
            Controls.Add(topPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "UsuarioLista";
            Text = "UsuarioLista";
            Load += UsuarioLista_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)usuarioDataGridView).EndInit();
            panelFiltros.ResumeLayout(false);
            panelFiltros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button agregarButton;
        private System.Windows.Forms.DataGridView usuarioDataGridView;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.ComboBox cmbFiltroTipo;
        private System.Windows.Forms.Label lblFiltroTipo;
        private System.Windows.Forms.TextBox txtFiltroLegajo;
        private System.Windows.Forms.Label lblFiltroLegajo;
    }
}