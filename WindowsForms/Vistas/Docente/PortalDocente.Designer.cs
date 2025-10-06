namespace WindowsForms
{
    partial class PortalDocente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblMisCursos = new System.Windows.Forms.Label();
            this.dgvMisCursos = new System.Windows.Forms.DataGridView();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.lblAlumnosInscriptos = new System.Windows.Forms.Label();
            this.dgvAlumnosInscriptos = new System.Windows.Forms.DataGridView();
            this.LegajoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompletoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CondicionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisCursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscriptos)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.topPanel.Controls.Add(this.lblBienvenida);
            this.topPanel.Controls.Add(this.btnCerrarSesion);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1082, 60);
            this.topPanel.TabIndex = 1;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.White;
            this.lblBienvenida.Location = new System.Drawing.Point(25, 16);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(182, 28);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Portal del Docente";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(920, 14);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(150, 32);
            this.btnCerrarSesion.TabIndex = 0;
            this.btnCerrarSesion.Text = "CERRAR SESIÓN";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.splitContainer);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.mainPanel.Size = new System.Drawing.Size(1082, 593);
            this.mainPanel.TabIndex = 2;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(10, 10);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lblMisCursos);
            this.splitContainer.Panel1.Controls.Add(this.dgvMisCursos);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.btnGuardarCambios);
            this.splitContainer.Panel2.Controls.Add(this.lblAlumnosInscriptos);
            this.splitContainer.Panel2.Controls.Add(this.dgvAlumnosInscriptos);
            this.splitContainer.Size = new System.Drawing.Size(1062, 573);
            this.splitContainer.SplitterDistance = 350;
            this.splitContainer.TabIndex = 0;
            // 
            // lblMisCursos
            // 
            this.lblMisCursos.AutoSize = true;
            this.lblMisCursos.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblMisCursos.Location = new System.Drawing.Point(12, 10);
            this.lblMisCursos.Name = "lblMisCursos";
            this.lblMisCursos.Size = new System.Drawing.Size(95, 23);
            this.lblMisCursos.TabIndex = 1;
            this.lblMisCursos.Text = "Mis Cursos";
            // 
            // dgvMisCursos
            // 
            this.dgvMisCursos.AllowUserToAddRows = false;
            this.dgvMisCursos.AllowUserToDeleteRows = false;
            this.dgvMisCursos.AllowUserToResizeRows = false;
            this.dgvMisCursos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMisCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMisCursos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMisCursos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMisCursos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMisCursos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMisCursos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMisCursos.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMisCursos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMisCursos.EnableHeadersVisualStyles = false;
            this.dgvMisCursos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvMisCursos.Location = new System.Drawing.Point(16, 40);
            this.dgvMisCursos.MultiSelect = false;
            this.dgvMisCursos.Name = "dgvMisCursos";
            this.dgvMisCursos.ReadOnly = true;
            this.dgvMisCursos.RowHeadersVisible = false;
            this.dgvMisCursos.RowTemplate.Height = 40;
            this.dgvMisCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMisCursos.Size = new System.Drawing.Size(320, 521);
            this.dgvMisCursos.TabIndex = 0;
            this.dgvMisCursos.SelectionChanged += new System.EventHandler(this.dgvMisCursos_SelectionChanged);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGuardarCambios.Enabled = false;
            this.btnGuardarCambios.FlatAppearance.BorderSize = 0;
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardarCambios.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCambios.Location = new System.Drawing.Point(544, 521);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(150, 40);
            this.btnGuardarCambios.TabIndex = 2;
            this.btnGuardarCambios.Text = "GUARDAR CAMBIOS";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // lblAlumnosInscriptos
            // 
            this.lblAlumnosInscriptos.AutoSize = true;
            this.lblAlumnosInscriptos.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblAlumnosInscriptos.Location = new System.Drawing.Point(12, 10);
            this.lblAlumnosInscriptos.Name = "lblAlumnosInscriptos";
            this.lblAlumnosInscriptos.Size = new System.Drawing.Size(161, 23);
            this.lblAlumnosInscriptos.TabIndex = 1;
            this.lblAlumnosInscriptos.Text = "Alumnos Inscriptos";
            // 
            // dgvAlumnosInscriptos
            // 
            this.dgvAlumnosInscriptos.AllowUserToAddRows = false;
            this.dgvAlumnosInscriptos.AllowUserToDeleteRows = false;
            this.dgvAlumnosInscriptos.AllowUserToResizeRows = false;
            this.dgvAlumnosInscriptos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlumnosInscriptos.AutoGenerateColumns = false;
            this.dgvAlumnosInscriptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlumnosInscriptos.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlumnosInscriptos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlumnosInscriptos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAlumnosInscriptos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlumnosInscriptos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAlumnosInscriptos.ColumnHeadersHeight = 40;
            this.dgvAlumnosInscriptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LegajoColumn,
            this.NombreCompletoColumn,
            this.CondicionColumn,
            this.NotaColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlumnosInscriptos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAlumnosInscriptos.EnableHeadersVisualStyles = false;
            this.dgvAlumnosInscriptos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.dgvAlumnosInscriptos.Location = new System.Drawing.Point(16, 40);
            this.dgvAlumnosInscriptos.MultiSelect = false;
            this.dgvAlumnosInscriptos.Name = "dgvAlumnosInscriptos";
            this.dgvAlumnosInscriptos.RowHeadersVisible = false;
            this.dgvAlumnosInscriptos.RowTemplate.Height = 40;
            this.dgvAlumnosInscriptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAlumnosInscriptos.Size = new System.Drawing.Size(678, 465);
            this.dgvAlumnosInscriptos.TabIndex = 0;
            // 
            // LegajoColumn
            // 
            this.LegajoColumn.DataPropertyName = "LegajoAlumno";
            this.LegajoColumn.FillWeight = 80F;
            this.LegajoColumn.HeaderText = "Legajo";
            this.LegajoColumn.Name = "LegajoColumn";
            this.LegajoColumn.ReadOnly = true;
            // 
            // NombreCompletoColumn
            // 
            this.NombreCompletoColumn.DataPropertyName = "NombreCompleto";
            this.NombreCompletoColumn.FillWeight = 200F;
            this.NombreCompletoColumn.HeaderText = "Nombre Completo";
            this.NombreCompletoColumn.Name = "NombreCompletoColumn";
            this.NombreCompletoColumn.ReadOnly = true;
            // 
            // CondicionColumn
            // 
            this.CondicionColumn.DataPropertyName = "Condicion";
            this.CondicionColumn.HeaderText = "Condición";
            this.CondicionColumn.Name = "CondicionColumn";
            // 
            // NotaColumn
            // 
            this.NotaColumn.DataPropertyName = "Nota";
            this.NotaColumn.FillWeight = 60F;
            this.NotaColumn.HeaderText = "Nota";
            this.NotaColumn.Name = "NotaColumn";
            // 
            // PortalDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "PortalDocente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portal del Docente";
            this.Load += new System.EventHandler(this.PortalDocente_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisCursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscriptos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvMisCursos;
        private System.Windows.Forms.Label lblMisCursos;
        private System.Windows.Forms.DataGridView dgvAlumnosInscriptos;
        private System.Windows.Forms.Label lblAlumnosInscriptos;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.DataGridViewTextBoxColumn LegajoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompletoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CondicionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotaColumn;
    }
}