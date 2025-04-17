using InventoryManagement.Model;
using System;
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

            string qry = "select * from dbo.tb_SYS_USER";
            MainClass.LoadData(qry, dgvViewPurchase, lb);
        }
        //private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (guna2DataGridView1)
        //}
    }
}
