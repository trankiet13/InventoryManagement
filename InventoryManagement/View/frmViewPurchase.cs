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
    public partial class frmViewPurchase : SampleView
    {
        public frmViewPurchase()
        {
            InitializeComponent();
        }

        private void frmViewPurchase_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public override void btAddNew_Click(object sender, EventArgs e)
        {
            frmAddPurchase frmaddPurchase = new frmAddPurchase();
            frmaddPurchase.ShowDialog();
            LoadData();

        }
        private void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvDate);
            lb.Items.Add(dgvSupid);
            lb.Items.Add(dgvSupplier);
            lb.Items.Add(dgvAmount);

            string qry = "select dMainID, mdate, m.mSupCusId, s.TENNCC, SUM(d.amount) " +
    "from tblMian m inner join tblDetails d on d.dMainID = m.MainID " +
    "inner join dbo.tb_NHACUNGCAP s on s.MANCC = m.mSupCusID " +
    "where m.mType = 'PUR' and TENNCC like '%" + txtSearch.Text + "%' " +
    "group by dMainID, mdate, m.mSupCusID, s.TENNCC"; 

            MainClass.LoadData(qry, dgvViewPurchase, lb);
        }
        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update
            if (dgvViewPurchase.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmAddPurchase frmAddPurchase = new frmAddPurchase();
                frmAddPurchase.MainID = Convert.ToInt32(dgvViewPurchase.CurrentRow.Cells["dgvid"].Value);
                frmAddPurchase.supID = Convert.ToInt32(dgvViewPurchase.CurrentRow.Cells["dgvSupId"].Value);
                MainClass.BlurBackGround(frmAddPurchase);
                LoadData();
            }
            // Delete
            if (dgvViewPurchase.CurrentCell.OwningColumn.Name == "dgvDelete")
            {
                Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                if (guna2MessageDialog1.Show("Are you sure you want to delete this record?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvViewPurchase.CurrentRow.Cells["dgvid"].Value);
                    string qry = "delete from tblMian where MainID = " + id + "";
                    string qry2 = "delete from tblDetails where dMainID = " + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQL(qry, ht);
                    if (MainClass.SQL(qry2, ht) > 0)
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
