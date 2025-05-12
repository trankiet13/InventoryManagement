using BusinessLayer;
using System;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class frmResetPassword : Sample
    {
        private readonly AccountBL _accountBL;
        private readonly string _username;

        public frmResetPassword(string username, string randomCode)
        {
            InitializeComponent();
            _accountBL = new AccountBL();
            _username = username;

        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra mật khẩu mới và xác nhận có khớp không
                if (string.IsNullOrWhiteSpace(txtResetPass.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtResetPass.Text != txtResetPassVer.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. Gọi Business Layer để cập nhật mật khẩu
                bool result = _accountBL.ResetPassword(_username, txtResetPassVer.Text);

                if (result)
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể đặt lại mật khẩu!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmResetPassword_Load(object sender, EventArgs e)
        {

        }
        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            // Đổi trạng thái hiện/ẩn mật khẩu
            txtResetPass.UseSystemPasswordChar = !txtResetPass.UseSystemPasswordChar;
            txtResetPassVer.UseSystemPasswordChar = !txtResetPassVer.UseSystemPasswordChar;

            // Đổi hình ảnh dựa trên trạng thái
            btnShowPassword.Image = txtResetPass.UseSystemPasswordChar && txtResetPassVer.UseSystemPasswordChar
                ? Properties.Resources.eye_close // Mắt đóng
                : Properties.Resources.eye_open;   // Mắt mở
        }


    }
}