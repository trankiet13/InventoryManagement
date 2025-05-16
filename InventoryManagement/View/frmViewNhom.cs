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
    public partial class frmViewNhom : SampleView
    {
        private readonly NhomHHBL nhomHHBL = new NhomHHBL();
        public frmViewNhom()
        {
            InitializeComponent();

        }

        private void frmViewNhom_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                DataTable dt = nhomHHBL.GetNhomHH(txtSearch.Text);

                // Đảm bảo cấu trúc DataGridView trước khi gán dữ liệu
                dgvViewNhom.Columns.Clear();
                dgvViewNhom.AutoGenerateColumns = false;

                // Cột ID
                DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
                colId.Name = "dgvId";
                colId.HeaderText = "ID";
                colId.DataPropertyName = "IDNHOM";
                dgvViewNhom.Columns.Add(colId);

                // Cột Name
                DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
                colName.Name = "dgvName";
                colName.HeaderText = "Name";
                colName.DataPropertyName = "TENNHOM";
                dgvViewNhom.Columns.Add(colName);
                // Cột Edit
                DataGridViewImageColumn dgvEdit = new DataGridViewImageColumn();
                dgvEdit.Name = "dgvEdit";
                dgvEdit.HeaderText = "Sửa";
                dgvEdit.Image = Properties.Resources.update; // Thêm icon từ Resources
                dgvEdit.Width = 60;
                dgvEdit.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvViewNhom.Columns.Add(dgvEdit);

                // Cột Xóa (Sử dụng ImageColumn)
                DataGridViewImageColumn dgvDelete = new DataGridViewImageColumn();
                dgvDelete.Name = "dgvDelete";
                dgvDelete.HeaderText = "Xóa";
                dgvDelete.Image = Properties.Resources.delet; // Thêm icon từ Resources
                dgvDelete.Width = 60;
                dgvDelete.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvViewNhom.Columns.Add(dgvDelete);
                dgvViewNhom.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btAddNew_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackGround(new frmAddNhom(this));
            LoadData();
        }

        private void dgvViewNhom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Sửa
                if (dgvViewNhom.Columns[e.ColumnIndex].Name == "dgvEdit")
                {
                    frmAddNhom frm = new frmAddNhom(this);
                    frm.id = Convert.ToInt32(dgvViewNhom.Rows[e.RowIndex].Cells["dgvId"].Value);
                    frm.txtName.Text = dgvViewNhom.Rows[e.RowIndex].Cells["dgvName"].Value.ToString();

                    MainClass.BlurBackGround(frm);
                    LoadData();
                }
                // Xóa
                else if (dgvViewNhom.Columns[e.ColumnIndex].Name == "dgvDelete")
                {
                    Guna2MessageDialog dialog = new Guna2MessageDialog()
                    {
                        Buttons = MessageDialogButtons.YesNo,
                        Icon = MessageDialogIcon.Question,
                        Text = "Bạn có chắc chắn muốn xóa danh mục này?"
                    };

                    if (dialog.Show() == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvViewNhom.Rows[e.RowIndex].Cells["dgvId"].Value);
                        try
                        {
                            int result = nhomHHBL.DeleteCategory(id);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
