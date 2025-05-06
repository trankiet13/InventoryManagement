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
using System.Collections;
using System.IO;
using BusinessLayer;
using System.Xml.Linq;
using Guna.UI2.WinForms.Enums;
using InventoryManagement.View;
namespace InventoryManagement.Model
{
    public partial class frmAddUser1 : SampleAdd
    {
        private frmViewUser parentForm;
        private Guna2MessageDialog messageDialog = new Guna2MessageDialog();
        //public frmAddUser(frmViewUser parent)
        //{
        //    InitializeComponent();
        //    parentForm = parent;
        //}

        //private void frmAddUser_Load(object sender, EventArgs e)
        //{

        //}
        //public override void btSave_Click(object sender, EventArgs e)
        //{

        //    if (MainClass.Validation(this) == false)
        //    {
        //        messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
        //        messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
        //        messageDialog.Show("Please fill all the required fields");
        //        return;
        //    }

        //    string username = txtUsername.Text;
        //    string password = txtPassword.Text;
        //    string fullname = txtFullName.Text;
        //    string madvi = txtID.Text; // textbox mã đơn vị
        //    string macty = txtMACTY.Text; // textbox mã công ty

        //    UserBL userBL = new UserBL();
        //    int result = userBL.SaveUser(MainClass.id, username, password, fullname, madvi, macty);

        //    if (result > 0)
        //    {
        //        messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
        //        messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
        //        messageDialog.Show("User saved successfully");
        //        parentForm.LoadDataGridView();
        //        MainClass.id = 0;
        //        txtUsername.Text = "";
        //        txtPassword.Text = "";
        //        txtFullName.Text = "";
        //        txtID.Text = "";
        //        txtMACTY.Text = "";
        //    }
        //}

        //public int id = 0;

        //// Thêm constructor nhận userId
        //public frmAddUser(int userId = 0)
        //{
        //    InitializeComponent();
        //    this.id = userId;



        //    // Load thông tin nếu là chỉnh sửa
        //    if (id != 0)
        //    {
        //        LoadUserInfo();

        //    }
        //}
        //private void LoadUserInfo()
        //{
        //    UserBL userBL = new UserBL();
        //    DataTable dt = userBL.GetUserById(id);

        //    if (dt.Rows.Count > 0)
        //    {
        //        DataRow row = dt.Rows[0];
        //        txtUserName.Text = row["USERNAME"].ToString();
        //        txtFullName.Text = row["FULLNAME"].ToString();
        //        txtPass.Text = row["PASSWD"].ToString();

        //        // Set giá trị quyền
        //        switch (row["ISGROUP"].ToString())
        //        {
        //            case "1": cbbRole.SelectedItem = "Admin"; break;
        //            case "2": cbbRole.SelectedItem = "User"; break;
        //            case "3": cbbRole.SelectedItem = "Staff"; break;
        //        }
        //        txtEmail.Text = row["Email"].ToString();

        //        // Thiết lập combobox công ty và đơn vị
        //        cbbMaCty.SelectedValue = row["MACTY"].ToString(); // Bind giá trị MACTY
        //        LoadDonViByCongTy(); // Load đơn vị tương ứng
        //        cbbMaDvi.SelectedValue = row["MADVI"].ToString(); // Bind giá trị MADVI
        //    }
        //}


        //public static bool Validation(Form F)
        //{
        //    bool isValid = false;
        //    int count = 0;
        //    foreach (Control c in F.Controls)
        //    {
        //        //sử dụng tag c để kiểm tra trống
        //        if (Convert.ToString(c.Tag) != "" && Convert.ToString(c.Tag) != null)
        //        {
        //            if (c is Guna.UI2.WinForms.Guna2TextBox)
        //            {
        //                Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
        //                if (t.Text.Trim() == "")
        //                {
        //                    t.BorderColor = Color.Red;
        //                    t.FocusedState.BorderColor = Color.Red;
        //                    t.HoverState.BorderColor = Color.Red;
        //                    count++;
        //                }
        //                else
        //                {
        //                    t.BorderColor = Color.FromArgb(213, 218, 223);
        //                    t.FocusedState.BorderColor = Color.FromArgb(95, 61, 204);
        //                    t.HoverState.BorderColor = Color.FromArgb(95, 61, 204);
        //                }
        //            }

