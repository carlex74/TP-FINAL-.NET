namespace WindowsForms.Vistas.Curso
{
    partial class CursoDetalle
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
            this.components = new System.ComponentModel.Container();
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.descripcionLabel = new System.Windows.Forms.Label();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.anioLabel = new System.Windows.Forms.Label();
            this.anioTextBox = new System.Windows.Forms.TextBox();
            this.cupoTextBox = new System.Windows.Forms.TextBox();
            this.cupoLabel = new System.Windows.Forms.Label();
            this.materiaComboBox = new System.Windows.Forms.ComboBox();
            this.materiaLabel = new System.Windows.Forms.Label();
            this.comisionComboBox = new System.Windows.Forms.ComboBox();
            this.comisionLabel = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(450, 60);
            this.topPanel.TabIndex = 10;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(25, 16);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(133, 28);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Nuevo Curso";
            // 
            // descripcionLabel
            // 
            this.descripcionLabel.AutoSize = true;
            this.descripcionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.descripcionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.descripcionLabel.Location = new System.Drawing.Point(40, 205);
            this.descripcionLabel.Name = "descripcionLabel";
            this.descripcionLabel.Size = new System.Drawing.Size(91, 20);
            this.descripcionLabel.TabIndex = 11;
            this.descripcionLabel.Text = "Descripción:";
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.descripcionTextBox.Location = new System.Drawing.Point(44, 230);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(360, 27);
            this.descripcionTextBox.TabIndex = 3;
            // 
            // aceptarButton
            // 
            this.aceptarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.aceptarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aceptarButton.FlatAppearance.BorderSize = 0;
            this.aceptarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptarButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.aceptarButton.ForeColor = System.Drawing.Color.White;
            this.aceptarButton.Location = new System.Drawing.Point(194, 450);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(100, 32);
            this.aceptarButton.TabIndex = 6;
            this.aceptarButton.Text = "ACEPTAR";
            this.aceptarButton.UseVisualStyleBackColor = false;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.cancelarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.FlatAppearance.BorderSize = 0;
            this.cancelarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelarButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cancelarButton.ForeColor = System.Drawing.Color.White;
            this.cancelarButton.Location = new System.Drawing.Point(300, 450);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(100, 32);
            this.cancelarButton.TabIndex = 7;
            this.cancelarButton.Text = "CANCELAR";
            this.cancelarButton.UseVisualStyleBackColor = false;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.idLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.idLabel.Location = new System.Drawing.Point(40, 85);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(27, 20);
            this.idLabel.TabIndex = 12;
            this.idLabel.Text = "ID:";
            // 
            // idTextBox
            // 
            this.idTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.idTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.idTextBox.Location = new System.Drawing.Point(44, 110);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.ReadOnly = true;
            this.idTextBox.Size = new System.Drawing.Size(100, 27);
            this.idTextBox.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // anioLabel
            // 
            this.anioLabel.AutoSize = true;
            this.anioLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.anioLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.anioLabel.Location = new System.Drawing.Point(40, 145);
            this.anioLabel.Name = "anioLabel";
            this.anioLabel.Size = new System.Drawing.Size(117, 20);
            this.anioLabel.TabIndex = 14;
            this.anioLabel.Text = "Año Calendario:";
            // 
            // anioTextBox
            // 
            this.anioTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.anioTextBox.Location = new System.Drawing.Point(44, 170);
            this.anioTextBox.Name = "anioTextBox";
            this.anioTextBox.Size = new System.Drawing.Size(160, 27);
            this.anioTextBox.TabIndex = 1;
            // 
            // cupoTextBox
            // 
            this.cupoTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cupoTextBox.Location = new System.Drawing.Point(244, 170);
            this.cupoTextBox.Name = "cupoTextBox";
            this.cupoTextBox.Size = new System.Drawing.Size(160, 27);
            this.cupoTextBox.TabIndex = 2;
            // 
            // cupoLabel
            // 
            this.cupoLabel.AutoSize = true;
            this.cupoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cupoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cupoLabel.Location = new System.Drawing.Point(240, 145);
            this.cupoLabel.Name = "cupoLabel";
            this.cupoLabel.Size = new System.Drawing.Size(47, 20);
            this.cupoLabel.TabIndex = 16;
            this.cupoLabel.Text = "Cupo:";
            // 
            // materiaComboBox
            // 
            this.materiaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materiaComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.materiaComboBox.FormattingEnabled = true;
            this.materiaComboBox.Location = new System.Drawing.Point(44, 290);
            this.materiaComboBox.Name = "materiaComboBox";
            this.materiaComboBox.Size = new System.Drawing.Size(360, 28);
            this.materiaComboBox.TabIndex = 4;
            // 
            // materiaLabel
            // 
            this.materiaLabel.AutoSize = true;
            this.materiaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.materiaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.materiaLabel.Location = new System.Drawing.Point(40, 265);
            this.materiaLabel.Name = "materiaLabel";
            this.materiaLabel.Size = new System.Drawing.Size(63, 20);
            this.materiaLabel.TabIndex = 18;
            this.materiaLabel.Text = "Materia:";
            // 
            // comisionComboBox
            // 
            this.comisionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comisionComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comisionComboBox.FormattingEnabled = true;
            this.comisionComboBox.Location = new System.Drawing.Point(44, 350);
            this.comisionComboBox.Name = "comisionComboBox";
            this.comisionComboBox.Size = new System.Drawing.Size(360, 28);
            this.comisionComboBox.TabIndex = 5;
            // 
            // comisionLabel
            // 
            this.comisionLabel.AutoSize = true;
            this.comisionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comisionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comisionLabel.Location = new System.Drawing.Point(40, 325);
            this.comisionLabel.Name = "comisionLabel";
            this.comisionLabel.Size = new System.Drawing.Size(74, 20);
            this.comisionLabel.TabIndex = 20;
            this.comisionLabel.Text = "Comisión:";
            // 
            // CursoDetalle
            // 
            this.AcceptButton = this.aceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(450, 500);
            this.Controls.Add(this.comisionComboBox);
            this.Controls.Add(this.comisionLabel);
            this.Controls.Add(this.materiaComboBox);
            this.Controls.Add(this.materiaLabel);
            this.Controls.Add(this.cupoTextBox);
            this.Controls.Add(this.cupoLabel);
            this.Controls.Add(this.anioTextBox);
            this.Controls.Add(this.anioLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.descripcionTextBox);
            this.Controls.Add(this.descripcionLabel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CursoDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CursoDetalle";
            this.Load += new System.EventHandler(this.CursoDetalle_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label descripcionLabel;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label anioLabel;
        private System.Windows.Forms.TextBox anioTextBox;
        private System.Windows.Forms.TextBox cupoTextBox;
        private System.Windows.Forms.Label cupoLabel;
        private System.Windows.Forms.ComboBox comisionComboBox;
        private System.Windows.Forms.Label comisionLabel;
        private System.Windows.Forms.ComboBox materiaComboBox;
        private System.Windows.Forms.Label materiaLabel;
    }
}