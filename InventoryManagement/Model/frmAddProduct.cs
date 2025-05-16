using BusinessLayer;
using InventoryManagement.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventoryManagement.Model
{
    public partial class frmAddProduct : SampleAdd
    {
        private ProductsBL productsBL;
        private Product selectedProduct;
        private string autoRandomBarcode;

        public frmAddProduct(View.frmViewProduct frmProductView, Product product = null)
        {
            InitializeComponent();
            selectedProduct = product;
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            LoadXuatXu();
            LoadNhaCungCap();
            LoadDVT();
            LoadNhomSanPham();

            if (selectedProduct != null)
            {
                txtbarcode.Text = selectedProduct.BARCODE;
                txtbarcode.Enabled = false;
                txtTenHH.Text = selectedProduct.TENHH;
                txtTentat.Text = selectedProduct.TENTAT;
                spGia.Text = selectedProduct.DONGIA?.ToString();
                cbDvt.Text = selectedProduct.DVT?.ToString();
                if (!string.IsNullOrEmpty(selectedProduct.IDNHOM))
                {
                    cbNhom.SelectedValue = selectedProduct.IDNHOM;
                }

                cbNcc.SelectedValue = selectedProduct.MANCC;
                cbXuatxu.SelectedValue = selectedProduct.MAXX;
                txtMota.Text = selectedProduct.MOTA;
                chkDisabled.Checked = selectedProduct.DISABLED ?? false;
            }
            else
            {
                autoRandomBarcode = GenerateRandomBarcode();
                txtbarcode.Text = autoRandomBarcode;
                txtbarcode.Enabled = false;
            }
        }

        private string GenerateRandomBarcode()
        {
            Random random = new Random();
            int barcodeNumber = random.Next(1000000, 9999999);
            return barcodeNumber.ToString();
        }

        public override void btSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenHH.Text) ||
                string.IsNullOrWhiteSpace(txtTentat.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbDvt.SelectedValue == null || cbNcc.SelectedValue == null || cbXuatxu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Đơn vị tính, Nhà cung cấp và Xuất xứ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string barcode = txtbarcode.Text.Trim();

                Product product = new Product
                {
                    BARCODE = barcode,
                    TENHH = txtTenHH.Text.Trim(),
                    TENTAT = txtTentat.Text.Trim(),
                    DVT = (cbDvt.SelectedItem as DataRowView)?["TEN"].ToString(),
                    DONGIA = decimal.TryParse(spGia.Text, out decimal gia) ? gia : 0,
                    MANCC = Convert.ToInt32(cbNcc.SelectedValue),
                    MAXX = Convert.ToInt32(cbXuatxu.SelectedValue),
                    IDNHOM = cbNhom.SelectedValue.ToString(),
                    MOTA = txtMota.Text.Trim(),
                    CREATED_DATE = DateTime.Now,
                    CREATED_BY = MainClass.id,
                    DISABLED = chkDisabled.Checked,
                    pImage = imageByteArray
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

        private void LoadNhomSanPham()
        {
            ProductsBL bl = new ProductsBL();
            DataTable dt = bl.LoadNhomSanPham();
            cbNhom.DataSource = dt;
            cbNhom.DisplayMember = "TENNHOM";
            cbNhom.ValueMember = "IDNHOM";
            cbNhom.SelectedIndex = -1;
        }

        public string filePath = "";
        Byte[] imageByteArray;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (.jpg, .png)|*.png;*.jpg;*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filePath = ofd.FileName;
                    txtPic.Image = new Bitmap(filePath);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        txtPic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageByteArray = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message, "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddNhom_Click(object sender, EventArgs e)
        {
            frmViewNhom frmViewNhom = new frmViewNhom();
            frmViewNhom.ShowDialog();
            LoadNhomSanPham();
        }

        private void btnAddXX_Click(object sender, EventArgs e)
        {
            frmViewXuatXu frmViewXuatXu = new frmViewXuatXu();
            frmViewXuatXu.ShowDialog();
            LoadXuatXu();
        }

     
    }
}
