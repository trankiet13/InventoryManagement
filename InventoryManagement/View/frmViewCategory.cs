using BusinessLayer;
using InventoryManagement.Model;
using System;
using System.Collections;
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
        private void frmViewCategory_Load(object sender, EventArgs e)
        {
            
            LoadData();

        }
        //private void LoadData()
        //{
        //    ListBox lb = new ListBox();
        //    lb.Items.Add(dgvId);
        //    lb.Items.Add(dgvName);
        //    string qry = "select * from dbo.tb_DVT where TEN like '%" + txtSearch.Text + "%' order by ID desc ";
        //    MainClass.LoadData(qry, dgvViewCategory, lb);
        //}
        private void LoadData()
        {
            string qry = "SELECT * FROM dbo.tb_DVT WHERE TEN LIKE '%" + txtSearch.Text + "%' ORDER BY ID DESC";

            try
            {
                SqlCommand cmd = new SqlCommand(qry, MainClass.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gán dữ liệu theo tên cột - an toàn tuyệt đối
                dgvViewCategory.Columns["dgvId"].DataPropertyName = "ID";
                dgvViewCategory.Columns["dgvName"].DataPropertyName = "TEN";

                // ❌ KHÔNG gán gì cho dgvDelete (nó là cột icon, không cần dữ liệu)

                dgvViewCategory.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvViewCategory.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmAddCategory frmAddCategory = new frmAddCategory(this);
                frmAddCategory.id = Convert.ToInt32(dgvViewCategory.CurrentRow.Cells["dgvId"].Value);
                frmAddCategory.txtName.Text = Convert.ToString(dgvViewCategory.CurrentRow.Cells["dgvName"].Value);
                MainClass.BlurBackGround(frmAddCategory);
                LoadData();

            }
            if (dgvViewCategory.CurrentCell.OwningColumn.Name == "dgvDelete")
            {
                Guna.UI2.WinForms.Guna2MessageDialog messageDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
                int id = Convert.ToInt32(dgvViewCategory.CurrentRow.Cells["dgvId"].Value);
                string qry = "Delete from dbo.tb_DVT where ID = " + id + "";
                
                Hashtable ht = new Hashtable();
                if (MainClass.SQL(qry, ht) > 0)
                {
                    messageDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    messageDialog.Text = "Xóa danh mục thành công!";
                    messageDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    messageDialog.Show();
                    LoadData();
                }

            }
        }
        public override void btAddNew_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackGround(new frmAddCategory(this));
            LoadData();
        }
    }
}
