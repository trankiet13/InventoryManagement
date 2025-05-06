using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using BusinessLayer;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace InventoryManagement
{
    public partial class frmSendCode : Sample
    {
        string randomCode;
        public static string to;
        private string _username; // Thêm biến để lưu username

        public frmSendCode()
        {
            InitializeComponent();
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            _username = txtUser.Text.Trim(); // Lưu username từ textbox
            to = txtEmail.Text.Trim();

            // Kiểm tra email và username có nhập không
            if (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(to))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ username và email!");
                return;
            }

            // Kiểm tra tài khoản có tồn tại không (sử dụng AccountBL)
            AccountBL accountBL = new AccountBL();
            if (!accountBL.CheckAccount(_username, to))
            {
                MessageBox.Show("Tài khoản hoặc email không đúng!");
                return;
            }

            // Tạo và gửi mã OTP
            Random rand = new Random();
            randomCode = (rand.Next(100000, 999999)).ToString(); // Sinh mã 6 số

            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress("ngocchi1010001@gmail.com", "Hệ thống Quản lý Kho");
                message.Body = $"Xin chào {_username},\n\n" +
                $"Bạn vừa yêu cầu đặt lại mật khẩu. Mã OTP của bạn là: {randomCode}\n\n" +
                $"Nếu không phải bạn thực hiện, vui lòng bỏ qua email này.\n\n" +
                "Trân trọng,\nĐội ngũ hỗ trợ hệ thống InventoryManagement";

                message.Subject = "Mã xác nhận đổi mật khẩu";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("ngocchi1010001@gmail.com", "tsojwjhtmhfbugab"),
                    EnableSsl = true
                };

                smtp.Send(message);
                MessageBox.Show("Đã gửi mã xác nhận tới email!\n(Vui lòng kiểm tra cả mục thư rác/spam)", "Thông báo");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
            }
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            if (randomCode == txtCode.Text.Trim())
            {

                // Mở form reset password và truyền username + mã OTP
                frmResetPassword rp = new frmResetPassword(_username, randomCode);
                rp.ShowDialog();
                this.Close(); // Đóng luôn frmSendCode sau khi frmResetPassword đóng

            }
            else
            {
                MessageBox.Show("Mã xác nhận không đúng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSendCode_Load(object sender, EventArgs e)
        {

        }
    }
}