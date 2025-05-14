using InventoryManagement.Report;
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

namespace InventoryManagement.View
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

        }
        private DataTable dTable(string qry)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);
            return dt;

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string qry = "SELECT \r\n    P.BARCODE,\r\n    P.TENHH,\r\n   \r\n    ISNULL(SUM(CASE WHEN M.mType = 'NH' THEN D.qty ELSE 0 END), 0)\r\n    - ISNULL(SUM(CASE WHEN M.mType = 'XH' THEN D.qty ELSE 0 END), 0) AS TonKho\r\nFROM dbo.tb_HANGHOA P\r\nLEFT JOIN tblDetails D ON CAST(P.BARCODE AS INT) = D.productID\r\nLEFT JOIN tblMian M ON D.dMainID = M.MainId\r\nGROUP BY P.BARCODE, P.TENHH\r\nORDER BY P.BARCODE";
            DataTable dt = dTable(qry);
            frmPrint frm = new frmPrint();
            //rptStock cr = new rptStock();
            rptStock cr = new rptStock();
            cr.SetDataSource(dt);
            frm.crystalReportViewer1.ReportSource = cr;
            frm.crystalReportViewer1.Refresh();
            frm.ShowDialog();
        }
    }
}
