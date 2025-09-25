namespace WindowsForms
{
    partial class UsuarioDetalle
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
            this.legajoLabel = new System.Windows.Forms.Label();
            this.legajoTextBox = new System.Windows.Forms.TextBox();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.claveTextBox = new System.Windows.Forms.TextBox();
            this.claveLabel = new System.Windows.Forms.Label();
            this.tipoLabel = new System.Windows.Forms.Label();
            this.tipoComboBox = new System.Windows.Forms.ComboBox();
            this.personaLabel = new System.Windows.Forms.Label();
            this.personaComboBox = new System.Windows.Forms.ComboBox();
            this.habilitadoCheckBox = new System.Windows.Forms.CheckBox();
            this.planLabel = new System.Windows.Forms.Label();
            this.planComboBox = new System.Windows.Forms.ComboBox();
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
            this.titleLabel.Size = new System.Drawing.Size(150, 28);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Nuevo Usuario";
            // 
            // legajoLabel
            // 
            this.legajoLabel.AutoSize = true;
            this.legajoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.legajoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.legajoLabel.Location = new System.Drawing.Point(40, 85);
            this.legajoLabel.Name = "legajoLabel";
            this.legajoLabel.Size = new System.Drawing.Size(55, 20);
            this.legajoLabel.TabIndex = 11;
            this.legajoLabel.Text = "Legajo:";
            // 
            // legajoTextBox
            // 
            this.legajoTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.legajoTextBox.Location = new System.Drawing.Point(44, 110);
            this.legajoTextBox.Name = "legajoTextBox";
            this.legajoTextBox.Size = new System.Drawing.Size(360, 27);
            this.legajoTextBox.TabIndex = 0;
            // 
            // aceptarButton
            // 
            this.aceptarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.aceptarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aceptarButton.FlatAppearance.BorderSize = 0;
            this.aceptarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptarButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.aceptarButton.ForeColor = System.Drawing.Color.White;
            this.aceptarButton.Location = new System.Drawing.Point(194, 440);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(120, 32);
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
            this.cancelarButton.Location = new System.Drawing.Point(320, 440);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(120, 32);
            this.cancelarButton.TabIndex = 7;
            this.cancelarButton.Text = "CANCELAR";
            this.cancelarButton.UseVisualStyleBackColor = false;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // claveTextBox
            // 
            this.claveTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.claveTextBox.Location = new System.Drawing.Point(44, 170);
            this.claveTextBox.Name = "claveTextBox";
            this.claveTextBox.Size = new System.Drawing.Size(360, 27);
            this.claveTextBox.TabIndex = 1;
            this.claveTextBox.UseSystemPasswordChar = true;
            // 
            // claveLabel
            // 
            this.claveLabel.AutoSize = true;
            this.claveLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.claveLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.claveLabel.Location = new System.Drawing.Point(40, 145);
            this.claveLabel.Name = "claveLabel";
            this.claveLabel.Size = new System.Drawing.Size(86, 20);
            this.claveLabel.TabIndex = 14;
            this.claveLabel.Text = "Contraseña:";
            // 
            // tipoLabel
            // 
            this.tipoLabel.AutoSize = true;
            this.tipoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tipoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tipoLabel.Location = new System.Drawing.Point(40, 205);
            this.tipoLabel.Name = "tipoLabel";
            this.tipoLabel.Size = new System.Drawing.Size(40, 20);
            this.tipoLabel.TabIndex = 16;
            this.tipoLabel.Text = "Tipo:";
            // 
            // tipoComboBox
            // 
            this.tipoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tipoComboBox.FormattingEnabled = true;
            this.tipoComboBox.Location = new System.Drawing.Point(44, 230);
            this.tipoComboBox.Name = "tipoComboBox";
            this.tipoComboBox.Size = new System.Drawing.Size(360, 28);
            this.tipoComboBox.TabIndex = 2;
            this.tipoComboBox.SelectedIndexChanged += new System.EventHandler(this.tipoComboBox_SelectedIndexChanged);
            // 
            // personaLabel
            // 
            this.personaLabel.AutoSize = true;
            this.personaLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.personaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.personaLabel.Location = new System.Drawing.Point(40, 265);
            this.personaLabel.Name = "personaLabel";
            this.personaLabel.Size = new System.Drawing.Size(63, 20);
            this.personaLabel.TabIndex = 18;
            this.personaLabel.Text = "Persona:";
            // 
            // personaComboBox
            // 
            this.personaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.personaComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.personaComboBox.FormattingEnabled = true;
            this.personaComboBox.Location = new System.Drawing.Point(44, 290);
            this.personaComboBox.Name = "personaComboBox";
            this.personaComboBox.Size = new System.Drawing.Size(360, 28);
            this.personaComboBox.TabIndex = 3;
            // 
            // habilitadoCheckBox
            // 
            this.habilitadoCheckBox.AutoSize = true;
            this.habilitadoCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.habilitadoCheckBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.habilitadoCheckBox.Location = new System.Drawing.Point(44, 388);
            this.habilitadoCheckBox.Name = "habilitadoCheckBox";
            this.habilitadoCheckBox.Size = new System.Drawing.Size(99, 24);
            this.habilitadoCheckBox.TabIndex = 5;
            this.habilitadoCheckBox.Text = "Habilitado";
            this.habilitadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // planLabel
            // 
            this.planLabel.AutoSize = true;
            this.planLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.planLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.planLabel.Location = new System.Drawing.Point(40, 325);
            this.planLabel.Name = "planLabel";
            this.planLabel.Size = new System.Drawing.Size(40, 20);
            this.planLabel.TabIndex = 20;
            this.planLabel.Text = "Plan:";
            this.planLabel.Visible = false;
            // 
            // planComboBox
            // 
            this.planComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.planComboBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.planComboBox.FormattingEnabled = true;
            this.planComboBox.Location = new System.Drawing.Point(44, 350);
            this.planComboBox.Name = "planComboBox";
            this.planComboBox.Size = new System.Drawing.Size(360, 28);
            this.planComboBox.TabIndex = 4;
            this.planComboBox.Visible = false;
            // 
            // UsuarioDetalle
            // 
            this.AcceptButton = this.aceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(450, 500);
            this.Controls.Add(this.planComboBox);
            this.Controls.Add(this.planLabel);
            this.Controls.Add(this.habilitadoCheckBox);
            this.Controls.Add(this.personaComboBox);
            this.Controls.Add(this.personaLabel);
            this.Controls.Add(this.tipoComboBox);
            this.Controls.Add(this.tipoLabel);
            this.Controls.Add(this.claveTextBox);
            this.Controls.Add(this.claveLabel);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.legajoTextBox);
            this.Controls.Add(this.legajoLabel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UsuarioDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UsuarioDetalle";
            this.Load += new System.EventHandler(this.UsuarioDetalle_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label legajoLabel;
        private System.Windows.Forms.TextBox legajoTextBox;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ComboBox personaComboBox;
        private System.Windows.Forms.Label personaLabel;
        private System.Windows.Forms.ComboBox tipoComboBox;
        private System.Windows.Forms.Label tipoLabel;
        private System.Windows.Forms.TextBox claveTextBox;
        private System.Windows.Forms.Label claveLabel;
        private System.Windows.Forms.CheckBox habilitadoCheckBox;
        private System.Windows.Forms.ComboBox planComboBox;
        private System.Windows.Forms.Label planLabel;
    }
}