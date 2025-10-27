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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.topPanel = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.tabControlDocente = new System.Windows.Forms.TabControl();
            this.tabPageCalificaciones = new System.Windows.Forms.TabPage();
            this.splitContainerCalificaciones = new System.Windows.Forms.SplitContainer();
            this.lblMisCursos = new System.Windows.Forms.Label();
            this.dgvMisCursos = new System.Windows.Forms.DataGridView();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.lblAlumnosInscriptos = new System.Windows.Forms.Label();
            this.dgvAlumnosInscriptos = new System.Windows.Forms.DataGridView();
            this.LegajoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompletoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CondicionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotaColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageReportes = new System.Windows.Forms.TabPage();
            this.splitContainerReporte = new System.Windows.Forms.SplitContainer();
            this.dgvReporteAlumnos = new System.Windows.Forms.DataGridView();
            this.chartRendimiento = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelFiltroReporte = new System.Windows.Forms.Panel();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.cmbCursosReporte = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.tabControlDocente.SuspendLayout();
            this.tabPageCalificaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCalificaciones)).BeginInit();
            this.splitContainerCalificaciones.Panel1.SuspendLayout();
            this.splitContainerCalificaciones.Panel2.SuspendLayout();
            this.splitContainerCalificaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisCursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscriptos)).BeginInit();
            this.tabPageReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReporte)).BeginInit();
            this.splitContainerReporte.Panel1.SuspendLayout();
            this.splitContainerReporte.Panel2.SuspendLayout();
            this.splitContainerReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteAlumnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRendimiento)).BeginInit();
            this.panelFiltroReporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.topPanel.Controls.Add(this.lblBienvenida);
            this.topPanel.Controls.Add(this.btnCerrarSesion);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1082, 60);
            this.topPanel.TabIndex = 1;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = System.Drawing.Color.White;
            this.lblBienvenida.Location = new System.Drawing.Point(22, 16);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(193, 28);
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
            this.btnCerrarSesion.Location = new System.Drawing.Point(929, 15);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(141, 32);
            this.btnCerrarSesion.TabIndex = 0;
            this.btnCerrarSesion.Text = "CERRAR SESIÓN";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.tabControlDocente);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.mainPanel.Size = new System.Drawing.Size(1082, 593);
            this.mainPanel.TabIndex = 2;
            // 
            // tabControlDocente
            // 
            this.tabControlDocente.Controls.Add(this.tabPageCalificaciones);
            this.tabControlDocente.Controls.Add(this.tabPageReportes);
            this.tabControlDocente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDocente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tabControlDocente.Location = new System.Drawing.Point(10, 10);
            this.tabControlDocente.Name = "tabControlDocente";
            this.tabControlDocente.SelectedIndex = 0;
            this.tabControlDocente.Size = new System.Drawing.Size(1062, 573);
            this.tabControlDocente.TabIndex = 0;
            // 
            // tabPageCalificaciones
            // 
            this.tabPageCalificaciones.Controls.Add(this.splitContainerCalificaciones);
            this.tabPageCalificaciones.Location = new System.Drawing.Point(4, 29);
            this.tabPageCalificaciones.Name = "tabPageCalificaciones";
            this.tabPageCalificaciones.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCalificaciones.Size = new System.Drawing.Size(1054, 540);
            this.tabPageCalificaciones.TabIndex = 0;
            this.tabPageCalificaciones.Text = "Calificaciones";
            this.tabPageCalificaciones.UseVisualStyleBackColor = true;
            // 
            // splitContainerCalificaciones
            // 
            this.splitContainerCalificaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCalificaciones.Location = new System.Drawing.Point(3, 3);
            this.splitContainerCalificaciones.Name = "splitContainerCalificaciones";
            // 
            // splitContainerCalificaciones.Panel1
            // 
            this.splitContainerCalificaciones.Panel1.Controls.Add(this.lblMisCursos);
            this.splitContainerCalificaciones.Panel1.Controls.Add(this.dgvMisCursos);
            // 
            // splitContainerCalificaciones.Panel2
            // 
            this.splitContainerCalificaciones.Panel2.Controls.Add(this.btnGuardarCambios);
            this.splitContainerCalificaciones.Panel2.Controls.Add(this.lblAlumnosInscriptos);
            this.splitContainerCalificaciones.Panel2.Controls.Add(this.dgvAlumnosInscriptos);
            this.splitContainerCalificaciones.Size = new System.Drawing.Size(1048, 534);
            this.splitContainerCalificaciones.SplitterDistance = 450;
            this.splitContainerCalificaciones.TabIndex = 0;
            // 
            // lblMisCursos
            // 
            this.lblMisCursos.AutoSize = true;
            this.lblMisCursos.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblMisCursos.Location = new System.Drawing.Point(11, 8);
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
            this.dgvMisCursos.Location = new System.Drawing.Point(14, 32);
            this.dgvMisCursos.MultiSelect = false;
            this.dgvMisCursos.Name = "dgvMisCursos";
            this.dgvMisCursos.ReadOnly = true;
            this.dgvMisCursos.RowHeadersVisible = false;
            this.dgvMisCursos.RowHeadersWidth = 51;
            this.dgvMisCursos.RowTemplate.Height = 40;
            this.dgvMisCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMisCursos.Size = new System.Drawing.Size(422, 495);
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
            this.btnGuardarCambios.Location = new System.Drawing.Point(433, 497);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(150, 32);
            this.btnGuardarCambios.TabIndex = 2;
            this.btnGuardarCambios.Text = "GUARDAR CAMBIOS";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // lblAlumnosInscriptos
            // 
            this.lblAlumnosInscriptos.AutoSize = true;
            this.lblAlumnosInscriptos.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblAlumnosInscriptos.Location = new System.Drawing.Point(11, 8);
            this.lblAlumnosInscriptos.Name = "lblAlumnosInscriptos";
            this.lblAlumnosInscriptos.Size = new System.Drawing.Size(158, 23);
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
            this.dgvAlumnosInscriptos.Location = new System.Drawing.Point(14, 32);
            this.dgvAlumnosInscriptos.MultiSelect = false;
            this.dgvAlumnosInscriptos.Name = "dgvAlumnosInscriptos";
            this.dgvAlumnosInscriptos.RowHeadersVisible = false;
            this.dgvAlumnosInscriptos.RowHeadersWidth = 51;
            this.dgvAlumnosInscriptos.RowTemplate.Height = 40;
            this.dgvAlumnosInscriptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAlumnosInscriptos.Size = new System.Drawing.Size(569, 449);
            this.dgvAlumnosInscriptos.TabIndex = 0;
            // 
            // LegajoColumn
            // 
            this.LegajoColumn.DataPropertyName = "LegajoAlumno";
            this.LegajoColumn.FillWeight = 80F;
            this.LegajoColumn.HeaderText = "Legajo";
            this.LegajoColumn.MinimumWidth = 6;
            this.LegajoColumn.Name = "LegajoColumn";
            this.LegajoColumn.ReadOnly = true;
            // 
            // NombreCompletoColumn
            // 
            this.NombreCompletoColumn.DataPropertyName = "NombreCompleto";
            this.NombreCompletoColumn.FillWeight = 200F;
            this.NombreCompletoColumn.HeaderText = "Nombre Completo";
            this.NombreCompletoColumn.MinimumWidth = 6;
            this.NombreCompletoColumn.Name = "NombreCompletoColumn";
            this.NombreCompletoColumn.ReadOnly = true;
            // 
            // CondicionColumn
            // 
            this.CondicionColumn.DataPropertyName = "Condicion";
            this.CondicionColumn.HeaderText = "Condición";
            this.CondicionColumn.MinimumWidth = 6;
            this.CondicionColumn.Name = "CondicionColumn";
            // 
            // NotaColumn
            // 
            this.NotaColumn.DataPropertyName = "Nota";
            this.NotaColumn.FillWeight = 60F;
            this.NotaColumn.HeaderText = "Nota";
            this.NotaColumn.MinimumWidth = 6;
            this.NotaColumn.Name = "NotaColumn";
            // 
            // tabPageReportes
            // 
            this.tabPageReportes.Controls.Add(this.splitContainerReporte);
            this.tabPageReportes.Controls.Add(this.panelFiltroReporte);
            this.tabPageReportes.Location = new System.Drawing.Point(4, 29);
            this.tabPageReportes.Name = "tabPageReportes";
            this.tabPageReportes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReportes.Size = new System.Drawing.Size(1054, 540);
            this.tabPageReportes.TabIndex = 1;
            this.tabPageReportes.Text = "Reporte de Rendimiento";
            this.tabPageReportes.UseVisualStyleBackColor = true;
            // 
            // splitContainerReporte
            // 
            this.splitContainerReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerReporte.Location = new System.Drawing.Point(3, 56);
            this.splitContainerReporte.Name = "splitContainerReporte";
            // 
            // splitContainerReporte.Panel1
            // 
            this.splitContainerReporte.Panel1.Controls.Add(this.dgvReporteAlumnos);
            // 
            // splitContainerReporte.Panel2
            // 
            this.splitContainerReporte.Panel2.Controls.Add(this.chartRendimiento);
            this.splitContainerReporte.Size = new System.Drawing.Size(1048, 481);
            this.splitContainerReporte.SplitterDistance = 650;
            this.splitContainerReporte.TabIndex = 1;
            // 
            // dgvReporteAlumnos
            // 
            this.dgvReporteAlumnos.AllowUserToAddRows = false;
            this.dgvReporteAlumnos.AllowUserToDeleteRows = false;
            this.dgvReporteAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteAlumnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReporteAlumnos.Location = new System.Drawing.Point(0, 0);
            this.dgvReporteAlumnos.Name = "dgvReporteAlumnos";
            this.dgvReporteAlumnos.ReadOnly = true;
            this.dgvReporteAlumnos.RowHeadersVisible = false;
            this.dgvReporteAlumnos.RowHeadersWidth = 51;
            this.dgvReporteAlumnos.RowTemplate.Height = 25;
            this.dgvReporteAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporteAlumnos.Size = new System.Drawing.Size(650, 481);
            this.dgvReporteAlumnos.TabIndex = 0;
            // 
            // chartRendimiento
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRendimiento.ChartAreas.Add(chartArea1);
            this.chartRendimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartRendimiento.Legends.Add(legend1);
            this.chartRendimiento.Location = new System.Drawing.Point(0, 0);
            this.chartRendimiento.Name = "chartRendimiento";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRendimiento.Series.Add(series1);
            this.chartRendimiento.Size = new System.Drawing.Size(394, 481);
            this.chartRendimiento.TabIndex = 0;
            this.chartRendimiento.Text = "chart1";
            // 
            // panelFiltroReporte
            // 
            this.panelFiltroReporte.Controls.Add(this.btnGenerarReporte);
            this.panelFiltroReporte.Controls.Add(this.cmbCursosReporte);
            this.panelFiltroReporte.Controls.Add(this.label1);
            this.panelFiltroReporte.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltroReporte.Location = new System.Drawing.Point(3, 3);
            this.panelFiltroReporte.Name = "panelFiltroReporte";
            this.panelFiltroReporte.Size = new System.Drawing.Size(1048, 53);
            this.panelFiltroReporte.TabIndex = 0;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnGenerarReporte.FlatAppearance.BorderSize = 0;
            this.btnGenerarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerarReporte.ForeColor = System.Drawing.Color.White;
            this.btnGenerarReporte.Location = new System.Drawing.Point(904, 11);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(129, 29);
            this.btnGenerarReporte.TabIndex = 2;
            this.btnGenerarReporte.Text = "Generar";
            this.btnGenerarReporte.UseVisualStyleBackColor = false;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // cmbCursosReporte
            // 
            this.cmbCursosReporte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCursosReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCursosReporte.FormattingEnabled = true;
            this.cmbCursosReporte.Location = new System.Drawing.Point(168, 12);
            this.cmbCursosReporte.Name = "cmbCursosReporte";
            this.cmbCursosReporte.Size = new System.Drawing.Size(730, 28);
            this.cmbCursosReporte.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione un Curso:";
            // 
            // PortalDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
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
            this.tabControlDocente.ResumeLayout(false);
            this.tabPageCalificaciones.ResumeLayout(false);
            this.splitContainerCalificaciones.Panel1.ResumeLayout(false);
            this.splitContainerCalificaciones.Panel1.PerformLayout();
            this.splitContainerCalificaciones.Panel2.ResumeLayout(false);
            this.splitContainerCalificaciones.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCalificaciones)).EndInit();
            this.splitContainerCalificaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisCursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosInscriptos)).EndInit();
            this.tabPageReportes.ResumeLayout(false);
            this.splitContainerReporte.Panel1.ResumeLayout(false);
            this.splitContainerReporte.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReporte)).EndInit();
            this.splitContainerReporte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteAlumnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRendimiento)).EndInit();
            this.panelFiltroReporte.ResumeLayout(false);
            this.panelFiltroReporte.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TabControl tabControlDocente;
        private System.Windows.Forms.TabPage tabPageCalificaciones;
        private System.Windows.Forms.SplitContainer splitContainerCalificaciones;
        private System.Windows.Forms.Label lblMisCursos;
        private System.Windows.Forms.DataGridView dgvMisCursos;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Label lblAlumnosInscriptos;
        private System.Windows.Forms.DataGridView dgvAlumnosInscriptos;
        private System.Windows.Forms.TabPage tabPageReportes;
        private System.Windows.Forms.Panel panelFiltroReporte;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.ComboBox cmbCursosReporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainerReporte;
        private System.Windows.Forms.DataGridView dgvReporteAlumnos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRendimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn LegajoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompletoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CondicionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotaColumn;
    }
}