        //        }
        //        if (count == 0)
        //        {
        //            isValid = true;
        //        }
        //        else
        //        {
        //            isValid = false;
        //        }
        //    }

        //    return isValid;
        //}

        //private void LoadCongTyAndDonVi()
        //{
        //    // Load công ty
        //    UserBL userBL = new UserBL();
        //    DataTable dtCty = userBL.GetCongTyList();
        //    cbbMaCty.DisplayMember = "TENCTY";
        //    cbbMaCty.ValueMember = "MACTY";
        //    cbbMaCty.DataSource = dtCty;

        //    // Sửa sự kiện SelectedIndexChanged
        //    cbbMaCty.SelectedIndexChanged += (s, e) =>
        //    {
        //        // Reset combobox đơn vị
        //        cbbMaDvi.DataSource = null;    // Xóa nguồn dữ liệu cũ
        //        cbbMaDvi.Items.Clear();        // Xóa các item hiện có
        //        cbbMaDvi.Text = "";            // Xóa text hiển thị

        //        // Load lại đơn vị theo công ty mới
        //        LoadDonViByCongTy();
        //    };

        //    // Load đơn vị ban đầu (nếu có dữ liệu)
        //    if (cbbMaCty.Items.Count > 0)
        //    {
        //        LoadDonViByCongTy();
        //    }
        //}
        //public void LoadDonViByCongTy()
        //{
        //    if (cbbMaCty.SelectedValue != null)
        //    {
        //        string maCongTy = cbbMaCty.SelectedValue.ToString();
        //        UserBL userBL = new UserBL();
        //        DataTable dtDvi = userBL.GetDonViListByMaCongTy(maCongTy);

        //        // Thêm dòng mặc định nếu không có đơn vị
        //        if (dtDvi.Rows.Count == 0)
        //        {
        //            dtDvi = new DataTable();
        //            dtDvi.Columns.Add("MADVI");
        //            dtDvi.Columns.Add("TENDVI");
        //            dtDvi.Rows.Add("", "-- Không có đơn vị --");
        //        }

        //        // Bind dữ liệu mới
        //        cbbMaDvi.DisplayMember = "TENDVI";
        //        cbbMaDvi.ValueMember = "MADVI";
        //        cbbMaDvi.DataSource = dtDvi;
        //    }
        //}
        //public override void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Validation(this) == false)
        //        {
        //            guna2MessageDialog1.Show("Không được để trống");
        //            return;
        //        }

        //        UserBL bl = new UserBL();
        //        int role = 0;



        //        switch (cbbRole.SelectedItem?.ToString())
        //        {
        //            case "Admin": role = 1; break;
        //            case "User": role = 2; break;
        //            case "Staff": role = 3; break;
        //            default: role = 2; break;
        //        }


        //        // Lấy mã công ty và mã đơn vị
        //        string maCongTy = cbbMaCty.SelectedValue.ToString();
        //        string maDonVi = cbbMaDvi.SelectedValue.ToString();

        //        // Gọi phương thức SaveUser (sẽ tự động kiểm tra trùng username)
        //        int result = bl.SaveUser(id, txtUserName.Text, txtFullName.Text, txtPass.Text, maCongTy, maDonVi, role, txtEmail.Text);

        //        if (result > 0)
        //        {
        //            guna2MessageDialog1.Show("Lưu thành công");
        //            this.Close();
        //        }
        //        else
        //        {
        //            guna2MessageDialog1.Show("Thao tác thất bại");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Hiển thị thông báo lỗi từ Business Layer
        //        guna2MessageDialog1.Icon = MessageDialogIcon.Error;
        //        guna2MessageDialog1.Show(ex.Message);
        //    }
        //}

        public override void btClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
