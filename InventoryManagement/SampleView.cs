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

namespace InventoryManagement
{
    public partial class SampleView : Sample
    {
        // do frmUserAdd k thể kế thể trực tiếp từ cha của SampleView
        protected Guna2MessageDialog guna2MessageDialog1;

        public SampleView()
        {
            InitializeComponent();
            guna2MessageDialog1 = new Guna2MessageDialog(); // Khởi tạo MessageDialog
        }

        public virtual void btnAdd_Click(object sender, EventArgs e)
        {
        }

        public virtual void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void SampleView_Load(object sender, EventArgs e)
        {
        }
    }
}
