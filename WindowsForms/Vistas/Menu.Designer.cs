namespace WindowsForms.Vistas
{
    partial class Menu
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
            seleccionABMLabel = new Label();
            planButton = new Button();
            especialidadButton = new Button();
            SuspendLayout();
            // 
            // seleccionABMLabel
            // 
            seleccionABMLabel.AutoSize = true;
            seleccionABMLabel.Font = new Font("Segoe UI", 20F);
            seleccionABMLabel.Location = new Point(103, 59);
            seleccionABMLabel.Name = "seleccionABMLabel";
            seleccionABMLabel.Size = new Size(260, 46);
            seleccionABMLabel.TabIndex = 16;
            seleccionABMLabel.Text = "Seleccione ABM";
            // 
            // planButton
            // 
            planButton.Font = new Font("Segoe UI", 16F);
            planButton.Location = new Point(235, 155);
            planButton.Name = "planButton";
            planButton.Size = new Size(206, 87);
            planButton.TabIndex = 15;
            planButton.Text = "Plan";
            planButton.UseVisualStyleBackColor = true;
            planButton.Click += planButton_Click;
            // 
            // especialidadButton
            // 
            especialidadButton.Font = new Font("Segoe UI", 16F);
            especialidadButton.Location = new Point(23, 155);
            especialidadButton.Name = "especialidadButton";
            especialidadButton.Size = new Size(206, 87);
            especialidadButton.TabIndex = 14;
            especialidadButton.Text = "Especialidad";
            especialidadButton.UseVisualStyleBackColor = true;
            especialidadButton.Click += especialidadButton_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 285);
            Controls.Add(seleccionABMLabel);
            Controls.Add(planButton);
            Controls.Add(especialidadButton);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label seleccionABMLabel;
        private Button planButton;
        private Button especialidadButton;
    }
}