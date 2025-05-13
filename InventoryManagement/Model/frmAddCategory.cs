using Guna.UI2.WinForms;
using InventoryManagement.View;
using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLayer;

namespace InventoryManagement.Model
{
    public partial class frmAddCategory : SampleAdd
    {
        private frmViewCategory parentForm;
        public int id = 0;
        private readonly CategoryBL categoryBL = new CategoryBL(); // Sử dụng BusinessLayer

        public frmAddCategory(frmViewCategory parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void frmAddCategory_Load(object sender, EventArgs e)
        {
        }

        public override void btSave_Click(object sender, EventArgs e)
        {
            if (Validation(this) == false)
            {
                ShowMessage("Please fill all the required fields.", MessageDialogIcon.Warning);
                return;
            }

            try
            {
                int result = categoryBL.SaveCategory(id, txtName.Text);
                if (result > 0)
                {
                    ShowMessage("Cập nhật danh mục thành công!", MessageDialogIcon.Information);
                    id = 0;
                    txtName.Text = "";
                    txtName.Focus();

                    // Load lại danh sách sau khi lưu
                    parentForm.LoadData();
                }
                else
                {
                    ShowMessage("Không thể cập nhật danh mục!", MessageDialogIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Lỗi: " + ex.Message, MessageDialogIcon.Error);
            }
        }

        // Hàm hiển thị thông báo
        private void ShowMessage(string text, MessageDialogIcon icon)
        {
            Guna2MessageDialog messageDialog = new Guna2MessageDialog
            {
                Buttons = MessageDialogButtons.OK,
                Text = text,
                Icon = icon
            };
            messageDialog.Show();
        }

        public override void btClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Phương thức kiểm tra dữ liệu
        public static bool Validation(Form f)
        {
            bool isValid = true;
            int count = 0;
            foreach (Control c in f.Controls)
            {
                if (Convert.ToString(c.Tag) != "" && Convert.ToString(c.Tag) != null)
                {
                    if (c is Guna2TextBox)
                    {
                        Guna2TextBox t = (Guna2TextBox)c;
                        if (t.Text.Trim() == "")
                        {
                            t.BorderColor = Color.Red;
                            count++;
                        }
                        else
                        {
                            t.BorderColor = Color.FromArgb(95, 69, 204);
                        }
                    }
                }
            }
            return count == 0;
        }
    }
}