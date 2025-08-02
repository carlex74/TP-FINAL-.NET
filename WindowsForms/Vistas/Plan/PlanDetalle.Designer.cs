namespace WindowsForms.Vistas
{
    partial class PlanDetalle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DescripcionTextBox = new TextBox();
            IdTextBox = new TextBox();
            DescripcionLabel = new Label();
            IdLabel = new Label();
            cancelarButton = new Button();
            aceptarButton = new Button();
            IdEspecialidadTextBox = new TextBox();
            IdEspecialidadLabel = new Label();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // DescripcionTextBox
            // 
            DescripcionTextBox.Location = new Point(198, 101);
            DescripcionTextBox.Name = "DescripcionTextBox";
            DescripcionTextBox.Size = new Size(281, 27);
            DescripcionTextBox.TabIndex = 11;
            // 
            // IdTextBox
            // 
            IdTextBox.BackColor = SystemColors.Window;
            IdTextBox.Location = new Point(198, 32);
            IdTextBox.Name = "IdTextBox";
            IdTextBox.ReadOnly = true;
            IdTextBox.Size = new Size(65, 27);
            IdTextBox.TabIndex = 10;
            IdTextBox.TabStop = false;
            // 
            // DescripcionLabel
            // 
            DescripcionLabel.AutoSize = true;
            DescripcionLabel.Font = new Font("Segoe UI", 12F);
            DescripcionLabel.Location = new Point(27, 98);
            DescripcionLabel.Name = "DescripcionLabel";
            DescripcionLabel.Size = new Size(114, 28);
            DescripcionLabel.TabIndex = 9;
            DescripcionLabel.Text = "Descripcion";
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Font = new Font("Segoe UI", 12F);
            IdLabel.Location = new Point(27, 28);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(31, 28);
            IdLabel.TabIndex = 8;
            IdLabel.Text = "ID";
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(330, 235);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(149, 45);
            cancelarButton.TabIndex = 7;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(162, 235);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(149, 45);
            aceptarButton.TabIndex = 6;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // IdEspecialidadTextBox
            // 
            IdEspecialidadTextBox.BackColor = SystemColors.Window;
            IdEspecialidadTextBox.Location = new Point(198, 171);
            IdEspecialidadTextBox.Name = "IdEspecialidadTextBox";
            IdEspecialidadTextBox.Size = new Size(65, 27);
            IdEspecialidadTextBox.TabIndex = 13;
            // 
            // IdEspecialidadLabel
            // 
            IdEspecialidadLabel.AutoSize = true;
            IdEspecialidadLabel.Font = new Font("Segoe UI", 12F);
            IdEspecialidadLabel.Location = new Point(27, 169);
            IdEspecialidadLabel.Name = "IdEspecialidadLabel";
            IdEspecialidadLabel.Size = new Size(144, 28);
            IdEspecialidadLabel.TabIndex = 12;
            IdEspecialidadLabel.Text = "ID Especialidad";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // PlanDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 299);
            Controls.Add(IdEspecialidadTextBox);
            Controls.Add(IdEspecialidadLabel);
            Controls.Add(DescripcionTextBox);
            Controls.Add(IdTextBox);
            Controls.Add(DescripcionLabel);
            Controls.Add(IdLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Name = "PlanDetalle";
            Text = "PlanDetalle";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox DescripcionTextBox;
        private TextBox IdTextBox;
        private Label DescripcionLabel;
        private Label IdLabel;
        private Button cancelarButton;
        private Button aceptarButton;
        private TextBox IdEspecialidadTextBox;
        private Label IdEspecialidadLabel;
        private ErrorProvider errorProvider;
    }
}