namespace WindowsForms
{
    partial class DocenteCursoDetalle
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
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.docenteLabel = new System.Windows.Forms.Label();
            this.docenteComboBox = new System.Windows.Forms.ComboBox();
            this.cursoLabel = new System.Windows.Forms.Label();
            this.cursoComboBox = new System.Windows.Forms.ComboBox();
            this.cargoLabel = new System.Windows.Forms.Label();
            this.cargoComboBox = new System.Windows.Forms.ComboBox();
            this.topPanel.SuspendLayout();
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
            this.topPanel.TabIndex = 11;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(25, 16);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(188, 28);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Nueva Asignación";
            // 
            // aceptarButton
            // 
            this.aceptarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.aceptarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aceptarButton.FlatAppearance.BorderSize = 0;
            this.aceptarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptarButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.aceptarButton.ForeColor = System.Drawing.Color.White;
            this.aceptarButton.Location = new System.Drawing.Point(194, 300);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(120, 32);
            this.aceptarButton.TabIndex = 3;
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
            this.cancelarButton.Location = new System.Drawing.Point(320, 300);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(120, 32);
            this.cancelarButton.TabIndex = 4;
            this.cancelarButton.Text = "CANCELAR";
            this.cancelarButton.UseVisualStyleBackColor = false;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // docenteLabel
            // 
            this.docenteLabel.AutoSize = true;
            this.docenteLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.docenteLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.docenteLabel.Location = new System.Drawing.Point(40, 85);
            this.docenteLabel.Name = "docenteLabel";
            this.docenteLabel.Size = new System.Drawing.Size(68, 20);
            this.docenteLabel.TabIndex = 13;
            this.docenteLabel.Text = "Docente:";
            // 
            // docenteComboBox
            // 
            this.docenteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.docenteComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.docenteComboBox.FormattingEnabled = true;
            this.docenteComboBox.Location = new System.Drawing.Point(44, 110);
            this.docenteComboBox.Name = "docenteComboBox";
            this.docenteComboBox.Size = new System.Drawing.Size(360, 28);
            this.docenteComboBox.TabIndex = 0;
            // 
            // cursoLabel
            // 
            this.cursoLabel.AutoSize = true;
            this.cursoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cursoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cursoLabel.Location = new System.Drawing.Point(40, 145);
            this.cursoLabel.Name = "cursoLabel";
            this.cursoLabel.Size = new System.Drawing.Size(49, 20);
            this.cursoLabel.TabIndex = 15;
            this.cursoLabel.Text = "Curso:";
            // 
            // cursoComboBox
            // 
            this.cursoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cursoComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cursoComboBox.FormattingEnabled = true;
            this.cursoComboBox.Location = new System.Drawing.Point(44, 170);
            this.cursoComboBox.Name = "cursoComboBox";
            this.cursoComboBox.Size = new System.Drawing.Size(360, 28);
            this.cursoComboBox.TabIndex = 1;
            // 
            // cargoLabel
            // 
            this.cargoLabel.AutoSize = true;
            this.cargoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cargoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cargoLabel.Location = new System.Drawing.Point(40, 205);
            this.cargoLabel.Name = "cargoLabel";
            this.cargoLabel.Size = new System.Drawing.Size(52, 20);
            this.cargoLabel.TabIndex = 17;
            this.cargoLabel.Text = "Cargo:";
            // 
            // cargoComboBox
            // 
            this.cargoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cargoComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cargoComboBox.FormattingEnabled = true;
            this.cargoComboBox.Location = new System.Drawing.Point(44, 230);
            this.cargoComboBox.Name = "cargoComboBox";
            this.cargoComboBox.Size = new System.Drawing.Size(360, 28);
            this.cargoComboBox.TabIndex = 2;
            // 
            // DocenteCursoDetalle
            // 
            this.AcceptButton = this.aceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(450, 360);
            this.Controls.Add(this.cargoComboBox);
            this.Controls.Add(this.cargoLabel);
            this.Controls.Add(this.cursoComboBox);
            this.Controls.Add(this.cursoLabel);
            this.Controls.Add(this.docenteComboBox);
            this.Controls.Add(this.docenteLabel);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DocenteCursoDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DocenteCursoDetalle";
            this.Load += new System.EventHandler(this.DocenteCursoDetalle_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Label docenteLabel;
        private System.Windows.Forms.ComboBox docenteComboBox;
        private System.Windows.Forms.Label cursoLabel;
        private System.Windows.Forms.ComboBox cursoComboBox;
        private System.Windows.Forms.Label cargoLabel;
        private System.Windows.Forms.ComboBox cargoComboBox;
    }
}