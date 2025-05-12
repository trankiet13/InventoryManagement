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
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Legend legend16 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartDVT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartNhom = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbTotalUser = new System.Windows.Forms.Label();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.linkUser = new System.Windows.Forms.LinkLabel();
            this.linkProduct = new System.Windows.Forms.LinkLabel();
            this.lbTotalProduct = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhom)).BeginInit();
            this.pnlTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartDVT
            // 
            this.chartDVT.Dock = System.Windows.Forms.DockStyle.Top;
            legend15.Name = "Legend1";
            this.chartDVT.Legends.Add(legend15);
            this.chartDVT.Location = new System.Drawing.Point(0, 0);
            this.chartDVT.Name = "chartDVT";
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            this.chartDVT.Series.Add(series15);
            this.chartDVT.Size = new System.Drawing.Size(1606, 517);
            this.chartDVT.TabIndex = 0;
            this.chartDVT.Text = "chart1";
            // 
            // chartNhom
            // 
            this.chartNhom.Dock = System.Windows.Forms.DockStyle.Right;
            legend16.Name = "Legend1";
            this.chartNhom.Legends.Add(legend16);
            this.chartNhom.Location = new System.Drawing.Point(457, 517);
            this.chartNhom.Name = "chartNhom";
            series16.Legend = "Legend1";
            series16.Name = "Series1";
            this.chartNhom.Series.Add(series16);
            this.chartNhom.Size = new System.Drawing.Size(1149, 343);
            this.chartNhom.TabIndex = 1;
            this.chartNhom.Text = "chart2";
            // 
            // lbTotalUser
            // 
            this.lbTotalUser.BackColor = System.Drawing.Color.Orange;
            this.lbTotalUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalUser.ForeColor = System.Drawing.Color.White;
            this.lbTotalUser.Image = global::InventoryManagement.Properties.Resources.icons8_user_50__1_;
            this.lbTotalUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTotalUser.Location = new System.Drawing.Point(12, 163);
            this.lbTotalUser.Name = "lbTotalUser";
            this.lbTotalUser.Size = new System.Drawing.Size(322, 82);
            this.lbTotalUser.TabIndex = 1;
            this.lbTotalUser.Text = "Tổng user";
            this.lbTotalUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(35)))), ((int)(((byte)(70)))));
            this.pnlTotal.Controls.Add(this.linkUser);
            this.pnlTotal.Controls.Add(this.linkProduct);
            this.pnlTotal.Controls.Add(this.lbTotalProduct);
            this.pnlTotal.Controls.Add(this.lbTotalUser);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotal.Location = new System.Drawing.Point(0, 517);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(457, 343);
            this.pnlTotal.TabIndex = 2;
            // 
            // linkUser
            // 
            this.linkUser.BackColor = System.Drawing.Color.White;
            this.linkUser.DisabledLinkColor = System.Drawing.Color.White;
            this.linkUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkUser.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkUser.LinkColor = System.Drawing.Color.IndianRed;
            this.linkUser.Location = new System.Drawing.Point(12, 245);
            this.linkUser.Name = "linkUser";
            this.linkUser.Size = new System.Drawing.Size(322, 23);
            this.linkUser.TabIndex = 3;
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
            this.linkProduct.Location = new System.Drawing.Point(12, 121);
            this.linkProduct.Name = "linkProduct";
            this.linkProduct.Size = new System.Drawing.Size(322, 23);
            this.linkProduct.TabIndex = 2;
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
            this.lbTotalProduct.Image = global::InventoryManagement.Properties.Resources.icons8_shopping_cart_64;
            this.lbTotalProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTotalProduct.Location = new System.Drawing.Point(12, 28);
            this.lbTotalProduct.Name = "lbTotalProduct";
            this.lbTotalProduct.Size = new System.Drawing.Size(322, 93);
            this.lbTotalProduct.TabIndex = 0;
            this.lbTotalProduct.Text = "Tổng sản phẩm";
            this.lbTotalProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmProductStatistical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1606, 860);
            this.Controls.Add(this.pnlTotal);
            this.Controls.Add(this.chartNhom);
            this.Controls.Add(this.chartDVT);
            this.Name = "frmProductStatistical";
            this.Text = "Statistical";
            this.Load += new System.EventHandler(this.frmProductStatistical_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNhom)).EndInit();
            this.pnlTotal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDVT;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNhom;
        private System.Windows.Forms.Label lbTotalUser;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lbTotalProduct;
        private System.Windows.Forms.LinkLabel linkUser;
        private System.Windows.Forms.LinkLabel linkProduct;
    }
}