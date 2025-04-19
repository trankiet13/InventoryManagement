using BusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InventoryManagement.Model
{
    public partial class frmUserAdd : SampleAdd
    {
        public int id = 0;

        // Thêm constructor nhận userId
        public frmUserAdd(int userId = 0)
        {
            InitializeComponent();
            this.id = userId;

            // Disable các trường không được phép sửa nếu không phải Admin
            if (LoginInfo.CurrentUser.IsGroup != 1)
            {
                txtMaCongTy.Enabled = false;
                txtDonVi.Enabled = false;
                cbbRole.Enabled = false;
            }

            // Load thông tin nếu là chỉnh sửa
            if (id != 0)
            {
                LoadUserInfo();
                CheckPermission(); // Kiểm tra quyền khi mở form
            }
        }
        private void LoadUserInfo()
        {
            UserBL userBL = new UserBL();
            DataTable dt = userBL.GetUserById(id);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtUser.Text = row["USERNAME"].ToString();
                txtName.Text = row["FULLNAME"].ToString();
                txtPass.Text = row["PASSWD"].ToString();
                txtMaCongTy.Text = row["MACTY"].ToString();
                txtDonVi.Text = row["MADVI"].ToString();

                // Set giá trị quyền
                switch (row["ISGROUP"].ToString())
                {
                    case "1": cbbRole.SelectedItem = "Admin"; break;
                    case "2": cbbRole.SelectedItem = "User"; break;
                    case "3": cbbRole.SelectedItem = "Staff"; break;
                }
            }
        }

        private void CheckPermission()
        {
            // Chỉ Admin hoặc chính user đó được sửa
            if (LoginInfo.CurrentUser.IsGroup != 1 && id != LoginInfo.CurrentUser.UserID)
            {
                MessageBox.Show("Bạn không có quyền chỉnh sửa thông tin này!");
                this.Close();
            }
        }
        public static bool Validation(Form F)
        {
            bool isValid = false;
            int count = 0;
            foreach (Control c in F.Controls)
            {
                //sử dụng tag c để kiểm tra trống
                if (Convert.ToString(c.Tag) != "" && Convert.ToString(c.Tag) != null)
                {
                    if (c is Guna.UI2.WinForms.Guna2TextBox)
                    {
                        Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
                        if (t.Text.Trim() == "")
                        {
                            t.BorderColor = Color.Red;
                            t.FocusedState.BorderColor = Color.Red;
                            t.HoverState.BorderColor = Color.Red;
                            count++;
                        }
                        else
                        {
                            t.BorderColor = Color.FromArgb(213, 218, 223);
                            t.FocusedState.BorderColor = Color.FromArgb(95, 61, 204);
                            t.HoverState.BorderColor = Color.FromArgb(95, 61, 204);
                        }
                    }

                }
                if (count == 0)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }


        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation(this) == false)
                {
                    guna2MessageDialog1.Show("Không được để trống");
                    return;
                }

                // Kiểm tra quyền lưu dữ liệu
                if (LoginInfo.CurrentUser.IsGroup != 1 && id != LoginInfo.CurrentUser.UserID)
                {
                    guna2MessageDialog1.Show("Bạn không có quyền thực hiện thao tác này!");
                    return;
                }

                UserBL bl = new UserBL();
                string macty = txtMaCongTy.Text;
                string madvi = txtDonVi.Text;
                int role = 0;

                // Xử lý role (chỉ Admin được thay đổi)
                if (LoginInfo.CurrentUser.IsGroup == 1)
                {
                    switch (cbbRole.SelectedItem?.ToString())
                    {
                        case "Admin": role = 1; break;
                        case "User": role = 2; break;
                        case "Staff": role = 3; break;
                        default: role = 2; break;
                    }
                }
                else
                {
                    // Giữ nguyên role từ CSDL nếu không phải Admin
                    DataTable dt = bl.GetUserById(id);
                    role = Convert.ToInt32(dt.Rows[0]["ISGROUP"]);
                    macty = dt.Rows[0]["MACTY"].ToString();
                    madvi = dt.Rows[0]["MADVI"].ToString();
                }

                // Gọi phương thức SaveUser (sẽ tự động kiểm tra trùng username)
                int result = bl.SaveUser(id, txtUser.Text, txtName.Text, txtPass.Text, macty, madvi, role);

                if (result > 0)
                {
                    guna2MessageDialog1.Show("Lưu thành công");
                    this.Close();
                }
                else
                {
                    guna2MessageDialog1.Show("Thao tác thất bại");
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi từ Business Layer
                guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                guna2MessageDialog1.Show(ex.Message);
            }
        }


        private void frmUserAdd_Load(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
