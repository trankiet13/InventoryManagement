using BusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InventoryManagement.Model
{
    public partial class frmUserAdd : SampleAdd
    {
        public int id = 0;

        // Thêm constructor nhận userId
        public frmUserAdd(int userId = 0)
        {
            InitializeComponent();
            this.id = userId;



            // Load thông tin nếu là chỉnh sửa
            if (id != 0)
            {
                LoadUserInfo();

            }
        }
        private void LoadUserInfo()
        {
            UserBL userBL = new UserBL();
            DataTable dt = userBL.GetUserById(id);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtUser.Text = row["USERNAME"].ToString();
                txtName.Text = row["FULLNAME"].ToString();
                txtPass.Text = row["PASSWD"].ToString();

                // Set giá trị quyền
                switch (row["ISGROUP"].ToString())
                {
                    case "1": cbbRole.SelectedItem = "Admin"; break;
                    case "2": cbbRole.SelectedItem = "User"; break;
                    case "3": cbbRole.SelectedItem = "Staff"; break;
                }
                txtEmail.Text = row["Email"].ToString();

                // Thiết lập combobox công ty và đơn vị
                cbbMaCty.SelectedValue = row["MACTY"].ToString(); // Bind giá trị MACTY
                LoadDonViByCongTy(); // Load đơn vị tương ứng
                cbbMaDvi.SelectedValue = row["MADVI"].ToString(); // Bind giá trị MADVI
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
                int result = bl.SaveUser(id, txtUser.Text, txtName.Text, txtPass.Text, maCongTy, maDonVi, role, txtEmail.Text);

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
        private void frmUserAdd_Load(object sender, EventArgs e)
        {
            LoadCongTyAndDonVi();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}