using InventoryManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement.View
{
    public partial class frmViewCustomer : SampleView
    {
        frmAddCustomer frmAddCustomer = new frmAddCustomer();
        public frmViewCustomer()
        {
            InitializeComponent();
        }

        private void frmViewCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public override void btAddNew_Click(object sender, EventArgs e)
        {
            //MainClass.BlurBackGround(new frmAddCustomer());
            //LoadData();
            frmAddCustomer = new frmAddCustomer();
            frmAddCustomer.ShowDialog();
            LoadData();
        }
        private void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvEmail);


            string qry = "SELECT * FROM Customer WHERE cusName LIKE '%" + txtSearch.Text + "%' ORDER BY cusID DESC";

            MainClass.LoadData(qry, dgvViewCustomer, lb);
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update
            if (dgvViewCustomer.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmAddCustomer frmAddCustomer = new frmAddCustomer();
                frmAddCustomer.id = Convert.ToInt32(dgvViewCustomer.CurrentRow.Cells["dgvid"].Value);
                frmAddCustomer.txtName.Text = dgvViewCustomer.CurrentRow.Cells["dgvName"].Value.ToString();
                frmAddCustomer.txtPhone.Text = dgvViewCustomer.CurrentRow.Cells["dgvPhone"].Value.ToString();
                frmAddCustomer.txtEmail.Text = dgvViewCustomer.CurrentRow.Cells["dgvEmail"].Value.ToString();

                MainClass.BlurBackGround(frmAddCustomer);
                LoadData();
            }
            // Delete
            if (dgvViewCustomer.CurrentCell.OwningColumn.Name == "dgvDelete")
            {
                Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                if (guna2MessageDialog1.Show("Are you sure you want to delete this record?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvViewCustomer.CurrentRow.Cells["dgvid"].Value);
                    string qry = "delete from Customer where MainID = " + id + "";

                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);
                    if (MainClass.SQL(qry, ht) > 0)
                    {
                        Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
                        guna2MessageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                        guna2MessageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                        guna2MessageDialog.Text = "Record deleted successfully.";
                        guna2MessageDialog.Show();
                        LoadData();
                    }

                }
            }
        }
    }
}
