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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartDVT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartNhom = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.linkUser = new System.Windows.Forms.LinkLabel();
            this.linkProduct = new System.Windows.Forms.LinkLabel();
            this.lbTotalProduct = new System.Windows.Forms.Label();
            this.lbTotalUser = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDVT)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhom)).BeginInit();
            this.pnlTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chartDVT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1254, 446);
            this.panel1.TabIndex = 0;
            // 
            // chartDVT
            // 
            this.chartDVT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(75)))));
            this.chartDVT.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartDVT.Legends.Add(legend1);
            this.chartDVT.Location = new System.Drawing.Point(0, 0);
            this.chartDVT.Name = "chartDVT";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDVT.Series.Add(series1);
            this.chartDVT.Size = new System.Drawing.Size(1254, 446);
            this.chartDVT.TabIndex = 0;
            this.chartDVT.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(75)))));
            this.panel2.Controls.Add(this.chartNhom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 446);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1254, 345);
            this.panel2.TabIndex = 1;
            // 
            // chartNhom
            // 
            this.chartNhom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(75)))));
            this.chartNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartNhom.Legends.Add(legend2);
            this.chartNhom.Location = new System.Drawing.Point(0, 0);
            this.chartNhom.Name = "chartNhom";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartNhom.Series.Add(series2);
            this.chartNhom.Size = new System.Drawing.Size(1254, 345);
            this.chartNhom.TabIndex = 0;
            this.chartNhom.Text = "chart2";
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(70)))));
            this.pnlTotal.Controls.Add(this.linkUser);
            this.pnlTotal.Controls.Add(this.linkProduct);
            this.pnlTotal.Controls.Add(this.lbTotalProduct);
            this.pnlTotal.Controls.Add(this.lbTotalUser);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTotal.Location = new System.Drawing.Point(0, 446);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(523, 345);
            this.pnlTotal.TabIndex = 1;
            // 
            // linkUser
            // 
            this.linkUser.BackColor = System.Drawing.Color.White;
            this.linkUser.DisabledLinkColor = System.Drawing.Color.White;
            this.linkUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkUser.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkUser.LinkColor = System.Drawing.Color.IndianRed;
            this.linkUser.Location = new System.Drawing.Point(54, 270);
            this.linkUser.Name = "linkUser";
            this.linkUser.Size = new System.Drawing.Size(322, 23);
            this.linkUser.TabIndex = 7;
            this.linkUser.TabStop = true;
            this.linkUser.Text = "More Info";
            this.linkUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUser_LinkClicked);
            // 
            // linkProduct
            // 
            this.linkProduct.ActiveLinkColor = System.Drawing.Color.LightGray;
            this.linkProduct.BackColor = System.Drawing.Color.White;
            this.linkProduct.DisabledLinkColor = System.Drawing.Color.White;
            this.linkProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkProduct.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkProduct.LinkColor = System.Drawing.Color.IndianRed;
            this.linkProduct.Location = new System.Drawing.Point(54, 146);
            this.linkProduct.Name = "linkProduct";
            this.linkProduct.Size = new System.Drawing.Size(322, 23);
            this.linkProduct.TabIndex = 6;
            this.linkProduct.TabStop = true;
            this.linkProduct.Text = "More Info";
            this.linkProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkProduct.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProduct_LinkClicked);
            // 
            // lbTotalProduct
            // 
            this.lbTotalProduct.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.lbTotalProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalProduct.ForeColor = System.Drawing.Color.White;
            this.lbTotalProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTotalProduct.Location = new System.Drawing.Point(54, 53);
            this.lbTotalProduct.Name = "lbTotalProduct";
            this.lbTotalProduct.Size = new System.Drawing.Size(322, 93);
            this.lbTotalProduct.TabIndex = 4;
            this.lbTotalProduct.Text = "Tổng sản phẩm";
            this.lbTotalProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTotalUser
            // 
            this.lbTotalUser.BackColor = System.Drawing.Color.Orange;
            this.lbTotalUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalUser.ForeColor = System.Drawing.Color.White;
            this.lbTotalUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTotalUser.Location = new System.Drawing.Point(54, 188);
            this.lbTotalUser.Name = "lbTotalUser";
            this.lbTotalUser.Size = new System.Drawing.Size(322, 82);
            this.lbTotalUser.TabIndex = 5;
            this.lbTotalUser.Text = "Tổng user";
            this.lbTotalUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmProductStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 791);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmProductStatistical";
            this.Text = "Statistical";
            this.Load += new System.EventHandler(this.frmProductStatistical_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDVT)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartNhom)).EndInit();
            this.pnlTotal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDVT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNhom;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.LinkLabel linkUser;
        private System.Windows.Forms.LinkLabel linkProduct;
        private System.Windows.Forms.Label lbTotalProduct;
        private System.Windows.Forms.Label lbTotalUser;
    }
}