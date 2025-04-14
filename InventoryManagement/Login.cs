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
            string user, pass;
            user = txtUser.Text.Trim();
            pass = txtPassword.Text;

            Account account = new Account(user, pass);
            if (UserLogin(account) == true)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                string mess = " User or Password is incorrect ! ";
                DialogResult result = MessageBox.Show(mess, "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    txtPassword.Clear();
                    txtUser.Focus();
                }
                else
                    this.DialogResult = DialogResult.Cancel;
            }
        }


    }
}
