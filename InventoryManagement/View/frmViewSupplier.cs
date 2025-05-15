using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using InventoryManagement.Model;
using TransferObject;

namespace InventoryManagement.View
{
    public partial class frmViewSupplier : SampleView
    {
        private SupplierBL supplierBL;  
        public frmViewSupplier()
        {
            InitializeComponent();
            supplierBL = new SupplierBL();
        }

        private void LoadData()
        {
            try
            {
                dgvSupplierView.DataSource = supplierBL.GetAllSuppliers();

                if (!dgvSupplierView.Columns.Contains("Update"))
                {
                    DataGridViewImageColumn updateIcon = new DataGridViewImageColumn();
                    updateIcon.Name = "Update";
                    updateIcon.HeaderText = "Sửa";
                    updateIcon.Image = Properties.Resources.update; // đường dẫn icon
                    updateIcon.ImageLayout = DataGridViewImageCellLayout.Zoom; // hoặc .Normal, .Stretch
                    dgvSupplierView.Columns.Add(updateIcon);
                }
                // Thêm nút Delete nếu chưa có
                if (!dgvSupplierView.Columns.Contains("Delete"))
                {
                    DataGridViewImageColumn updateIcon = new DataGridViewImageColumn();
                    updateIcon.Name = "Delete";
                    updateIcon.HeaderText = "Xóa";
                    updateIcon.Image = Properties.Resources.delet; // đường dẫn icon
                    updateIcon.ImageLayout = DataGridViewImageCellLayout.Zoom; // hoặc .Normal, .Stretch
                    dgvSupplierView.Columns.Add(updateIcon);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void frmViewSupplier_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btAddNew_Click(object sender, EventArgs e)
        {
            frmAddSupplier addSupplier = new frmAddSupplier();
            DialogResult dialogResult = addSupplier.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                // refresh
                LoadData();
            }
        }

        private void SearchSupplier()
        {
            string keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                dgvSupplierView.DataSource = supplierBL.SearchSupplier(keyword);
            }
            else
            {
                LoadData();
            }
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchSupplier();
        }

        private void dgvSupplierView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            int mancc = Convert.ToInt32(dgvSupplierView.Rows[e.RowIndex].Cells["MANCC"].Value);
            string columnName = dgvSupplierView.Columns[e.ColumnIndex].Name;

            if (columnName == "Update")
            {
                Supplier selected = supplierBL.GetAllSuppliers().FirstOrDefault(p => p.MANCC == mancc);
                if (selected != null)
                {
                    frmAddSupplier frm = new frmAddSupplier(selected);
                    DialogResult result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
            else if (columnName == "Delete")
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    int result = supplierBL.DeleteSupplier(mancc);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nhà cung cấp.", "Lỗi");
                    }
                }
            }
        }

    }
}
