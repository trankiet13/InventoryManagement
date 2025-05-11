using BusinessLayer;
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
using TransferObject;


namespace InventoryManagement
{
    public partial class LoginForm : Form
    {
        private LoginBL loginBL;
        public LoginForm()
        {
            InitializeComponent();
            loginBL = new LoginBL();
        }
        
        private void txtUser_Enter(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
        //kiểm tra login tồn tại k
        bool UserLogin(Account account)
        {
            try
            {
                return (loginBL.Login(account));
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPassword.Text;

            LoginBL loginBL = new LoginBL();
            Account acc = loginBL.GetAccount(user, pass);

            if (acc != null)
            {
                // Lưu tài khoản đăng nhập để dùng phân quyền
                LoginInfo.CurrentUser = acc;


                this.DialogResult = DialogResult.OK; // Đóng form login
            }


            else
            {
                string mess = "Tài khoản hoặc mật khẩu không đúng!";
                DialogResult result = MessageBox.Show(mess, "Đăng nhập",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    txtPassword.Clear();
                    txtUser.Focus();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void btnForgetPass_Click(object sender, EventArgs e)
        {
            frmSendCode sc = new frmSendCode();

            sc.ShowDialog();
        }
    }
}
