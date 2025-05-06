using BusinessLayer;
using InventoryManagement.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TransferObject;

namespace InventoryManagement
{
    public partial class frmMai : Form
    {
        
        public frmMai()
        {
            InitializeComponent();
            ///kiểm tra k phải admin thì ẩn btUser
            if (LoginInfo.CurrentUser != null && LoginInfo.CurrentUser.IsGroup != 1)
            {
                btUser.Visible = false; // Ẩn nút nếu không phải admin
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void form_Load_Load(object sender, EventArgs e)
        {
            this.Show();
            this.Enabled = false;
            LoginForm login = new LoginForm();
            DialogResult result = login.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Enabled = true;
                if (LoginInfo.CurrentUser.IsGroup != 1)
                {
                    btUser.Visible = false;
                }

            }
            else
            {
                Application.Exit();
            }


        }
        public void AddControls (Form F)
        {
            this.pnRight.Controls.Clear();
            F.Dock = DockStyle.Fill;
            F.TopLevel = false;
            pnRight.Controls.Add(F);
            F.Show();
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pnRight_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnRight.Controls.Clear();
            pnRight.Controls.Add(childForm);
            childForm.Show();
        }
        private void btUser_Click(object sender, EventArgs e)
        {
            LoadChildForm(new View.frmUserView());
        }

        private void pnTop_Paint(object sender, PaintEventArgs e)
        {
            //LoadChildForm(new Model.frmAddUser());
        }

        private void bnCategoy_Click(object sender, EventArgs e)
        {
            LoadChildForm(new View.frmViewCategory());
        }

        private void bnPurchase_Click(object sender, EventArgs e)
        {
            LoadChildForm(new View.frmViewPurchase());
        }

        private void bnProducts_Click(object sender, EventArgs e)
        {
            LoadChildForm(new View.frmViewProduct());
        }

        private void bnCustomers_Click(object sender, EventArgs e)
        {
            LoadChildForm(new View.frmViewCustomer());
        }

        private void btSales_Click(object sender, EventArgs e)
        {
            LoadChildForm(new View.frmViewSale());
        }

        private void bnHome_Click(object sender, EventArgs e)
        {
            try
            {
                ProductsBL productsBL = new ProductsBL();
                var products = productsBL.GetAllProducts();

                frmProductStatistical frmProductStatistical = new frmProductStatistical(products);
                LoadChildForm(frmProductStatistical);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmSetting st = new frmSetting();
            st.Show();
        }
    }
}
