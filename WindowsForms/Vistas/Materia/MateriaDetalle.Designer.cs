namespace WindowsForms.Vistas.Materia
{
    partial class MateriaDetalle
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
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            aceptarButton = new Button();
            cancelarButton = new Button();
            idLabel = new Label();
            idTextBox = new TextBox();
            errorProvider = new ErrorProvider(components);
            descripcionTextBox = new TextBox();
            descripcionLabel = new Label();
            hsSemanalesTextBox = new TextBox();
            hsSemanalesLabel = new Label();
            hsTotalesTextBox = new TextBox();
            hsTotalesLabel = new Label();
            btnAsignarPlanes = new Button();
            planesAsignadosLabel = new Label();
            planesAsignadosTextBox = new TextBox();
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
            titleLabel.Size = new Size(144, 28);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Nueva Materia";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Font = new Font("Segoe UI", 9F);
            nombreLabel.ForeColor = Color.FromArgb(64, 64, 64);
            nombreLabel.Location = new Point(40, 181);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(67, 20);
            nombreLabel.TabIndex = 11;
            nombreLabel.Text = "Nombre:";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Font = new Font("Segoe UI", 9F);
            nombreTextBox.Location = new Point(44, 212);
            nombreTextBox.Margin = new Padding(3, 4, 3, 4);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(360, 27);
            nombreTextBox.TabIndex = 1;
            // 
            // aceptarButton
            // 
            aceptarButton.BackColor = Color.FromArgb(0, 122, 204);
            aceptarButton.Cursor = Cursors.Hand;
            aceptarButton.FlatAppearance.BorderSize = 0;
            aceptarButton.FlatStyle = FlatStyle.Flat;
            aceptarButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            aceptarButton.ForeColor = Color.White;
            aceptarButton.Location = new Point(194, 588);
            aceptarButton.Margin = new Padding(3, 4, 3, 4);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(100, 40);
            aceptarButton.TabIndex = 6;
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
            cancelarButton.Location = new Point(300, 588);
            cancelarButton.Margin = new Padding(3, 4, 3, 4);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(100, 40);
            cancelarButton.TabIndex = 7;
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
            idLabel.Size = new Size(27, 20);
            idLabel.TabIndex = 12;
            idLabel.Text = "ID:";
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
            // descripcionTextBox
            // 
            descripcionTextBox.Font = new Font("Segoe UI", 9F);
            descripcionTextBox.Location = new Point(44, 288);
            descripcionTextBox.Margin = new Padding(3, 4, 3, 4);
            descripcionTextBox.Name = "descripcionTextBox";
            descripcionTextBox.Size = new Size(360, 27);
            descripcionTextBox.TabIndex = 2;
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new Font("Segoe UI", 9F);
            descripcionLabel.ForeColor = Color.FromArgb(64, 64, 64);
            descripcionLabel.Location = new Point(40, 256);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new Size(90, 20);
            descripcionLabel.TabIndex = 14;
            descripcionLabel.Text = "Descripción:";
            // 
            // hsSemanalesTextBox
            // 
            hsSemanalesTextBox.Font = new Font("Segoe UI", 9F);
            hsSemanalesTextBox.Location = new Point(44, 362);
            hsSemanalesTextBox.Margin = new Padding(3, 4, 3, 4);
            hsSemanalesTextBox.Name = "hsSemanalesTextBox";
            hsSemanalesTextBox.Size = new Size(160, 27);
            hsSemanalesTextBox.TabIndex = 3;
            // 
            // hsSemanalesLabel
            // 
            hsSemanalesLabel.AutoSize = true;
            hsSemanalesLabel.Font = new Font("Segoe UI", 9F);
            hsSemanalesLabel.ForeColor = Color.FromArgb(64, 64, 64);
            hsSemanalesLabel.Location = new Point(40, 331);
            hsSemanalesLabel.Name = "hsSemanalesLabel";
            hsSemanalesLabel.Size = new Size(107, 20);
            hsSemanalesLabel.TabIndex = 16;
            hsSemanalesLabel.Text = "Hs. Semanales:";
            // 
            // hsTotalesTextBox
            // 
            hsTotalesTextBox.Font = new Font("Segoe UI", 9F);
            hsTotalesTextBox.Location = new Point(244, 362);
            hsTotalesTextBox.Margin = new Padding(3, 4, 3, 4);
            hsTotalesTextBox.Name = "hsTotalesTextBox";
            hsTotalesTextBox.Size = new Size(160, 27);
            hsTotalesTextBox.TabIndex = 4;
            // 
            // hsTotalesLabel
            // 
            hsTotalesLabel.AutoSize = true;
            hsTotalesLabel.Font = new Font("Segoe UI", 9F);
            hsTotalesLabel.ForeColor = Color.FromArgb(64, 64, 64);
            hsTotalesLabel.Location = new Point(240, 331);
            hsTotalesLabel.Name = "hsTotalesLabel";
            hsTotalesLabel.Size = new Size(83, 20);
            hsTotalesLabel.TabIndex = 18;
            hsTotalesLabel.Text = "Hs. Totales:";
            // 
            // btnAsignarPlanes
            // 
            btnAsignarPlanes.BackColor = Color.FromArgb(23, 162, 184);
            btnAsignarPlanes.Cursor = Cursors.Hand;
            btnAsignarPlanes.FlatAppearance.BorderSize = 0;
            btnAsignarPlanes.FlatStyle = FlatStyle.Flat;
            btnAsignarPlanes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAsignarPlanes.ForeColor = Color.White;
            btnAsignarPlanes.Location = new Point(275, 403);
            btnAsignarPlanes.Margin = new Padding(3, 4, 3, 4);
            btnAsignarPlanes.Name = "btnAsignarPlanes";
            btnAsignarPlanes.Size = new Size(129, 30);
            btnAsignarPlanes.TabIndex = 5;
            btnAsignarPlanes.Text = "Administrar Planes";
            btnAsignarPlanes.UseVisualStyleBackColor = false;
            btnAsignarPlanes.Click += btnAsignarPlanes_Click;
            // 
            // planesAsignadosLabel
            // 
            planesAsignadosLabel.AutoSize = true;
            planesAsignadosLabel.Font = new Font("Segoe UI", 9F);
            planesAsignadosLabel.ForeColor = Color.FromArgb(64, 64, 64);
            planesAsignadosLabel.Location = new Point(40, 406);
            planesAsignadosLabel.Name = "planesAsignadosLabel";
            planesAsignadosLabel.Size = new Size(127, 20);
            planesAsignadosLabel.TabIndex = 20;
            planesAsignadosLabel.Text = "Planes Asignados:";
            // 
            // planesAsignadosTextBox
            // 
            planesAsignadosTextBox.BackColor = SystemColors.ControlLight;
            planesAsignadosTextBox.Font = new Font("Segoe UI", 9F);
            planesAsignadosTextBox.Location = new Point(44, 438);
            planesAsignadosTextBox.Margin = new Padding(3, 4, 3, 4);
            planesAsignadosTextBox.Multiline = true;
            planesAsignadosTextBox.Name = "planesAsignadosTextBox";
            planesAsignadosTextBox.ReadOnly = true;
            planesAsignadosTextBox.ScrollBars = ScrollBars.Vertical;
            planesAsignadosTextBox.Size = new Size(360, 99);
            planesAsignadosTextBox.TabIndex = 21;
            // 
            // MateriaDetalle
            // 
            AcceptButton = aceptarButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            CancelButton = cancelarButton;
            ClientSize = new Size(450, 650);
            Controls.Add(planesAsignadosTextBox);
            Controls.Add(planesAsignadosLabel);
            Controls.Add(btnAsignarPlanes);
            Controls.Add(hsTotalesTextBox);
            Controls.Add(hsTotalesLabel);
            Controls.Add(hsSemanalesTextBox);
            Controls.Add(hsSemanalesLabel);
            Controls.Add(descripcionTextBox);
            Controls.Add(descripcionLabel);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(nombreTextBox);
            Controls.Add(nombreLabel);
            Controls.Add(topPanel);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MateriaDetalle";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MateriaDetalle";
            Load += MateriaDetalle_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.TextBox hsTotalesTextBox;
        private System.Windows.Forms.Label hsTotalesLabel;
        private System.Windows.Forms.TextBox hsSemanalesTextBox;
        private System.Windows.Forms.Label hsSemanalesLabel;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.Label descripcionLabel;
        private System.Windows.Forms.Button btnAsignarPlanes;
        private System.Windows.Forms.TextBox planesAsignadosTextBox;
        private System.Windows.Forms.Label planesAsignadosLabel;
    }
}