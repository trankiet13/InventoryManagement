using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using Guna.UI2.WinForms;
using InventoryManagement.Model;

namespace InventoryManagement.View
{
    public partial class frmViewXuatXu : SampleView
    {
        private readonly XuatXuBL xuatXuBL = new XuatXuBL();
        public frmViewXuatXu()
        {
            InitializeComponent();
        }



        public void LoadData()
        {
            try
            {
                DataTable dt = xuatXuBL.GetXuatXu(txtSearch.Text);

                // Đảm bảo cấu trúc DataGridView trước khi gán dữ liệu
                dgvViewXuatXu.Columns.Clear();
                dgvViewXuatXu.AutoGenerateColumns = false;

                // Cột ID
                DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
                colId.Name = "dgvId";
                colId.HeaderText = "ID";
                colId.DataPropertyName = "ID";
                dgvViewXuatXu.Columns.Add(colId);

                // Cột Name
                DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
                colName.Name = "dgvName";
                colName.HeaderText = "Name";
                colName.DataPropertyName = "TEN";
                dgvViewXuatXu.Columns.Add(colName);
                // Cột Edit
                DataGridViewImageColumn dgvEdit = new DataGridViewImageColumn();
                dgvEdit.Name = "dgvEdit";
                dgvEdit.HeaderText = "Sửa";
                dgvEdit.Image = Properties.Resources.update; // Thêm icon từ Resources
                dgvEdit.Width = 60;
                dgvEdit.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvViewXuatXu.Columns.Add(dgvEdit);

                // Cột Xóa (Sử dụng ImageColumn)
                DataGridViewImageColumn dgvDelete = new DataGridViewImageColumn();
                dgvDelete.Name = "dgvDelete";
                dgvDelete.HeaderText = "Xóa";
                dgvDelete.Image = Properties.Resources.delet; // Thêm icon từ Resources
                dgvDelete.Width = 60;
                dgvDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvViewXuatXu.Columns.Add(dgvDelete);
                dgvViewXuatXu.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Search
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btAddNew_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackGround(new frmAddXuatXu(this));
            LoadData();
        }

        private void dgvViewXuatXu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Xử lý sự kiện chỉnh sửa (dgvEdit)
                if (dgvViewXuatXu.Columns[e.ColumnIndex].Name == "dgvEdit")
                {
                    frmAddXuatXu frm = new frmAddXuatXu(this);
                    frm.id = Convert.ToInt32(dgvViewXuatXu.Rows[e.RowIndex].Cells["dgvId"].Value);
                    frm.txtName.Text = dgvViewXuatXu.Rows[e.RowIndex].Cells["dgvName"].Value.ToString();

                    MainClass.BlurBackGround(frm);
                    LoadData();
                }
                // Xử lý sự kiện xóa (dgvDelete)
                else if (dgvViewXuatXu.Columns[e.ColumnIndex].Name == "dgvDelete")
                {
                    Guna2MessageDialog dialog = new Guna2MessageDialog()
                    {
                        Buttons = MessageDialogButtons.YesNo,
                        Icon = MessageDialogIcon.Question,
                        Text = "Bạn có chắc chắn muốn xóa danh mục này?"
                    };

                    if (dialog.Show() == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvViewXuatXu.Rows[e.RowIndex].Cells["dgvId"].Value);
                        try
                        {
                            int result = xuatXuBL.DeleteXuatXu(id);
                            if (result > 0)
                            {
                                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void frmViewXuatXu_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
