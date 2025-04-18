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
        public Account LoggedInAccount { get; set; }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            frmUserAdd addForm = new frmUserAdd();
    
            addForm.ShowDialog();
            LoadDt(); // Sau khi thêm xong, load lại dữ liệu
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







        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Bỏ qua nếu header

            string colName = guna2DataGridView1.Columns[e.ColumnIndex].Name;

            if (colName == "dgvEdit")
            {
                frmUserAdd frm = new frmUserAdd();

                // Gán dữ liệu từ DataGridView vào frmUserAdd
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtUser.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvUserName"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.txtPass.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvPass"].Value);
                frm.txtMaCongTy.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvCty"].Value);
                frm.txtDonVi.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvdvi"].Value);

                // Lấy giá trị quyền từ cột ISGROUP (dgvRole) và gán vào ComboBox
                string roleText = guna2DataGridView1.CurrentRow.Cells["dgvRole"].Value.ToString();

                if (roleText == "Admin")
                    frm.cbbRole.SelectedItem = "Admin";
                else if (roleText == "User")
                    frm.cbbRole.SelectedItem = "User";
                else if (roleText == "Staff")
                    frm.cbbRole.SelectedItem = "Staff";

                frm.ShowDialog();
                LoadDt(); // Cập nhật lại danh sách
            }

            if (colName == "dgvDel")
            {
                int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    UserBL userBL = new UserBL();
                    int kq = userBL.DeleteUser(id); // Gọi BusinessLayer để xóa
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
    }
}



//            if (colName == "dgvDel")
//            {
//                int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);

//                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//                if (result == DialogResult.Yes)
//                {
//                    UserBL userBL = new UserBL();
//                    int kq = userBL.DeleteUser(id); // Gọi BusinessLayer để xóa
//                    if (kq > 0)
//                    {
//                        // Thay đổi phần này để không gặp lỗi circular reference

//                        guna2MessageDialog1.Show("Xóa thành công");
//                        LoadDt();
//                    }
//                    else
//                    {

//                        guna2MessageDialog1.Show("Xóa thất bại");
//                    }
//                }
//            }
//        }

//    }
//}
