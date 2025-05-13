using BusinessLayer;
using Guna.UI2.WinForms;
using InventoryManagement.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace InventoryManagement.View
{
    public partial class frmViewCategory : SampleView
    {
        private readonly CategoryBL categoryBL = new CategoryBL();
        public frmViewCategory()
        {
            InitializeComponent();
        }

        private void frmViewCategory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                DataTable dt = categoryBL.GetCategories(txtSearch.Text);

                // Đảm bảo cấu trúc DataGridView trước khi gán dữ liệu
                dgvViewCategory.Columns.Clear();
                dgvViewCategory.AutoGenerateColumns = false;

                // Cột ID
                DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
                colId.Name = "dgvId";
                colId.HeaderText = "ID";
                colId.DataPropertyName = "ID";
                dgvViewCategory.Columns.Add(colId);

                // Cột Name
                DataGridViewTextBoxColumn colName = new DataGridViewTextBoxColumn();
                colName.Name = "dgvName";
                colName.HeaderText = "Name";
                colName.DataPropertyName = "TEN";
                dgvViewCategory.Columns.Add(colName);

                dgvViewCategory.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Xử lý sự kiện chỉnh sửa (dgvEdit)
                if (dgvViewCategory.Columns[e.ColumnIndex].Name == "dgvEdit")
                {
                    frmAddCategory frm = new frmAddCategory(this);
                    frm.id = Convert.ToInt32(dgvViewCategory.Rows[e.RowIndex].Cells["dgvId"].Value);
                    frm.txtName.Text = dgvViewCategory.Rows[e.RowIndex].Cells["dgvName"].Value.ToString();
                    MainClass.BlurBackGround(frm);
                    LoadData();
                }
                // Xử lý sự kiện xóa (dgvDelete)
                else if (dgvViewCategory.Columns[e.ColumnIndex].Name == "dgvDelete")
                {
                    Guna2MessageDialog dialog = new Guna2MessageDialog()
                    {
                        Buttons = MessageDialogButtons.YesNo,
                        Icon = MessageDialogIcon.Question,
                        Text = "Bạn có chắc chắn muốn xóa danh mục này?"
                    };

                    if (dialog.Show() == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgvViewCategory.Rows[e.RowIndex].Cells["dgvId"].Value);
                        try
                        {
                            int result = categoryBL.DeleteCategory(id);
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
        //Search
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btAddNew_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackGround(new frmAddCategory(this));
            LoadData();
        }
    }
}