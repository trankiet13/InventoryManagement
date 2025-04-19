using InventoryManagement.Model;
using System;
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
using System.Security.AccessControl;
using Guna.UI2.WinForms;
using System.Collections;
using TransferObject;
using System.Web.Security;


namespace InventoryManagement.View
{
    public partial class frmUserView : SampleView
    {
        public frmUserView()
        {
            InitializeComponent();
        }

        private void frmUserView_Load(object sender, EventArgs e)
        {
            LoadDt();
        }


        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {

            LoadDt();
        }

        private UserBL userBL = new UserBL();

        //Load dữ liệu lên datagv
        private void LoadDt()
        {
            DataTable dt = userBL.GetUsersByName(txtSearch.Text);
            guna2DataGridView1.Rows.Clear();
            int count = 1;
            foreach (DataRow row in dt.Rows)
            {
                // Kiểm tra giá trị ISGROUP, có thể là 0, 1, 2, 3, hoặc một giá trị khác
                string roleValue = row["ISGROUP"].ToString().Trim(); // Lấy giá trị cột ISGROUP
                int role = 0; // Mặc định là user

                // Kiểm tra nếu giá trị có thể chuyển thành int
                if (int.TryParse(roleValue, out role))
                {
                    string roleName = ""; // Biến chứa tên vai trò

                    // Kiểm tra giá trị và chuyển đổi thành tên
                    if (role == 1)
                        roleName = "Admin";
                    else if (role == 2)
                        roleName = "User";
                    else if (role == 3)
                        roleName = "Staff";
                    else
                        roleName = "Unknown"; // Nếu không phải là giá trị hợp lệ

                    // Thêm dòng vào DataGridView với tên vai trò thay vì số
                    guna2DataGridView1.Rows.Add(count++, row["IDUSER"], row["USERNAME"], row["FULLNAME"], row["PASSWD"], row["MACTY"], row["MADVI"], roleName);
                }
                else
                {
                    // Nếu không thể chuyển đổi, sử dụng "Unknown"
                    guna2DataGridView1.Rows.Add(count++, row["IDUSER"], row["USERNAME"], row["FULLNAME"], row["PASSWD"], row["MACTY"], row["MADVI"], "Unknown");
                }
            }
        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            if (LoginInfo.CurrentUser.IsGroup == 1)
            {
                frmUserAdd addForm = new frmUserAdd();
                addForm.ShowDialog();
                LoadDt(); // Sau khi thêm xong, load lại dữ liệu
            }
            else
            {
                MessageBox.Show("Bạn không phải admin!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }


        }
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = guna2DataGridView1.Columns[e.ColumnIndex].Name;
            int selectedUserId = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);

            if (colName == "dgvEdit")
            {
                // Kiểm tra quyền
                if (LoginInfo.CurrentUser.IsGroup != 1) // Không phải Admin
                {
                    // Chỉ được sửa thông tin của chính mình
                    if (selectedUserId != LoginInfo.CurrentUser.UserID)
                    {
                        MessageBox.Show("Bạn không có quyền sửa thông tin người khác!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                // Mở form chỉnh sửa
                frmUserAdd frm = new frmUserAdd();
                frm.id = selectedUserId;
                frm.txtUser.Text = guna2DataGridView1.CurrentRow.Cells["dgvUserName"].Value.ToString();
                frm.txtName.Text = guna2DataGridView1.CurrentRow.Cells["dgvName"].Value.ToString();
                frm.txtPass.Text = guna2DataGridView1.CurrentRow.Cells["dgvPass"].Value.ToString();
                frm.txtMaCongTy.Text = guna2DataGridView1.CurrentRow.Cells["dgvCty"].Value.ToString();
                frm.txtDonVi.Text = guna2DataGridView1.CurrentRow.Cells["dgvdvi"].Value.ToString();

                // Set giá trị quyền (chỉ Admin được thay đổi)
                string roleText = guna2DataGridView1.CurrentRow.Cells["dgvRole"].Value.ToString();
                frm.cbbRole.SelectedItem = roleText;
                frm.cbbRole.Enabled = (LoginInfo.CurrentUser.IsGroup == 1); // Chỉ Admin được chọn quyền

                frm.ShowDialog();
                LoadDt();
            }
            else if (colName == "dgvDel")
            {
                // Chỉ Admin được xóa
                if (LoginInfo.CurrentUser.IsGroup != 1)
                {
                    MessageBox.Show("Bạn không có quyền xóa người dùng!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                // Xử lý xóa...
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UserBL userBL = new UserBL();
                    int kq = userBL.DeleteUser(selectedUserId);
                    if (kq > 0)
                    {
                        guna2MessageDialog1.Show("Xóa thành công");
                        LoadDt();
                    }
                    else
                    {
                        guna2MessageDialog1.Show("Xóa thất bại");
                    }
                }
            }
        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
