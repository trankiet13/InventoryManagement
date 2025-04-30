namespace InventoryManagement.Model
{
    partial class ucProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProduct));
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.Label();
            this.txtPic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPic)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.lbPrice);
            this.guna2ShadowPanel1.Controls.Add(this.lbProductName);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(13, 44);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(126, 140);
            this.guna2ShadowPanel1.TabIndex = 0;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(43, 98);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(39, 20);
            this.lbPrice.TabIndex = 2;
            this.lbPrice.Text = "200";
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductName.Location = new System.Drawing.Point(10, 67);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(106, 18);
            this.lbProductName.TabIndex = 1;
            this.lbProductName.Text = "Prduct Name";
            this.lbProductName.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtPic
            // 
            this.txtPic.BackColor = System.Drawing.Color.Transparent;
            this.txtPic.Image = ((System.Drawing.Image)(resources.GetObject("txtPic.Image")));
            this.txtPic.ImageRotate = 0F;
            this.txtPic.Location = new System.Drawing.Point(32, 11);
            this.txtPic.Name = "txtPic";
            this.txtPic.Size = new System.Drawing.Size(90, 90);
            this.txtPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.txtPic.TabIndex = 0;
            this.txtPic.TabStop = false;
            this.txtPic.UseTransparentBackground = true;
            this.txtPic.Click += new System.EventHandler(this.txtPic_Click);
            // 
            // ucProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPic);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "ucProduct";
            this.Size = new System.Drawing.Size(153, 196);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        public Guna.UI2.WinForms.Guna2PictureBox txtPic;
        public System.Windows.Forms.Label lbProductName;
        public System.Windows.Forms.Label lbPrice;
    }
}
