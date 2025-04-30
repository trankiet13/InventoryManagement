using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement.Model
{
    public partial class frmAddCustomer : SampleAdd
    {
        Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
        public frmAddCustomer()
        {
            InitializeComponent();
        }
        public int id = 0;
        public override void btClosee_Click(object sender, EventArgs e)
        {
            if (MainClass.Validation(this) == false)
            {
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Show("Please fill all the fields");
                return;
            }
            else
            {
                string qry = "";
                if (id == 0)
                {
                    qry = @"insert into Customer values(@name,@phone,@Email)";
                }
                else
                {
                    qry = @"update Customer set cusName = @name, cusPhone = @phone, cusEmail = @Email where cusID = @id";
                }
                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@name", txtName.Text);
                ht.Add("@phone", txtPhone.Text);
                ht.Add("@Email", txtEmail.Text);
                
                if(MainClass.SQL(qry, ht) > 0)
                {
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Show("Record saved successfully");
                    id = 0;
                    txtName.Text = "";
                    txtPhone.Text = "";
                     txtEmail.Text = "";
                    txtName.Focus();

                }
               
            }
        }
    }
}
