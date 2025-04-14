using BusinessLayer;
using Guna.UI2.WinForms;
using InventoryManagement.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows.Forms;
using System.Xml.Linq;
using TransferObject;

namespace InventoryManagement.Model
{
    public partial class frmAddCategory : SampleAdd
    {
        public int id = 0;
        public frmAddCategory()
        {
            InitializeComponent();
        }

        private void frmAddCategory_Load(object sender, EventArgs e)
        {
            
        }
        public override void btSave_Click(object sender, EventArgs e)
        {
            
        }
        public override void btClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static bool Validation(Form f)
        {
            bool isValid = true;
            int count = 0;
            foreach (Control c in f.Controls)
            {
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
                            t.BorderColor = Color.FromArgb(95, 69, 204);
                            t.FocusedState.BorderColor = Color.Red;
                            t.HoverState.BorderColor = Color.Red;
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
        private void bnSave_Click(object sender, EventArgs e)
        {
            if (Validation(this) == false)
            {
                Guna2MessageDialog messageDialog = new Guna2MessageDialog();
                messageDialog.Buttons = MessageDialogButtons.OK;
                messageDialog.Text = "Please fill all the required fields.";
                messageDialog.Icon = MessageDialogIcon.Warning;
                return;
            }
            else
            {
                

            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
