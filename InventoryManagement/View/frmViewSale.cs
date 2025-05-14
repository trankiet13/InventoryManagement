using BusinessLayer;
using Guna.UI2.WinForms;
using InventoryManagement.Model;
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
using static BusinessLayer.SaleBL;

namespace InventoryManagement.View
{
    public partial class frmViewSale : SampleView
    {
        private SaleBL saleBL = new SaleBL(); // Khởi tạo BLL

        public frmViewSale()
        {
            InitializeComponent();
            dgvViewSale.DataBindingComplete += DgvViewSale_DataBindingComplete;
            dgvViewSale.Sorted += DgvViewSale_Sorted;
        }
        private void frmViewSale_Load(object sender, EventArgs e)
        {

            LoadData();
        }
        public override void btAddNew_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackGround(new frmAddSale());
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Gọi BLL để lấy dữ liệu
                DataTable dt = saleBL.GetSalesData(txtSearch.Text.Trim());

                // Định dạng DataGridView
                dgvViewSale.AutoGenerateColumns = false;
                dgvViewSale.DataSource = dt;

                // Thiết lập các cột (nếu cần customize)
                dgvId.DataPropertyName = "dMainID";
                dgvDate.DataPropertyName = "mdate";
                dgvCustomer.DataPropertyName = "cusName";
                dgvsupid.DataPropertyName = "mSupCusId";
                dgvAmount.DataPropertyName = "TotalAmount";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateRowNumbers()
        {
            foreach (DataGridViewRow row in dgvViewSale.Rows)
            {
                row.Cells["dgvSr"].Value = row.Index + 1;
            }
        }

        private void DgvViewSale_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            UpdateRowNumbers();
        }

        private void DgvViewSale_Sorted(object sender, EventArgs e)
        {
            UpdateRowNumbers();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý Update
            if (dgvViewSale.CurrentCell.OwningColumn.Name == "dgvUpdate")
            {
                frmAddSale frmAddSale = new frmAddSale();
                frmAddSale.id = Convert.ToInt32(dgvViewSale.CurrentRow.Cells["dgvId"].Value); // Truyền MainID (dMainID)
                frmAddSale.cusID = Convert.ToInt32(dgvViewSale.CurrentRow.Cells["dgvsupid"].Value); // Truyền CusID (mSupCusId)

                MainClass.BlurBackGround(frmAddSale);
                LoadData();
            }

            // Xử lý Delete
            if (dgvViewSale.CurrentCell.OwningColumn.Name == "dgvDelete")
            {
                var dialog = new Guna2MessageDialog
                {
                    Buttons = MessageDialogButtons.YesNo,
                    Icon = MessageDialogIcon.Warning,
                    Text = "Bạn có chắc chắn muốn xóa bản ghi này?",
                    Caption = "Xác nhận xóa"
                };

                if (dialog.Show() == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvViewSale.CurrentRow.Cells["dgvId"].Value);

                    if (saleBL.DeleteSale(id))
                    {
                        new Guna2MessageDialog
                        {
                            Buttons = MessageDialogButtons.OK,
                            Icon = MessageDialogIcon.Information,
                            Text = "Xóa bản ghi thành công!"
                        }.Show();
                        LoadData();
                    }
                    else
                    {
                        new Guna2MessageDialog
                        {
                            Buttons = MessageDialogButtons.OK,
                            Icon = MessageDialogIcon.Error,
                            Text = "Xóa bản ghi thất bại!"
                        }.Show();
                    }
                }
            }
        }


        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(); // Tải lại dữ liệu khi có thay đổi tìm kiếm
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }
    
