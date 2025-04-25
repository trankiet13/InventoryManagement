using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;

namespace InventoryManagement.Model
{
    public partial class frmAddProduct : SampleAdd
    {
        private Product selectedProduct;

        public frmAddProduct(View.frmProductView frmProductView,Product product = null)
        {
            InitializeComponent();
            selectedProduct = product;    
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            LoadXuatXu();
            LoadNhaCungCap();
            LoadDVT();

            if (selectedProduct != null)
            {
                txtBarcode.Text = selectedProduct.BARCODE;
                txtBarcode.Enabled = false;

                txtTenHH.Text = selectedProduct.TENHH;
                txtTentat.Text = selectedProduct.TENTAT;
                spGia.Text = selectedProduct.DONGIA?.ToString();
                cbDvt.Text = selectedProduct.DVT?.ToString();
                cbNcc.SelectedValue = selectedProduct.MANCC;
                cbXuatxu.SelectedValue = selectedProduct.MAXX;
                txtMota.Text = selectedProduct.MOTA;
                chkDisabled.Checked = selectedProduct.DISABLED ?? false;
            }
        }

        public override void btSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenHH.Text) ||
                string.IsNullOrWhiteSpace(txtTentat.Text)) 
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thiếu thông tin",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            if (cbDvt.SelectedValue == null || cbNcc.SelectedValue == null || cbXuatxu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Đơn vị tính, Nhà cung cấp và Xuất xứ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string barcode = txtBarcode.Text.Trim();

                Product product = new Product
                {
                    BARCODE = barcode,
                    TENHH = txtTenHH.Text.Trim(),
                    TENTAT = txtTentat.Text.Trim(),
                    DVT = (cbDvt.SelectedItem as DataRowView)?["TEN"].ToString(),
                    DONGIA = decimal.TryParse(spGia.Text, out decimal gia) ? gia : 0,
                    MANCC = Convert.ToInt32(cbNcc.SelectedValue),
                    MAXX = Convert.ToInt32(cbXuatxu.SelectedValue),
                    IDNHOM = "10",
                    MOTA = txtMota.Text.Trim(),
                    CREATED_DATE = DateTime.Now,
                    CREATED_BY = MainClass.id,
                    DISABLED = chkDisabled.Checked
                };


                ProductsBL productsBL = new ProductsBL();
                int success;

                if (selectedProduct == null)
                {
                    // Add new product
                    success = productsBL.AddProduct(product);
                }
                else
                {
                    // Update existing product
                    success = productsBL.UpdateProduct(product);
                }

                if (success > 0)
                {
                    MessageBox.Show(selectedProduct == null ? "Thêm sản phẩm thành công!" : "Cập nhật sản phẩm thành công!",
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(selectedProduct == null ? "Lỗi khi thêm sản phẩm." : "Lỗi khi cập nhật sản phẩm.",
                                  "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void btClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadXuatXu()
        {
            ProductsBL bl = new ProductsBL();
            DataTable dt = bl.LoadXuatXu();
            cbXuatxu.DataSource = dt;
            cbXuatxu.DisplayMember = "TEN";
            cbXuatxu.ValueMember = "ID";
            cbXuatxu.SelectedIndex = -1;
        }

        private void LoadNhaCungCap()
        {
            ProductsBL bl = new ProductsBL();
            DataTable dt = bl.LoadNhaCungCap();
            cbNcc.DataSource = dt;
            cbNcc.DisplayMember = "TENNCC";
            cbNcc.ValueMember = "MANCC";
            cbNcc.SelectedIndex = -1;
        }

        private void LoadDVT()
        {
            ProductsBL bl = new ProductsBL();
            DataTable dt = bl.LoadDVT();
            cbDvt.DataSource = dt;
            cbDvt.DisplayMember = "TEN";
            cbDvt.SelectedIndex = -1;
        }
    }
}
