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
            this.materiaPanel = new System.Windows.Forms.Panel();
            this.materiaPictureBox = new System.Windows.Forms.PictureBox();
            this.materiaLabel = new System.Windows.Forms.Label();
            this.comisionPanel = new System.Windows.Forms.Panel();
            this.comisionPictureBox = new System.Windows.Forms.PictureBox();
            this.comisionLabel = new System.Windows.Forms.Label();
            this.cursoPanel = new System.Windows.Forms.Panel();
            this.cursoPictureBox = new System.Windows.Forms.PictureBox();
            this.cursoLabel = new System.Windows.Forms.Label();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.logoLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.sideMenuPanel.SuspendLayout();
            this.cerrarSesionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cerrarSesionPictureBox)).BeginInit();
            this.usuarioPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioPictureBox)).BeginInit();
            this.personaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personaPictureBox)).BeginInit();
            this.planPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planPictureBox)).BeginInit();
            this.especialidadPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadPictureBox)).BeginInit();
            this.materiaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materiaPictureBox)).BeginInit();
            this.comisionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comisionPictureBox)).BeginInit();
            this.cursoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursoPictureBox)).BeginInit();
            this.logoPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sideMenuPanel
            // 
            this.sideMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(110)))));
            this.sideMenuPanel.Controls.Add(this.cerrarSesionPanel);
            this.sideMenuPanel.Controls.Add(this.cursoPanel);
            this.sideMenuPanel.Controls.Add(this.comisionPanel);
            this.sideMenuPanel.Controls.Add(this.materiaPanel);
            this.sideMenuPanel.Controls.Add(this.usuarioPanel);
            this.sideMenuPanel.Controls.Add(this.personaPanel);
            this.sideMenuPanel.Controls.Add(this.planPanel);
            this.sideMenuPanel.Controls.Add(this.especialidadPanel);
            this.sideMenuPanel.Controls.Add(this.logoPanel);
            this.sideMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenuPanel.Location = new System.Drawing.Point(0, 0);
            this.sideMenuPanel.Name = "sideMenuPanel";
            this.sideMenuPanel.Size = new System.Drawing.Size(250, 600);
            this.sideMenuPanel.TabIndex = 0;
            // 
            // cerrarSesionPanel
            // 
            this.cerrarSesionPanel.Controls.Add(this.cerrarSesionPictureBox);
            this.cerrarSesionPanel.Controls.Add(this.cerrarSesionLabel);
            this.cerrarSesionPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrarSesionPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cerrarSesionPanel.Location = new System.Drawing.Point(0, 540);
            this.cerrarSesionPanel.Name = "cerrarSesionPanel";
            this.cerrarSesionPanel.Size = new System.Drawing.Size(250, 60);
            this.cerrarSesionPanel.TabIndex = 5;
            this.cerrarSesionPanel.Click += new System.EventHandler(this.cerrarSesionButton_Click);
            // 
            // cerrarSesionPictureBox
            // 
            this.cerrarSesionPictureBox.Image = global::WindowsForms.Properties.Resources.icono_logout;
            this.cerrarSesionPictureBox.Location = new System.Drawing.Point(20, 18);
            this.cerrarSesionPictureBox.Name = "cerrarSesionPictureBox";
            this.cerrarSesionPictureBox.Size = new System.Drawing.Size(24, 24);
            this.cerrarSesionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cerrarSesionPictureBox.TabIndex = 1;
            this.cerrarSesionPictureBox.TabStop = false;
            this.cerrarSesionPictureBox.Click += new System.EventHandler(this.cerrarSesionButton_Click);
            // 
            // cerrarSesionLabel
            // 
            this.cerrarSesionLabel.AutoSize = true;
            this.cerrarSesionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.cerrarSesionLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.cerrarSesionLabel.Location = new System.Drawing.Point(60, 19);
            this.cerrarSesionLabel.Name = "cerrarSesionLabel";
            this.cerrarSesionLabel.Size = new System.Drawing.Size(115, 23);
            this.cerrarSesionLabel.TabIndex = 0;
            this.cerrarSesionLabel.Text = "Cerrar Sesión";
            this.cerrarSesionLabel.Click += new System.EventHandler(this.cerrarSesionButton_Click);
            // 
            // usuarioPanel
            // 
            this.usuarioPanel.Controls.Add(this.usuarioPictureBox);
            this.usuarioPanel.Controls.Add(this.usuarioLabel);
            this.usuarioPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usuarioPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.usuarioPanel.Location = new System.Drawing.Point(0, 280);
            this.usuarioPanel.Name = "usuarioPanel";
            this.usuarioPanel.Size = new System.Drawing.Size(250, 60);
            this.usuarioPanel.TabIndex = 4;
            this.usuarioPanel.Click += new System.EventHandler(this.usuarioButton_Click);
            // 
            // usuarioPictureBox
            // 
            this.usuarioPictureBox.Image = global::WindowsForms.Properties.Resources.icono_usuario;
            this.usuarioPictureBox.Location = new System.Drawing.Point(20, 18);
            this.usuarioPictureBox.Name = "usuarioPictureBox";
            this.usuarioPictureBox.Size = new System.Drawing.Size(24, 24);
            this.usuarioPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.usuarioPictureBox.TabIndex = 1;
            this.usuarioPictureBox.TabStop = false;
            this.usuarioPictureBox.Click += new System.EventHandler(this.usuarioButton_Click);
            // 
            // usuarioLabel
            // 
            this.usuarioLabel.AutoSize = true;
            this.usuarioLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.usuarioLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.usuarioLabel.Location = new System.Drawing.Point(60, 19);
            this.usuarioLabel.Name = "usuarioLabel";
            this.usuarioLabel.Size = new System.Drawing.Size(76, 23);
            this.usuarioLabel.TabIndex = 0;
            this.usuarioLabel.Text = "Usuarios";
            this.usuarioLabel.Click += new System.EventHandler(this.usuarioButton_Click);
            // 
            // personaPanel
            // 
            this.personaPanel.Controls.Add(this.personaPictureBox);
            this.personaPanel.Controls.Add(this.personaLabel);
            this.personaPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.personaPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.personaPanel.Location = new System.Drawing.Point(0, 220);
            this.personaPanel.Name = "personaPanel";
            this.personaPanel.Size = new System.Drawing.Size(250, 60);
            this.personaPanel.TabIndex = 3;
            this.personaPanel.Click += new System.EventHandler(this.personaButton_Click);
            // 
            // personaPictureBox
            // 
            this.personaPictureBox.Image = global::WindowsForms.Properties.Resources.icono_persona;
            this.personaPictureBox.Location = new System.Drawing.Point(20, 18);
            this.personaPictureBox.Name = "personaPictureBox";
            this.personaPictureBox.Size = new System.Drawing.Size(24, 24);
            this.personaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.personaPictureBox.TabIndex = 1;
            this.personaPictureBox.TabStop = false;
            this.personaPictureBox.Click += new System.EventHandler(this.personaButton_Click);
            // 
            // personaLabel
            // 
            this.personaLabel.AutoSize = true;
            this.personaLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.personaLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.personaLabel.Location = new System.Drawing.Point(60, 19);
            this.personaLabel.Name = "personaLabel";
            this.personaLabel.Size = new System.Drawing.Size(78, 23);
            this.personaLabel.TabIndex = 0;
            this.personaLabel.Text = "Personas";
            this.personaLabel.Click += new System.EventHandler(this.personaButton_Click);
            // 
            // planPanel
            // 
            this.planPanel.Controls.Add(this.planPictureBox);
            this.planPanel.Controls.Add(this.planLabel);
            this.planPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.planPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.planPanel.Location = new System.Drawing.Point(0, 160);
            this.planPanel.Name = "planPanel";
            this.planPanel.Size = new System.Drawing.Size(250, 60);
            this.planPanel.TabIndex = 2;
            this.planPanel.Click += new System.EventHandler(this.planButton_Click);
            // 
            // planPictureBox
            // 
            this.planPictureBox.Image = global::WindowsForms.Properties.Resources.icono_plan;
            this.planPictureBox.Location = new System.Drawing.Point(20, 18);
            this.planPictureBox.Name = "planPictureBox";
            this.planPictureBox.Size = new System.Drawing.Size(24, 24);
            this.planPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.planPictureBox.TabIndex = 1;
            this.planPictureBox.TabStop = false;
            this.planPictureBox.Click += new System.EventHandler(this.planButton_Click);
            // 
            // planLabel
            // 
            this.planLabel.AutoSize = true;
            this.planLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.planLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.planLabel.Location = new System.Drawing.Point(60, 19);
            this.planLabel.Name = "planLabel";
            this.planLabel.Size = new System.Drawing.Size(59, 23);
            this.planLabel.TabIndex = 0;
            this.planLabel.Text = "Planes";
            this.planLabel.Click += new System.EventHandler(this.planButton_Click);
            // 
            // especialidadPanel
            // 
            this.especialidadPanel.Controls.Add(this.especialidadPictureBox);
            this.especialidadPanel.Controls.Add(this.especialidadLabel);
            this.especialidadPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.especialidadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.especialidadPanel.Location = new System.Drawing.Point(0, 100);
            this.especialidadPanel.Name = "especialidadPanel";
            this.especialidadPanel.Size = new System.Drawing.Size(250, 60);
            this.especialidadPanel.TabIndex = 1;
            this.especialidadPanel.Click += new System.EventHandler(this.especialidadButton_Click);
            // 
            // especialidadPictureBox
            // 
            this.especialidadPictureBox.Image = global::WindowsForms.Properties.Resources.icono_especialidad;
            this.especialidadPictureBox.Location = new System.Drawing.Point(20, 18);
            this.especialidadPictureBox.Name = "especialidadPictureBox";
            this.especialidadPictureBox.Size = new System.Drawing.Size(24, 24);
            this.especialidadPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.especialidadPictureBox.TabIndex = 1;
            this.especialidadPictureBox.TabStop = false;
            this.especialidadPictureBox.Click += new System.EventHandler(this.especialidadButton_Click);
            // 
            // especialidadLabel
            // 
            this.especialidadLabel.AutoSize = true;
            this.especialidadLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.especialidadLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.especialidadLabel.Location = new System.Drawing.Point(60, 19);
            this.especialidadLabel.Name = "especialidadLabel";
            this.especialidadLabel.Size = new System.Drawing.Size(121, 23);
            this.especialidadLabel.TabIndex = 0;
            this.especialidadLabel.Text = "Especialidades";
            this.especialidadLabel.Click += new System.EventHandler(this.especialidadButton_Click);
            //
            // materiaPanel
            //
            this.materiaPanel.Controls.Add(this.materiaPictureBox);
            this.materiaPanel.Controls.Add(this.materiaLabel);
            this.materiaPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materiaPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.materiaPanel.Location = new System.Drawing.Point(0, 340);
            this.materiaPanel.Name = "materiaPanel";
            this.materiaPanel.Size = new System.Drawing.Size(250, 60);
            this.materiaPanel.TabIndex = 6;
            this.materiaPanel.Click += new System.EventHandler(this.materiaButton_Click);
            //
            // materiaPictureBox
            //
            this.materiaPictureBox.Image = global::WindowsForms.Properties.Resources.icono_materia;
            this.materiaPictureBox.Location = new System.Drawing.Point(20, 18);
            this.materiaPictureBox.Name = "materiaPictureBox";
            this.materiaPictureBox.Size = new System.Drawing.Size(24, 24);
            this.materiaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.materiaPictureBox.TabIndex = 1;
            this.materiaPictureBox.TabStop = false;
            this.materiaPictureBox.Click += new System.EventHandler(this.materiaButton_Click);
            //
            // materiaLabel
            //
            this.materiaLabel.AutoSize = true;
            this.materiaLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.materiaLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.materiaLabel.Location = new System.Drawing.Point(60, 19);
            this.materiaLabel.Name = "materiaLabel";
            this.materiaLabel.Size = new System.Drawing.Size(76, 23);
            this.materiaLabel.TabIndex = 0;
            this.materiaLabel.Text = "Materias";
            this.materiaLabel.Click += new System.EventHandler(this.materiaButton_Click);
            //
            // comisionPanel
            //
            this.comisionPanel.Controls.Add(this.comisionPictureBox);
            this.comisionPanel.Controls.Add(this.comisionLabel);
            this.comisionPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comisionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.comisionPanel.Location = new System.Drawing.Point(0, 400); // Ajusta la posición
            this.comisionPanel.Name = "comisionPanel";
            this.comisionPanel.Size = new System.Drawing.Size(250, 60);
            this.comisionPanel.TabIndex = 7;
            this.comisionPanel.Click += new System.EventHandler(this.comisionButton_Click);
            //
            // comisionPictureBox
            //
            this.comisionPictureBox.Image = global::WindowsForms.Properties.Resources.icono_comision;
            this.comisionPictureBox.Location = new System.Drawing.Point(20, 18);
            this.comisionPictureBox.Name = "comisionPictureBox";
            this.comisionPictureBox.Size = new System.Drawing.Size(24, 24);
            this.comisionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.comisionPictureBox.TabIndex = 1;
            this.comisionPictureBox.TabStop = false;
            this.comisionPictureBox.Click += new System.EventHandler(this.comisionButton_Click);
            //
            // comisionLabel
            //
            this.comisionLabel.AutoSize = true;
            this.comisionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.comisionLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.comisionLabel.Location = new System.Drawing.Point(60, 19);
            this.comisionLabel.Name = "comisionLabel";
            this.comisionLabel.Size = new System.Drawing.Size(98, 23);
            this.comisionLabel.TabIndex = 0;
            this.comisionLabel.Text = "Comisiones";
            this.comisionLabel.Click += new System.EventHandler(this.comisionButton_Click);
            //
            // cursoPanel
            //
            this.cursoPanel.Controls.Add(this.cursoPictureBox);
            this.cursoPanel.Controls.Add(this.cursoLabel);
            this.cursoPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cursoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.cursoPanel.Location = new System.Drawing.Point(0, 460);
            this.cursoPanel.Name = "cursoPanel";
            this.cursoPanel.Size = new System.Drawing.Size(250, 60);
            this.cursoPanel.TabIndex = 8;
            this.cursoPanel.Click += new System.EventHandler(this.cursoButton_Click);
            //
            // cursoPictureBox
            //
            this.cursoPictureBox.Image = global::WindowsForms.Properties.Resources.icono_curso;
            this.cursoPictureBox.Location = new System.Drawing.Point(20, 18);
            this.cursoPictureBox.Name = "cursoPictureBox";
            this.cursoPictureBox.Size = new System.Drawing.Size(24, 24);
            this.cursoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cursoPictureBox.TabIndex = 1;
            this.cursoPictureBox.TabStop = false;
            this.cursoPictureBox.Click += new System.EventHandler(this.cursoButton_Click);
            //
            // cursoLabel
            //
            this.cursoLabel.AutoSize = true;
            this.cursoLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.cursoLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.cursoLabel.Location = new System.Drawing.Point(60, 19);
            this.cursoLabel.Name = "cursoLabel";
            this.cursoLabel.Size = new System.Drawing.Size(63, 23);
            this.cursoLabel.TabIndex = 0;
            this.cursoLabel.Text = "Cursos";
            this.cursoLabel.Click += new System.EventHandler(this.cursoButton_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.logoLabel);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(250, 100);
            this.logoPanel.TabIndex = 0;
            // 
            // logoLabel
            // 
            this.logoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(0, 0);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(250, 100);
            this.logoLabel.TabIndex = 0;
            this.logoLabel.Text = "Academia NET";
            this.logoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.mainPanel.Controls.Add(this.welcomeLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(250, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(750, 600);
            this.mainPanel.TabIndex = 1;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.welcomeLabel.ForeColor = System.Drawing.Color.DarkGray;
            this.welcomeLabel.Location = new System.Drawing.Point(140, 270);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(470, 41);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Seleccione una opción del menú";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sideMenuPanel);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Administración";
            this.sideMenuPanel.ResumeLayout(false);
            this.cerrarSesionPanel.ResumeLayout(false);
            this.cerrarSesionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cerrarSesionPictureBox)).EndInit();
            this.usuarioPanel.ResumeLayout(false);
            this.usuarioPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioPictureBox)).EndInit();
            this.personaPanel.ResumeLayout(false);
            this.personaPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personaPictureBox)).EndInit();
            this.planPanel.ResumeLayout(false);
            this.planPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planPictureBox)).EndInit();
            this.especialidadPanel.ResumeLayout(false);
            this.especialidadPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.especialidadPictureBox)).EndInit();
            this.logoPanel.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
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
    }
}