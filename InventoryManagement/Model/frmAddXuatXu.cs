using BusinessLayer;
using Guna.UI2.WinForms;
using InventoryManagement.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InventoryManagement.Model
{
    public partial class frmAddXuatXu : SampleAdd
    {
        public frmAddXuatXu()
        {
            InitializeComponent();
        }

        private readonly frmViewXuatXu parentForm;
        private readonly XuatXuBL xuatXuBL = new XuatXuBL();

        public int id = 0;

        public frmAddXuatXu(frmViewXuatXu parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void frmAddXuatXu_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                DataRow row = xuatXuBL.GetXuatXuById(id);
                if (row != null)
                {
                    txtName.Text = row["TENNUOC"].ToString();
                }
            }
        }

        public override void btSave_Click(object sender, EventArgs e)
        {
            if (!Validation(this))
            {
                ShowMessage("Vui lòng nhập tên quốc gia.", MessageDialogIcon.Warning);
                return;
            }

            try
            {
                int result = xuatXuBL.SaveXuatXu(id, txtName.Text.Trim());
                if (result > 0)
                {
                    ShowMessage("Lưu thành công!", MessageDialogIcon.Information);
                    id = 0;
                    txtName.Text = "";
                    txtName.Focus();

                    parentForm.LoadData();
                    this.Close();
                }
                else
                {
                    ShowMessage("Không thể lưu!", MessageDialogIcon.Error);
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
            Guna2MessageDialog msg = new Guna2MessageDialog
            {
                Buttons = MessageDialogButtons.OK,
                Text = text,
                Icon = icon
            };
            msg.Show();
        }

        public static bool Validation(Form f)
        {
            int count = 0;
            foreach (Control c in f.Controls)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(c.Tag)))
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

        private void frmAddXuatXu_Load_1(object sender, EventArgs e)
        {

        }
    }
}
