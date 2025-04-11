using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }
        bool UserLogin(string user, string password)
        {
            return true;
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtUser.Text.Trim();
            pass = txtPassword.Text;

            if (UserLogin(user, pass) == true)
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
