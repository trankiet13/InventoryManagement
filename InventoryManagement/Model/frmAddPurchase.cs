using BusinessLayer;

using System;
using System.Data;
using System.Windows.Forms;

namespace InventoryManagement.Model
{
    public partial class frmAddPurchase : SampleAdd
    {
        private readonly PurchaseBL purchaseBL = new PurchaseBL();
        public int MainID = 0;
        public int supID = 0;
        public decimal Amount = 0;
        public string ProductName = "";
        public int Quantity = 0;
        public decimal Cost = 0;
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public frmAddPurchase()
        {
            InitializeComponent();
        }


        // Load form và khởi tạo dữ liệu
        private void frmAddPurchase_Load(object sender, EventArgs e)
        {
            // Load danh sách NCC
            DataTable dtSuppliers = purchaseBL.GetSuppliers();
            cbSupplier.DataSource = dtSuppliers;
            cbSupplier.DisplayMember = "name";
            cbSupplier.ValueMember = "id";
            cbSupplier.SelectedIndex = -1;

            // Xử lý khi chỉnh sửa
            if (MainID > 0)
            {
                // Set giá trị từ đơn cũ
                txtDateTime.Value = PurchaseDate;
                txtAmount.Text = TotalAmount.ToString("N0");
                cbSupplier.SelectedValue = supID;

                // Load sản phẩm và chi tiết
                LoadProductsBySupplier(supID);
                LoadPurchaseDetails(MainID); // Load chi tiết từ CSDL
            }

            dgvAddPurchase.Columns["dgvAmount"].DefaultCellStyle.Format = "N0";
        }
        // Thêm phương thức load chi tiết
        private void LoadPurchaseDetails(int mainID)
        {
            try
            {
                DataTable dtDetails = purchaseBL.GetPurchaseDetails(mainID);
                dgvAddPurchase.Rows.Clear();

                foreach (DataRow row in dtDetails.Rows)
                {
                    dgvAddPurchase.Rows.Add(
                        dgvAddPurchase.Rows.Count + 1, // dgvSR
                        row["detailID"],                // dgvid
                        row["productID"],              // dgvproid
                        row["name"],                   // dgvname
                        row["qty"],                    // dgvqty
                        row["cost"],                   // dgvCost 
                        row["amount"]                  // dgvAmount
                    );
                }

                // Cập nhật tổng tiền
                txtAmount.Text = TotalAmount.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message);
            }
        }
        // Load sản phẩm theo NCC được chọn
        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedValue != null &&
                int.TryParse(cbSupplier.SelectedValue.ToString(), out int supplierID))
            {
                LoadProductsBySupplier(supplierID); // Load sản phẩm khi NCC thay đổi
            }
            else
            {
                cbProduct.DataSource = null; // Reset nếu không có NCC được chọn
            }
        }

        private void LoadProductsBySupplier(int supplierID)
        {
            try
            {
                DataTable dtProducts = purchaseBL.GetProductsBySupplier(supplierID);
                if (dtProducts == null || dtProducts.Rows.Count == 0)
                {
                    MessageBox.Show("Nhà cung cấp này không có sản phẩm.");
                    cbProduct.DataSource = null;
                    txtCost.Text = "";
                    return;
                }

                // Gán DataSource và hiển thị tên sản phẩm
                cbProduct.DataSource = dtProducts;
                cbProduct.DisplayMember = "name";
                cbProduct.ValueMember = "id";
                cbProduct.SelectedIndex = 0;

                // Tự động điền giá vào txtCost khi chọn sản phẩm đầu tiên
                txtCost.Text = dtProducts.Rows[0]["DONGIA"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sản phẩm: {ex.Message}");
            }
        }

        // Thêm sản phẩm vào DataGridView
        private void btAddNew_Click(object sender, EventArgs e)
        {
            if (cbProduct.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return;
            }

            // Lấy giá trị từ các controls
            string productID = cbProduct.SelectedValue.ToString();
            string productName = cbProduct.Text;
            decimal quantity = Convert.ToDecimal(txtQuantity.Text);
            decimal cost = Convert.ToDecimal(txtCost.Text); // Lấy từ txtCost (đã điền tự động)
            decimal amount = quantity * cost;

            // Thêm hàng vào DataGridView
            dgvAddPurchase.Rows.Add(
                dgvAddPurchase.Rows.Count + 1, // dgvSR (số thứ tự)
                0,                             // dgvid = 0 (hàng mới)
                productID,                     // dgvproid (ẩn)
                productName,                   // dgvname
                quantity,                      // dgvqty
                cost,                          // dgvCost (lấy từ txtCost)
                amount.ToString("N0")          // dgvAmount
            );

            // Reset controls
            cbProduct.SelectedIndex = -1;
            txtQuantity.Text = "";
            txtCost.Text = "";
            txtAmount.Text = "";
        }
        // Lưu đơn hàng
        public override void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin!");
                    return;
                }

                DataTable dtDetails = ConvertGridToDataTable();
                int result = purchaseBL.SavePurchase(
                    MainID,
                    txtDateTime.Value.Date,
                    Convert.ToInt32(cbSupplier.SelectedValue),
                    dtDetails
                );

                if (result > 0)
                {
                    MessageBox.Show("Lưu đơn hàng thành công!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        // Chuyển DataGridView sang DataTable
        private DataTable ConvertGridToDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("detailID", typeof(int));
            dt.Columns.Add("productID", typeof(string));
            dt.Columns.Add("qty", typeof(int));
            dt.Columns.Add("price", typeof(decimal));
            dt.Columns.Add("amount", typeof(decimal));
            dt.Columns.Add("cost", typeof(decimal)); // Thêm cột cost

            foreach (DataGridViewRow row in dgvAddPurchase.Rows)
            {
                if (row.IsNewRow) continue;

                dt.Rows.Add(
                    Convert.ToInt32(row.Cells["dgvid"].Value),
                    row.Cells["dgvproid"].Value.ToString(),
                    Convert.ToInt32(row.Cells["dgvqty"].Value),
                    Convert.ToDecimal(row.Cells["dgvCost"].Value), // Lấy từ dgvCost
                    Convert.ToDecimal(row.Cells["dgvAmount"].Value),
                    Convert.ToDecimal(row.Cells["dgvCost"].Value)   // Gán cost từ dgvCost
                );
            }

            return dt;
        }
        // Validate dữ liệu đầu vào
        private bool ValidateInputs()
        {
            bool isValid = true;

            if (cbSupplier.SelectedIndex == -1)
            {
                cbSupplier.Focus();
                isValid = false;
            }

            if (dgvAddPurchase.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm!");
                isValid = false;
            }

            return isValid;
        }

        // Tính toán Amount tự động
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQuantity.Text) && !string.IsNullOrEmpty(txtCost.Text))
            {
                decimal qty, cost;
                if (decimal.TryParse(txtQuantity.Text, out qty) && decimal.TryParse(txtCost.Text, out cost))
                {
                    txtAmount.Text = (qty * cost).ToString("N2");
                }
            }
        }

        // Xử lý nhập barcode
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txtBarcode.Text))
            {
                string barcode = txtBarcode.Text;
                DataTable product = purchaseBL.GetProductDetails(barcode);
                if (product.Rows.Count > 0)
                {
                    cbProduct.SelectedValue = product.Rows[0]["BARCODE"].ToString();
                    txtCost.Text = product.Rows[0]["DONGIA"].ToString();
                    cbSupplier.SelectedValue = product.Rows[0]["MANCC"].ToString();
                    cbProduct.SelectedValue = product.Rows[0]["TENHH"].ToString();
                    txtBarcode.Text = "";
                    txtQuantity.Focus();
                }
            }
        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProduct.SelectedValue != null && cbProduct.DataSource != null)
            {
                DataTable dtProducts = (DataTable)cbProduct.DataSource;
                string selectedProductID = cbProduct.SelectedValue.ToString();

                // Tìm hàng tương ứng với productID được chọn
                DataRow[] rows = dtProducts.Select($"id = '{selectedProductID}'");
                if (rows.Length > 0)
                {
                    // Lấy giá từ cột DONGIA và gán vào txtCost
                    txtCost.Text = rows[0]["DONGIA"].ToString();
                }
            }
        }

        private void dgvAddPurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public override void btClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}