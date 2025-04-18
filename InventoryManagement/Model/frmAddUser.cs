﻿using Guna.UI2.WinForms;
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
    public partial class frmAddUser : SampleAdd
    {
        private frmViewUser parentForm;
        private Guna2MessageDialog messageDialog = new Guna2MessageDialog();
        public frmAddUser(frmViewUser parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            
        }
        public override void btSave_Click(object sender, EventArgs e)
        {

            if (MainClass.Validation(this) == false)
            {
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                messageDialog.Show("Please fill all the required fields");
                return;
            }

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string fullname = txtFullName.Text;
            string madvi = txtID.Text; // textbox mã đơn vị
            string macty = txtMACTY.Text; // textbox mã công ty

            UserBL userBL = new UserBL();
            int result = userBL.SaveUser(MainClass.id, username, password, fullname, madvi, macty);

            if (result > 0)
            {
                messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                messageDialog.Show("User saved successfully");
                parentForm.LoadDataGridView();
                MainClass.id = 0;
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtFullName.Text = "";
                txtID.Text = "";
                txtMACTY.Text = "";
            }
        }
        

        public override void btClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
