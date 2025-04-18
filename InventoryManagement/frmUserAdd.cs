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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InventoryManagement.Model
{
    public partial class frmUserAdd : SampleAdd
    {
        public frmUserAdd()
        {
            InitializeComponent();
        }
        //check kh duoc de trong txt.
        public static bool Validation(Form F)
        {
            bool isValid = false;
            int count = 0;
            foreach (Control c in F.Controls)
            {
                //using tag of the control to check if we want to validate it or not
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

        public int id = 0;
        public override void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation(this) == false)
            {
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Không được để trống");
                return;
            }
            else
            {
                UserBL bl = new UserBL();

               
                int role = 0;
                if (cbbRole.SelectedItem != null)
                {
                    switch (cbbRole.SelectedItem.ToString())
                    {
                        case "Admin":
                            role = 1;
                            break;
                        case "User":
                            role = 2;
                            break;
                        case "Staff":
                            role = 3;
                            break;
                        default:
                            role = 0;
                            break;
                    }
                }

                int result = bl.SaveUser(id, txtUser.Text, txtName.Text, txtPass.Text, txtMaCongTy.Text, txtDonVi.Text, role);

                if (result > 0)
                {
                    guna2MessageDialog1.Show("Lưu thành công");

                    // Reset txt ve 0 sau khi luu
                    id = 0;
                    txtUser.Clear();
                    txtName.Clear();
                    txtPass.Clear();
                    txtMaCongTy.Clear();
                    txtDonVi.Clear();
                    cbbRole.SelectedIndex = -1;
                }
                else
                {
                    guna2MessageDialog1.Show("Thao tác thất bại");
                }
            }
        }


        private void frmUserAdd_Load(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
