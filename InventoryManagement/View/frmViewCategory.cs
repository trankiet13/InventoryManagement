using BusinessLayer;
using InventoryManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using TransferObject;

namespace InventoryManagement.View
{
    public partial class frmViewCategory : SampleView 
    {
        
        public frmViewCategory()
        {
            InitializeComponent();
        }
        private CategoryBL categoryBL = new CategoryBL();
        private void frmViewCategory_Load(object sender, EventArgs e)
        {
            try
            {
                dgvViewCategory.DataSource = categoryBL.GetAllCategories();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public override void btAddNew_Click(object sender, EventArgs e)
        {
            frmAddCategory frmaddCategory = new frmAddCategory();
            frmaddCategory.ShowDialog();
        }
    }
}
