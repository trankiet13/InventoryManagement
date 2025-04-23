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
        public frmAddProduct(View.frmProductView frmProductView)
        {
            InitializeComponent();
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            LoadXuatXu();
            LoadNhaCungCap();
            LoadDVT();
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
                int success = productsBL.AddProduct(product); // gọi xuống BL
                if (success > 0)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            { 
                throw ex;
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
