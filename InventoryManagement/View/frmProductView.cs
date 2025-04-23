using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using System.Data.SqlClient;
using BusinessLayer;
using InventoryManagement.Model;

namespace InventoryManagement.View
{
    public partial class frmProductView : SampleView
    {
        private ProductsBL productsBL;
        public frmProductView()
        {
            InitializeComponent();
            productsBL = new ProductsBL();
        }

        private void LoadProduct()
        {
            try
            {
                dgvProductView.DataSource = productsBL.GetAllProducts();
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
    }
}
