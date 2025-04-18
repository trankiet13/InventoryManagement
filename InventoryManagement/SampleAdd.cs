using System;

namespace InventoryManagement
{
    public partial class SampleAdd : Sample
    {
        public SampleAdd()
        {
            InitializeComponent();
        }

        public virtual void btnSave_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SampleAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
