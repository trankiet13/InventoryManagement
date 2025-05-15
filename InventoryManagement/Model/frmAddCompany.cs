using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;

namespace InventoryManagement.Model
{
    public partial class frmAddCompany : SampleAdd
    {
        private CompanyBL companyBL = new CompanyBL();
        private List<BranchTO> branches = new List<BranchTO>();

        public frmAddCompany()
        {
            InitializeComponent();
        }

        // Thêm đơn vị vào danh sách

        private void btnAddBranch_Click(object sender, EventArgs e)
        {
            frmAddBranch frm = new frmAddBranch();
            BranchTO newBranch = new BranchTO
            {
                MADVI = "",
                TENDVI = "",
                DIENTHOAI = "",
                FAX = "",
                EMAIL = "",
                DIACHI = ""
            };

            frm.LoadBranch(newBranch);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                branches.Add(newBranch);
                RefreshBranchGrid();
            }
        }

        // Xóa đơn vị đã chọn
        private void btnDeleteBranch_Click(object sender, EventArgs e)
        {
            if (dgvBranch.SelectedRows.Count > 0)
            {
                int index = dgvBranch.SelectedRows[0].Index;
                branches.RemoveAt(index);
                RefreshBranchGrid();
            }
        }
        private string companyID = "";
        public override void btClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Lưu thông tin công ty và các đơn vị
        public override void btSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                MessageBox.Show("Please enter Company Name.");
                return;
            }

            CompanyTO company = new CompanyTO
            {
                MACTY = string.IsNullOrEmpty(companyID) ? "" : companyID, // Để trống sẽ tự động tạo
                TENCTY = txtCompanyName.Text,
                DIACHI = txtLocation.Text,
                DIENTHOAI = txtPhone.Text,
                EMAIL = txtEmail.Text,
                FAX = txtFax.Text,
                DISABLED = false
            };

            CompanyBL companyBL = new CompanyBL();
            foreach (var branch in branches)
            {
                // Nếu mã đơn vị bị trống hoặc trùng thì tạo lại mã mới
                if (string.IsNullOrEmpty(branch.MADVI) || companyBL.IsBranchIDExists(branch.MADVI))
                {
                    branch.MADVI = companyBL.GetNextBranchID();
                }
            }

            try
            {
                bool result = companyBL.SaveCompany(company, branches);

                if (result)
                {
                    MessageBox.Show("Company and branches saved successfully.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to save company.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompanyName.Focus();
            }
        }
        private void dgvBranch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Xử lý Edit (chỉnh sửa đơn vị)
                if (e.ColumnIndex == dgvBranch.Columns["dgvEdit"].Index)
                {
                    string branchID = dgvBranch.Rows[e.RowIndex].Cells["dgvCompanyID"].Value?.ToString();
                    var branch = branches.Find(b => b.MADVI == branchID);
                    if (branch != null)
                    {
                        frmAddBranch frm = new frmAddBranch();
                        frm.LoadBranch(branch);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            RefreshBranchGrid();
                        }
                    }
                }

                // Xử lý Delete (xóa đơn vị)
                else if (e.ColumnIndex == dgvBranch.Columns["dgvDel"].Index)
                {
                    string branchID = dgvBranch.Rows[e.RowIndex].Cells["dgvCompanyID"].Value?.ToString();
                    var branch = branches.Find(b => b.MADVI == branchID);
                    if (branch != null)
                    {
                        var confirmResult = MessageBox.Show("Are you sure you want to delete this branch?",
                                                            "Delete Branch",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Question);
                        if (confirmResult == DialogResult.Yes)
                        {
                            branches.Remove(branch);
                            RefreshBranchGrid();
                        }
                    }
                }
            }
        }

        // Hiển thị danh sách đơn vị
        private void RefreshBranchGrid()
        {
            dgvBranch.Rows.Clear();
            for (int i = 0; i < branches.Count; i++)
            {
                var branch = branches[i];
                dgvBranch.Rows.Add(
                    i + 1,
                    branch.MADVI,
                    branch.TENDVI,
                    branch.DIENTHOAI,
                    branch.FAX,
                    branch.EMAIL,
                    branch.DIACHI,
                    Properties.Resources.edit, // Hình ảnh Edit
                    Properties.Resources.del // Hình ảnh Delete
                );
            }
        }


        private void frmAddCompany_Load(object sender, EventArgs e)
        {

        }



    }
}
