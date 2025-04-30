namespace InventoryManagement.View
{
    partial class frmViewPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewPurchase));
            this.dgvViewPurchase = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvSr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSupid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvDelete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(341, 32);
            // 
            // dgvViewPurchase
            // 
            this.dgvViewPurchase.AllowUserToAddRows = false;
            this.dgvViewPurchase.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvViewPurchase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvViewPurchase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvViewPurchase.ColumnHeadersHeight = 18;
            this.dgvViewPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvViewPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvSr,
            this.dgvid,
            this.dgvDate,
            this.dgvSupid,
            this.dgvSupplier,
            this.dgvAmount,
            this.dgvEdit,
            this.dgvDelete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvViewPurchase.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvViewPurchase.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvViewPurchase.Location = new System.Drawing.Point(94, 166);
            this.dgvViewPurchase.Name = "dgvViewPurchase";
            this.dgvViewPurchase.ReadOnly = true;
            this.dgvViewPurchase.RowHeadersVisible = false;
            this.dgvViewPurchase.RowHeadersWidth = 51;
            this.dgvViewPurchase.RowTemplate.Height = 24;
            this.dgvViewPurchase.Size = new System.Drawing.Size(718, 325);
            this.dgvViewPurchase.TabIndex = 3;
            this.dgvViewPurchase.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvViewPurchase.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvViewPurchase.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvViewPurchase.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvViewPurchase.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvViewPurchase.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvViewPurchase.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvViewPurchase.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvViewPurchase.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvViewPurchase.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvViewPurchase.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvViewPurchase.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvViewPurchase.ThemeStyle.HeaderStyle.Height = 18;
            this.dgvViewPurchase.ThemeStyle.ReadOnly = true;
            this.dgvViewPurchase.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvViewPurchase.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvViewPurchase.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvViewPurchase.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvViewPurchase.ThemeStyle.RowsStyle.Height = 24;
            this.dgvViewPurchase.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvViewPurchase.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgvSr
            // 
            this.dgvSr.HeaderText = "Sr";
            this.dgvSr.MinimumWidth = 6;
            this.dgvSr.Name = "dgvSr";
            this.dgvSr.ReadOnly = true;
            // 
            // dgvid
            // 
            this.dgvid.HeaderText = "dgvID";
            this.dgvid.MinimumWidth = 6;
            this.dgvid.Name = "dgvid";
            this.dgvid.ReadOnly = true;
            // 
            // dgvDate
            // 
            this.dgvDate.HeaderText = "Date";
            this.dgvDate.MinimumWidth = 6;
            this.dgvDate.Name = "dgvDate";
            this.dgvDate.ReadOnly = true;
            // 
            // dgvSupid
            // 
            this.dgvSupid.HeaderText = "Supid";
            this.dgvSupid.MinimumWidth = 6;
            this.dgvSupid.Name = "dgvSupid";
            this.dgvSupid.ReadOnly = true;
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.HeaderText = "Supplier";
            this.dgvSupplier.MinimumWidth = 6;
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.ReadOnly = true;
            // 
            // dgvAmount
            // 
            this.dgvAmount.HeaderText = "Amount";
            this.dgvAmount.MinimumWidth = 6;
            this.dgvAmount.Name = "dgvAmount";
            this.dgvAmount.ReadOnly = true;
            // 
            // dgvEdit
            // 
            this.dgvEdit.HeaderText = "Edit";
            this.dgvEdit.Image = ((System.Drawing.Image)(resources.GetObject("dgvEdit.Image")));
            this.dgvEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dgvEdit.MinimumWidth = 6;
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.ReadOnly = true;
            // 
            // dgvDelete
            // 
            this.dgvDelete.HeaderText = "Delete";
            this.dgvDelete.MinimumWidth = 6;
            this.dgvDelete.Name = "dgvDelete";
            this.dgvDelete.ReadOnly = true;
            // 
            // frmViewPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 558);
            this.Controls.Add(this.dgvViewPurchase);
            this.Name = "frmViewPurchase";
            this.Text = "frmViewPurchase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmViewPurchase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPurchase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgvViewPurchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSupid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAmount;
        private System.Windows.Forms.DataGridViewImageColumn dgvEdit;
        private System.Windows.Forms.DataGridViewImageColumn dgvDelete;
    }
}