using BusinessLayer;
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
        //public override void btAddNew_Click(object sender, EventArgs e)
        //{
        //    //MainClass.BlurBackGround(new frmAddCustomer());
        //    //LoadData();
        //    frmAddCustomer = new frmAddCustomer();
        //    frmAddCustomer.ShowDialog();
        //    LoadData();
        //}
        //private void LoadData()
        //{
        //    ListBox lb = new ListBox();
        //    lb.Items.Add(dgvId);
        //    lb.Items.Add(dgvName);
        //    lb.Items.Add(dgvPhone);
        //    lb.Items.Add(dgvEmail);


        //    string qry = "SELECT * FROM Customer WHERE cusName LIKE '%" + txtSearch.Text + "%' ORDER BY cusID DESC";

        //    MainClass.LoadData(qry, dgvViewCustomer, lb);
        //}
        //public override void txtSearch_TextChanged(object sender, EventArgs e)
        //{
        //    LoadData();
        //}
        //private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Update
        //    if (dgvViewCustomer.CurrentCell.OwningColumn.Name == "dgvUpdate")
        //    {
        //        frmAddCustomer frmAddCustomer = new frmAddCustomer();
        //        frmAddCustomer.id = Convert.ToInt32(dgvViewCustomer.CurrentRow.Cells["dgvId"].Value);
        //        frmAddCustomer.txtName.Text = dgvViewCustomer.CurrentRow.Cells["dgvName"].Value.ToString();
        //        frmAddCustomer.txtPhone.Text = dgvViewCustomer.CurrentRow.Cells["dgvPhone"].Value.ToString();
        //        frmAddCustomer.txtEmail.Text = dgvViewCustomer.CurrentRow.Cells["dgvEmail"].Value.ToString();

        //        MainClass.BlurBackGround(frmAddCustomer);
        //        LoadData();
        //    }
        //    // Delete
        //    if (dgvViewCustomer.CurrentCell.OwningColumn.Name == "dgvDelete")
        //    {
        //        Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
        //        guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
        //        guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
        //        if (guna2MessageDialog1.Show("Are you sure you want to delete this record?") == DialogResult.Yes)
        //        {
        //            object value = Convert.ToInt32(dgvViewCustomer.CurrentRow.Cells["dgvId"].Value);

        //            string qry = "delete from Customer where cusID = " + value + "";

        //            Hashtable ht = new Hashtable();
        //            MainClass.SQL(qry, ht);
        //            if (MainClass.SQL(qry, ht) > 0)
        //            {
        //                Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
        //                guna2MessageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
        //                guna2MessageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
        //                guna2MessageDialog.Text = "Record deleted successfully.";
        //                guna2MessageDialog.Show();
        //                LoadData();
        //            }

        //        }
        //    }
        //}
        
        CustomerBL bll = new CustomerBL();

        private void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvName);
            lb.Items.Add(dgvPhone);
            lb.Items.Add(dgvEmail);
            bll.LoadCustomers(txtSearch.Text, dgvViewCustomer, lb);
        }

        public override void btAddNew_Click(object sender, EventArgs e)
        {
            frmAddCustomer = new frmAddCustomer();
            frmAddCustomer.ShowDialog();
            LoadData();
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvViewCustomer.CurrentCell.OwningColumn.Name == "dgvUpdate")
            {
                frmAddCustomer frm = new frmAddCustomer();
                frm.id = Convert.ToInt32(dgvViewCustomer.CurrentRow.Cells["dgvId"].Value);
                frm.txtName.Text = dgvViewCustomer.CurrentRow.Cells["dgvName"].Value.ToString();
                frm.txtPhone.Text = dgvViewCustomer.CurrentRow.Cells["dgvPhone"].Value.ToString();
                frm.txtEmail.Text = dgvViewCustomer.CurrentRow.Cells["dgvEmail"].Value.ToString();

                MainClass.BlurBackGround(frm);
                LoadData();
            }

            if (dgvViewCustomer.CurrentCell.OwningColumn.Name == "dgvDelete")
            {
                var dialog = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo,
                    Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
                };
                if (dialog.Show("Are you sure you want to delete this record?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvViewCustomer.CurrentRow.Cells["dgvId"].Value);
                    if (bll.DeleteCustomer(id))
                    {
                        var msg = new Guna.UI2.WinForms.Guna2MessageDialog
                        {
                            Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
                            Icon = Guna.UI2.WinForms.MessageDialogIcon.Information
                        };
                        msg.Show("Record deleted successfully.");
                        LoadData();
                    }
                }
            }
        }
    }
}

