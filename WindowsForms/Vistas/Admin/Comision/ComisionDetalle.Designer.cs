namespace WindowsForms
{
    partial class ComisionDetalle
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
            components = new System.ComponentModel.Container();
            topPanel = new Panel();
            titleLabel = new Label();
            descripcionLabel = new Label();
            descripcionTextBox = new TextBox();
            aceptarButton = new Button();
            cancelarButton = new Button();
            idLabel = new Label();
            idTextBox = new TextBox();
            errorProvider = new ErrorProvider(components);
            anioTextBox = new TextBox();
            anioLabel = new Label();
            planesAsignadosTextBox = new TextBox();
            planesAsignadosLabel = new Label();
            btnAsignarPlanes = new Button();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(0, 122, 204);
            topPanel.Controls.Add(titleLabel);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(3, 4, 3, 4);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(450, 75);
            topPanel.TabIndex = 10;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(25, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(161, 28);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Nueva Comisión";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new Font("Segoe UI", 9F);
            descripcionLabel.ForeColor = Color.FromArgb(64, 64, 64);
            descripcionLabel.Location = new Point(40, 181);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(90, 20);
            descripcionLabel.TabIndex = 11;
            descripcionLabel.Text = "Descripción:";
            // 
            // descripcionTextBox
            // 
            descripcionTextBox.Font = new Font("Segoe UI", 9F);
            descripcionTextBox.Location = new Point(44, 212);
            descripcionTextBox.Margin = new Padding(3, 4, 3, 4);
            descripcionTextBox.Name = "descripcionTextBox";
            descripcionTextBox.Size = new Size(360, 27);
            descripcionTextBox.TabIndex = 1;
            // 
            // aceptarButton
            // 
            aceptarButton.BackColor = Color.FromArgb(0, 122, 204);
            aceptarButton.Cursor = Cursors.Hand;
            aceptarButton.FlatAppearance.BorderSize = 0;
            aceptarButton.FlatStyle = FlatStyle.Flat;
            aceptarButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            aceptarButton.ForeColor = Color.White;
            aceptarButton.Location = new Point(194, 475);
            aceptarButton.Margin = new Padding(3, 4, 3, 4);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(100, 40);
            aceptarButton.TabIndex = 4;
            aceptarButton.Text = "ACEPTAR";
            aceptarButton.UseVisualStyleBackColor = false;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.BackColor = Color.FromArgb(108, 117, 125);
            cancelarButton.Cursor = Cursors.Hand;
            cancelarButton.DialogResult = DialogResult.Cancel;
            cancelarButton.FlatAppearance.BorderSize = 0;
            cancelarButton.FlatStyle = FlatStyle.Flat;
            cancelarButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cancelarButton.ForeColor = Color.White;
            cancelarButton.Location = new Point(300, 475);
            cancelarButton.Margin = new Padding(3, 4, 3, 4);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(100, 40);
            cancelarButton.TabIndex = 5;
            cancelarButton.Text = "CANCELAR";
            cancelarButton.UseVisualStyleBackColor = false;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new Font("Segoe UI", 9F);
            idLabel.ForeColor = Color.FromArgb(64, 64, 64);
            idLabel.Location = new Point(40, 106);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(37, 20);
            idLabel.TabIndex = 12;
            idLabel.Text = "Nro:";
            // 
            // idTextBox
            // 
            idTextBox.BackColor = SystemColors.ControlLight;
            idTextBox.Font = new Font("Segoe UI", 9F);
            idTextBox.Location = new Point(44, 138);
            idTextBox.Margin = new Padding(3, 4, 3, 4);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(100, 27);
            idTextBox.TabIndex = 0;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // anioTextBox
            // 
            anioTextBox.Font = new Font("Segoe UI", 9F);
            anioTextBox.Location = new Point(44, 288);
            anioTextBox.Margin = new Padding(3, 4, 3, 4);
            anioTextBox.Name = "anioTextBox";
            anioTextBox.Size = new Size(360, 27);
            anioTextBox.TabIndex = 2;
            // 
            // anioLabel
            // 
            anioLabel.AutoSize = true;
            anioLabel.Font = new Font("Segoe UI", 9F);
            anioLabel.ForeColor = Color.FromArgb(64, 64, 64);
            anioLabel.Location = new Point(40, 256);
            anioLabel.Name = "anioLabel";
            anioLabel.Size = new Size(127, 20);
            anioLabel.TabIndex = 14;
            anioLabel.Text = "Año Especialidad:";
            // 
            // planesAsignadosTextBox
            // 
            planesAsignadosTextBox.BackColor = SystemColors.ControlLight;
            planesAsignadosTextBox.Font = new Font("Segoe UI", 9F);
            planesAsignadosTextBox.Location = new Point(44, 361);
            planesAsignadosTextBox.Margin = new Padding(3, 4, 3, 4);
            planesAsignadosTextBox.Multiline = true;
            planesAsignadosTextBox.Name = "planesAsignadosTextBox";
            planesAsignadosTextBox.ReadOnly = true;
            planesAsignadosTextBox.ScrollBars = ScrollBars.Vertical;
            planesAsignadosTextBox.Size = new Size(360, 99);
            planesAsignadosTextBox.TabIndex = 17;
            planesAsignadosTextBox.TabStop = false;
            // 
            // planesAsignadosLabel
            // 
            planesAsignadosLabel.AutoSize = true;
            planesAsignadosLabel.Font = new Font("Segoe UI", 9F);
            planesAsignadosLabel.ForeColor = Color.FromArgb(64, 64, 64);
            planesAsignadosLabel.Location = new Point(40, 330);
            planesAsignadosLabel.Name = "planesAsignadosLabel";
            planesAsignadosLabel.Size = new Size(127, 20);
            planesAsignadosLabel.TabIndex = 16;
            planesAsignadosLabel.Text = "Planes Asignados:";
            // 
            // btnAsignarPlanes
            // 
            btnAsignarPlanes.BackColor = Color.FromArgb(23, 162, 184);
            btnAsignarPlanes.Cursor = Cursors.Hand;
            btnAsignarPlanes.FlatAppearance.BorderSize = 0;
            btnAsignarPlanes.FlatStyle = FlatStyle.Flat;
            btnAsignarPlanes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAsignarPlanes.ForeColor = Color.White;
            btnAsignarPlanes.Location = new Point(275, 326);
            btnAsignarPlanes.Margin = new Padding(3, 4, 3, 4);
            btnAsignarPlanes.Name = "btnAsignarPlanes";
            btnAsignarPlanes.Size = new Size(129, 29);
            btnAsignarPlanes.TabIndex = 3;
            btnAsignarPlanes.Text = "Administrar Planes";
            btnAsignarPlanes.UseVisualStyleBackColor = false;
            btnAsignarPlanes.Click += btnAsignarPlanes_Click;
            // 
            // ComisionDetalle
            // 
            AcceptButton = aceptarButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            CancelButton = cancelarButton;
            ClientSize = new Size(450, 538);
            Controls.Add(planesAsignadosTextBox);
            Controls.Add(planesAsignadosLabel);
            Controls.Add(btnAsignarPlanes);
            Controls.Add(anioTextBox);
            Controls.Add(anioLabel);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(descripcionTextBox);
            Controls.Add(descripcionLabel);
            Controls.Add(topPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ComisionDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ComisionDetalle";
            Load += ComisionDetalle_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.TextBox anioTextBox;
        private System.Windows.Forms.Label anioLabel;
        private System.Windows.Forms.Button btnAsignarPlanes;
        private System.Windows.Forms.Label planesAsignadosLabel;
        private System.Windows.Forms.TextBox planesAsignadosTextBox;
    }
}