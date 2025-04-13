namespace InventoryManagement
{
    partial class frmMai
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
            this.btMaxizeBox = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btMinizeBox = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnTop = new Guna.UI2.WinForms.Guna2Panel();
            this.pnRight = new Guna.UI2.WinForms.Guna2Panel();
            this.pnLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.btSales = new Guna.UI2.WinForms.Guna2Button();
            this.bnCustomers = new Guna.UI2.WinForms.Guna2Button();
            this.bnPurchase = new Guna.UI2.WinForms.Guna2Button();
            this.bnProducts = new Guna.UI2.WinForms.Guna2Button();
            this.bnCategoy = new Guna.UI2.WinForms.Guna2Button();
            this.bnHome = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btUser = new Guna.UI2.WinForms.Guna2Button();
            this.pnTop.SuspendLayout();
            this.pnLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btMaxizeBox
            // 
            this.btMaxizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMaxizeBox.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btMaxizeBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.btMaxizeBox.IconColor = System.Drawing.Color.White;
            this.btMaxizeBox.Location = new System.Drawing.Point(951, 9);
            this.btMaxizeBox.Name = "btMaxizeBox";
            this.btMaxizeBox.Size = new System.Drawing.Size(45, 29);
            this.btMaxizeBox.TabIndex = 0;
            this.btMaxizeBox.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.CustomClick = true;
            this.btExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.btExit.IconColor = System.Drawing.Color.White;
            this.btExit.Location = new System.Drawing.Point(1014, 9);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(45, 29);
            this.btExit.TabIndex = 1;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btMinizeBox
            // 
            this.btMinizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMinizeBox.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btMinizeBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.btMinizeBox.IconColor = System.Drawing.Color.White;
            this.btMinizeBox.Location = new System.Drawing.Point(880, 9);
            this.btMinizeBox.Name = "btMinizeBox";
            this.btMinizeBox.Size = new System.Drawing.Size(45, 29);
            this.btMinizeBox.TabIndex = 2;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.btMaxizeBox);
            this.pnTop.Controls.Add(this.btExit);
            this.pnTop.Controls.Add(this.btMinizeBox);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1070, 45);
            this.pnTop.TabIndex = 3;
            this.pnTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnTop_Paint);
            // 
            // pnRight
            // 
            this.pnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnRight.Location = new System.Drawing.Point(337, 51);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(733, 608);
            this.pnRight.TabIndex = 4;
            this.pnRight.Paint += new System.Windows.Forms.PaintEventHandler(this.pnRight_Paint);
            // 
            // pnLeft
            // 
            this.pnLeft.BorderRadius = 60;
            this.pnLeft.Controls.Add(this.btUser);
            this.pnLeft.Controls.Add(this.btSales);
            this.pnLeft.Controls.Add(this.bnCustomers);
            this.pnLeft.Controls.Add(this.bnPurchase);
            this.pnLeft.Controls.Add(this.bnProducts);
            this.pnLeft.Controls.Add(this.bnCategoy);
            this.pnLeft.Controls.Add(this.bnHome);
            this.pnLeft.Controls.Add(this.label1);
            this.pnLeft.Controls.Add(this.guna2CirclePictureBox1);
            this.pnLeft.CustomizableEdges.BottomLeft = false;
            this.pnLeft.CustomizableEdges.BottomRight = false;
            this.pnLeft.CustomizableEdges.TopLeft = false;
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(201)))));
            this.pnLeft.Location = new System.Drawing.Point(0, 45);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(331, 614);
            this.pnLeft.TabIndex = 4;
            // 
            // btSales
            // 
            this.btSales.AutoRoundedCorners = true;
            this.btSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btSales.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btSales.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSales.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSales.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSales.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSales.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btSales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSales.ForeColor = System.Drawing.Color.White;
            this.btSales.Location = new System.Drawing.Point(71, 462);
            this.btSales.Name = "btSales";
            this.btSales.Size = new System.Drawing.Size(180, 45);
            this.btSales.TabIndex = 7;
            this.btSales.Text = "Sales";
            // 
            // bnCustomers
            // 
            this.bnCustomers.AutoRoundedCorners = true;
            this.bnCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnCustomers.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnCustomers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bnCustomers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bnCustomers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bnCustomers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bnCustomers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnCustomers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCustomers.ForeColor = System.Drawing.Color.White;
            this.bnCustomers.Location = new System.Drawing.Point(71, 397);
            this.bnCustomers.Name = "bnCustomers";
            this.bnCustomers.Size = new System.Drawing.Size(180, 45);
            this.bnCustomers.TabIndex = 6;
            this.bnCustomers.Text = "Customers";
            // 
            // bnPurchase
            // 
            this.bnPurchase.AutoRoundedCorners = true;
            this.bnPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnPurchase.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnPurchase.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bnPurchase.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bnPurchase.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bnPurchase.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bnPurchase.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnPurchase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnPurchase.ForeColor = System.Drawing.Color.White;
            this.bnPurchase.Location = new System.Drawing.Point(71, 331);
            this.bnPurchase.Name = "bnPurchase";
            this.bnPurchase.Size = new System.Drawing.Size(180, 45);
            this.bnPurchase.TabIndex = 5;
            this.bnPurchase.Text = "Purchases";
            // 
            // bnProducts
            // 
            this.bnProducts.AutoRoundedCorners = true;
            this.bnProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnProducts.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnProducts.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bnProducts.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bnProducts.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bnProducts.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bnProducts.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnProducts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnProducts.ForeColor = System.Drawing.Color.White;
            this.bnProducts.Location = new System.Drawing.Point(71, 274);
            this.bnProducts.Name = "bnProducts";
            this.bnProducts.Size = new System.Drawing.Size(180, 45);
            this.bnProducts.TabIndex = 4;
            this.bnProducts.Text = "Products";
            // 
            // bnCategoy
            // 
            this.bnCategoy.AutoRoundedCorners = true;
            this.bnCategoy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnCategoy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnCategoy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bnCategoy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bnCategoy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bnCategoy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bnCategoy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnCategoy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCategoy.ForeColor = System.Drawing.Color.White;
            this.bnCategoy.Location = new System.Drawing.Point(71, 213);
            this.bnCategoy.Name = "bnCategoy";
            this.bnCategoy.Size = new System.Drawing.Size(180, 45);
            this.bnCategoy.TabIndex = 3;
            this.bnCategoy.Text = "Category";
            // 
            // bnHome
            // 
            this.bnHome.AutoRoundedCorners = true;
            this.bnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnHome.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bnHome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.bnHome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnHome.ForeColor = System.Drawing.Color.White;
            this.bnHome.Location = new System.Drawing.Point(71, 162);
            this.bnHome.Name = "bnHome";
            this.bnHome.Size = new System.Drawing.Size(180, 45);
            this.bnHome.TabIndex = 2;
            this.bnHome.Text = "Home";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(111, 37);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(64, 64);
            this.guna2CirclePictureBox1.TabIndex = 0;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // btUser
            // 
            this.btUser.AutoRoundedCorners = true;
            this.btUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUser.ForeColor = System.Drawing.Color.White;
            this.btUser.Location = new System.Drawing.Point(73, 523);
            this.btUser.Name = "btUser";
            this.btUser.Size = new System.Drawing.Size(180, 45);
            this.btUser.TabIndex = 8;
            this.btUser.Text = "User";
            this.btUser.Click += new System.EventHandler(this.btUser_Click);
            // 
            // frmMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 659);
            this.Controls.Add(this.pnRight);
            this.Controls.Add(this.pnLeft);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMai";
            this.Text = "Sales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.form_Load_Load);
            this.pnTop.ResumeLayout(false);
            this.pnLeft.ResumeLayout(false);
            this.pnLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox btMaxizeBox;
        private Guna.UI2.WinForms.Guna2ControlBox btExit;
        private Guna.UI2.WinForms.Guna2ControlBox btMinizeBox;
        private Guna.UI2.WinForms.Guna2Panel pnTop;
        private Guna.UI2.WinForms.Guna2Panel pnRight;
        private Guna.UI2.WinForms.Guna2Panel pnLeft;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2Button btSales;
        private Guna.UI2.WinForms.Guna2Button bnCustomers;
        private Guna.UI2.WinForms.Guna2Button bnPurchase;
        private Guna.UI2.WinForms.Guna2Button bnProducts;
        private Guna.UI2.WinForms.Guna2Button bnCategoy;
        private Guna.UI2.WinForms.Guna2Button bnHome;
        private Guna.UI2.WinForms.Guna2Button btUser;
    }
}