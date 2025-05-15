using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;

namespace InventoryManagement.Model
{
    public partial class frmAddSupplier : SampleAdd
    {
        private SupplierBL supplierBL;
        private Supplier _supplierToUpdate;

        public frmAddSupplier()
        {
            InitializeComponent();
            supplierBL = new SupplierBL();
        }

        public frmAddSupplier(Supplier supplier) : this() // gọi constructor mặc định
        {
            _supplierToUpdate = supplier;
        }

        private void frmAddSupplier_Load(object sender, EventArgs e)
        {
            if (_supplierToUpdate != null)
            {
                txtName.Text = _supplierToUpdate.TENNCC;
                txtEmail.Text = _supplierToUpdate.EMAIL;
                txtPhone.Text = _supplierToUpdate.DIENTHOAI;
                txtFax.Text = _supplierToUpdate.FAX;
                txtAddress.Text = _supplierToUpdate.DIACHI;
                chkDisabled.Checked = _supplierToUpdate.DISABLED;
            }
        }

        public override void btSave_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier
            {
                TENNCC = txtName.Text,
                EMAIL = txtEmail.Text,
                DIENTHOAI = txtPhone.Text,
                FAX = txtFax.Text,
                DIACHI = txtAddress.Text,
                CREATED_DATE = DateTime.Now,
                DISABLED = chkDisabled.Checked
            };

            int result;

            if (_supplierToUpdate == null)
            {
                result = supplierBL.InsertSupplier(supplier);
            }
            else
            {
                supplier.MANCC = _supplierToUpdate.MANCC; // giữ lại ID để update đúng dòng
                result = supplierBL.UpdateSupplier(supplier);
            }

            if (result > 0)
            {
                MessageBox.Show("Lưu nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu nhà cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void btClosee_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
