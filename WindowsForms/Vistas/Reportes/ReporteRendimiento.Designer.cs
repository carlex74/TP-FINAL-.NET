namespace WindowsForms
{
    partial class ReporteRendimientoForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cursosComboBox = new System.Windows.Forms.ComboBox();
            this.generarButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.reporteDataGridView = new System.Windows.Forms.DataGridView();
            this.rendimientoChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnGenerarPdf = new System.Windows.Forms.Button();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reporteDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rendimientoChart)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(800, 60);
            this.topPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(12, 14);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(325, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Reporte: Rendimiento por Curso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione un Curso:";
            // 
            // cursosComboBox
            // 
            this.cursosComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cursosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cursosComboBox.FormattingEnabled = true;
            this.cursosComboBox.Location = new System.Drawing.Point(153, 72);
            this.cursosComboBox.Name = "cursosComboBox";
            this.cursosComboBox.Size = new System.Drawing.Size(328, 28);
            this.cursosComboBox.TabIndex = 2;
            // 
            // generarButton
            // 
            this.generarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.generarButton.FlatAppearance.BorderSize = 0;
            this.generarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generarButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.generarButton.ForeColor = System.Drawing.Color.White;
            this.generarButton.Location = new System.Drawing.Point(487, 70);
            this.generarButton.Name = "generarButton";
            this.generarButton.Size = new System.Drawing.Size(150, 32);
            this.generarButton.TabIndex = 3;
            this.generarButton.Text = "Generar Reporte";
            this.generarButton.UseVisualStyleBackColor = false;
            this.generarButton.Click += new System.EventHandler(this.generarButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 118);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.reporteDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rendimientoChart);
            this.splitContainer1.Size = new System.Drawing.Size(776, 320);
            this.splitContainer1.SplitterDistance = 450;
            this.splitContainer1.TabIndex = 4;
            // 
            // reporteDataGridView
            // 
            this.reporteDataGridView.AllowUserToAddRows = false;
            this.reporteDataGridView.AllowUserToDeleteRows = false;
            this.reporteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reporteDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reporteDataGridView.Location = new System.Drawing.Point(0, 0);
            this.reporteDataGridView.Name = "reporteDataGridView";
            this.reporteDataGridView.ReadOnly = true;
            this.reporteDataGridView.RowHeadersVisible = false;
            this.reporteDataGridView.RowTemplate.Height = 24;
            this.reporteDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reporteDataGridView.Size = new System.Drawing.Size(450, 320);
            this.reporteDataGridView.TabIndex = 0;
            // 
            // rendimientoChart
            // 
            chartArea1.Name = "ChartArea1";
            this.rendimientoChart.ChartAreas.Add(chartArea1);
            this.rendimientoChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.rendimientoChart.Legends.Add(legend1);
            this.rendimientoChart.Location = new System.Drawing.Point(0, 0);
            this.rendimientoChart.Name = "rendimientoChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.rendimientoChart.Series.Add(series1);
            this.rendimientoChart.Size = new System.Drawing.Size(322, 320);
            this.rendimientoChart.TabIndex = 0;
            this.rendimientoChart.Text = "chart1";
            // 
            // btnGenerarPdf
            // 
            this.btnGenerarPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarPdf.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGenerarPdf.FlatAppearance.BorderSize = 0;
            this.btnGenerarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerarPdf.ForeColor = System.Drawing.Color.White;
            this.btnGenerarPdf.Location = new System.Drawing.Point(643, 70);
            this.btnGenerarPdf.Name = "btnGenerarPdf";
            this.btnGenerarPdf.Size = new System.Drawing.Size(145, 32);
            this.btnGenerarPdf.TabIndex = 5;
            this.btnGenerarPdf.Text = "Generar PDF";
            this.btnGenerarPdf.UseVisualStyleBackColor = false;
            this.btnGenerarPdf.Click += new System.EventHandler(this.btnGenerarPdf_Click);
            // 
            // ReporteRendimientoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerarPdf);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.generarButton);
            this.Controls.Add(this.cursosComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReporteRendimientoForm";
            this.Text = "ReporteRendimientoForm";
            this.Load += new System.EventHandler(this.ReporteRendimientoForm_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reporteDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rendimientoChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cursosComboBox;
        private System.Windows.Forms.Button generarButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView reporteDataGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart rendimientoChart;
        private System.Windows.Forms.Button btnGenerarPdf;
    }
}