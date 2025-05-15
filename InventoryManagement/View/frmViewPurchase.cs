using InventoryManagement.Model;
using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer; // Thêm namespace BusinessLayer
using Guna.UI2.WinForms;

namespace InventoryManagement.View
{
    public partial class frmViewPurchase : SampleView
    {
        private readonly PurchaseBL _purchaseBL = new PurchaseBL();

        public frmViewPurchase()
        {
            InitializeComponent();

        }

        private void frmViewPurchase_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            dgvViewPurchase.RowPostPaint += DgvViewPurchase_RowPostPaint; // Thêm dòng này
            LoadData();
        }

        private void DgvViewPurchase_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Chỉ gán số thứ tự vào cột "dgvSr" (xóa phần vẽ lên header)
            if (dgvViewPurchase.Columns.Contains("dgvSr"))
            {
                dgvViewPurchase.Rows[e.RowIndex].Cells["dgvSr"].Value = e.RowIndex + 1;
            }
        }
        public void LoadPurchases()
        {
            // Giả sử phương thức này tải dữ liệu từ CSDL
            DataTable dt = _purchaseBL.LoadPurchases("");
            dgvViewPurchase.DataSource = dt;

            // Định dạng cột Amount không hiển thị số thập phân
            dgvViewPurchase.Columns["Amount"].DefaultCellStyle.Format = "N0";
        }
        private void ConfigureDataGridView()
        {
            dgvViewPurchase.AutoGenerateColumns = false;
            dgvViewPurchase.Columns.Clear();

            // --- Cột Số thứ tự (KHÔNG liên kết CSDL) ---
            DataGridViewTextBoxColumn dgvSr = new DataGridViewTextBoxColumn();
            dgvSr.Name = "dgvSr";
            dgvSr.HeaderText = "Sr #";
            dgvSr.ReadOnly = true;
            dgvSr.Width = 50;
            dgvViewPurchase.Columns.Add(dgvSr);

            // --- Các cột dữ liệu từ CSDL ---
            // Cột ID (Ẩn đi nếu không cần hiển thị)
            DataGridViewTextBoxColumn dgvid = new DataGridViewTextBoxColumn();
            dgvid.Name = "dgvid";
            dgvid.HeaderText = "ID";
            dgvid.DataPropertyName = "dMainID";
            dgvid.Visible = false; // Ẩn cột ID
            dgvViewPurchase.Columns.Add(dgvid);

            // Cột Ngày
            DataGridViewTextBoxColumn dgvDate = new DataGridViewTextBoxColumn();
            dgvDate.Name = "dgvDate";
            dgvDate.HeaderText = "Ngày";
            dgvDate.DataPropertyName = "mdate";
            dgvViewPurchase.Columns.Add(dgvDate);

            // Cột Mã NCC
            DataGridViewTextBoxColumn dgvsupid = new DataGridViewTextBoxColumn();
            dgvsupid.Name = "dgvsupid";
            dgvsupid.HeaderText = "Mã NCC";
            dgvsupid.DataPropertyName = "mSupCusId";
            dgvViewPurchase.Columns.Add(dgvsupid);

            // Cột Tên NCC
            DataGridViewTextBoxColumn dgvSupplier = new DataGridViewTextBoxColumn();
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.HeaderText = "Nhà cung cấp";
            dgvSupplier.DataPropertyName = "TENNCC";
            dgvViewPurchase.Columns.Add(dgvSupplier);

            // Cột Tổng tiền (Sửa lại DataPropertyName)
            DataGridViewTextBoxColumn dgvAmount = new DataGridViewTextBoxColumn();
            dgvAmount.Name = "dgvAmount";
            dgvAmount.HeaderText = "Tổng tiền";
            dgvAmount.DataPropertyName = "TotalAmount"; // Phải trùng với tên cột trong SQL
            dgvViewPurchase.Columns.Add(dgvAmount);

            // Thêm nút Edit/Delete (tuỳ chỉnh theo control thực tế của bạn)
            DataGridViewImageColumn dgvEdit = new DataGridViewImageColumn();
            dgvEdit.Name = "dgvEdit";
            dgvEdit.HeaderText = "Sửa";
            dgvEdit.Image = Properties.Resources.update; // Thêm icon từ Resources
            dgvEdit.Width = 60;
            dgvEdit.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvViewPurchase.Columns.Add(dgvEdit);

            // Cột Xóa (Sử dụng ImageColumn)
            DataGridViewImageColumn dgvDelete = new DataGridViewImageColumn();
            dgvDelete.Name = "dgvDelete";
            dgvDelete.HeaderText = "Xóa";
            dgvDelete.Image = Properties.Resources.delet; // Thêm icon từ Resources
            dgvDelete.Width = 60;
            dgvDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvViewPurchase.Columns.Add(dgvDelete);
        }

        private void LoadData()
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                DataTable dt = _purchaseBL.LoadPurchases(searchText);
                dgvViewPurchase.DataSource = dt;

                // Kích hoạt đánh lại số thứ tự
                dgvViewPurchase.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void btAddNew_Click(object sender, EventArgs e)
        {
            frmAddPurchase frmAddPurchase = new frmAddPurchase();
            frmAddPurchase.ShowDialog();
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            {
                // Xử lý nút Sửa
                if (dgvViewPurchase.Columns[e.ColumnIndex].Name == "dgvEdit")
                {
                    DataGridViewRow row = dgvViewPurchase.Rows[e.RowIndex];
                    frmAddPurchase frm = new frmAddPurchase
                    {
                        MainID = Convert.ToInt32(row.Cells["dgvid"].Value),
                        supID = Convert.ToInt32(row.Cells["dgvsupid"].Value),
                        PurchaseDate = Convert.ToDateTime(row.Cells["dgvDate"].Value),
                        TotalAmount = Convert.ToDecimal(row.Cells["dgvAmount"].Value)
                    };
                    frm.ShowDialog();
                    LoadData();
                    return;
                }

                // Xử lý nút Xóa
                if (dgvViewPurchase.Columns[e.ColumnIndex].Name == "dgvDelete")
                {
                    Guna2MessageDialog confirmDialog = new Guna2MessageDialog
                    {
                        Buttons = MessageDialogButtons.YesNo,
                        Icon = MessageDialogIcon.Warning,
                        Text = "Bạn có chắc chắn muốn xóa đơn hàng này?"
                    };

                    if (confirmDialog.Show() == DialogResult.Yes)
                    {
                        try
                        {
                            int mainID = Convert.ToInt32(dgvViewPurchase.Rows[e.RowIndex].Cells["dgvid"].Value);
                            bool success = _purchaseBL.DeletePurchase(mainID);

                            if (success)
                            {
                                Guna2MessageDialog successDialog = new Guna2MessageDialog
                                {
                                    Buttons = MessageDialogButtons.OK,
                                    Icon = MessageDialogIcon.Information,
                                    Text = "Xóa đơn hàng thành công!"
                                };
                                successDialog.Show();
                                LoadData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}