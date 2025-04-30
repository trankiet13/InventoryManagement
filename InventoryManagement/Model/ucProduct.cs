using System;
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
    public partial class ucProduct : UserControl
    {
        public event EventHandler onSelect = null;
        public ucProduct()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtPic_Click(object sender, EventArgs e)
        {
            onSelect?.Invoke(this, e);
        }
        public int id { get; set; }
        public string Pcost { get; set; }
        public string PName
        {
            get { return lbProductName.Text; }
            set { lbProductName.Text = value; }
        }
        public string Price
        {
            get { return lbPrice.Text; }
            set { lbPrice.Text = value; }
        }
        public Image Pimage
        {
            get { return txtPic.Image; }
            set { txtPic.Image = value; }
        }
    }
}
