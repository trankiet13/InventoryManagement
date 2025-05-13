using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        public int MainID = 0;
        public int supID = 0;
        private void frmAddPurchase_Load(object sender, EventArgs e)
        {
            //string qry = "Select  BARCODE 'id' , TENHH 'name' from dbo.tb_HangHoa";
            //string qry2 = " select MANCC  'id', TENNCC 'name' from dbo.tb_NHACUNGCAP";
            //MainClass.CBFFILL(qry, cbProduct);
            //MainClass.CBFFILL(qry2, cbSupplier);
            //if (supID > 0)
            //{
            //    cbSupplier.SelectedValue = supID;
            //    LoadForEdit();
            //}
            // Load danh sách nhà cung cấp

            string qry2 = "SELECT MANCC 'id', TENNCC 'name' FROM dbo.tb_NHACUNGCAP";
            MainClass.CBFFILL(qry2, cbSupplier);

            // Đăng ký sự kiện chọn NCC
            cbSupplier.SelectedIndexChanged += cbSupplier_SelectedIndexChanged;

            // Xử lý khi chỉnh sửa
            if (supID > 0)
            {
                cbSupplier.SelectedValue = supID;
                // Sự kiện SelectedIndexChanged sẽ tự động kích hoạt
            }
            else
            {
                cbProduct.DataSource = null; // Khởi tạo rỗng
            }

        }
        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedValue != null && cbSupplier.SelectedValue.ToString() != "")
            {
                int supplierID = Convert.ToInt32(cbSupplier.SelectedValue);
                string qry = "SELECT BARCODE AS 'id', TENHH AS 'name' FROM dbo.tb_HANGHOA WHERE MANCC = @mancc";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@mancc", supplierID)
                };
                MainClass.CBFFILL(qry, cbProduct, parameters);
            }
            else
            {
                cbProduct.DataSource = null; // Xóa dữ liệu nếu không chọn NCC
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProduct.SelectedIndex != -1)
            {
                txtQuantity.Text = "";
                getDetail();
            }
        }
        private void getDetail()
        {
            string qry = "select * from dbo.tb_HANGHOA where BARCODE = " + Convert.ToInt32(cbProduct.SelectedValue) + "";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con); SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txtCost.Text = dt.Rows[0]["DONGIA"].ToString();
            }
        }
        private void Caculate()
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
        public override void btClosee_Click(object sender, EventArgs e)
        {
            this.Close();
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

            dgvAddPurchase.Rows.Add(0, 0, pid, pname, qty, cost, amt);
            cbProduct.SelectedIndex = -1;
            cbProduct.SelectedIndex = 0;
            txtQuantity.Text = "";

            txtAmount.Text = "";


        }

        private void dgvAddPurchase_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            int count = 0;
            foreach (DataGridViewRow row in dgvAddPurchase.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }
        public override void btSave_Click(object sender, EventArgs e)
        {
            if (MainClass.Validation(this) == false)
            {
                Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
            }
        }
    }
}