namespace InventoryManagement.View
{
    partial class frmUserView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dvgSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvpass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvdvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvDel = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.guna2DataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView1.ColumnHeadersHeight = 35;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dvgSTT,
            this.dgvid,
            this.dgvUserName,
            this.dgvname,
            this.dgvpass,
            this.dgvCty,
            this.dgvdvi,
            this.dgvRole,
            this.dgvEdit,
            this.dgvDel});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(47, 137);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.Size = new System.Drawing.Size(846, 344);
            this.guna2DataGridView1.TabIndex = 1;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 35;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellClick);
       
            // 
            // dvgSTT
            // 
            this.dvgSTT.HeaderText = "STT";
            this.dvgSTT.MinimumWidth = 6;
            this.dvgSTT.Name = "dvgSTT";
            this.dvgSTT.ReadOnly = true;
            // 
            // dgvid
            // 
            this.dgvid.HeaderText = "IDUSER";
            this.dgvid.MinimumWidth = 6;
            this.dgvid.Name = "dgvid";
            this.dgvid.ReadOnly = true;
            this.dgvid.Visible = false;
            // 
            // dgvUserName
            // 
            this.dgvUserName.HeaderText = "UserName";
            this.dgvUserName.MinimumWidth = 6;
            this.dgvUserName.Name = "dgvUserName";
            this.dgvUserName.ReadOnly = true;
            // 
            // dgvname
            // 
            this.dgvname.HeaderText = "Full Name";
            this.dgvname.MinimumWidth = 6;
            this.dgvname.Name = "dgvname";
            this.dgvname.ReadOnly = true;
            // 
            // dgvpass
            // 
            this.dgvpass.HeaderText = "PASSWD";
            this.dgvpass.MinimumWidth = 6;
            this.dgvpass.Name = "dgvpass";
            this.dgvpass.ReadOnly = true;
            this.dgvpass.Visible = false;
            // 
            // dgvCty
            // 
            this.dgvCty.HeaderText = "Mã Công Ty";
            this.dgvCty.MinimumWidth = 6;
            this.dgvCty.Name = "dgvCty";
            this.dgvCty.ReadOnly = true;
            // 
            // dgvdvi
            // 
            this.dgvdvi.HeaderText = "Đơn vị";
            this.dgvdvi.MinimumWidth = 6;
            this.dgvdvi.Name = "dgvdvi";
            this.dgvdvi.ReadOnly = true;
            // 
            // dgvRole
            // 
            this.dgvRole.HeaderText = "Role";
            this.dgvRole.MinimumWidth = 6;
            this.dgvRole.Name = "dgvRole";
            this.dgvRole.ReadOnly = true;
            // 
            // dgvEdit
            // 
            this.dgvEdit.HeaderText = "";
            this.dgvEdit.Image = global::InventoryManagement.Properties.Resources._9055423_bxs_edit_icon;
            this.dgvEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvEdit.MinimumWidth = 6;
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.ReadOnly = true;
            // 
            // dgvDel
            // 
            this.dgvDel.HeaderText = "";
            this.dgvDel.Image = global::InventoryManagement.Properties.Resources._1564502_basket_delete_remove_icon;
            this.dgvDel.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvDel.MinimumWidth = 6;
            this.dgvDel.Name = "dgvDel";
            this.dgvDel.ReadOnly = true;
            // 
            // frmUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 507);
            this.Controls.Add(this.guna2DataGridView1);
            this.Name = "frmUserView";
            this.Text = "frmUserView";
            this.Load += new System.EventHandler(this.frmUserView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dvgSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvpass;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvdvi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRole;
        private System.Windows.Forms.DataGridViewImageColumn dgvEdit;
        private System.Windows.Forms.DataGridViewImageColumn dgvDel;
    }
}