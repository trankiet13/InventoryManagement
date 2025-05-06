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
using static BusinessLayer.SaleBL;

namespace InventoryManagement.View
{
    public partial class frmViewSale : SampleView
    {
        public frmViewSale()
        {
            InitializeComponent();
        }
        private void frmViewSale_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btAddNew_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackGround(new frmAddSale());
            LoadData();

        }
        private void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Add(dgvId);
            lb.Items.Add(dgvDate);
            lb.Items.Add(dgvCustomer);
            lb.Items.Add(dgvCusID);
            lb.Items.Add(dgvAmount);

            string qry = "select dMainID, mdate, m.mSupCusId, c.cusName, SUM(d.amount) " +
    "from tblMian m inner join tblDetails d on d.dMainID = m.MainID " +
    "inner join Customer c on c.cusID = m.mSupCusID " +
    "where m.mType = 'SAL' and c.cusName like '%" + txtSearch.Text + "%' " +
    "group by dMainID, mdate, m.mSupCusID, c.cusName";

            MainClass.LoadData(qry, dgvViewSale, lb);
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //// Update
            //if (dgvViewSale.CurrentCell.OwningColumn.Name == "dgvEdit")
            //{
            //    frmAddSale frmAddSale = new frmAddSale();
            //    frmAddSale.id = Convert.ToInt32(dgvViewSale.CurrentRow.Cells["dgvid"].Value);
            //    frmAddSale.cusID = Convert.ToInt32(dgvViewSale.CurrentRow.Cells["dgvCustomer"].Value);
            //    MainClass.BlurBackGround(frmAddSale);
            //    LoadData();
            //}
            //// Delete
            //if (dgvViewSale.CurrentCell.OwningColumn.Name == "dgvDelete")
            //{
            //    Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            //    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;
            //    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
            //    if (guna2MessageDialog1.Show("Are you sure you want to delete this record?") == DialogResult.Yes)
            //    {
            //        int id = Convert.ToInt32(dgvViewSale.CurrentRow.Cells["dgvid"].Value);
            //        string qry = "delete from tblMian where MainID = " + id + "";
            //        string qry2 = "delete from tblDetails where dMainID = " + id + "";
            //        Hashtable ht = new Hashtable();
            //        MainClass.SQL(qry, ht);
            //        if (MainClass.SQL(qry2, ht) > 0)
            //        {
            //            Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            //            guna2MessageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            //            guna2MessageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            //            guna2MessageDialog.Text = "Record deleted successfully.";
            //            guna2MessageDialog.Show();
            //            LoadData();
            //        }

            //    }

            //}
            // Update
            if (dgvViewSale.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmAddSale frmAddSale = new frmAddSale();
                frmAddSale.id = Convert.ToInt32(dgvViewSale.CurrentRow.Cells["dgvid"].Value);
                frmAddSale.cusID = Convert.ToInt32(dgvViewSale.CurrentRow.Cells["dgvCustomer"].Value);
                MainClass.BlurBackGround(frmAddSale);
                LoadData();
            }

            // Delete
            if (dgvViewSale.CurrentCell.OwningColumn.Name == "dgvDelete")
            {
                var dialog = new Guna.UI2.WinForms.Guna2MessageDialog
                {
                    Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo,
                    Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
                };

                if (dialog.Show("Are you sure you want to delete this record?") == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvViewSale.CurrentRow.Cells["dgvid"].Value);
                    SaleBLL bll = new SaleBLL();

                    if (bll.DeleteSale(id))
                    {
                        var successDialog = new Guna.UI2.WinForms.Guna2MessageDialog
                        {
                            Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK,
                            Icon = Guna.UI2.WinForms.MessageDialogIcon.Information,
                            Text = "Record deleted successfully."
                        };
                        successDialog.Show();
                        LoadData();
                    }
                }
            }

        }
    }
    }
