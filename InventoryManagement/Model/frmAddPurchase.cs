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
                guna2MessageDialog1.Text = "Please fill all the required fields.";
                return;
            }
            string qry1 = ""; // for main table
            string qry2 = ""; // for details table
            int record = 0;
            if (MainID == 0)
            {
                qry1 = @"insert into tblMian Values (@date,@type,@supID)
                        Select SCOPE_IDENTITY()";
            }
            else
            {
                qry1 = @"update tblMian set mdate = @date, mType = @type, mSupCusID = @supID where MainID = @id";
            }
            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            cmd.Parameters.AddWithValue("@id", MainID);
            //cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(txtDateTime.Value).Date);
            //cmd.Parameters.AddWithValue("@type", "Pur");
            //cmd.Parameters.AddWithValue("@supID", Convert.ToInt32(cbSupplier.SelectedValue));
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = Convert.ToDateTime(txtDateTime.Value).Date;
            cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = "Pur";
            cmd.Parameters.Add("@supID", SqlDbType.Int).Value = Convert.ToInt32(cbSupplier.SelectedValue);

            if (MainClass.con.State == ConnectionState.Closed)
            {
                MainClass.con.Open();
            }
            if (MainID == 0)
            {
                MainID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            else
            {
                cmd.ExecuteNonQuery();
            }

            // insert details table 
            try
            {
                foreach (DataGridViewRow row in dgvAddPurchase.Rows)
                {


                    int did = Convert.ToInt32(row.Cells["dgvid"].Value);


                    if (did == 0)
                    {
                        qry2 = "Insert into tblDetails Values(@mID,@proID,@qty,@price,@amount,@cost)";
                    }
                    else
                    {
                        qry2 = "Update tblDetails set dMainID = @mID, productID = @proID, qty = @qty, price = @price, amount = @amount, cost = @cost where detailID = @id ";
                    }
                    SqlCommand cmd1 = new SqlCommand(qry2, MainClass.con);
                    cmd1.Parameters.AddWithValue("@id", did);
                    cmd1.Parameters.AddWithValue("@mID", MainID);
                    cmd1.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvproid"].Value));

                    cmd1.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["dgvqty"].Value));
                    cmd1.Parameters.AddWithValue("@price", Convert.ToDouble(row.Cells["dgvCost"].Value));
                    cmd1.Parameters.AddWithValue("@amount", Convert.ToDouble(row.Cells["dgvAmount"].Value));
                    cmd1.Parameters.AddWithValue("@cost", Convert.ToDouble(row.Cells["dgvCost"].Value));
                    //dgvAddPurchase.Columns["dgvproid"].Visible = false;
                    Console.WriteLine($"Executing Query: {qry2}");
                    foreach (SqlParameter param in cmd1.Parameters)
                    {
                        Console.WriteLine($"{param.ParameterName}: {param.Value}");
                    }
                    record += cmd1.ExecuteNonQuery();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi khi lưu chi tiết: " + sqlEx.Message + "\n" + "SQL Error Code: " + sqlEx.Number);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu chi tiết: " + ex.Message + "\n" + ex.StackTrace);
            }
            if (record == 0)
            {
                MessageBox.Show("Lỗi khi lưu chi tiết sản phẩm.");
            }
            if (record > 0)
            {
                Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                guna2MessageDialog1.Text = "Data Saved Successfully";
                guna2MessageDialog1.Show();

                MainID = 0;
                supID = 0;
                txtDateTime.Value = DateTime.Now;
                cbSupplier.SelectedIndex = 0;
                cbSupplier.SelectedIndex = -1;

            }
        }
    }
}