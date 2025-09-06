namespace WindowsForms
{
    partial class EnConstruccionForm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.constructionPictureBox = new System.Windows.Forms.PictureBox();
            this.cerrarSesionButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constructionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 60);
            this.topPanel.TabIndex = 11;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(25, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(201, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Portal de Usuario";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.subtitleLabel);
            this.mainPanel.Controls.Add(this.constructionPictureBox);
            this.mainPanel.Controls.Add(this.cerrarSesionButton);
            this.mainPanel.Controls.Add(this.welcomeLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 390);
            this.mainPanel.TabIndex = 12;
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subtitleLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.subtitleLabel.Location = new System.Drawing.Point(200, 240);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(400, 23);
            this.subtitleLabel.TabIndex = 3;
            this.subtitleLabel.Text = "Estamos trabajando para traerte nuevas funcionalidades.";
            this.subtitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // constructionPictureBox
            // 
            this.constructionPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.constructionPictureBox.Image = global::WindowsForms.Properties.Resources.icono_construccion;
            this.constructionPictureBox.Location = new System.Drawing.Point(350, 80);
            this.constructionPictureBox.Name = "constructionPictureBox";
            this.constructionPictureBox.Size = new System.Drawing.Size(100, 100);
            this.constructionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.constructionPictureBox.TabIndex = 2;
            this.constructionPictureBox.TabStop = false;
            // 
            // cerrarSesionButton
            // 
            this.cerrarSesionButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cerrarSesionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.cerrarSesionButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrarSesionButton.FlatAppearance.BorderSize = 0;
            this.cerrarSesionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cerrarSesionButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cerrarSesionButton.ForeColor = System.Drawing.Color.White;
            this.cerrarSesionButton.Location = new System.Drawing.Point(325, 290);
            this.cerrarSesionButton.Name = "cerrarSesionButton";
            this.cerrarSesionButton.Size = new System.Drawing.Size(150, 32);
            this.cerrarSesionButton.TabIndex = 1;
            this.cerrarSesionButton.Text = "CERRAR SESIÓN";
            this.cerrarSesionButton.UseVisualStyleBackColor = false;
            this.cerrarSesionButton.Click += new System.EventHandler(this.cerrarSesionButton_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.welcomeLabel.Location = new System.Drawing.Point(200, 190);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(400, 38);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "¡Página en Construcción!";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnConstruccionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EnConstruccionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnConstruccionForm";
            this.Load += new System.EventHandler(this.EnConstruccionForm_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.constructionPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button cerrarSesionButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.PictureBox constructionPictureBox;
        private System.Windows.Forms.Label subtitleLabel;
    }
}