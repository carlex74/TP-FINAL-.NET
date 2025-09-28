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
            sideMenuPanel = new Panel();
            cerrarSesionPanel = new Panel();
            cerrarSesionPictureBox = new PictureBox();
            cerrarSesionLabel = new Label();
            asignacionesPanel = new Panel();
            asignacionesPictureBox = new PictureBox();
            asignacionesLabel = new Label();
            cursoPanel = new Panel();
            cursoPictureBox = new PictureBox();
            cursoLabel = new Label();
            comisionPanel = new Panel();
            comisionPictureBox = new PictureBox();
            comisionLabel = new Label();
            materiaPanel = new Panel();
            materiaPictureBox = new PictureBox();
            materiaLabel = new Label();
            usuarioPanel = new Panel();
            usuarioPictureBox = new PictureBox();
            usuarioLabel = new Label();
            personaPanel = new Panel();
            personaPictureBox = new PictureBox();
            personaLabel = new Label();
            planPanel = new Panel();
            planPictureBox = new PictureBox();
            planLabel = new Label();
            especialidadPanel = new Panel();
            especialidadPictureBox = new PictureBox();
            especialidadLabel = new Label();
            logoPanel = new Panel();
            userInfoLabel = new Label();
            logoLabel = new Label();
            mainPanel = new Panel();
            welcomeLabel = new Label();
            sideMenuPanel.SuspendLayout();
            cerrarSesionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cerrarSesionPictureBox).BeginInit();
            asignacionesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)asignacionesPictureBox).BeginInit();
            cursoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cursoPictureBox).BeginInit();
            comisionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)comisionPictureBox).BeginInit();
            materiaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)materiaPictureBox).BeginInit();
            usuarioPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)usuarioPictureBox).BeginInit();
            personaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)personaPictureBox).BeginInit();
            planPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)planPictureBox).BeginInit();
            especialidadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)especialidadPictureBox).BeginInit();
            logoPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
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
            sideMenuPanel.Margin = new Padding(3, 4, 3, 4);
            sideMenuPanel.Name = "sideMenuPanel";
            sideMenuPanel.Size = new Size(343, 822);
            sideMenuPanel.TabIndex = 0;
            // 
            // cerrarSesionPanel
            // 
            cerrarSesionPanel.Controls.Add(cerrarSesionPictureBox);
            cerrarSesionPanel.Controls.Add(cerrarSesionLabel);
            cerrarSesionPanel.Cursor = Cursors.Hand;
            cerrarSesionPanel.Dock = DockStyle.Bottom;
            cerrarSesionPanel.Location = new Point(0, 747);
            cerrarSesionPanel.Margin = new Padding(3, 4, 3, 4);
            cerrarSesionPanel.Name = "cerrarSesionPanel";
            cerrarSesionPanel.Size = new Size(343, 75);
            cerrarSesionPanel.TabIndex = 9;
            cerrarSesionPanel.Click += cerrarSesionButton_Click;
            // 
            // cerrarSesionPictureBox
            // 
            cerrarSesionPictureBox.Image = Properties.Resources.icono_logout;
            cerrarSesionPictureBox.Location = new Point(20, 22);
            cerrarSesionPictureBox.Margin = new Padding(3, 4, 3, 4);
            cerrarSesionPictureBox.Name = "cerrarSesionPictureBox";
            cerrarSesionPictureBox.Size = new Size(24, 30);
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
            cerrarSesionLabel.Location = new Point(60, 24);
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
            asignacionesPanel.Location = new Point(0, 650);
            asignacionesPanel.Margin = new Padding(3, 4, 3, 4);
            asignacionesPanel.Name = "asignacionesPanel";
            asignacionesPanel.Size = new Size(343, 75);
            asignacionesPanel.TabIndex = 8;
            asignacionesPanel.Click += asignacionesButton_Click;
            // 
            // asignacionesPictureBox
            // 
            asignacionesPictureBox.Image = Properties.Resources.icono_docente_curso;
            asignacionesPictureBox.Location = new Point(20, 22);
            asignacionesPictureBox.Margin = new Padding(3, 4, 3, 4);
            asignacionesPictureBox.Name = "asignacionesPictureBox";
            asignacionesPictureBox.Size = new Size(24, 30);
            asignacionesPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            asignacionesPictureBox.TabIndex = 1;
            asignacionesPictureBox.TabStop = false;
            asignacionesPictureBox.Click += asignacionesButton_Click;
            // 
            // asignacionesLabel
            // 
            asignacionesLabel.AutoSize = true;
            asignacionesLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            asignacionesLabel.ForeColor = Color.Gainsboro;
            asignacionesLabel.Location = new Point(60, 24);
            asignacionesLabel.Name = "asignacionesLabel";
            asignacionesLabel.Size = new Size(255, 23);
            asignacionesLabel.TabIndex = 0;
            asignacionesLabel.Text = "Asignaciones Docentes a Cursos";
            asignacionesLabel.Click += asignacionesButton_Click;
            // 
            // cursoPanel
            // 
            cursoPanel.Controls.Add(cursoPictureBox);
            cursoPanel.Controls.Add(cursoLabel);
            cursoPanel.Cursor = Cursors.Hand;
            cursoPanel.Dock = DockStyle.Top;
            cursoPanel.Location = new Point(0, 575);
            cursoPanel.Margin = new Padding(3, 4, 3, 4);
            cursoPanel.Name = "cursoPanel";
            cursoPanel.Size = new Size(343, 75);
            cursoPanel.TabIndex = 7;
            cursoPanel.Click += cursoButton_Click;
            // 
            // cursoPictureBox
            // 
            cursoPictureBox.Image = Properties.Resources.icono_curso;
            cursoPictureBox.Location = new Point(20, 22);
            cursoPictureBox.Margin = new Padding(3, 4, 3, 4);
            cursoPictureBox.Name = "cursoPictureBox";
            cursoPictureBox.Size = new Size(24, 30);
            cursoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            cursoPictureBox.TabIndex = 1;
            cursoPictureBox.TabStop = false;
            cursoPictureBox.Click += cursoButton_Click;
            // 
            // cursoLabel
            // 
            cursoLabel.AutoSize = true;
            cursoLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            cursoLabel.ForeColor = Color.Gainsboro;
            cursoLabel.Location = new Point(60, 24);
            cursoLabel.Name = "cursoLabel";
            cursoLabel.Size = new Size(61, 23);
            cursoLabel.TabIndex = 0;
            cursoLabel.Text = "Cursos";
            cursoLabel.Click += cursoButton_Click;
            // 
            // comisionPanel
            // 
            comisionPanel.Controls.Add(comisionPictureBox);
            comisionPanel.Controls.Add(comisionLabel);
            comisionPanel.Cursor = Cursors.Hand;
            comisionPanel.Dock = DockStyle.Top;
            comisionPanel.Location = new Point(0, 500);
            comisionPanel.Margin = new Padding(3, 4, 3, 4);
            comisionPanel.Name = "comisionPanel";
            comisionPanel.Size = new Size(343, 75);
            comisionPanel.TabIndex = 6;
            comisionPanel.Click += comisionButton_Click;
            // 
            // comisionPictureBox
            // 
            comisionPictureBox.Image = Properties.Resources.icono_comision;
            comisionPictureBox.Location = new Point(20, 22);
            comisionPictureBox.Margin = new Padding(3, 4, 3, 4);
            comisionPictureBox.Name = "comisionPictureBox";
            comisionPictureBox.Size = new Size(24, 30);
            comisionPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            comisionPictureBox.TabIndex = 1;
            comisionPictureBox.TabStop = false;
            comisionPictureBox.Click += comisionButton_Click;
            // 
            // comisionLabel
            // 
            comisionLabel.AutoSize = true;
            comisionLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            comisionLabel.ForeColor = Color.Gainsboro;
            comisionLabel.Location = new Point(60, 24);
            comisionLabel.Name = "comisionLabel";
            comisionLabel.Size = new Size(97, 23);
            comisionLabel.TabIndex = 0;
            comisionLabel.Text = "Comisiones";
            comisionLabel.Click += comisionButton_Click;
            // 
            // materiaPanel
            // 
            materiaPanel.Controls.Add(materiaPictureBox);
            materiaPanel.Controls.Add(materiaLabel);
            materiaPanel.Cursor = Cursors.Hand;
            materiaPanel.Dock = DockStyle.Top;
            materiaPanel.Location = new Point(0, 425);
            materiaPanel.Margin = new Padding(3, 4, 3, 4);
            materiaPanel.Name = "materiaPanel";
            materiaPanel.Size = new Size(343, 75);
            materiaPanel.TabIndex = 5;
            materiaPanel.Click += materiaButton_Click;
            // 
            // materiaPictureBox
            // 
            materiaPictureBox.Image = Properties.Resources.icono_materia;
            materiaPictureBox.Location = new Point(20, 22);
            materiaPictureBox.Margin = new Padding(3, 4, 3, 4);
            materiaPictureBox.Name = "materiaPictureBox";
            materiaPictureBox.Size = new Size(24, 30);
            materiaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            materiaPictureBox.TabIndex = 1;
            materiaPictureBox.TabStop = false;
            materiaPictureBox.Click += materiaButton_Click;
            // 
            // materiaLabel
            // 
            materiaLabel.AutoSize = true;
            materiaLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            materiaLabel.ForeColor = Color.Gainsboro;
            materiaLabel.Location = new Point(60, 24);
            materiaLabel.Name = "materiaLabel";
            materiaLabel.Size = new Size(76, 23);
            materiaLabel.TabIndex = 0;
            materiaLabel.Text = "Materias";
            materiaLabel.Click += materiaButton_Click;
            // 
            // usuarioPanel
            // 
            usuarioPanel.Controls.Add(usuarioPictureBox);
            usuarioPanel.Controls.Add(usuarioLabel);
            usuarioPanel.Cursor = Cursors.Hand;
            usuarioPanel.Dock = DockStyle.Top;
            usuarioPanel.Location = new Point(0, 350);
            usuarioPanel.Margin = new Padding(3, 4, 3, 4);
            usuarioPanel.Name = "usuarioPanel";
            usuarioPanel.Size = new Size(343, 75);
            usuarioPanel.TabIndex = 4;
            usuarioPanel.Click += usuarioButton_Click;
            // 
            // usuarioPictureBox
            // 
            usuarioPictureBox.Image = Properties.Resources.icono_usuario;
            usuarioPictureBox.Location = new Point(20, 22);
            usuarioPictureBox.Margin = new Padding(3, 4, 3, 4);
            usuarioPictureBox.Name = "usuarioPictureBox";
            usuarioPictureBox.Size = new Size(24, 30);
            usuarioPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            usuarioPictureBox.TabIndex = 1;
            usuarioPictureBox.TabStop = false;
            usuarioPictureBox.Click += usuarioButton_Click;
            // 
            // usuarioLabel
            // 
            usuarioLabel.AutoSize = true;
            usuarioLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            usuarioLabel.ForeColor = Color.Gainsboro;
            usuarioLabel.Location = new Point(60, 24);
            usuarioLabel.Name = "usuarioLabel";
            usuarioLabel.Size = new Size(75, 23);
            usuarioLabel.TabIndex = 0;
            usuarioLabel.Text = "Usuarios";
            usuarioLabel.Click += usuarioButton_Click;
            // 
            // personaPanel
            // 
            personaPanel.Controls.Add(personaPictureBox);
            personaPanel.Controls.Add(personaLabel);
            personaPanel.Cursor = Cursors.Hand;
            personaPanel.Dock = DockStyle.Top;
            personaPanel.Location = new Point(0, 275);
            personaPanel.Margin = new Padding(3, 4, 3, 4);
            personaPanel.Name = "personaPanel";
            personaPanel.Size = new Size(343, 75);
            personaPanel.TabIndex = 3;
            personaPanel.Click += personaButton_Click;
            // 
            // personaPictureBox
            // 
            personaPictureBox.Image = Properties.Resources.icono_persona;
            personaPictureBox.Location = new Point(20, 22);
            personaPictureBox.Margin = new Padding(3, 4, 3, 4);
            personaPictureBox.Name = "personaPictureBox";
            personaPictureBox.Size = new Size(24, 30);
            personaPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            personaPictureBox.TabIndex = 1;
            personaPictureBox.TabStop = false;
            personaPictureBox.Click += personaButton_Click;
            // 
            // personaLabel
            // 
            personaLabel.AutoSize = true;
            personaLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            personaLabel.ForeColor = Color.Gainsboro;
            personaLabel.Location = new Point(60, 24);
            personaLabel.Name = "personaLabel";
            personaLabel.Size = new Size(77, 23);
            personaLabel.TabIndex = 0;
            personaLabel.Text = "Personas";
            personaLabel.Click += personaButton_Click;
            // 
            // planPanel
            // 
            planPanel.Controls.Add(planPictureBox);
            planPanel.Controls.Add(planLabel);
            planPanel.Cursor = Cursors.Hand;
            planPanel.Dock = DockStyle.Top;
            planPanel.Location = new Point(0, 200);
            planPanel.Margin = new Padding(3, 4, 3, 4);
            planPanel.Name = "planPanel";
            planPanel.Size = new Size(343, 75);
            planPanel.TabIndex = 2;
            planPanel.Click += planButton_Click;
            // 
            // planPictureBox
            // 
            planPictureBox.Image = Properties.Resources.icono_plan;
            planPictureBox.Location = new Point(20, 22);
            planPictureBox.Margin = new Padding(3, 4, 3, 4);
            planPictureBox.Name = "planPictureBox";
            planPictureBox.Size = new Size(24, 30);
            planPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            planPictureBox.TabIndex = 1;
            planPictureBox.TabStop = false;
            planPictureBox.Click += planButton_Click;
            // 
            // planLabel
            // 
            planLabel.AutoSize = true;
            planLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            planLabel.ForeColor = Color.Gainsboro;
            planLabel.Location = new Point(60, 24);
            planLabel.Name = "planLabel";
            planLabel.Size = new Size(59, 23);
            planLabel.TabIndex = 0;
            planLabel.Text = "Planes";
            planLabel.Click += planButton_Click;
            // 
            // especialidadPanel
            // 
            especialidadPanel.Controls.Add(especialidadPictureBox);
            especialidadPanel.Controls.Add(especialidadLabel);
            especialidadPanel.Cursor = Cursors.Hand;
            especialidadPanel.Dock = DockStyle.Top;
            especialidadPanel.Location = new Point(0, 125);
            especialidadPanel.Margin = new Padding(3, 4, 3, 4);
            especialidadPanel.Name = "especialidadPanel";
            especialidadPanel.Size = new Size(343, 75);
            especialidadPanel.TabIndex = 1;
            especialidadPanel.Click += especialidadButton_Click;
            // 
            // especialidadPictureBox
            // 
            especialidadPictureBox.Image = Properties.Resources.icono_especialidad;
            especialidadPictureBox.Location = new Point(20, 22);
            especialidadPictureBox.Margin = new Padding(3, 4, 3, 4);
            especialidadPictureBox.Name = "especialidadPictureBox";
            especialidadPictureBox.Size = new Size(24, 30);
            especialidadPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            especialidadPictureBox.TabIndex = 1;
            especialidadPictureBox.TabStop = false;
            especialidadPictureBox.Click += especialidadButton_Click;
            // 
            // especialidadLabel
            // 
            especialidadLabel.AutoSize = true;
            especialidadLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            especialidadLabel.ForeColor = Color.Gainsboro;
            especialidadLabel.Location = new Point(60, 24);
            especialidadLabel.Name = "especialidadLabel";
            especialidadLabel.Size = new Size(119, 23);
            especialidadLabel.TabIndex = 0;
            especialidadLabel.Text = "Especialidades";
            especialidadLabel.Click += especialidadButton_Click;
            // 
            // logoPanel
            // 
            logoPanel.Controls.Add(userInfoLabel);
            logoPanel.Controls.Add(logoLabel);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Margin = new Padding(3, 4, 3, 4);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(343, 125);
            logoPanel.TabIndex = 0;
            // 
            // userInfoLabel
            // 
            userInfoLabel.AutoSize = true;
            userInfoLabel.Font = new Font("Segoe UI", 9F);
            userInfoLabel.ForeColor = Color.LightGray;
            userInfoLabel.Location = new Point(12, 81);
            userInfoLabel.Name = "userInfoLabel";
            userInfoLabel.Size = new Size(66, 20);
            userInfoLabel.TabIndex = 1;
            userInfoLabel.Text = "Usuario: ";
            // 
            // logoLabel
            // 
            logoLabel.Dock = DockStyle.Top;
            logoLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoLabel.ForeColor = Color.White;
            logoLabel.Location = new Point(0, 0);
            logoLabel.Name = "logoLabel";
            logoLabel.Size = new Size(343, 75);
            logoLabel.TabIndex = 0;
            logoLabel.Text = "Academia NET";
            logoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(245, 247, 250);
            mainPanel.Controls.Add(welcomeLabel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(343, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(983, 822);
            mainPanel.TabIndex = 1;
            // 
            // welcomeLabel
            // 
            welcomeLabel.Anchor = AnchorStyles.None;
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            welcomeLabel.ForeColor = Color.DarkGray;
            welcomeLabel.Location = new Point(256, 374);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(468, 41);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Seleccione una opción del menú";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1326, 822);
            Controls.Add(mainPanel);
            Controls.Add(sideMenuPanel);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1000, 738);
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
    }
}