using BusinessLayer;
using Guna.UI2.WinForms;
using InventoryManagement.View;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InventoryManagement.Model
{
    public partial class frmAddNhom : SampleAdd
    {
        private readonly frmViewNhom parentForm;
        private readonly NhomHHBL nhomHHBL = new NhomHHBL();

        public int id = 0;

        public frmAddNhom(frmViewNhom parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void frmAddNhom_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                DataRow row = nhomHHBL.GetNhomHHById(id);
                if (row != null)
                {
                    txtName.Text = row["TENNHOM"].ToString();
                }
            }
        }

        public override void btSave_Click(object sender, EventArgs e)
        {
            if (!Validation(this))
            {
                ShowMessage("Vui lòng nhập đầy đủ thông tin.", MessageDialogIcon.Warning);
                return;
            }

            try
            {
                int result = nhomHHBL.SaveCategory(id, txtName.Text.Trim());
                if (result > 0)
                {
                    ShowMessage("Lưu thành công!", MessageDialogIcon.Information);
                    id = 0;
                    txtName.Text = "";
                    txtName.Focus();

                    parentForm.LoadData(); // refresh lại danh sách
                    this.Close(); // đóng form sau khi lưu
                }
                else
                {
                    ShowMessage("Không thể lưu dữ liệu!", MessageDialogIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Lỗi: " + ex.Message, MessageDialogIcon.Error);
            }
        }

        public override void btClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        public static bool Validation(Form f)
        {
            bool isValid = true;
            int count = 0;
            foreach (Control c in f.Controls)
            {
                if (Convert.ToString(c.Tag) != "" && Convert.ToString(c.Tag) != null)
                {
                    if (c is Guna2TextBox t)
                    {
                        if (string.IsNullOrWhiteSpace(t.Text))
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

        private void frmAddNhom_Load_1(object sender, EventArgs e)
        {

        }
    }
}
