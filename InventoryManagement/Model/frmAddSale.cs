using BusinessLayer;
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
   
        private SaleBL saleBL = new SaleBL(); // Khởi tạo Business Layer
        public int id = 0;
        public int cusID = 0;

        public frmAddSale()
        {
            InitializeComponent();
        }

        private void frmAddSale_Load(object sender, EventArgs e)
        {
            try
            {
                // Đặt ngày hiện tại vào DateTimePicker
                txtDateTime.Value = DateTime.Now;

                // Load danh sách khách hàng từ BusinessLayer
                DataTable dtCustomers = saleBL.GetCustomers();
                cbCustomer.DataSource = dtCustomers;
                cbCustomer.DisplayMember = "cusName";
                cbCustomer.ValueMember = "cusID";
                cbCustomer.SelectedIndex = -1;

                if (cusID > 0)
                {
                    cbCustomer.SelectedValue = cusID;
                }

                LoadProductsFromDatabase();
                if (id > 0)
                {
                    DataTable dtSale = saleBL.GetSaleByID(id);
                    if (dtSale.Rows.Count > 0)
                    {
                        // Load thông tin chính
                        txtDateTime.Value = Convert.ToDateTime(dtSale.Rows[0]["mdate"]);
                        cbCustomer.SelectedValue = Convert.ToInt32(dtSale.Rows[0]["mSupCusID"]);

                        // Load chi tiết vào DataGridView
                        foreach (DataRow row in dtSale.Rows)
                        {
                            int productID = Convert.ToInt32(row["productID"]);
                            int qty = Convert.ToInt32(row["qty"]);
                            int price = Convert.ToInt32(row["price"]);
                            int cost = Convert.ToInt32(row["cost"]);

                            // Tìm sản phẩm trong flowLayoutPanel để thêm vào giỏ hàng
                            foreach (Control control in flowLayoutPanel1.Controls)
                            {
                                if (control is ucProduct product && product.id == productID)
                                {
                                    // Thêm vào DataGridView
                                    guna2DataGridView1.Rows.Add(new object[] {
                                0,
                                productID,
                                product.PName,
                                qty,
                                price,
                                cost,
                                qty * price
                            });
                                    break;
                                }
                            }
                        }
                        GrandTotal(); // Tính lại tổng
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi tải danh sách khách hàng: " + ex.Message);
            }
        }



        // Thêm sản phẩm vào flowLayoutPanel
        public void Additems(string id, string name, string price, Image image, string cost)
        {
            var productControl = new ucProduct()
            {
                PName = name,
                Price = price,
                Pimage = image,
                Pcost = cost,
                id = Convert.ToInt32(id)
            };

            flowLayoutPanel1.Controls.Add(productControl);

            productControl.onSelect += (ss, ee) =>
            {
                var selectedProduct = (ucProduct)ss;
                UpdateOrAddToCart(selectedProduct);
            };
        }

        // Cập nhật hoặc thêm sản phẩm vào giỏ hàng
        private void UpdateOrAddToCart(ucProduct product)
        {
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells["dgvproid"].Value) == product.id)
                {
                    row.Cells["dgvQty"].Value = Convert.ToInt32(row.Cells["dgvQty"].Value) + 1;
                    row.Cells["dgvAmount"].Value = Convert.ToInt32(row.Cells["dgvQty"].Value) * Convert.ToInt32(row.Cells["dgvPrice"].Value);
                    GrandTotal();
                    return;
                }
            }
            guna2DataGridView1.Rows.Add(new object[] { 0, product.id, product.PName, 1, product.Price, product.Pcost, null, null });
            GrandTotal();
        }

        // Tính tổng tiền
        private void GrandTotal()
        {
            double total = 0;
            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.Cells["dgvAmount"].Value != null)
                {
                    total += Convert.ToDouble(row.Cells["dgvAmount"].Value);
                }
            }
            lbPrice.Text = total.ToString("N2");
        }

        // Tải sản phẩm từ Business Layer
        private void LoadProductsFromDatabase()
        {
            try
            {
                DataTable dtProducts = saleBL.GetProducts();
                foreach (DataRow row in dtProducts.Rows)
                {
                    byte[] imageBytes = (byte[])row["pImage"];
                    Image productImage = Image.FromStream(new MemoryStream(imageBytes));
                    Additems(
                        row["BARCODE"].ToString(),
                        row["TENHH"].ToString(),
                        row["DONGIA"].ToString(),
                        productImage,
                        row["DONGIA"].ToString()
                    );
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi tải sản phẩm: " + ex.Message);
            }
        }

        // Xử lý lưu đơn hàng
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                // Lưu đơn hàng chính
                int mainID = saleBL.SaveSale(
                    mainID: id,
                    date: txtDateTime.Value.Date,
                    cusID: Convert.ToInt32(cbCustomer.SelectedValue)
                );

                // Lưu chi tiết đơn hàng
                int recordsAffected = 0;
                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    recordsAffected += saleBL.SaveSaleDetail(
                        detailID: Convert.ToInt32(row.Cells["dgvId"].Value),
                        mainID: mainID,
                        productID: Convert.ToInt32(row.Cells["dgvproid"].Value),
                        qty: Convert.ToInt32(row.Cells["dgvQty"].Value),
                        price: Convert.ToInt32(row.Cells["dgvPrice"].Value),
                        cost: Convert.ToInt32(row.Cells["dgvCost"].Value)
                    );
                }

                if (recordsAffected > 0)
                {
                    ShowSuccessMessage("Lưu đơn hàng thành công!");
                    ResetForm();
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi lưu đơn hàng: " + ex.Message);
            }
        }

        // Validate form
        private bool ValidateForm()
        {
            if (cbCustomer.SelectedIndex == -1)
            {
                ShowErrorMessage("Vui lòng chọn khách hàng!");
                return false;
            }

            if (guna2DataGridView1.Rows.Count == 0)
            {
                ShowErrorMessage("Vui lòng thêm sản phẩm vào đơn hàng!");
                return false;
            }

            return true;
        }

        // Reset form sau khi lưu
        private void ResetForm()
        {
            id = 0;
            cusID = 0;
            txtDateTime.Value = DateTime.Now;
            cbCustomer.SelectedIndex = -1;
            guna2DataGridView1.Rows.Clear();
            lbPrice.Text = "0.00";
        }

        // Hiển thị thông báo lỗi
        private void ShowErrorMessage(string message)
        {
            new Guna2MessageDialog()
            {
                Buttons = MessageDialogButtons.OK,
                Icon = MessageDialogIcon.Error,
                Text = message
            }.Show();
        }

        // Hiển thị thông báo thành công
        private void ShowSuccessMessage(string message)
        {
            new Guna2MessageDialog()
            {
                Buttons = MessageDialogButtons.OK,
                Icon = MessageDialogIcon.Information,
                Text = message
            }.Show();
        }

        // Các sự kiện khác
        private void btClosee_Click(object sender, EventArgs e) => ResetForm();
        private void txtSearch_TextChanged(object sender, EventArgs e) => FilterProducts();

        // Lọc sản phẩm
        private void FilterProducts()
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is ucProduct product)
                {
                    product.Visible = product.PName.ToLower().Contains(searchText);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
