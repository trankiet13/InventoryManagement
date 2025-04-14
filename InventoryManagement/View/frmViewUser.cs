using Guna.UI2.WinForms;
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
using InventoryManagement.Model;

namespace InventoryManagement.View
{
    public partial class frmViewUser : SampleView
    {
        public frmViewUser()
        {
            InitializeComponent();
        }
        private UserBL userBL = new UserBL();

        private void frmViewUser_Load(object sender, EventArgs e)
        {
            try
            {
                dgvViewUser.DataSource = userBL.GetAccounts();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            LoadDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }
        public override void btAddNew_Click(object sender, EventArgs e)
        {
            frmAddUser frmaddUser = new frmAddUser(this);
            frmaddUser.ShowDialog();
            
        }
        public void LoadDataGridView()
        {
            UserBL userBL = new UserBL();
            dgvViewUser.DataSource = userBL.LoadUsers();
        }

    }
}
