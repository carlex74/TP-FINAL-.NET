namespace WindowsForms
{
    partial class PersonaDetalle
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
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.apellidoTextBox = new System.Windows.Forms.TextBox();
            this.apellidoLabel = new System.Windows.Forms.Label();
            this.dniTextBox = new System.Windows.Forms.TextBox();
            this.dniLabel = new System.Windows.Forms.Label();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.telefonoTextBox = new System.Windows.Forms.TextBox();
            this.telefonoLabel = new System.Windows.Forms.Label();
            this.direccionTextBox = new System.Windows.Forms.TextBox();
            this.direccionLabel = new System.Windows.Forms.Label();
            this.fechaNacimientoLabel = new System.Windows.Forms.Label();
            this.fechaNacimientoPicker = new System.Windows.Forms.DateTimePicker();
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
            this.topPanel.Size = new System.Drawing.Size(600, 60);
            this.topPanel.TabIndex = 10;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(25, 16);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(155, 28);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Nueva Persona";
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nombreLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nombreLabel.Location = new System.Drawing.Point(40, 145);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(67, 20);
            this.nombreLabel.TabIndex = 11;
            this.nombreLabel.Text = "Nombre:";
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nombreTextBox.Location = new System.Drawing.Point(44, 170);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(250, 27);
            this.nombreTextBox.TabIndex = 1;
            // 
            // aceptarButton
            // 
            this.aceptarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.aceptarButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aceptarButton.FlatAppearance.BorderSize = 0;
            this.aceptarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptarButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.aceptarButton.ForeColor = System.Drawing.Color.White;
            this.aceptarButton.Location = new System.Drawing.Point(344, 380);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(120, 32);
            this.aceptarButton.TabIndex = 8;
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
            this.cancelarButton.Location = new System.Drawing.Point(470, 380);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(120, 32);
            this.cancelarButton.TabIndex = 9;
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
            // apellidoTextBox
            // 
            this.apellidoTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.apellidoTextBox.Location = new System.Drawing.Point(304, 170);
            this.apellidoTextBox.Name = "apellidoTextBox";
            this.apellidoTextBox.Size = new System.Drawing.Size(250, 27);
            this.apellidoTextBox.TabIndex = 2;
            // 
            // apellidoLabel
            // 
            this.apellidoLabel.AutoSize = true;
            this.apellidoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.apellidoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.apellidoLabel.Location = new System.Drawing.Point(300, 145);
            this.apellidoLabel.Name = "apellidoLabel";
            this.apellidoLabel.Size = new System.Drawing.Size(69, 20);
            this.apellidoLabel.TabIndex = 14;
            this.apellidoLabel.Text = "Apellido:";
            // 
            // dniTextBox
            // 
            this.dniTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dniTextBox.Location = new System.Drawing.Point(44, 230);
            this.dniTextBox.Name = "dniTextBox";
            this.dniTextBox.Size = new System.Drawing.Size(250, 27);
            this.dniTextBox.TabIndex = 3;
            // 
            // dniLabel
            // 
            this.dniLabel.AutoSize = true;
            this.dniLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dniLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dniLabel.Location = new System.Drawing.Point(40, 205);
            this.dniLabel.Name = "dniLabel";
            this.dniLabel.Size = new System.Drawing.Size(39, 20);
            this.dniLabel.TabIndex = 16;
            this.dniLabel.Text = "DNI:";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.emailTextBox.Location = new System.Drawing.Point(44, 290);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(250, 27);
            this.emailTextBox.TabIndex = 5;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.emailLabel.Location = new System.Drawing.Point(40, 265);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(49, 20);
            this.emailLabel.TabIndex = 18;
            this.emailLabel.Text = "Email:";
            // 
            // telefonoTextBox
            // 
            this.telefonoTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.telefonoTextBox.Location = new System.Drawing.Point(304, 290);
            this.telefonoTextBox.Name = "telefonoTextBox";
            this.telefonoTextBox.Size = new System.Drawing.Size(250, 27);
            this.telefonoTextBox.TabIndex = 6;
            // 
            // telefonoLabel
            // 
            this.telefonoLabel.AutoSize = true;
            this.telefonoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.telefonoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.telefonoLabel.Location = new System.Drawing.Point(300, 265);
            this.telefonoLabel.Name = "telefonoLabel";
            this.telefonoLabel.Size = new System.Drawing.Size(67, 20);
            this.telefonoLabel.TabIndex = 20;
            this.telefonoLabel.Text = "Teléfono:";
            // 
            // direccionTextBox
            // 
            this.direccionTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.direccionTextBox.Location = new System.Drawing.Point(44, 350);
            this.direccionTextBox.Name = "direccionTextBox";
            this.direccionTextBox.Size = new System.Drawing.Size(510, 27);
            this.direccionTextBox.TabIndex = 7;
            // 
            // direccionLabel
            // 
            this.direccionLabel.AutoSize = true;
            this.direccionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.direccionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.direccionLabel.Location = new System.Drawing.Point(40, 325);
            this.direccionLabel.Name = "direccionLabel";
            this.direccionLabel.Size = new System.Drawing.Size(75, 20);
            this.direccionLabel.TabIndex = 22;
            this.direccionLabel.Text = "Dirección:";
            // 
            // fechaNacimientoLabel
            // 
            this.fechaNacimientoLabel.AutoSize = true;
            this.fechaNacimientoLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fechaNacimientoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fechaNacimientoLabel.Location = new System.Drawing.Point(300, 205);
            this.fechaNacimientoLabel.Name = "fechaNacimientoLabel";
            this.fechaNacimientoLabel.Size = new System.Drawing.Size(147, 20);
            this.fechaNacimientoLabel.TabIndex = 14;
            this.fechaNacimientoLabel.Text = "Fecha de Nacimiento:";
            // 
            // fechaNacimientoPicker
            // 
            this.fechaNacimientoPicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fechaNacimientoPicker.Location = new System.Drawing.Point(304, 230);
            this.fechaNacimientoPicker.Name = "fechaNacimientoPicker";
            this.fechaNacimientoPicker.Size = new System.Drawing.Size(250, 27);
            this.fechaNacimientoPicker.TabIndex = 4;
            // 
            // PersonaDetalle
            // 
            this.AcceptButton = this.aceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(600, 430);
            this.Controls.Add(this.fechaNacimientoPicker);
            this.Controls.Add(this.fechaNacimientoLabel);
            this.Controls.Add(this.direccionTextBox);
            this.Controls.Add(this.direccionLabel);
            this.Controls.Add(this.telefonoTextBox);
            this.Controls.Add(this.telefonoLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.dniTextBox);
            this.Controls.Add(this.dniLabel);
            this.Controls.Add(this.apellidoTextBox);
            this.Controls.Add(this.apellidoLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.nombreTextBox);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PersonaDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PersonaDetalle";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox dniTextBox;
        private System.Windows.Forms.Label dniLabel;
        private System.Windows.Forms.TextBox apellidoTextBox;
        private System.Windows.Forms.Label apellidoLabel;
        private System.Windows.Forms.DateTimePicker fechaNacimientoPicker;
        private System.Windows.Forms.Label fechaNacimientoLabel;
        private System.Windows.Forms.TextBox direccionTextBox;
        private System.Windows.Forms.Label direccionLabel;
        private System.Windows.Forms.TextBox telefonoTextBox;
        private System.Windows.Forms.Label telefonoLabel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
    }
}