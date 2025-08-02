namespace WindowsForms
{
    partial class EspecialidadDetalle
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            aceptarButton = new Button();
            cancelarButton = new Button();
            IdLabel = new Label();
            DescripcionLabel = new Label();
            IdTextBox = new TextBox();
            DescripcionTextBox = new TextBox();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(183, 153);
            aceptarButton.Margin = new Padding(3, 2, 3, 2);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(130, 34);
            aceptarButton.TabIndex = 0;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(330, 153);
            cancelarButton.Margin = new Padding(3, 2, 3, 2);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(130, 34);
            cancelarButton.TabIndex = 1;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Font = new Font("Segoe UI", 12F);
            IdLabel.Location = new Point(33, 28);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(25, 21);
            IdLabel.TabIndex = 2;
            IdLabel.Text = "ID";
            // 
            // DescripcionLabel
            // 
            DescripcionLabel.AutoSize = true;
            DescripcionLabel.Font = new Font("Segoe UI", 12F);
            DescripcionLabel.Location = new Point(33, 80);
            DescripcionLabel.Name = "DescripcionLabel";
            DescripcionLabel.Size = new Size(91, 21);
            DescripcionLabel.TabIndex = 3;
            DescripcionLabel.Text = "Descripcion";
            // 
            // IdTextBox
            // 
            IdTextBox.BackColor = SystemColors.Window;
            IdTextBox.Location = new Point(183, 32);
            IdTextBox.Margin = new Padding(3, 2, 3, 2);
            IdTextBox.Name = "IdTextBox";
            IdTextBox.ReadOnly = true;
            IdTextBox.Size = new Size(57, 23);
            IdTextBox.TabIndex = 4;
            IdTextBox.TabStop = false;
            IdTextBox.TextChanged += IdTextBox_TextChanged;
            // 
            // DescripcionTextBox
            // 
            DescripcionTextBox.Location = new Point(183, 81);
            DescripcionTextBox.Margin = new Padding(3, 2, 3, 2);
            DescripcionTextBox.Name = "DescripcionTextBox";
            DescripcionTextBox.Size = new Size(246, 23);
            DescripcionTextBox.TabIndex = 5;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // EspecialidadDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 196);
            Controls.Add(DescripcionTextBox);
            Controls.Add(IdTextBox);
            Controls.Add(DescripcionLabel);
            Controls.Add(IdLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EspecialidadDetalle";
            Text = "EspecialidadDetalle";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button aceptarButton;
        private Button cancelarButton;
        private Label IdLabel;
        private Label DescripcionLabel;
        private TextBox IdTextBox;
        private TextBox DescripcionTextBox;
        private ErrorProvider errorProvider;
    }
}
