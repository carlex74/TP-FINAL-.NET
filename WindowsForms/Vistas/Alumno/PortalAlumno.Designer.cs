namespace WindowsForms.Vistas.Alumno
{
    partial class PortalAlumno
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
            lblBienvenida = new Label();
            btnCerrarSesion = new Button();
            mainPanel = new Panel();
            splitContainer = new SplitContainer();
            lblMateriasDisponibles = new Label();
            materiasDisponiblesListBox = new ListBox();
            btnInscribirse = new Button();
            lblComisiones = new Label();
            comisionesListBox = new ListBox();
            btnAnular = new Button();
            lblMisInscripciones = new Label();
            misInscripcionesDataGridView = new DataGridView();
            topPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)misInscripcionesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(0, 122, 204);
            topPanel.Controls.Add(lblBienvenida);
            topPanel.Controls.Add(btnCerrarSesion);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(3, 4, 3, 4);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(982, 75);
            topPanel.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(25, 20);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(177, 28);
            lblBienvenida.TabIndex = 1;
            lblBienvenida.Text = "Portal del Alumno";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarSesion.BackColor = Color.FromArgb(220, 53, 69);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(820, 18);
            btnCerrarSesion.Margin = new Padding(3, 4, 3, 4);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(150, 40);
            btnCerrarSesion.TabIndex = 0;
            btnCerrarSesion.Text = "CERRAR SESIÓN";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(splitContainer);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 75);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(10, 12, 10, 12);
            mainPanel.Size = new Size(982, 741);
            mainPanel.TabIndex = 1;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(10, 12);
            splitContainer.Margin = new Padding(3, 4, 3, 4);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(lblMateriasDisponibles);
            splitContainer.Panel1.Controls.Add(materiasDisponiblesListBox);
            splitContainer.Panel1.Controls.Add(btnInscribirse);
            splitContainer.Panel1.Controls.Add(lblComisiones);
            splitContainer.Panel1.Controls.Add(comisionesListBox);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(btnAnular);
            splitContainer.Panel2.Controls.Add(lblMisInscripciones);
            splitContainer.Panel2.Controls.Add(misInscripcionesDataGridView);
            splitContainer.Size = new Size(962, 717);
            splitContainer.SplitterDistance = 449;
            splitContainer.TabIndex = 0;
            // 
            // lblMateriasDisponibles
            // 
            lblMateriasDisponibles.AutoSize = true;
            lblMateriasDisponibles.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblMateriasDisponibles.Location = new Point(12, 12);
            lblMateriasDisponibles.Name = "lblMateriasDisponibles";
            lblMateriasDisponibles.Size = new Size(191, 23);
            lblMateriasDisponibles.TabIndex = 0;
            lblMateriasDisponibles.Text = "Seleccione una materia:";
            // 
            // materiasDisponiblesListBox
            // 
            materiasDisponiblesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materiasDisponiblesListBox.Font = new Font("Segoe UI", 9F);
            materiasDisponiblesListBox.FormattingEnabled = true;
            materiasDisponiblesListBox.Location = new Point(16, 50);
            materiasDisponiblesListBox.Margin = new Padding(3, 4, 3, 4);
            materiasDisponiblesListBox.Name = "materiasDisponiblesListBox";
            materiasDisponiblesListBox.Size = new Size(419, 224);
            materiasDisponiblesListBox.TabIndex = 1;
            materiasDisponiblesListBox.SelectedIndexChanged += materiasDisponiblesListBox_SelectedIndexChanged;
            // 
            // btnInscribirse
            // 
            btnInscribirse.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnInscribirse.BackColor = Color.FromArgb(40, 167, 69);
            btnInscribirse.FlatAppearance.BorderSize = 0;
            btnInscribirse.FlatStyle = FlatStyle.Flat;
            btnInscribirse.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnInscribirse.ForeColor = Color.White;
            btnInscribirse.Location = new Point(285, 652);
            btnInscribirse.Margin = new Padding(3, 4, 3, 4);
            btnInscribirse.Name = "btnInscribirse";
            btnInscribirse.Size = new Size(150, 50);
            btnInscribirse.TabIndex = 4;
            btnInscribirse.Text = "INSCRIBIRSE";
            btnInscribirse.UseVisualStyleBackColor = false;
            btnInscribirse.Click += btnInscribirse_Click;
            // 
            // lblComisiones
            // 
            lblComisiones.AutoSize = true;
            lblComisiones.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblComisiones.Location = new Point(12, 300);
            lblComisiones.Name = "lblComisiones";
            lblComisiones.Size = new Size(201, 23);
            lblComisiones.TabIndex = 2;
            lblComisiones.Text = "Seleccione una comisión:";
            // 
            // comisionesListBox
            // 
            comisionesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comisionesListBox.Font = new Font("Segoe UI", 9F);
            comisionesListBox.FormattingEnabled = true;
            comisionesListBox.Location = new Point(16, 338);
            comisionesListBox.Margin = new Padding(3, 4, 3, 4);
            comisionesListBox.Name = "comisionesListBox";
            comisionesListBox.Size = new Size(419, 264);
            comisionesListBox.TabIndex = 3;
            // 
            // btnAnular
            // 
            btnAnular.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAnular.BackColor = Color.FromArgb(220, 53, 69);
            btnAnular.FlatAppearance.BorderSize = 0;
            btnAnular.FlatStyle = FlatStyle.Flat;
            btnAnular.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAnular.ForeColor = Color.White;
            btnAnular.Location = new Point(345, 652);
            btnAnular.Margin = new Padding(3, 4, 3, 4);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(150, 50);
            btnAnular.TabIndex = 2;
            btnAnular.Text = "ANULAR INSCRIPCIÓN";
            btnAnular.UseVisualStyleBackColor = false;
            btnAnular.Click += btnAnular_Click;
            // 
            // lblMisInscripciones
            // 
            lblMisInscripciones.AutoSize = true;
            lblMisInscripciones.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            lblMisInscripciones.Location = new Point(12, 12);
            lblMisInscripciones.Name = "lblMisInscripciones";
            lblMisInscripciones.Size = new Size(140, 23);
            lblMisInscripciones.TabIndex = 1;
            lblMisInscripciones.Text = "Mis Inscripciones";
            // 
            // misInscripcionesDataGridView
            // 
            misInscripcionesDataGridView.AllowUserToAddRows = false;
            misInscripcionesDataGridView.AllowUserToDeleteRows = false;
            misInscripcionesDataGridView.AllowUserToResizeRows = false;
            misInscripcionesDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            misInscripcionesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            misInscripcionesDataGridView.BackgroundColor = Color.White;
            misInscripcionesDataGridView.BorderStyle = BorderStyle.None;
            misInscripcionesDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            misInscripcionesDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            misInscripcionesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            misInscripcionesDataGridView.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            misInscripcionesDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            misInscripcionesDataGridView.EnableHeadersVisualStyles = false;
            misInscripcionesDataGridView.GridColor = Color.FromArgb(238, 238, 238);
            misInscripcionesDataGridView.Location = new Point(16, 50);
            misInscripcionesDataGridView.Margin = new Padding(3, 4, 3, 4);
            misInscripcionesDataGridView.MultiSelect = false;
            misInscripcionesDataGridView.Name = "misInscripcionesDataGridView";
            misInscripcionesDataGridView.ReadOnly = true;
            misInscripcionesDataGridView.RowHeadersVisible = false;
            misInscripcionesDataGridView.RowHeadersWidth = 51;
            misInscripcionesDataGridView.RowTemplate.Height = 40;
            misInscripcionesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            misInscripcionesDataGridView.Size = new Size(479, 582);
            misInscripcionesDataGridView.TabIndex = 0;
            // 
            // PortalAlumno
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(982, 816);
            Controls.Add(mainPanel);
            Controls.Add(topPanel);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1000, 863);
            Name = "PortalAlumno";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Portal del Alumno";
            Load += PortalAlumno_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)misInscripcionesDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox materiasDisponiblesListBox;
        private System.Windows.Forms.ListBox comisionesListBox;
        private System.Windows.Forms.Label lblMateriasDisponibles;
        private System.Windows.Forms.Label lblComisiones;
        private System.Windows.Forms.DataGridView misInscripcionesDataGridView;
        private System.Windows.Forms.Label lblMisInscripciones;
        private System.Windows.Forms.Button btnInscribirse;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.DataGridViewTextBoxColumn CursoIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MateriaColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComisionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CondicionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotaColumn;
    }
}