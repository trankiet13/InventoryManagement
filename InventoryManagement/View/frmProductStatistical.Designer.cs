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
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartDVT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartNhom = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbTotalProduct = new System.Windows.Forms.Label();
            this.lbTotalUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhom)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDVT
            // 
            this.chartDVT.Dock = System.Windows.Forms.DockStyle.Top;
            legend7.Name = "Legend1";
            this.chartDVT.Legends.Add(legend7);
            this.chartDVT.Location = new System.Drawing.Point(0, 0);
            this.chartDVT.Name = "chartDVT";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartDVT.Series.Add(series7);
            this.chartDVT.Size = new System.Drawing.Size(1251, 606);
            this.chartDVT.TabIndex = 0;
            this.chartDVT.Text = "chart1";
            // 
            // chartNhom
            // 
            this.chartNhom.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend8.Name = "Legend1";
            this.chartNhom.Legends.Add(legend8);
            this.chartNhom.Location = new System.Drawing.Point(0, 377);
            this.chartNhom.Name = "chartNhom";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartNhom.Series.Add(series8);
            this.chartNhom.Size = new System.Drawing.Size(1251, 431);
            this.chartNhom.TabIndex = 1;
            this.chartNhom.Text = "chart2";
            // 
            // lbTotalProduct
            // 
            this.lbTotalProduct.BackColor = System.Drawing.Color.DodgerBlue;
            this.lbTotalProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalProduct.ForeColor = System.Drawing.Color.White;
            this.lbTotalProduct.Location = new System.Drawing.Point(1088, 507);
            this.lbTotalProduct.Name = "lbTotalProduct";
            this.lbTotalProduct.Size = new System.Drawing.Size(167, 52);
            this.lbTotalProduct.TabIndex = 0;
            this.lbTotalProduct.Text = "Tổng sản phẩm";
            this.lbTotalProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTotalUser
            // 
            this.lbTotalUser.BackColor = System.Drawing.Color.DodgerBlue;
            this.lbTotalUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalUser.ForeColor = System.Drawing.Color.White;
            this.lbTotalUser.Location = new System.Drawing.Point(1084, 588);
            this.lbTotalUser.Name = "lbTotalUser";
            this.lbTotalUser.Size = new System.Drawing.Size(167, 52);
            this.lbTotalUser.TabIndex = 1;
            this.lbTotalUser.Text = "Tổng user";
            this.lbTotalUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmProductStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 808);
            this.Controls.Add(this.lbTotalUser);
            this.Controls.Add(this.lbTotalProduct);
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
        private System.Windows.Forms.Label lbTotalProduct;
        private System.Windows.Forms.Label lbTotalUser;
    }
}