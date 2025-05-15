using BusinessLayer;
using System;
using System.Windows.Forms;
using TransferObject;

namespace InventoryManagement.Model
{
    public partial class frmAddBranch : SampleAdd
    {
        public BranchTO branch; // Đối tượng Branch được truyền vào
        private CompanyBL companyBL = new CompanyBL();
        public frmAddBranch()
        {
            InitializeComponent();
        }

        public override void btSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBranchName.Text))
            {
                MessageBox.Show("Please enter Branch Name.");
                return;
            }
            // Tạo mã đơn vị tự động nếu chưa có
            // Tạo mã đơn vị tự động nếu chưa có
            if (string.IsNullOrEmpty(branch.MADVI))
            {
                branch.MADVI = companyBL.GetNextBranchID();
            }

            // Kiểm tra mã đơn vị đã tồn tại
            if (companyBL.IsBranchIDExists(branch.MADVI))
            {
                MessageBox.Show("Branch ID already exists. Generating new ID...");
                branch.MADVI = companyBL.GetNextBranchID();
            }

            branch.TENDVI = txtBranchName.Text;
            branch.FAX = txtFax.Text;
            branch.EMAIL = txtEmail.Text;
            branch.DIACHI = txtLocation.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        public override void btClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Phương thức khởi tạo với đối tượng Branch để chỉnh sửa
        public void LoadBranch(BranchTO branch)
        {
            this.branch = branch;
            txtBranchName.Text = branch.TENDVI;
            txtFax.Text = branch.FAX;
            txtEmail.Text = branch.EMAIL;
            txtLocation.Text = branch.DIACHI;
        }

        private void frmAddBranch_Load(object sender, EventArgs e)
        {

        }

        private void txtBranchName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtFax_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
