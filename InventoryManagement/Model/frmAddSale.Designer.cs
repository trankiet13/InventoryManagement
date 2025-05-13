namespace InventoryManagement.Model
{
    partial class frmAddSale
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSale));
            this.lbCustomer = new System.Windows.Forms.Label();
            this.cbCustomer = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbName = new System.Windows.Forms.Label();
            this.txtBarcode = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ucProduct1 = new InventoryManagement.Model.ucProduct();
            this.ucProduct2 = new InventoryManagement.Model.ucProduct();
            this.ucProduct3 = new InventoryManagement.Model.ucProduct();
            this.ucProduct4 = new InventoryManagement.Model.ucProduct();
            this.ucProduct5 = new InventoryManagement.Model.ucProduct();
            this.ucProduct6 = new InventoryManagement.Model.ucProduct();
            this.ucProduct7 = new InventoryManagement.Model.ucProduct();
            this.ucProduct8 = new InventoryManagement.Model.ucProduct();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btClosee = new Guna.UI2.WinForms.Guna2Button();
            this.btSave = new Guna.UI2.WinForms.Guna2Button();
            this.dgvID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvproid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCustomer
            // 
            this.lbCustomer.AutoSize = true;
            this.lbCustomer.Location = new System.Drawing.Point(277, 32);
            this.lbCustomer.Name = "lbCustomer";
            this.lbCustomer.Size = new System.Drawing.Size(64, 16);
            this.lbCustomer.TabIndex = 19;
            this.lbCustomer.Text = "Customer";
            // 
            // cbCustomer
            // 
            this.cbCustomer.AutoRoundedCorners = true;
            this.cbCustomer.BackColor = System.Drawing.Color.Transparent;
            this.cbCustomer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomer.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCustomer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCustomer.ItemHeight = 30;
            this.cbCustomer.Location = new System.Drawing.Point(255, 53);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(187, 36);
            this.cbCustomer.TabIndex = 18;
            this.cbCustomer.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Date";
            // 
            // txtDateTime
            // 
            this.txtDateTime.Animated = true;
            this.txtDateTime.AutoRoundedCorners = true;
            this.txtDateTime.BackColor = System.Drawing.Color.Transparent;
            this.txtDateTime.Checked = true;
            this.txtDateTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.txtDateTime.IndicateFocus = true;
            this.txtDateTime.Location = new System.Drawing.Point(32, 51);
            this.txtDateTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtDateTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtDateTime.Name = "txtDateTime";
            this.txtDateTime.Size = new System.Drawing.Size(200, 36);
            this.txtDateTime.TabIndex = 16;
            this.txtDateTime.UseTransparentBackground = true;
            this.txtDateTime.Value = new System.DateTime(2025, 4, 15, 21, 29, 2, 179);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(471, 30);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 16);
            this.lbName.TabIndex = 21;
            this.lbName.Text = "Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Animated = true;
            this.txtBarcode.AutoRoundedCorners = true;
            this.txtBarcode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBarcode.DefaultText = "";
            this.txtBarcode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBarcode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBarcode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBarcode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBarcode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBarcode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBarcode.Location = new System.Drawing.Point(459, 51);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.PlaceholderText = "";
            this.txtBarcode.SelectedText = "";
            this.txtBarcode.Size = new System.Drawing.Size(197, 40);
            this.txtBarcode.TabIndex = 20;
          
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.lbPrice);
            this.guna2Panel1.Controls.Add(this.lbTotal);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            this.guna2Panel1.Location = new System.Drawing.Point(727, 32);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(388, 57);
            this.guna2Panel1.TabIndex = 22;
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbPrice.Location = new System.Drawing.Point(225, 16);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(50, 25);
            this.lbPrice.TabIndex = 28;
            this.lbPrice.Text = "0.00";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.BackColor = System.Drawing.Color.Transparent;
            this.lbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbTotal.Location = new System.Drawing.Point(37, 16);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(115, 25);
            this.lbTotal.TabIndex = 27;
            this.lbTotal.Text = "Grand Total";
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.guna2DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.guna2DataGridView1.ColumnHeadersHeight = 30;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvID,
            this.dgvproid,
            this.dgvProduct,
            this.dgvQty,
            this.dgvPrice,
            this.dgvAmount,
            this.dgvCost,
            this.dataGridViewImageColumn1});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(727, 118);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.Size = new System.Drawing.Size(402, 475);
            this.guna2DataGridView1.TabIndex = 23;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 30;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.ucProduct1);
            this.flowLayoutPanel1.Controls.Add(this.ucProduct2);
            this.flowLayoutPanel1.Controls.Add(this.ucProduct3);
            this.flowLayoutPanel1.Controls.Add(this.ucProduct4);
            this.flowLayoutPanel1.Controls.Add(this.ucProduct5);
            this.flowLayoutPanel1.Controls.Add(this.ucProduct6);
            this.flowLayoutPanel1.Controls.Add(this.ucProduct7);
            this.flowLayoutPanel1.Controls.Add(this.ucProduct8);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 174);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(644, 419);
            this.flowLayoutPanel1.TabIndex = 24;
            // 
            // ucProduct1
            // 
            this.ucProduct1.id = 0;
            this.ucProduct1.Location = new System.Drawing.Point(3, 3);
            this.ucProduct1.Name = "ucProduct1";
            this.ucProduct1.Pcost = null;
            this.ucProduct1.Pimage = ((System.Drawing.Image)(resources.GetObject("ucProduct1.Pimage")));
            this.ucProduct1.PName = "Prduct Name";
            this.ucProduct1.Price = "200";
            this.ucProduct1.Size = new System.Drawing.Size(153, 196);
            this.ucProduct1.TabIndex = 0;
            this.ucProduct1.Visible = false;
            // 
            // ucProduct2
            // 
            this.ucProduct2.id = 0;
            this.ucProduct2.Location = new System.Drawing.Point(162, 3);
            this.ucProduct2.Name = "ucProduct2";
            this.ucProduct2.Pcost = null;
            this.ucProduct2.Pimage = ((System.Drawing.Image)(resources.GetObject("ucProduct2.Pimage")));
            this.ucProduct2.PName = "Prduct Name";
            this.ucProduct2.Price = "200";
            this.ucProduct2.Size = new System.Drawing.Size(153, 196);
            this.ucProduct2.TabIndex = 1;
            this.ucProduct2.Visible = false;
            // 
            // ucProduct3
            // 
            this.ucProduct3.id = 0;
            this.ucProduct3.Location = new System.Drawing.Point(321, 3);
            this.ucProduct3.Name = "ucProduct3";
            this.ucProduct3.Pcost = null;
            this.ucProduct3.Pimage = ((System.Drawing.Image)(resources.GetObject("ucProduct3.Pimage")));
            this.ucProduct3.PName = "Prduct Name";
            this.ucProduct3.Price = "200";
            this.ucProduct3.Size = new System.Drawing.Size(153, 196);
            this.ucProduct3.TabIndex = 2;
            this.ucProduct3.Visible = false;
            // 
            // ucProduct4
            // 
            this.ucProduct4.id = 0;
            this.ucProduct4.Location = new System.Drawing.Point(480, 3);
            this.ucProduct4.Name = "ucProduct4";
            this.ucProduct4.Pcost = null;
            this.ucProduct4.Pimage = ((System.Drawing.Image)(resources.GetObject("ucProduct4.Pimage")));
            this.ucProduct4.PName = "Prduct Name";
            this.ucProduct4.Price = "200";
            this.ucProduct4.Size = new System.Drawing.Size(153, 196);
            this.ucProduct4.TabIndex = 3;
            this.ucProduct4.Visible = false;
            // 
            // ucProduct5
            // 
            this.ucProduct5.id = 0;
            this.ucProduct5.Location = new System.Drawing.Point(3, 205);
            this.ucProduct5.Name = "ucProduct5";
            this.ucProduct5.Pcost = null;
            this.ucProduct5.Pimage = ((System.Drawing.Image)(resources.GetObject("ucProduct5.Pimage")));
            this.ucProduct5.PName = "Prduct Name";
            this.ucProduct5.Price = "200";
            this.ucProduct5.Size = new System.Drawing.Size(153, 196);
            this.ucProduct5.TabIndex = 4;
            this.ucProduct5.Visible = false;
            // 
            // ucProduct6
            // 
            this.ucProduct6.id = 0;
            this.ucProduct6.Location = new System.Drawing.Point(162, 205);
            this.ucProduct6.Name = "ucProduct6";
            this.ucProduct6.Pcost = null;
            this.ucProduct6.Pimage = ((System.Drawing.Image)(resources.GetObject("ucProduct6.Pimage")));
            this.ucProduct6.PName = "Prduct Name";
            this.ucProduct6.Price = "200";
            this.ucProduct6.Size = new System.Drawing.Size(153, 196);
            this.ucProduct6.TabIndex = 5;
            this.ucProduct6.Visible = false;
            // 
            // ucProduct7
            // 
            this.ucProduct7.id = 0;
            this.ucProduct7.Location = new System.Drawing.Point(321, 205);
            this.ucProduct7.Name = "ucProduct7";
            this.ucProduct7.Pcost = null;
            this.ucProduct7.Pimage = ((System.Drawing.Image)(resources.GetObject("ucProduct7.Pimage")));
            this.ucProduct7.PName = "Prduct Name";
            this.ucProduct7.Price = "200";
            this.ucProduct7.Size = new System.Drawing.Size(153, 196);
            this.ucProduct7.TabIndex = 6;
            this.ucProduct7.Visible = false;
            // 
            // ucProduct8
            // 
            this.ucProduct8.id = 0;
            this.ucProduct8.Location = new System.Drawing.Point(480, 205);
            this.ucProduct8.Name = "ucProduct8";
            this.ucProduct8.Pcost = null;
            this.ucProduct8.Pimage = ((System.Drawing.Image)(resources.GetObject("ucProduct8.Pimage")));
            this.ucProduct8.PName = "Prduct Name";
            this.ucProduct8.Price = "200";
            this.ucProduct8.Size = new System.Drawing.Size(153, 196);
            this.ucProduct8.TabIndex = 7;
            this.ucProduct8.Visible = false;
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(243)))), ((int)(((byte)(238)))));
            this.lbSearch.Location = new System.Drawing.Point(44, 97);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(50, 16);
            this.lbSearch.TabIndex = 26;
            this.lbSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Animated = true;
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(32, 118);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(197, 40);
            this.txtSearch.TabIndex = 25;
           
            // 
            // btClosee
            // 
            this.btClosee.Animated = true;
            this.btClosee.AutoRoundedCorners = true;
            this.btClosee.BorderColor = System.Drawing.Color.Red;
            this.btClosee.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btClosee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btClosee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btClosee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btClosee.FillColor = System.Drawing.Color.Red;
            this.btClosee.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btClosee.ForeColor = System.Drawing.Color.White;
            this.btClosee.Location = new System.Drawing.Point(518, 113);
            this.btClosee.Name = "btClosee";
            this.btClosee.Size = new System.Drawing.Size(99, 45);
            this.btClosee.TabIndex = 9;
            this.btClosee.Text = "Clear";
           
            // 
            // btSave
            // 
            this.btSave.Animated = true;
            this.btSave.AutoRoundedCorners = true;
            this.btSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(69)))), ((int)(((byte)(204)))));
            this.btSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btSave.ForeColor = System.Drawing.Color.White;
            this.btSave.Location = new System.Drawing.Point(392, 113);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(107, 45);
            this.btSave.TabIndex = 8;
            this.btSave.Text = "Save";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // dgvID
            // 
            this.dgvID.FillWeight = 53.17036F;
            this.dgvID.HeaderText = "ID";
            this.dgvID.MinimumWidth = 6;
            this.dgvID.Name = "dgvID";
            this.dgvID.Visible = false;
            // 
            // dgvproid
            // 
            this.dgvproid.FillWeight = 53.17036F;
            this.dgvproid.HeaderText = "ProID";
            this.dgvproid.MinimumWidth = 6;
            this.dgvproid.Name = "dgvproid";
            this.dgvproid.Visible = false;
            // 
            // dgvProduct
            // 
            this.dgvProduct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvProduct.HeaderText = "Product";
            this.dgvProduct.MinimumWidth = 100;
            this.dgvProduct.Name = "dgvProduct";
            // 
            // dgvQty
            // 
            this.dgvQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvQty.FillWeight = 70F;
            this.dgvQty.HeaderText = "Quantity";
            this.dgvQty.MinimumWidth = 70;
            this.dgvQty.Name = "dgvQty";
            this.dgvQty.Width = 70;
            // 
            // dgvPrice
            // 
            this.dgvPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvPrice.FillWeight = 70F;
            this.dgvPrice.HeaderText = "Price";
            this.dgvPrice.MinimumWidth = 70;
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.Width = 70;
            // 
            // dgvAmount
            // 
            this.dgvAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvAmount.FillWeight = 70F;
            this.dgvAmount.HeaderText = "Amount";
            this.dgvAmount.MinimumWidth = 70;
            this.dgvAmount.Name = "dgvAmount";
            this.dgvAmount.Width = 70;
            // 
            // dgvCost
            // 
            this.dgvCost.HeaderText = "Cost";
            this.dgvCost.MinimumWidth = 6;
            this.dgvCost.Name = "dgvCost";
            this.dgvCost.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.FillWeight = 30F;
            this.dataGridViewImageColumn1.HeaderText = "Delete";
            this.dataGridViewImageColumn1.MinimumWidth = 30;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Visible = false;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // frmAddSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 631);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.guna2DataGridView1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lbCustomer);
            this.Controls.Add(this.btClosee);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDateTime);
            this.KeyPreview = true;
            this.Name = "frmAddSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddSale";
            this.Load += new System.EventHandler(this.frmAddSale_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCustomer;
        private Guna.UI2.WinForms.Guna2ComboBox cbCustomer;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker txtDateTime;
        private System.Windows.Forms.Label lbName;
        public Guna.UI2.WinForms.Guna2TextBox txtBarcode;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbSearch;
        public Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label lbTotal;
        private ucProduct ucProduct1;
        private System.Windows.Forms.Label lbPrice;
        private ucProduct ucProduct2;
        private ucProduct ucProduct3;
        private ucProduct ucProduct4;
        private ucProduct ucProduct5;
        private ucProduct ucProduct6;
        private ucProduct ucProduct7;
        private ucProduct ucProduct8;
        public Guna.UI2.WinForms.Guna2Button btClosee;
        public Guna.UI2.WinForms.Guna2Button btSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvproid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCost;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}