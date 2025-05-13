using BusinessLayer;
using InventoryManagement.Model;
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
using TransferObject;


namespace InventoryManagement.View
{
    public partial class frmViewProduct : SampleView
    {
        private ProductsBL productsBL;

        public frmViewProduct()
        {
            InitializeComponent();
            productsBL = new ProductsBL();
        }


        private void LoadProduct()
        {
            try
            {
                dgvProductView.DataSource = productsBL.GetAllProducts();

                // Thêm nút Update nếu chưa có
                if (!dgvProductView.Columns.Contains("Update"))
                {
                    DataGridViewButtonColumn updateButton = new DataGridViewButtonColumn();
                    updateButton.Name = "Update";
                    updateButton.HeaderText = "Sửa";
                    updateButton.Text = "Sửa";
                    updateButton.UseColumnTextForButtonValue = true;
                    dgvProductView.Columns.Add(updateButton);
                }

                // Thêm nút Delete nếu chưa có
                if (!dgvProductView.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                    deleteButton.Name = "Delete";
                    deleteButton.HeaderText = "Xóa";
                    deleteButton.Text = "Xóa";
                    deleteButton.UseColumnTextForButtonValue = true;
                    dgvProductView.Columns.Add(deleteButton);
                }

                // Gắn sự kiện nếu chưa gắn
                dgvProductView.CellClick -= dgvProductView_CellClick;
                dgvProductView.CellClick += dgvProductView_CellClick;

                dgvProductView.Columns["TENTAT"].Visible = false;
                dgvProductView.Columns["MOTA"].Visible = false;
                dgvProductView.Columns["CREATED_DATE"].Visible = false;
                dgvProductView.Columns["CREATED_BY"].Visible = false;
                dgvProductView.Columns["DISABLED"].Visible = false;
                dgvProductView.Columns["pImage"].Visible = false;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: \n" + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            LoadProduct();

        }
        //Tìm kiếm theo tên hàng hóa hoặc mã barcode
        private void SearchProduct()
        {
            string keyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {
                dgvProductView.DataSource = productsBL.SearchProduct(keyword);
            }
            else
            {
                LoadProduct();
            }
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProduct();
        }

        public override void btAddNew_Click(object sender, EventArgs e)
        {
            frmAddProduct frmaddProduct = new frmAddProduct(this);
            DialogResult dialogResult = frmaddProduct.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                // refresh
                LoadProduct();
            }
        }

        private void frmViewProduct_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void dgvProductView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string barcode = dgvProductView.Rows[e.RowIndex].Cells["BARCODE"].Value?.ToString();
            if (string.IsNullOrEmpty(barcode)) return;

            string columnName = dgvProductView.Columns[e.ColumnIndex].Name;

            if (columnName == "Update")
            {
                List<Product> products = productsBL.GetAllProducts();
                Product selected = products.FirstOrDefault(p => p.BARCODE == barcode);

                if (selected != null)
                {
                    frmAddProduct frm = new frmAddProduct(this, selected);
                    frm.ShowDialog();
                    LoadProduct();
                }
            }
            else if (columnName == "Delete")
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    int result = productsBL.DeleteProduct(barcode);
                    if (result > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadProduct();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa sản phẩm.", "Lỗi");
                    }
                }
            }
        }
        //private ProductsBL productsBL;


        //public void LoadData()
        //{
        //    try
        //    {
        //        dgvViewProducts.DataSource = productsBL.GetAllProducts();
        //    }
        //    catch (SqlException ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public override void btAddNew_Click(object sender, EventArgs e)
        //{
        //    frmAddProduct frmaddProduct = new frmAddProduct();
        //    DialogResult result = frmaddProduct.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        LoadData();
        //    }
        //}
        //private void frmViewProduct_Load(object sender, EventArgs e)
        //{
        //    LoadData();

        //}
    }
    
}
