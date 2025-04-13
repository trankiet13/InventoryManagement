using BusinessLayer;
using InventoryManagement.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class frmMai : Form
    {
        public frmMai()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void form_Load_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Enabled = false;
            LoginForm login = new LoginForm();
            DialogResult result = login.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Enabled = true;
            }
            else
            {
                Application.Exit();
            }
            
        }
        public void AddControls (Form F)
        {
            this.pnRight.Controls.Clear();
            F.Dock = DockStyle.Fill;
            F.TopLevel = false;
            pnRight.Controls.Add(F);
            F.Show();
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btUser_Click(object sender, EventArgs e)
        {
            View.frmViewUser frmViewUser = new View.frmViewUser();

            frmViewUser.TopLevel = false;
            pnRight.Controls.Clear();
            pnRight.Controls.Add(frmViewUser);
            frmViewUser.Dock = DockStyle.Fill;
            frmViewUser.FormBorderStyle = FormBorderStyle.None;
            frmViewUser.Show();
        }

        private void pnTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
