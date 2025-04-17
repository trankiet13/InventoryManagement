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

namespace InventoryManagement.Model
{
    public partial class frmAddPurchase : SampleAdd
    {
        public frmAddPurchase()
        {
            InitializeComponent();
        }
        public int id = 0;
        public int supID = 0;
        private void frmAddPurchase_Load(object sender, EventArgs e)
        {
            string qry = "Select  BARCODE 'id' , TENHH 'name' from dbo.tb_HangHoa";
            string qry2 = " select TENNCC  'name' from dbo.tb_NHACUNGCAP";
            MainClass.CBFFILL(qry, cbProduct);
            MainClass.CBFFILL(qry2, cbSupplier);    
            if (supID > 0)
            {
                cbSupplier.SelectedValue = supID;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbProduct.SelectedIndex != -1)
            {
                txtQuantity.Text = "";
                getDetail();
            }
        }
        private void getDetail()
        {
            string qry = "select * from dbo.tb_HANGHOA where BARCODE = " + Convert.ToInt32(cbProduct.SelectedValue) + "";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);    
            if (dt.Rows.Count > 0)
            {
                txtCost.Text = dt.Rows[0]["DONGIA"].ToString();   
            }   
        }
        private void Caculate ()
        {
            double qty = 0;
            double cost = 0;
            double tamt = 0;
            double.TryParse(txtQuantity.Text, out qty);
            double.TryParse(txtCost.Text, out cost);    
            tamt = qty * cost;
            txtAmount.Text = tamt.ToString();

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            Caculate();
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string qry = "select * from dbo.tb_HANGHOA where BARCODE = " + txtBarcode.Text + "";
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    cbProduct.SelectedValue = dt.Rows[0]["BARCODE"].ToString();
                    txtCost.Text = dt.Rows[0]["DONGIA"].ToString();
                    txtBarcode.Text = "";
                    txtQuantity.Focus();
                }
            }
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            string pid;
            string pname;
            string qty;
            string cost;
            string amt;

            pid = cbProduct.SelectedValue.ToString();
            pname = cbProduct.Text;
            qty = txtQuantity.Text;
            cost = txtCost.Text;
            amt = txtAmount.Text;
            dgvAddPurchase.Rows.Add(0,pid, pname, qty, cost, amt);
        }
    }
}
