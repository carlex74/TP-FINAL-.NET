namespace WindowsForms
{
    partial class Home
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
            this.sideMenuPanel = new System.Windows.Forms.Panel();
            this.cerrarSesionPanel = new System.Windows.Forms.Panel();
            this.cerrarSesionPictureBox = new System.Windows.Forms.PictureBox();
            this.cerrarSesionLabel = new System.Windows.Forms.Label();
            this.asignacionesPanel = new System.Windows.Forms.Panel();
            this.asignacionesPictureBox = new System.Windows.Forms.PictureBox();
            this.asignacionesLabel = new System.Windows.Forms.Label();
            this.cursoPanel = new System.Windows.Forms.Panel();
            this.cursoPictureBox = new System.Windows.Forms.PictureBox();
            this.cursoLabel = new System.Windows.Forms.Label();
            this.comisionPanel = new System.Windows.Forms.Panel();
            this.comisionPictureBox = new System.Windows.Forms.PictureBox();
            this.comisionLabel = new System.Windows.Forms.Label();
            this.materiaPanel = new System.Windows.Forms.Panel();
            this.materiaPictureBox = new System.Windows.Forms.PictureBox();
            this.materiaLabel = new System.Windows.Forms.Label();
            this.usuarioPanel = new System.Windows.Forms.Panel();
            this.usuarioPictureBox = new System.Windows.Forms.PictureBox();
            this.usuarioLabel = new System.Windows.Forms.Label();
            this.personaPanel = new System.Windows.Forms.Panel();
            this.personaPictureBox = new System.Windows.Forms.PictureBox();
            this.personaLabel = new System.Windows.Forms.Label();
            this.planPanel = new System.Windows.Forms.Panel();
            this.planPictureBox = new System.Windows.Forms.PictureBox();
            this.planLabel = new System.Windows.Forms.Label();
            this.especialidadPanel = new System.Windows.Forms.Panel();
            this.especialidadPictureBox = new System.Windows.Forms.PictureBox();
            this.especialidadLabel = new System.Windows.Forms.Label();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.userInfoLabel = new System.Windows.Forms.Label();
            this.logoLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rendimientoPorCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialAcadémicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sideMenuPanel.SuspendLayout();
            this.cerrarSesionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cerrarSesionPictureBox)).BeginInit();
            this.asignacionesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.asignacionesPictureBox)).BeginInit();
            this.cursoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursoPictureBox)).BeginInit();
            this.comisionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comisionPictureBox)).BeginInit();
            this.materiaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materiaPictureBox)).BeginInit();
            this.usuarioPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioPictureBox)).BeginInit();
            this.personaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personaPictureBox)).BeginInit();
            this.planPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planPictureBox)).BeginInit();
            this.especialidadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadPictureBox)).BeginInit();
            this.logoPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sideMenuPanel
            // 
            sideMenuPanel.BackColor = Color.FromArgb(60, 80, 110);
            sideMenuPanel.Controls.Add(cerrarSesionPanel);
            sideMenuPanel.Controls.Add(asignacionesPanel);
            sideMenuPanel.Controls.Add(cursoPanel);
            sideMenuPanel.Controls.Add(comisionPanel);
            sideMenuPanel.Controls.Add(materiaPanel);
            sideMenuPanel.Controls.Add(usuarioPanel);
            sideMenuPanel.Controls.Add(personaPanel);
            sideMenuPanel.Controls.Add(planPanel);
            sideMenuPanel.Controls.Add(especialidadPanel);
            sideMenuPanel.Controls.Add(logoPanel);
            sideMenuPanel.Dock = DockStyle.Left;
            sideMenuPanel.Location = new Point(0, 0);
            sideMenuPanel.Margin = new Padding(4, 3, 4, 3);
            sideMenuPanel.Name = "sideMenuPanel";
            sideMenuPanel.Size = new Size(292, 806);
            sideMenuPanel.TabIndex = 0;
            // 
            // cerrarSesionPanel
            // 
            cerrarSesionPanel.Controls.Add(cerrarSesionPictureBox);
            cerrarSesionPanel.Controls.Add(cerrarSesionLabel);
            cerrarSesionPanel.Cursor = Cursors.Hand;
            cerrarSesionPanel.Dock = DockStyle.Bottom;
            cerrarSesionPanel.Location = new Point(0, 732);
            cerrarSesionPanel.Margin = new Padding(4, 3, 4, 3);
            cerrarSesionPanel.Name = "cerrarSesionPanel";
            cerrarSesionPanel.Size = new Size(292, 74);
            cerrarSesionPanel.TabIndex = 9;
            cerrarSesionPanel.Click += cerrarSesionButton_Click;
            // 
            // cerrarSesionPictureBox
            // 
            cerrarSesionPictureBox.Image = Properties.Resources.icono_logout;
            cerrarSesionPictureBox.Location = new Point(17, 22);
            cerrarSesionPictureBox.Margin = new Padding(4, 3, 4, 3);
            cerrarSesionPictureBox.Name = "cerrarSesionPictureBox";
            cerrarSesionPictureBox.Size = new Size(21, 29);
            cerrarSesionPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            cerrarSesionPictureBox.TabIndex = 1;
            cerrarSesionPictureBox.TabStop = false;
            cerrarSesionPictureBox.Click += cerrarSesionButton_Click;
            // 
            // cerrarSesionLabel
            // 
            cerrarSesionLabel.AutoSize = true;
            cerrarSesionLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            cerrarSesionLabel.ForeColor = Color.Gainsboro;
            cerrarSesionLabel.Location = new Point(52, 23);
            cerrarSesionLabel.Margin = new Padding(4, 0, 4, 0);
            cerrarSesionLabel.Name = "cerrarSesionLabel";
            cerrarSesionLabel.Size = new Size(111, 23);
            cerrarSesionLabel.TabIndex = 0;
            cerrarSesionLabel.Text = "Cerrar Sesión";
            cerrarSesionLabel.Click += cerrarSesionButton_Click;
            // 
            // asignacionesPanel
            // 
            asignacionesPanel.Controls.Add(asignacionesPictureBox);
            asignacionesPanel.Controls.Add(asignacionesLabel);
            asignacionesPanel.Cursor = Cursors.Hand;
            asignacionesPanel.Dock = DockStyle.Top;
            asignacionesPanel.Location = new Point(0, 592);
            asignacionesPanel.Margin = new Padding(4, 3, 4, 3);
            asignacionesPanel.Name = "asignacionesPanel";
            asignacionesPanel.Size = new Size(292, 74);
            asignacionesPanel.TabIndex = 8;
            asignacionesPanel.Click += asignacionesButton_Click;
            // 
            // asignacionesPictureBox
            // 
            asignacionesPictureBox.Image = Properties.Resources.icono_docente_curso;
            asignacionesPictureBox.Location = new Point(17, 22);
            asignacionesPictureBox.Margin = new Padding(4, 3, 4, 3);
            asignacionesPictureBox.Name = "asignacionesPictureBox";
            asignacionesPictureBox.Size = new Size(21, 29);
            asignacionesPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            asignacionesPictureBox.TabIndex = 1;
            asignacionesPictureBox.TabStop = false;
            // 
            // asignacionesLabel
            // 
            asignacionesLabel.AutoSize = true;
            asignacionesLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            asignacionesLabel.ForeColor = Color.Gainsboro;
            asignacionesLabel.Location = new Point(52, 23);
            asignacionesLabel.Margin = new Padding(4, 0, 4, 0);
            asignacionesLabel.Name = "asignacionesLabel";
            asignacionesLabel.Size = new Size(185, 23);
            asignacionesLabel.TabIndex = 0;
            asignacionesLabel.Text = "Asignaciones Docentes";
            // 
            // cursoPanel
            // 
            cursoPanel.Controls.Add(cursoPictureBox);
            cursoPanel.Controls.Add(cursoLabel);
            cursoPanel.Cursor = Cursors.Hand;
            cursoPanel.Dock = DockStyle.Top;
            cursoPanel.Location = new Point(0, 518);
            cursoPanel.Margin = new Padding(4, 3, 4, 3);
            cursoPanel.Name = "cursoPanel";
            cursoPanel.Size = new Size(292, 74);
            cursoPanel.TabIndex = 7;
            cursoPanel.Click += cursoButton_Click;
            // 
            // cursoPictureBox
            // 
            cursoPictureBox.Image = Properties.Resources.icono_curso;
            cursoPictureBox.Location = new Point(17, 22);
            cursoPictureBox.Margin = new Padding(4, 3, 4, 3);
            cursoPictureBox.Name = "cursoPictureBox";
            cursoPictureBox.Size = new Size(21, 29);
            cursoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            cursoPictureBox.TabIndex = 1;
            cursoPictureBox.TabStop = false;
            // 
            // cursoLabel
            // 
            cursoLabel.AutoSize = true;
            cursoLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            cursoLabel.ForeColor = Color.Gainsboro;
            cursoLabel.Location = new Point(52, 23);
            cursoLabel.Margin = new Padding(4, 0, 4, 0);
            cursoLabel.Name = "cursoLabel";
            cursoLabel.Size = new Size(61, 23);
            cursoLabel.TabIndex = 0;
            cursoLabel.Text = "Cursos";
            // 
            // comisionPanel
            // 
            comisionPanel.Controls.Add(comisionPictureBox);
            comisionPanel.Controls.Add(comisionLabel);
            comisionPanel.Cursor = Cursors.Hand;
            comisionPanel.Dock = DockStyle.Top;
            comisionPanel.Location = new Point(0, 444);
            comisionPanel.Margin = new Padding(4, 3, 4, 3);
            comisionPanel.Name = "comisionPanel";
            comisionPanel.Size = new Size(292, 74);
            comisionPanel.TabIndex = 6;
            comisionPanel.Click += comisionButton_Click;
            // 
            // comisionPictureBox
            // 
            comisionPictureBox.Image = Properties.Resources.icono_comision;
            comisionPictureBox.Location = new Point(17, 22);
            comisionPictureBox.Margin = new Padding(4, 3, 4, 3);
            comisionPictureBox.Name = "comisionPictureBox";
            comisionPictureBox.Size = new Size(21, 29);
            comisionPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            comisionPictureBox.TabIndex = 1;
            comisionPictureBox.TabStop = false;
            // 
            // comisionLabel
            // 
            comisionLabel.AutoSize = true;
            comisionLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            comisionLabel.ForeColor = Color.Gainsboro;
            comisionLabel.Location = new Point(52, 23);
            comisionLabel.Margin = new Padding(4, 0, 4, 0);
            comisionLabel.Name = "comisionLabel";
            comisionLabel.Size = new Size(97, 23);
            comisionLabel.TabIndex = 0;
            comisionLabel.Text = "Comisiones";
            // 
            // materiaPanel
            // 
            materiaPanel.Controls.Add(materiaPictureBox);
            materiaPanel.Controls.Add(materiaLabel);
            materiaPanel.Cursor = Cursors.Hand;
            materiaPanel.Dock = DockStyle.Top;
            materiaPanel.Location = new Point(0, 370);
            materiaPanel.Margin = new Padding(4, 3, 4, 3);
            materiaPanel.Name = "materiaPanel";
            materiaPanel.Size = new Size(292, 74);
            materiaPanel.TabIndex = 5;
            materiaPanel.Click += materiaButton_Click;
            // 
            // materiaPictureBox
            // 
            materiaPictureBox.Image = Properties.Resources.icono_materia;
            materiaPictureBox.Location = new Point(17, 22);
            materiaPictureBox.Margin = new Padding(4, 3, 4, 3);
            materiaPictureBox.Name = "materiaPictureBox";
            materiaPictureBox.Size = new Size(21, 29);
            materiaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            materiaPictureBox.TabIndex = 1;
            materiaPictureBox.TabStop = false;
            // 
            // materiaLabel
            // 
            materiaLabel.AutoSize = true;
            materiaLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            materiaLabel.ForeColor = Color.Gainsboro;
            materiaLabel.Location = new Point(52, 23);
            materiaLabel.Margin = new Padding(4, 0, 4, 0);
            materiaLabel.Name = "materiaLabel";
            materiaLabel.Size = new Size(76, 23);
            materiaLabel.TabIndex = 0;
            materiaLabel.Text = "Materias";
            // 
            // usuarioPanel
            // 
            usuarioPanel.Controls.Add(usuarioPictureBox);
            usuarioPanel.Controls.Add(usuarioLabel);
            usuarioPanel.Cursor = Cursors.Hand;
            usuarioPanel.Dock = DockStyle.Top;
            usuarioPanel.Location = new Point(0, 296);
            usuarioPanel.Margin = new Padding(4, 3, 4, 3);
            usuarioPanel.Name = "usuarioPanel";
            usuarioPanel.Size = new Size(292, 74);
            usuarioPanel.TabIndex = 4;
            usuarioPanel.Click += usuarioButton_Click;
            // 
            // usuarioPictureBox
            // 
            usuarioPictureBox.Image = Properties.Resources.icono_usuario;
            usuarioPictureBox.Location = new Point(17, 22);
            usuarioPictureBox.Margin = new Padding(4, 3, 4, 3);
            usuarioPictureBox.Name = "usuarioPictureBox";
            usuarioPictureBox.Size = new Size(21, 29);
            usuarioPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            usuarioPictureBox.TabIndex = 1;
            usuarioPictureBox.TabStop = false;
            // 
            // usuarioLabel
            // 
            usuarioLabel.AutoSize = true;
            usuarioLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            usuarioLabel.ForeColor = Color.Gainsboro;
            usuarioLabel.Location = new Point(52, 23);
            usuarioLabel.Margin = new Padding(4, 0, 4, 0);
            usuarioLabel.Name = "usuarioLabel";
            usuarioLabel.Size = new Size(75, 23);
            usuarioLabel.TabIndex = 0;
            usuarioLabel.Text = "Usuarios";
            // 
            // personaPanel
            // 
            personaPanel.Controls.Add(personaPictureBox);
            personaPanel.Controls.Add(personaLabel);
            personaPanel.Cursor = Cursors.Hand;
            personaPanel.Dock = DockStyle.Top;
            personaPanel.Location = new Point(0, 222);
            personaPanel.Margin = new Padding(4, 3, 4, 3);
            personaPanel.Name = "personaPanel";
            personaPanel.Size = new Size(292, 74);
            personaPanel.TabIndex = 3;
            personaPanel.Click += personaButton_Click;
            // 
            // personaPictureBox
            // 
            personaPictureBox.Image = Properties.Resources.icono_persona;
            personaPictureBox.Location = new Point(17, 22);
            personaPictureBox.Margin = new Padding(4, 3, 4, 3);
            personaPictureBox.Name = "personaPictureBox";
            personaPictureBox.Size = new Size(21, 29);
            personaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            personaPictureBox.TabIndex = 1;
            personaPictureBox.TabStop = false;
            // 
            // personaLabel
            // 
            personaLabel.AutoSize = true;
            personaLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            personaLabel.ForeColor = Color.Gainsboro;
            personaLabel.Location = new Point(52, 23);
            personaLabel.Margin = new Padding(4, 0, 4, 0);
            personaLabel.Name = "personaLabel";
            personaLabel.Size = new Size(77, 23);
            personaLabel.TabIndex = 0;
            personaLabel.Text = "Personas";
            // 
            // planPanel
            // 
            planPanel.Controls.Add(planPictureBox);
            planPanel.Controls.Add(planLabel);
            planPanel.Cursor = Cursors.Hand;
            planPanel.Dock = DockStyle.Top;
            planPanel.Location = new Point(0, 148);
            planPanel.Margin = new Padding(4, 3, 4, 3);
            planPanel.Name = "planPanel";
            planPanel.Size = new Size(292, 74);
            planPanel.TabIndex = 2;
            planPanel.Click += planButton_Click;
            // 
            // planPictureBox
            // 
            planPictureBox.Image = Properties.Resources.icono_plan;
            planPictureBox.Location = new Point(17, 22);
            planPictureBox.Margin = new Padding(4, 3, 4, 3);
            planPictureBox.Name = "planPictureBox";
            planPictureBox.Size = new Size(21, 29);
            planPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            planPictureBox.TabIndex = 1;
            planPictureBox.TabStop = false;
            // 
            // planLabel
            // 
            planLabel.AutoSize = true;
            planLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            planLabel.ForeColor = Color.Gainsboro;
            planLabel.Location = new Point(52, 23);
            planLabel.Margin = new Padding(4, 0, 4, 0);
            planLabel.Name = "planLabel";
            planLabel.Size = new Size(59, 23);
            planLabel.TabIndex = 0;
            planLabel.Text = "Planes";
            // 
            // especialidadPanel
            // 
            especialidadPanel.Controls.Add(especialidadPictureBox);
            especialidadPanel.Controls.Add(especialidadLabel);
            especialidadPanel.Cursor = Cursors.Hand;
            especialidadPanel.Dock = DockStyle.Top;
            especialidadPanel.Location = new Point(0, 74);
            especialidadPanel.Margin = new Padding(4, 3, 4, 3);
            especialidadPanel.Name = "especialidadPanel";
            especialidadPanel.Size = new Size(292, 74);
            especialidadPanel.TabIndex = 1;
            especialidadPanel.Click += especialidadButton_Click;
            // 
            // especialidadPictureBox
            // 
            especialidadPictureBox.Image = Properties.Resources.icono_especialidad;
            especialidadPictureBox.Location = new Point(17, 22);
            especialidadPictureBox.Margin = new Padding(4, 3, 4, 3);
            especialidadPictureBox.Name = "especialidadPictureBox";
            especialidadPictureBox.Size = new Size(21, 29);
            especialidadPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            especialidadPictureBox.TabIndex = 1;
            especialidadPictureBox.TabStop = false;
            // 
            // especialidadLabel
            // 
            especialidadLabel.AutoSize = true;
            especialidadLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            especialidadLabel.ForeColor = Color.Gainsboro;
            especialidadLabel.Location = new Point(52, 23);
            especialidadLabel.Margin = new Padding(4, 0, 4, 0);
            especialidadLabel.Name = "especialidadLabel";
            especialidadLabel.Size = new Size(119, 23);
            especialidadLabel.TabIndex = 0;
            especialidadLabel.Text = "Especialidades";
            // 
            // logoPanel
            // 
            logoPanel.Controls.Add(userInfoLabel);
            logoPanel.Controls.Add(logoLabel);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Margin = new Padding(4, 3, 4, 3);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(292, 74);
            logoPanel.TabIndex = 0;
            // 
            // userInfoLabel
            // 
            userInfoLabel.AutoSize = true;
            userInfoLabel.Font = new Font("Segoe UI", 9F);
            userInfoLabel.ForeColor = Color.LightGray;
            userInfoLabel.Location = new Point(9, 43);
            userInfoLabel.Margin = new Padding(4, 0, 4, 0);
            userInfoLabel.Name = "userInfoLabel";
            userInfoLabel.Size = new Size(66, 20);
            userInfoLabel.TabIndex = 1;
            userInfoLabel.Text = "Usuario: ";
            // 
            // logoLabel
            // 
            logoLabel.AutoSize = true;
            logoLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            logoLabel.ForeColor = Color.White;
            logoLabel.Location = new Point(55, 11);
            logoLabel.Margin = new Padding(4, 0, 4, 0);
            logoLabel.Name = "logoLabel";
            logoLabel.Size = new Size(168, 31);
            logoLabel.TabIndex = 0;
            logoLabel.Text = "Academia NET";
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(245, 247, 250);
            mainPanel.Controls.Add(welcomeLabel);
            mainPanel.Controls.Add(menuStrip1);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(292, 0);
            mainPanel.Margin = new Padding(4, 3, 4, 3);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(949, 806);
            mainPanel.TabIndex = 1;
            // 
            // welcomeLabel
            // 
            welcomeLabel.Anchor = AnchorStyles.None;
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            welcomeLabel.ForeColor = Color.DarkGray;
            welcomeLabel.Location = new Point(241, 379);
            welcomeLabel.Margin = new Padding(4, 0, 4, 0);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(468, 41);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Seleccione una opción del menú";
            //
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rendimientoPorCursoToolStripMenuItem,
            this.historialAcadémicoToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // rendimientoPorCursoToolStripMenuItem
            // 
            this.rendimientoPorCursoToolStripMenuItem.Name = "rendimientoPorCursoToolStripMenuItem";
            this.rendimientoPorCursoToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.rendimientoPorCursoToolStripMenuItem.Text = "Rendimiento por Curso";
            this.rendimientoPorCursoToolStripMenuItem.Click += new System.EventHandler(this.rendimientoPorCursoToolStripMenuItem_Click);
            // 
            // historialAcadémicoToolStripMenuItem
            // 
            this.historialAcadémicoToolStripMenuItem.Name = "historialAcadémicoToolStripMenuItem";
            this.historialAcadémicoToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.historialAcadémicoToolStripMenuItem.Text = "Historial Académico";
            this.historialAcadémicoToolStripMenuItem.Click += new System.EventHandler(this.historialAcadémicoToolStripMenuItem_Click);
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1241, 806);
            Controls.Add(mainPanel);
            Controls.Add(sideMenuPanel);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1195, 773);
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel de Administración";
            sideMenuPanel.ResumeLayout(false);
            cerrarSesionPanel.ResumeLayout(false);
            cerrarSesionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cerrarSesionPictureBox).EndInit();
            asignacionesPanel.ResumeLayout(false);
            asignacionesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)asignacionesPictureBox).EndInit();
            cursoPanel.ResumeLayout(false);
            cursoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cursoPictureBox).EndInit();
            comisionPanel.ResumeLayout(false);
            comisionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)comisionPictureBox).EndInit();
            materiaPanel.ResumeLayout(false);
            materiaPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)materiaPictureBox).EndInit();
            usuarioPanel.ResumeLayout(false);
            usuarioPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)usuarioPictureBox).EndInit();
            personaPanel.ResumeLayout(false);
            personaPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)personaPictureBox).EndInit();
            planPanel.ResumeLayout(false);
            planPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)planPictureBox).EndInit();
            especialidadPanel.ResumeLayout(false);
            especialidadPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)especialidadPictureBox).EndInit();
            logoPanel.ResumeLayout(false);
            logoPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel sideMenuPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Panel especialidadPanel;
        private System.Windows.Forms.PictureBox especialidadPictureBox;
        private System.Windows.Forms.Label especialidadLabel;
        private System.Windows.Forms.Panel planPanel;
        private System.Windows.Forms.PictureBox planPictureBox;
        private System.Windows.Forms.Label planLabel;
        private System.Windows.Forms.Panel personaPanel;
        private System.Windows.Forms.PictureBox personaPictureBox;
        private System.Windows.Forms.Label personaLabel;
        private System.Windows.Forms.Panel usuarioPanel;
        private System.Windows.Forms.PictureBox usuarioPictureBox;
        private System.Windows.Forms.Label usuarioLabel;
        private System.Windows.Forms.Panel cerrarSesionPanel;
        private System.Windows.Forms.PictureBox cerrarSesionPictureBox;
        private System.Windows.Forms.Label cerrarSesionLabel;
        private System.Windows.Forms.Panel materiaPanel;
        private System.Windows.Forms.PictureBox materiaPictureBox;
        private System.Windows.Forms.Label materiaLabel;
        private System.Windows.Forms.Panel comisionPanel;
        private System.Windows.Forms.PictureBox comisionPictureBox;
        private System.Windows.Forms.Label comisionLabel;
        private System.Windows.Forms.Panel cursoPanel;
        private System.Windows.Forms.PictureBox cursoPictureBox;
        private System.Windows.Forms.Label cursoLabel;
        private System.Windows.Forms.Panel asignacionesPanel;
        private System.Windows.Forms.PictureBox asignacionesPictureBox;
        private System.Windows.Forms.Label asignacionesLabel;
        private System.Windows.Forms.Label userInfoLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rendimientoPorCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialAcadémicoToolStripMenuItem;
    }
}