namespace WindowsForms
{
    partial class ReporteHistorialForm
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
            topPanel = new Panel();
            titleLabel = new Label();
            label1 = new Label();
            alumnosComboBox = new ComboBox();
            generarButton = new Button();
            reporteDataGridView = new DataGridView();
            promedioLabel = new Label();
            btnGenerarPdf = new Button();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reporteDataGridView).BeginInit();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.BackColor = Color.FromArgb(0, 122, 204);
            topPanel.Controls.Add(titleLabel);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(2, 3, 2, 3);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(800, 64);
            topPanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(10, 15);
            titleLabel.Margin = new Padding(2, 0, 2, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(318, 31);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Reporte: Historial Académico";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(10, 80);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(139, 20);
            label1.TabIndex = 2;
            label1.Text = "Seleccione Alumno:";
            // 
            // alumnosComboBox
            // 
            alumnosComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            alumnosComboBox.FormattingEnabled = true;
            alumnosComboBox.Location = new Point(146, 77);
            alumnosComboBox.Margin = new Padding(2, 3, 2, 3);
            alumnosComboBox.Name = "alumnosComboBox";
            alumnosComboBox.Size = new Size(357, 28);
            alumnosComboBox.TabIndex = 3;
            // 
            // generarButton
            // 
            generarButton.BackColor = Color.FromArgb(40, 167, 69);
            generarButton.FlatAppearance.BorderSize = 0;
            generarButton.FlatStyle = FlatStyle.Flat;
            generarButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            generarButton.ForeColor = Color.White;
            generarButton.Location = new Point(519, 77);
            generarButton.Margin = new Padding(2, 3, 2, 3);
            generarButton.Name = "generarButton";
            generarButton.Size = new Size(143, 28);
            generarButton.TabIndex = 4;
            generarButton.Text = "Generar Reporte";
            generarButton.UseVisualStyleBackColor = false;
            generarButton.Click += generarButton_Click;
            // 
            // reporteDataGridView
            // 
            reporteDataGridView.AllowUserToAddRows = false;
            reporteDataGridView.AllowUserToDeleteRows = false;
            reporteDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            reporteDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reporteDataGridView.Location = new Point(14, 125);
            reporteDataGridView.Margin = new Padding(2, 3, 2, 3);
            reporteDataGridView.Name = "reporteDataGridView";
            reporteDataGridView.ReadOnly = true;
            reporteDataGridView.RowHeadersVisible = false;
            reporteDataGridView.RowHeadersWidth = 51;
            reporteDataGridView.RowTemplate.Height = 24;
            reporteDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reporteDataGridView.Size = new Size(773, 299);
            reporteDataGridView.TabIndex = 5;
            // 
            // promedioLabel
            // 
            promedioLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            promedioLabel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            promedioLabel.Location = new Point(14, 444);
            promedioLabel.Margin = new Padding(2, 0, 2, 0);
            promedioLabel.Name = "promedioLabel";
            promedioLabel.Size = new Size(772, 25);
            promedioLabel.TabIndex = 6;
            promedioLabel.Text = "Promedio General: -";
            promedioLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnGenerarPdf
            // 
            btnGenerarPdf.BackColor = Color.DodgerBlue;
            btnGenerarPdf.FlatAppearance.BorderSize = 0;
            btnGenerarPdf.FlatStyle = FlatStyle.Flat;
            btnGenerarPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGenerarPdf.ForeColor = Color.White;
            btnGenerarPdf.Location = new Point(676, 77);
            btnGenerarPdf.Margin = new Padding(2, 3, 2, 3);
            btnGenerarPdf.Name = "btnGenerarPdf";
            btnGenerarPdf.Size = new Size(110, 28);
            btnGenerarPdf.TabIndex = 7;
            btnGenerarPdf.Text = "Generar PDF";
            btnGenerarPdf.UseVisualStyleBackColor = false;
            btnGenerarPdf.Click += btnGenerarPdf_Click;
            // 
            // ReporteHistorialForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(800, 480);
            Controls.Add(btnGenerarPdf);
            Controls.Add(promedioLabel);
            Controls.Add(reporteDataGridView);
            Controls.Add(generarButton);
            Controls.Add(alumnosComboBox);
            Controls.Add(label1);
            Controls.Add(topPanel);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReporteHistorialForm";
            Text = "ReporteHistorialForm";
            Load += ReporteHistorialForm_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)reporteDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox alumnosComboBox;
        private System.Windows.Forms.Button generarButton;
        private System.Windows.Forms.DataGridView reporteDataGridView;
        private System.Windows.Forms.Label promedioLabel;
        private Button btnGenerarPdf;
    }
}