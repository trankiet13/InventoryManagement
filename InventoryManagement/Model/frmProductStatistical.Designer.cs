namespace InventoryManagement.View
{
    partial class frmProductStatistical
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartDVT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartNhom = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhom)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDVT
            // 
            this.chartDVT.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chartDVT.Legends.Add(legend1);
            this.chartDVT.Location = new System.Drawing.Point(0, 0);
            this.chartDVT.Name = "chartDVT";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDVT.Series.Add(series1);
            this.chartDVT.Size = new System.Drawing.Size(800, 377);
            this.chartDVT.TabIndex = 0;
            this.chartDVT.Text = "chart1";
            // 
            // chartNhom
            // 
            this.chartNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartNhom.Legends.Add(legend2);
            this.chartNhom.Location = new System.Drawing.Point(0, 377);
            this.chartNhom.Name = "chartNhom";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartNhom.Series.Add(series2);
            this.chartNhom.Size = new System.Drawing.Size(800, 73);
            this.chartNhom.TabIndex = 1;
            this.chartNhom.Text = "chart2";
            // 
            // frmProductStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartNhom);
            this.Controls.Add(this.chartDVT);
            this.Name = "frmProductStatistical";
            this.Text = "Statistical";
            this.Load += new System.EventHandler(this.frmProductStatistical_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDVT;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNhom;
    }
}