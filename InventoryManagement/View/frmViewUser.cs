using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace InventoryManagement.View
{
    public partial class frmViewUser : SampleView
    {
        public frmViewUser()
        {
            InitializeComponent();
        }
        private ProductsBL productsBL = new ProductsBL();

        private void frmViewUser_Load(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView1.DataSource = productsBL.GetAllProducts();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        //private void frmViewUser_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        guna2DataGridView1.DataSource = productsBL.GetAllProducts();
        //    }
        //    catch (SqlException ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}
