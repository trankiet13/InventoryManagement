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
using System.Xml.Linq;

namespace InventoryManagement
{
    public partial class SampleAdd : Form
    {
        public SampleAdd()
        {
            InitializeComponent();
            //txtName.Visible = false;
            //txtUsername.Visible = false;
            //txtPassword.Visible = false;
            //txtPhone.Visible = false;
        }

        public void SampleAdd_Load(object sender, EventArgs e)
        {

        }

        private void SampleAdd_Load_1(object sender, EventArgs e)
        {

        }

        public virtual void btSave_Click(object sender, EventArgs e)
        {

        }

        public virtual void btClosee_Click(object sender, EventArgs e)
        {

        }




        //private void bnBrowser_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "Image Files|*jpg;*jpeg;*png;*bmp";
        //    openFileDialog.Title = "Select an Image File";
        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        filePath = openFileDialog.FileName;
        //        pictureBox.ImageLocation = filePath;
        //        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        //    }

        //}
        //public static bool Validation( Form f)
        //{
        //    bool isValid = true;
        //    int count = 0;
        //    foreach (Control c in f.Controls) 
        //    {
        //        if(Convert.ToString(c.Tag)  !="" && Convert.ToString(c.Tag) !=null)
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
        //                 }
        //                else
        //                {
        //                    t.BorderColor = Color.FromArgb(95, 69, 204);
        //                    t.FocusedState.BorderColor = Color.Red;
        //                    t.HoverState.BorderColor = Color.Red;
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

        //private void bnSave_Click(object sender, EventArgs e)
        //{
        //    if ( Validation(this) == false)
        //    {
        //        Guna2MessageDialog messageDialog = new Guna2MessageDialog();
        //        messageDialog.Buttons = MessageDialogButtons.OK;
        //        messageDialog.Text = "Please fill all the required fields.";
        //        messageDialog.Icon = MessageDialogIcon.Warning;
        //        return;
        //    }
        //    else
        //    {
        //        MessageDialog.Show("OK");
        //    }
        //}
    }
}
