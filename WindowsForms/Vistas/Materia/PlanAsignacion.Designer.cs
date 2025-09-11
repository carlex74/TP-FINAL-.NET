namespace WindowsForms.Vistas.Materia
{
    partial class PlanAsignacion
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
            this.disponiblesListBox = new System.Windows.Forms.ListBox();
            this.asignadosListBox = new System.Windows.Forms.ListBox();
            this.agregarButton = new System.Windows.Forms.Button();
            this.quitarButton = new System.Windows.Forms.Button();
            this.agregarTodoButton = new System.Windows.Forms.Button();
            this.quitarTodoButton = new System.Windows.Forms.Button();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.disponiblesLabel = new System.Windows.Forms.Label();
            this.asignadosLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // disponiblesListBox
            // 
            this.disponiblesListBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.disponiblesListBox.FormattingEnabled = true;
            this.disponiblesListBox.ItemHeight = 20;
            this.disponiblesListBox.Location = new System.Drawing.Point(30, 110);
            this.disponiblesListBox.Name = "disponiblesListBox";
            this.disponiblesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.disponiblesListBox.Size = new System.Drawing.Size(220, 284);
            this.disponiblesListBox.TabIndex = 0;
            // 
            // asignadosListBox
            // 
            this.asignadosListBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.asignadosListBox.FormattingEnabled = true;
            this.asignadosListBox.ItemHeight = 20;
            this.asignadosListBox.Location = new System.Drawing.Point(350, 110);
            this.asignadosListBox.Name = "asignadosListBox";
            this.asignadosListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.asignadosListBox.Size = new System.Drawing.Size(220, 284);
            this.asignadosListBox.TabIndex = 1;
            // 
            // agregarButton
            // 
            this.agregarButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.agregarButton.Location = new System.Drawing.Point(265, 150);
            this.agregarButton.Name = "agregarButton";
            this.agregarButton.Size = new System.Drawing.Size(70, 35);
            this.agregarButton.TabIndex = 2;
            this.agregarButton.Text = ">";
            this.agregarButton.UseVisualStyleBackColor = true;
            this.agregarButton.Click += new System.EventHandler(this.agregarButton_Click);
            // 
            // quitarButton
            // 
            this.quitarButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.quitarButton.Location = new System.Drawing.Point(265, 195);
            this.quitarButton.Name = "quitarButton";
            this.quitarButton.Size = new System.Drawing.Size(70, 35);
            this.quitarButton.TabIndex = 3;
            this.quitarButton.Text = "<";
            this.quitarButton.UseVisualStyleBackColor = true;
            this.quitarButton.Click += new System.EventHandler(this.quitarButton_Click);
            // 
            // agregarTodoButton
            // 
            this.agregarTodoButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.agregarTodoButton.Location = new System.Drawing.Point(265, 240);
            this.agregarTodoButton.Name = "agregarTodoButton";
            this.agregarTodoButton.Size = new System.Drawing.Size(70, 35);
            this.agregarTodoButton.TabIndex = 4;
            this.agregarTodoButton.Text = ">>";
            this.agregarTodoButton.UseVisualStyleBackColor = true;
            this.agregarTodoButton.Click += new System.EventHandler(this.agregarTodoButton_Click);
            // 
            // quitarTodoButton
            // 
            this.quitarTodoButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.quitarTodoButton.Location = new System.Drawing.Point(265, 285);
            this.quitarTodoButton.Name = "quitarTodoButton";
            this.quitarTodoButton.Size = new System.Drawing.Size(70, 35);
            this.quitarTodoButton.TabIndex = 5;
            this.quitarTodoButton.Text = "<<";
            this.quitarTodoButton.UseVisualStyleBackColor = true;
            this.quitarTodoButton.Click += new System.EventHandler(this.quitarTodoButton_Click);
            // 
            // aceptarButton
            // 
            this.aceptarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.aceptarButton.FlatAppearance.BorderSize = 0;
            this.aceptarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptarButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.aceptarButton.ForeColor = System.Drawing.Color.White;
            this.aceptarButton.Location = new System.Drawing.Point(364, 413);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(100, 35);
            this.aceptarButton.TabIndex = 6;
            this.aceptarButton.Text = "ACEPTAR";
            this.aceptarButton.UseVisualStyleBackColor = false;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.FlatAppearance.BorderSize = 0;
            this.cancelarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelarButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cancelarButton.ForeColor = System.Drawing.Color.White;
            this.cancelarButton.Location = new System.Drawing.Point(470, 413);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(100, 35);
            this.cancelarButton.TabIndex = 7;
            this.cancelarButton.Text = "CANCELAR";
            this.cancelarButton.UseVisualStyleBackColor = false;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // disponiblesLabel
            // 
            this.disponiblesLabel.AutoSize = true;
            this.disponiblesLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.disponiblesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.disponiblesLabel.Location = new System.Drawing.Point(26, 87);
            this.disponiblesLabel.Name = "disponiblesLabel";
            this.disponiblesLabel.Size = new System.Drawing.Size(136, 20);
            this.disponiblesLabel.TabIndex = 8;
            this.disponiblesLabel.Text = "Planes Disponibles";
            // 
            // asignadosLabel
            // 
            this.asignadosLabel.AutoSize = true;
            this.asignadosLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.asignadosLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.asignadosLabel.Location = new System.Drawing.Point(346, 87);
            this.asignadosLabel.Name = "asignadosLabel";
            this.asignadosLabel.Size = new System.Drawing.Size(129, 20);
            this.asignadosLabel.TabIndex = 9;
            this.asignadosLabel.Text = "Planes Asignados";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(600, 60);
            this.topPanel.TabIndex = 11;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(25, 16);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(248, 28);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Asignar Planes a Materia";
            // 
            // PlanAsignacion
            // 
            this.AcceptButton = this.aceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(600, 470);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.asignadosLabel);
            this.Controls.Add(this.disponiblesLabel);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.quitarTodoButton);
            this.Controls.Add(this.agregarTodoButton);
            this.Controls.Add(this.quitarButton);
            this.Controls.Add(this.agregarButton);
            this.Controls.Add(this.asignadosListBox);
            this.Controls.Add(this.disponiblesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlanAsignacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asignar Planes";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox disponiblesListBox;
        private System.Windows.Forms.ListBox asignadosListBox;
        private System.Windows.Forms.Button agregarButton;
        private System.Windows.Forms.Button quitarButton;
        private System.Windows.Forms.Button agregarTodoButton;
        private System.Windows.Forms.Button quitarTodoButton;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Label disponiblesLabel;
        private System.Windows.Forms.Label asignadosLabel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
    }
}