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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMai));
            this.btMaxizeBox = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btMinizeBox = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnTop = new Guna.UI2.WinForms.Guna2Panel();
            this.pnRight = new Guna.UI2.WinForms.Guna2Panel();
            this.pnLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.lbUsername = new System.Windows.Forms.Label();
            this.btnSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.btUser = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnSetting = new Guna.UI2.WinForms.Guna2Button();
            this.pictureboxUsername = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btSales = new Guna.UI2.WinForms.Guna2Button();
            this.bnCustomers = new Guna.UI2.WinForms.Guna2Button();
            this.bnPurchase = new Guna.UI2.WinForms.Guna2Button();
            this.bnProducts = new Guna.UI2.WinForms.Guna2Button();
            this.bnCategoy = new Guna.UI2.WinForms.Guna2Button();
            this.bnHome = new Guna.UI2.WinForms.Guna2Button();
            this.pnTop.SuspendLayout();
            this.pnLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxUsername)).BeginInit();
            this.SuspendLayout();
            // 
            // btMaxizeBox
            // 
            this.btMaxizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMaxizeBox.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.btMaxizeBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.btMaxizeBox.IconColor = System.Drawing.Color.White;
            this.btMaxizeBox.Location = new System.Drawing.Point(960, 9);
            this.btMaxizeBox.Name = "btMaxizeBox";
            this.btMaxizeBox.Size = new System.Drawing.Size(45, 29);
            this.btMaxizeBox.TabIndex = 0;
            this.btMaxizeBox.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.CustomClick = true;
            this.btExit.FillColor = System.Drawing.Color.Crimson;
            this.btExit.IconColor = System.Drawing.Color.White;
            this.btExit.Location = new System.Drawing.Point(1023, 9);
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
            this.btMinizeBox.Location = new System.Drawing.Point(889, 9);
            this.btMinizeBox.Name = "btMinizeBox";
            this.btMinizeBox.Size = new System.Drawing.Size(45, 29);
            this.btMinizeBox.TabIndex = 2;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(61)))));
            this.pnTop.Controls.Add(this.btMaxizeBox);
            this.pnTop.Controls.Add(this.btExit);
            this.pnTop.Controls.Add(this.btMinizeBox);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1079, 45);
            this.pnTop.TabIndex = 3;
            this.pnTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnTop_Paint);
            // 
            // pnRight
            // 
            this.pnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(61)))));
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRight.Location = new System.Drawing.Point(308, 45);
            this.pnRight.Name = "pnRight";
            this.pnRight.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.pnRight.Size = new System.Drawing.Size(771, 828);
            this.pnRight.TabIndex = 4;
            this.pnRight.Paint += new System.Windows.Forms.PaintEventHandler(this.pnRight_Paint);
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnLeft.BorderRadius = 60;
            this.pnLeft.Controls.Add(this.btnSupplier);
            this.pnLeft.Controls.Add(this.btUser);
            this.pnLeft.Controls.Add(this.guna2Button1);
            this.pnLeft.Controls.Add(this.btnSetting);
            this.pnLeft.Controls.Add(this.pictureboxUsername);
            this.pnLeft.Controls.Add(this.btnLogout);
            this.pnLeft.Controls.Add(this.lbUsername);
            this.pnLeft.Controls.Add(this.btSales);
            this.pnLeft.Controls.Add(this.bnCustomers);
            this.pnLeft.Controls.Add(this.bnPurchase);
            this.pnLeft.Controls.Add(this.bnProducts);
            this.pnLeft.Controls.Add(this.bnCategoy);
            this.pnLeft.Controls.Add(this.bnHome);
            this.pnLeft.CustomizableEdges.BottomLeft = false;
            this.pnLeft.CustomizableEdges.BottomRight = false;
            this.pnLeft.CustomizableEdges.TopLeft = false;
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.FillColor = System.Drawing.Color.CornflowerBlue;
            this.pnLeft.Location = new System.Drawing.Point(0, 45);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(308, 828);
            this.pnLeft.TabIndex = 4;
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lbUsername.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.ForeColor = System.Drawing.Color.Transparent;
            this.lbUsername.Location = new System.Drawing.Point(80, 149);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(98, 21);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Text = "Username";
            this.lbUsername.Click += new System.EventHandler(this.lbUsername_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.AutoRoundedCorners = true;
            this.btnSupplier.BackColor = System.Drawing.Color.Transparent;
            this.btnSupplier.BorderColor = System.Drawing.Color.Transparent;
            this.btnSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSupplier.FillColor = System.Drawing.Color.Transparent;
            this.btnSupplier.Font = new System.Drawing.Font("Century Gothic", 10.2F);
            this.btnSupplier.ForeColor = System.Drawing.Color.White;
            this.btnSupplier.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.btnSupplier.Image = global::InventoryManagement.Properties.Resources.supplier;
            this.btnSupplier.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSupplier.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSupplier.Location = new System.Drawing.Point(46, 720);
            this.btnSupplier.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btnSupplier.Size = new System.Drawing.Size(207, 54);
            this.btnSupplier.TabIndex = 13;
            this.btnSupplier.Text = "     Supplier";
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btUser
            // 
            this.btUser.AutoRoundedCorners = true;
            this.btUser.BackColor = System.Drawing.Color.Transparent;
            this.btUser.BorderColor = System.Drawing.Color.Transparent;
            this.btUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btUser.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btUser.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btUser.ForeColor = System.Drawing.Color.White;
            this.btUser.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.btUser.Image = ((System.Drawing.Image)(resources.GetObject("btUser.Image")));
            this.btUser.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btUser.ImageSize = new System.Drawing.Size(30, 30);
            this.btUser.Location = new System.Drawing.Point(46, 780);
            this.btUser.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btUser.Name = "btUser";
            this.btUser.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btUser.Size = new System.Drawing.Size(207, 54);
            this.btUser.TabIndex = 8;
            this.btUser.Text = " User";
            this.btUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btUser.Click += new System.EventHandler(this.btUser_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.CornflowerBlue;
            this.guna2Button1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.Crimson;
            this.guna2Button1.Image = global::InventoryManagement.Properties.Resources.file;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button1.Location = new System.Drawing.Point(46, 660);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(207, 54);
            this.guna2Button1.TabIndex = 11;
            this.guna2Button1.Text = " Report";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.AutoRoundedCorners = true;
            this.btnSetting.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSetting.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btnSetting.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSetting.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSetting.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSetting.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSetting.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btnSetting.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.btnSetting.Image = global::InventoryManagement.Properties.Resources.setting;
            this.btnSetting.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSetting.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSetting.Location = new System.Drawing.Point(46, 540);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(207, 54);
            this.btnSetting.TabIndex = 9;
            this.btnSetting.Text = " Setting";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // pictureboxUsername
            // 
            this.pictureboxUsername.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pictureboxUsername.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureboxUsername.ErrorImage")));
            this.pictureboxUsername.Image = ((System.Drawing.Image)(resources.GetObject("pictureboxUsername.Image")));
            this.pictureboxUsername.ImageRotate = 0F;
            this.pictureboxUsername.Location = new System.Drawing.Point(46, 18);
            this.pictureboxUsername.Name = "pictureboxUsername";
            this.pictureboxUsername.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pictureboxUsername.Size = new System.Drawing.Size(207, 112);
            this.pictureboxUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureboxUsername.TabIndex = 0;
            this.pictureboxUsername.TabStop = false;
            this.pictureboxUsername.Click += new System.EventHandler(this.pictureboxUsername_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AutoRoundedCorners = true;
            this.btnLogout.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnLogout.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.CornflowerBlue;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.HoverState.FillColor = System.Drawing.Color.Crimson;
            this.btnLogout.Image = global::InventoryManagement.Properties.Resources._9104334_sign_out_logout_exit_out_icon;
            this.btnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.ImageSize = new System.Drawing.Size(30, 30);
            this.btnLogout.Location = new System.Drawing.Point(46, 600);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(207, 54);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = " Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btSales
            // 
            this.btSales.AutoRoundedCorners = true;
            this.btSales.BackColor = System.Drawing.Color.Transparent;
            this.btSales.BorderColor = System.Drawing.Color.Transparent;
            this.btSales.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSales.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSales.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSales.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSales.FillColor = System.Drawing.Color.Transparent;
            this.btSales.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSales.ForeColor = System.Drawing.Color.White;
            this.btSales.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.btSales.Image = ((System.Drawing.Image)(resources.GetObject("btSales.Image")));
            this.btSales.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btSales.ImageSize = new System.Drawing.Size(30, 30);
            this.btSales.Location = new System.Drawing.Point(46, 480);
            this.btSales.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btSales.Name = "btSales";
            this.btSales.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.btSales.Size = new System.Drawing.Size(207, 54);
            this.btSales.TabIndex = 7;
            this.btSales.Text = " Sale";
            this.btSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btSales.Click += new System.EventHandler(this.btSales_Click);
            // 
            // bnCustomers
            // 
            this.bnCustomers.AutoRoundedCorners = true;
            this.bnCustomers.BackColor = System.Drawing.Color.Transparent;
            this.bnCustomers.BorderColor = System.Drawing.Color.Transparent;
            this.bnCustomers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bnCustomers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bnCustomers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bnCustomers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bnCustomers.FillColor = System.Drawing.Color.Transparent;
            this.bnCustomers.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCustomers.ForeColor = System.Drawing.Color.White;
            this.bnCustomers.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.bnCustomers.Image = ((System.Drawing.Image)(resources.GetObject("bnCustomers.Image")));
            this.bnCustomers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bnCustomers.ImageSize = new System.Drawing.Size(30, 30);
            this.bnCustomers.Location = new System.Drawing.Point(46, 420);
            this.bnCustomers.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.bnCustomers.Name = "bnCustomers";
            this.bnCustomers.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.bnCustomers.Size = new System.Drawing.Size(207, 54);
            this.bnCustomers.TabIndex = 6;
            this.bnCustomers.Text = "     Customer";
            this.bnCustomers.Click += new System.EventHandler(this.bnCustomers_Click);
            // 
            // bnPurchase
            // 
            this.bnPurchase.AutoRoundedCorners = true;
            this.bnPurchase.BackColor = System.Drawing.Color.Transparent;
            this.bnPurchase.BorderColor = System.Drawing.Color.Transparent;
            this.bnPurchase.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bnPurchase.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bnPurchase.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bnPurchase.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bnPurchase.FillColor = System.Drawing.Color.Transparent;
            this.bnPurchase.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnPurchase.ForeColor = System.Drawing.Color.White;
            this.bnPurchase.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.bnPurchase.Image = ((System.Drawing.Image)(resources.GetObject("bnPurchase.Image")));
            this.bnPurchase.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bnPurchase.ImageSize = new System.Drawing.Size(30, 30);
            this.bnPurchase.Location = new System.Drawing.Point(46, 360);
            this.bnPurchase.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.bnPurchase.Name = "bnPurchase";
            this.bnPurchase.Size = new System.Drawing.Size(207, 54);
            this.bnPurchase.TabIndex = 5;
            this.bnPurchase.Text = "    Purchase";
            this.bnPurchase.Click += new System.EventHandler(this.bnPurchase_Click);
            // 
            // bnProducts
            // 
            this.bnProducts.AutoRoundedCorners = true;
            this.bnProducts.BackColor = System.Drawing.Color.Transparent;
            this.bnProducts.BorderColor = System.Drawing.Color.Transparent;
            this.bnProducts.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bnProducts.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bnProducts.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bnProducts.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bnProducts.FillColor = System.Drawing.Color.Transparent;
            this.bnProducts.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnProducts.ForeColor = System.Drawing.Color.White;
            this.bnProducts.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.bnProducts.Image = ((System.Drawing.Image)(resources.GetObject("bnProducts.Image")));
            this.bnProducts.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bnProducts.ImageSize = new System.Drawing.Size(30, 30);
            this.bnProducts.Location = new System.Drawing.Point(46, 300);
            this.bnProducts.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.bnProducts.Name = "bnProducts";
            this.bnProducts.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.bnProducts.Size = new System.Drawing.Size(207, 54);
            this.bnProducts.TabIndex = 4;
            this.bnProducts.Text = "   Products";
            this.bnProducts.Click += new System.EventHandler(this.bnProducts_Click);
            // 
            // bnCategoy
            // 
            this.bnCategoy.AutoRoundedCorners = true;
            this.bnCategoy.BackColor = System.Drawing.Color.Transparent;
            this.bnCategoy.BorderColor = System.Drawing.Color.Transparent;
            this.bnCategoy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bnCategoy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bnCategoy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bnCategoy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bnCategoy.FillColor = System.Drawing.Color.Transparent;
            this.bnCategoy.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnCategoy.ForeColor = System.Drawing.Color.White;
            this.bnCategoy.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.bnCategoy.Image = ((System.Drawing.Image)(resources.GetObject("bnCategoy.Image")));
            this.bnCategoy.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bnCategoy.ImageSize = new System.Drawing.Size(30, 30);
            this.bnCategoy.Location = new System.Drawing.Point(46, 240);
            this.bnCategoy.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.bnCategoy.Name = "bnCategoy";
            this.bnCategoy.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.bnCategoy.Size = new System.Drawing.Size(207, 54);
            this.bnCategoy.TabIndex = 3;
            this.bnCategoy.Text = "     Category";
            this.bnCategoy.Click += new System.EventHandler(this.bnCategoy_Click);
            // 
            // bnHome
            // 
            this.bnHome.AutoRoundedCorners = true;
            this.bnHome.BackColor = System.Drawing.Color.Transparent;
            this.bnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bnHome.BackgroundImage")));
            this.bnHome.BorderColor = System.Drawing.Color.Transparent;
            this.bnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bnHome.FillColor = System.Drawing.Color.Transparent;
            this.bnHome.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnHome.ForeColor = System.Drawing.Color.White;
            this.bnHome.HoverState.FillColor = System.Drawing.Color.LightSkyBlue;
            this.bnHome.Image = ((System.Drawing.Image)(resources.GetObject("bnHome.Image")));
            this.bnHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bnHome.ImageSize = new System.Drawing.Size(30, 30);
            this.bnHome.Location = new System.Drawing.Point(46, 180);
            this.bnHome.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.bnHome.Name = "bnHome";
            this.bnHome.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.bnHome.Size = new System.Drawing.Size(207, 54);
            this.bnHome.TabIndex = 2;
            this.bnHome.Text = " Home";
            this.bnHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bnHome.Click += new System.EventHandler(this.bnHome_Click);
            // 
            // frmMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1079, 873);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxUsername)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox btMaxizeBox;
        private Guna.UI2.WinForms.Guna2ControlBox btExit;
        private Guna.UI2.WinForms.Guna2ControlBox btMinizeBox;
        private Guna.UI2.WinForms.Guna2Panel pnTop;
        private Guna.UI2.WinForms.Guna2Panel pnRight;
        private Guna.UI2.WinForms.Guna2Panel pnLeft;
        private System.Windows.Forms.Label lbUsername;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pictureboxUsername;
        private Guna.UI2.WinForms.Guna2Button btSales;
        private Guna.UI2.WinForms.Guna2Button bnCustomers;
        private Guna.UI2.WinForms.Guna2Button bnPurchase;
        private Guna.UI2.WinForms.Guna2Button bnProducts;
        private Guna.UI2.WinForms.Guna2Button bnCategoy;
        private Guna.UI2.WinForms.Guna2Button bnHome;
        private Guna.UI2.WinForms.Guna2Button btUser;
        public Guna.UI2.WinForms.Guna2Button btnSetting;
        public Guna.UI2.WinForms.Guna2Button btnLogout;
        public Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button btnSupplier;
    }
}