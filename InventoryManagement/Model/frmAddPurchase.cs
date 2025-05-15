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
            if (supID > 0)
            {

                cbSupplier.SelectedValue = supID;
                LoadProductsBySupplier(supID);
                txtAmount.Text = Amount.ToString();
                cbProduct.Text = ProductName;
                txtQuantity.Text = Quantity.ToString();
                txtCost.Text = Cost.ToString();
            }
        }
       

        // Load sản phẩm theo NCC được chọn
        private void cbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedValue != null &&
                int.TryParse(cbSupplier.SelectedValue.ToString(), out int supplierID))
            {
                LoadProductsBySupplier(supplierID);
                 // Load sản phẩm khi NCC thay đổi
            }
            else
            {
                cbProduct.DataSource = null; // Reset nếu không có NCC được chọn
            }

        }
        // Trong LoadProductsBySupplier:
        private void LoadProductsBySupplier(int supplierID)
        {
            try
            {
                DataTable dtProducts = purchaseBL.GetProductsBySupplier(supplierID);

                // Kiểm tra dữ liệu hợp lệ
                if (dtProducts == null || dtProducts.Rows.Count == 0)
                {
                    MessageBox.Show("Nhà cung cấp này không có sản phẩm.");
                    cbProduct.DataSource = null; // Sửa thành null
                    return;
                }

                // Đảm bảo tên cột "id" và "name" tồn tại
                cbProduct.DataSource = dtProducts;
                cbProduct.DisplayMember = "name";
                cbProduct.ValueMember = "id";
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

            // Lấy giá trị ID từ SelectedValue
            int productID = Convert.ToInt32(cbProduct.SelectedValue);
            string productName = cbProduct.Text;

            if (string.IsNullOrEmpty(txtQuantity.Text) || string.IsNullOrEmpty(txtCost.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm!");
                return;
            }

            decimal quantity = Convert.ToDecimal(txtQuantity.Text);
            decimal cost = Convert.ToDecimal(txtCost.Text);
            decimal amount = quantity * cost;

            dgvAddPurchase.Rows.Add(
                0,              // dgvid
                productID,      // ProductID
                productName,    // ProductName
                quantity,       // Quantity
                cost,           // Cost
                amount.ToString("N2") // Amount
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
            dt.Columns.Add("productID", typeof(int));
            dt.Columns.Add("qty", typeof(int));
            dt.Columns.Add("price", typeof(decimal));
            dt.Columns.Add("amount", typeof(decimal));

            foreach (DataGridViewRow row in dgvAddPurchase.Rows)
            {
                if (row.IsNewRow) continue;

                dt.Rows.Add(
                    Convert.ToInt32(row.Cells["dgvid"].Value),
                    Convert.ToInt32(row.Cells["dgvproid"].Value),
                    Convert.ToInt32(row.Cells["dgvqty"].Value),
                    Convert.ToDecimal(row.Cells["dgvCost"].Value),
                    Convert.ToDecimal(row.Cells["dgvAmount"].Value)
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
                if (int.TryParse(txtBarcode.Text, out int barcode))
                {
                    DataTable product = purchaseBL.GetProductDetails(barcode);
                    if (product.Rows.Count > 0)
                    {
                        // Sửa thành cột "id" thay vì "BARCODE"
                        cbProduct.SelectedValue = product.Rows[0]["id"];
                        txtCost.Text = product.Rows[0]["DONGIA"].ToString();
                        txtBarcode.Text = "";
                        txtQuantity.Focus();
                    }
                }
            }
        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}