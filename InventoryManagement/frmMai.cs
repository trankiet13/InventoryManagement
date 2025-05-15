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
                // Hiển thị thông báo "Xin chào + full name"
                if (LoginInfo.CurrentUser != null)
                {
                    lbUsername.Text = "Xin chào " + LoginInfo.CurrentUser.Username +  " !!!!";
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

        private void lbUsername_Click(object sender, EventArgs e)
        {

        }

        private void pictureboxUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Xác nhận đăng xuất
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Đóng tất cả form con đang mở (nếu có)
                CloseAllChildForms();

                // Xóa thông tin người dùng
                LoginInfo.CurrentUser = null;

                // Ẩn form chính (frmMai)
                this.Hide();

                // Mở lại form đăng nhập
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog(); // Hiển thị dưới dạng dialog

                // Xử lý sau khi đăng nhập thành công hoặc hủy
                if (loginForm.DialogResult == DialogResult.OK)
                {
                    // Cập nhật thông tin người dùng mới
                    lbUsername.Text = "Xin chào " + LoginInfo.CurrentUser.Username;
                    btUser.Visible = (LoginInfo.CurrentUser.IsGroup == 1);

                    // Hiển thị lại form chính
                    this.Show();
                }
                else
                {
                    // Đóng ứng dụng nếu hủy đăng nhập
                    Application.Exit();
                }
            }
        }

        // Hàm đóng tất cả form con
        private void CloseAllChildForms()
        {
            // Lặp qua danh sách form đang mở và đóng các form con
            List<Form> openForms = new List<Form>();

            foreach (Form form in Application.OpenForms)
            {
                if (form != this && !(form is LoginForm))
                {
                    openForms.Add(form);
                }
            }

            foreach (Form form in openForms)
            {
                form.Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadChildForm(new View.frm());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            LoadChildForm(new frmViewSupplier());
        }
    }
    
}
