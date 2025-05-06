using BusinessLayer;
using Guna.UI2.WinForms;
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

namespace InventoryManagement
{
    public partial class frmSetting : SampleAdd
    {
        public int id = 0;

        public frmSetting()
        {
            InitializeComponent();
            LoadCongTyAndDonVi();

            LoadUserInfo();


        }
        //Load thông tin hiện tại của người dùng
        private void LoadUserInfo()
        {
            try
            {
                UserBL userBL = new UserBL();
                DataTable dt = userBL.GetUserById(LoginInfo.CurrentUser.UserID);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    this.id = Convert.ToInt32(row["IDUSER"]);// Gán ID để dùng khi cập nhật
                    txtUserName.Text = row["USERNAME"].ToString();
                    txtFullName.Text = row["FULLNAME"].ToString();
                    txtPassword.Text = row["PASSWD"].ToString();
                    txtMail.Text = row["Email"].ToString();

                    // Thiết lập combobox công ty và đơn vị
                    cbbMaCty.SelectedValue = row["MACTY"].ToString(); // Bind giá trị MACTY
                    LoadDonViByCongTy(); // Load đơn vị tương ứng
                    cbbMaDvi.SelectedValue = row["MADVI"].ToString(); // Bind giá trị MADVI
                    // Cập nhật ComboBox dựa trên giá trị IsGroup (1: Admin, 2: User, 3: Staff)
                    int role = Convert.ToInt32(row["ISGROUP"]);

                    // Set giá trị của ComboBox tương ứng với giá trị role từ DB
                    switch (role)
                    {
                        case 1:
                            cbbRole.SelectedItem = "Admin";
                            break;
                        case 2:
                            cbbRole.SelectedItem = "User";
                            break;
                        case 3:
                            cbbRole.SelectedItem = "Staff";
                            break;
                        default:
                            cbbRole.SelectedItem = "User"; // Default nếu không có giá trị hợp lệ
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                guna2MessageDialog1.Show("Lỗi khi tải thông tin người dùng: " + ex.Message);
            }
        }
        private void LoadCongTyAndDonVi()
        {
            // Load công ty
            UserBL userBL = new UserBL();
            DataTable dtCty = userBL.GetCongTyList();
            cbbMaCty.DisplayMember = "TENCTY";
            cbbMaCty.ValueMember = "MACTY";
            cbbMaCty.DataSource = dtCty;

            // Sửa sự kiện SelectedIndexChanged
            cbbMaCty.SelectedIndexChanged += (s, e) =>
            {
                // Reset combobox đơn vị
                cbbMaDvi.DataSource = null;    // Xóa nguồn dữ liệu cũ
                cbbMaDvi.Items.Clear();        // Xóa các item hiện có
                cbbMaDvi.Text = "";            // Xóa text hiển thị

                // Load lại đơn vị theo công ty mới
                LoadDonViByCongTy();
            };

            // Load đơn vị ban đầu (nếu có dữ liệu)
            if (cbbMaCty.Items.Count > 0)
            {
                LoadDonViByCongTy();
            }
        }
        public void LoadDonViByCongTy()
        {
            if (cbbMaCty.SelectedValue != null)
            {
                string maCongTy = cbbMaCty.SelectedValue.ToString();
                UserBL userBL = new UserBL();
                DataTable dtDvi = userBL.GetDonViListByMaCongTy(maCongTy);

                // Thêm dòng mặc định nếu không có đơn vị
                if (dtDvi.Rows.Count == 0)
                {
                    dtDvi = new DataTable();
                    dtDvi.Columns.Add("MADVI");
                    dtDvi.Columns.Add("TENDVI");
                    dtDvi.Rows.Add("", "-- Không có đơn vị --");
                }

                // Bind dữ liệu mới
                cbbMaDvi.DisplayMember = "TENDVI";
                cbbMaDvi.ValueMember = "MADVI";
                cbbMaDvi.DataSource = dtDvi;
            }
        }

        public static bool Validation(Form F)
        {
            bool isValid = false;
            int count = 0;
            foreach (Control c in F.Controls)
            {
                //sử dụng tag c để kiểm tra trống
                if (Convert.ToString(c.Tag) != "" && Convert.ToString(c.Tag) != null)
                {
                    if (c is Guna.UI2.WinForms.Guna2TextBox)
                    {
                        Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
                        if (t.Text.Trim() == "")
                        {
                            t.BorderColor = Color.Red;
                            t.FocusedState.BorderColor = Color.Red;
                            t.HoverState.BorderColor = Color.Red;
                            count++;
                        }
                        else
                        {
                            t.BorderColor = Color.FromArgb(213, 218, 223);
                            t.FocusedState.BorderColor = Color.FromArgb(95, 61, 204);
                            t.HoverState.BorderColor = Color.FromArgb(95, 61, 204);
                        }
                    }

                }
                if (count == 0)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }


        public override void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation(this) == false)
                {
                    guna2MessageDialog1.Show("Không được để trống");
                    return;
                }

                UserBL bl = new UserBL();

                int role = 0;



                switch (cbbRole.SelectedItem?.ToString())
                {
                    case "Admin": role = 1; break;
                    case "User": role = 2; break;
                    case "Staff": role = 3; break;
                    default: role = 2; break;
                }
                // Lấy mã công ty và mã đơn vị
                string maCongTy = cbbMaCty.SelectedValue.ToString();
                string maDonVi = cbbMaDvi.SelectedValue.ToString();

                // Gọi phương thức SaveUser (sẽ tự động kiểm tra trùng username)
                int result = bl.SaveUser(id, txtUserName.Text, txtFullName.Text, txtPassword.Text, maCongTy, maDonVi, role, txtMail.Text);
                if (result > 0)
                {
                    guna2MessageDialog1.Show("Lưu thành công");
                    this.Close();
                }
                else
                {
                    guna2MessageDialog1.Show("Thao tác thất bại");
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi từ Business Layer
                guna2MessageDialog1.Icon = MessageDialogIcon.Error;
                guna2MessageDialog1.Show(ex.Message);
            }
        }
        private void frmSetting_Load(object sender, EventArgs e)
        {
            LoadCongTyAndDonVi();
            // Ẩn Mã công ty, Mã đơn vị và Vai trò nếu không phải admin
            if (LoginInfo.CurrentUser.IsGroup != 1)
            {
                cbbMaCty.Visible = false;
                cbbMaDvi.Visible = false;
                cbbRole.Visible = false;

                // Ẩn label
                lbMaCty.Visible = false;
                lbMaDvi.Visible = false;
                lbRole.Visible = false;
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
