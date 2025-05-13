using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;

namespace InventoryManagement.Model
{
    public partial class frmAddSale : Form
    {
        public int id = 0;
        public int cusID = 0;

        public frmAddSale()
        {
            InitializeComponent();
        }

        private void frmAddSale_Load(object sender, EventArgs e)
        {
            string qry = "Select cusID 'id' , cusName 'name' from Customer";
            MainClass.CBFFILL(qry, cbCustomer);
            if (cusID > 0)
            {
                cbCustomer.SelectedValue = cusID;
            }
            LoadProductsFromDatabase();
        }
        public void Additems(string id, string name, string price, Image image, string cost)
        {
            var w = new ucProduct()
            {
                PName = name,
                Price = price,
                Pimage = image,
                Pcost = cost,
                id = Convert.ToInt32(id)

            };
            flowLayoutPanel1.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;
                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                {
                    if (Convert.ToInt32(item.Cells["dgvproid"].Value) == wdg.id)
                    {
                        item.Cells["dgvQty"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dgvQty"].Value.ToString()) * int.Parse(item.Cells["dgvPrice"].Value.ToString());

                        return;
                    }
                }
                // if dont find product in row
                guna2DataGridView1.Rows.Add(new object[] { 0, wdg.id, wdg.PName, 1, wdg.Price, wdg.Pcost, null, null });
                GrandTotal();
            };
        }
        private void GrandTotal()
        {
            //double tot = 0;
            //lbTotal.Text = "";
            //foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            //{
            //    tot += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            //}
            //lbTotal.Text = tot.ToString("N2");
            double tot = 0;
            lbPrice.Text = "0";
            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                if (item.Cells["dgvAmount"].Value != null &&
                    double.TryParse(item.Cells["dgvAmount"].Value.ToString(), out double amount))
                {
                    tot += amount;
                }
            }
            lbPrice.Text = tot.ToString("N2");

        }
        private void LoadProductsFromDatabase()
        {
            string qry = "Select * from dbo.tb_HANGHOA";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {

                    Byte[] imageArray = (Byte[])row["pImage"];
                    byte[] imageByteArray = imageArray;

                    try
                    {
                        Image img = Image.FromStream(new MemoryStream(imageByteArray));
                        Additems(row["BARCODE"].ToString(), row["TENHH"].ToString(), row["DONGIA"].ToString(), img, row["DONGIA"].ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi load ảnh sản phẩm: " + ex.Message);
                    }

                }
            }
            ;
        }

        private void btClosee_Click(object sender, EventArgs e)
        {
            guna2DataGridView1.Rows.Clear();
            txtDateTime.Value = DateTime.Now;
            cbCustomer.SelectedIndex = 0;
            cbCustomer.SelectedValue = -1;
            lbPrice.Text = "0.00";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanel1.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Sử dụng tham số để tránh lỗi SQL injection
                string qry = "SELECT * FROM dbo.tb_HANGHOA WHERE BARCODE = @barcode";
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Kiểm tra nếu sản phẩm đã có trong DataGridView
                    foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                    {
                        if (item.Cells["dgvproid"].Value != null &&
                            item.Cells["dgvproid"].Value.ToString() == row["BARCODE"].ToString())
                        {
                            int currentQty = int.Parse(item.Cells["dgvQty"].Value.ToString());
                            int price = int.Parse(item.Cells["dgvPrice"].Value.ToString());

                            item.Cells["dgvQty"].Value = currentQty + 1;
                            item.Cells["dgvAmount"].Value = (currentQty + 1) * price;
                            txtBarcode.Text = "";
                            return;
                        }
                    }

                    // Nếu chưa có, thêm mới vào DataGridView
                    guna2DataGridView1.Rows.Add(new object[]
                    {
                0, // ID chi tiết bán (nếu có)
                row["BARCODE"].ToString(), // dgvproid
                row["TENHH"].ToString(),   // dgvName
                1,                         // dgvQty
                row["DONGIA"].ToString(),  // dgvPrice
                row["DONGIA"].ToString()   // dgvCost (giá vốn, nếu khác thì thay)
                    });

                    txtBarcode.Text = "";
                    GrandTotal(); // tính lại tổng tiền
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm với mã barcode: " + txtBarcode.Text);
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (MainClass.Validation(this) == false)
            {
                // First have to create to store data
                Guna2MessageDialog guna2MessageDialog = new Guna2MessageDialog();
                guna2MessageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog.Text = "Vui lòng nhập đầy đủ thông tin bắt buộc!";
            }
            string qry1 = "";
            string qry2 = "";
            int record = 0;
            if (id == 0)
            {
                qry1 = @"insert into tblMian Values (@date,@type,@supID)
                        Select SCOPE_IDENTITY()";
            }
            else
            {
                qry1 = @"update tblMian set mdate = @date, mType = @type, mSupCusID = @supID where MainID = @id";
            }
            SqlCommand cmd1 = new SqlCommand(qry1, MainClass.con);
            cmd1.Parameters.AddWithValue("@id", id);
            cmd1.Parameters.AddWithValue("@Date", Convert.ToDateTime(txtDateTime.Value).Date);
            cmd1.Parameters.AddWithValue("@Type", "SAL");
            cmd1.Parameters.AddWithValue("@supID", Convert.ToInt32(cbCustomer.SelectedValue));
            if (MainClass.con.State == ConnectionState.Closed)
            {
                MainClass.con.Open();
            }
            if (id == 0)
            {
                id = Convert.ToInt32(cmd1.ExecuteScalar());
            }
            else
            {
                cmd1.ExecuteNonQuery();
            }
            // insert details table
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                int did = Convert.ToInt32(row.Cells["dgvId"].Value);
                if (did == 0)
                {
                    qry2 = "Insert into tblDetails Values (@mID,@proID,@qty,@price,@amount,@cost)";
                }
                else
                {
                    qry2 = "Update tblDetails set dMainID = @mID, productID = @proID, qty = @qty, price = @price, amount = @amount where detailID = @id";
                }
                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                cmd2.Parameters.AddWithValue("@id", did);
                cmd2.Parameters.AddWithValue("@mID", id);
                cmd2.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvproid"].Value));
                cmd2.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["dgvQty"].Value));
                cmd2.Parameters.AddWithValue("@cost", Convert.ToInt32(row.Cells["dgvCost"].Value));
                cmd2.Parameters.AddWithValue("@amount", Convert.ToInt32(row.Cells["dgvAmount"].Value));
                cmd2.Parameters.AddWithValue("@price", Convert.ToInt32(row.Cells["dgvCost"].Value));
                record += cmd2.ExecuteNonQuery();
            }
            if (record > 0)
            {
                Guna2MessageDialog guna2MessageDialog = new Guna2MessageDialog();
                guna2MessageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                guna2MessageDialog.Text = "Lưu thành công!";
                guna2MessageDialog.Show();

                id = 0;
                cusID = 0;
                txtDateTime.Value = DateTime.Now;
                cbCustomer.SelectedIndex = 0;
                cbCustomer.SelectedValue = -1;
                lbPrice.Text = "0.00";
                guna2DataGridView1.Rows.Clear();
            }
        }

        private void lbCustomer_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbName_Click(object sender, EventArgs e)
        {

        }

        private void lbSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
