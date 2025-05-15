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
using static BusinessLayer.ReportBL;

namespace InventoryManagement.View
{
    public partial class frm : Form
    {

        private string selectedReportType;
        private ReportBLL reportBLL = new ReportBLL();
        public frm()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = reportBLL.GetStockReportData();

                rptStock cr = new rptStock();
                frmPrint frm1 = new frmPrint();
                cr.SetDataSource(dt);

                frm1.crystalReportViewer2.ReportSource = cr;
                frm1.crystalReportViewer2.RefreshReport();
                frm1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo tồn kho: " + ex.Message);
            }
        }

        private void btSale_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = reportBLL.GetSalesReportData();

                rptSale cr = new rptSale();
                frmPrint frm = new frmPrint();
                cr.SetDataSource(dt);

                frm.crystalReportViewer2.ReportSource = cr;
                frm.crystalReportViewer2.RefreshReport();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo bán hàng: " + ex.Message);
            }
        }
        //private DataTable dTable(string qry)
        //{
        //    DataTable dt = new DataTable();
        //    SqlCommand sqlCommand = new SqlCommand(qry, MainClass.con);
        //    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
        //    da.Fill(dt);
        //    return dt;

        //}
        //private void guna2Button1_Click(object sender, EventArgs e)
        //{
        //    string qry = "SELECT \r\n    P.BARCODE,\r\n    P.TENHH,\r\n   \r\n    ISNULL(SUM(CASE WHEN M.mType = 'NH' THEN D.qty ELSE 0 END), 0)\r\n    - ISNULL(SUM(CASE WHEN M.mType = 'XH' THEN D.qty ELSE 0 END), 0) AS TonKho\r\nFROM dbo.tb_HANGHOA P\r\nLEFT JOIN tblDetails D ON CAST(P.BARCODE AS INT) = D.productID\r\nLEFT JOIN tblMian M ON D.dMainID = M.MainId\r\nGROUP BY P.BARCODE, P.TENHH\r\nORDER BY P.BARCODE";
        //    DataTable dt = dTable(qry);
        //    frmPrint frm1 = new frmPrint();
        //    //rptStock cr = new rptStock();
        //    rptStock cr = new rptStock();
        //    cr.SetDataSource(dt);
        //    frm1.crystalReportViewer2.ReportSource = cr;
        //    frm1.crystalReportViewer2.Refresh();
        //    frm1.ShowDialog();
        //}

        //private void btSale_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        string qry = "SELECT M.mdate AS [Date], " +
        //                "H.TENHH AS [Product Name], " +
        //                "ISNULL(C.cusName, 'Cash') AS [Customer Name], " +
        //                "D.qty AS [Qty], " +
        //                "D.price AS [Price], " +
        //                "D.amount AS [Amount] " +
        //                "FROM tblMian M " +
        //                "INNER JOIN tblDetails D ON M.MainId = D.dMainID " +
        //                "INNER JOIN tb_HANGHOA H ON D.productID = H.BARCODE " +
        //                "LEFT JOIN Customer C ON M.mSupCusID = C.cusID " +

        //                "ORDER BY M.mdate, H.TENHH;";
        //        DataTable dt = dTable(qry);

        //        // Khởi tạo report và form
        //        rptSale cr = new rptSale();
        //        frmPrint frm = new frmPrint();
        //        // Gán dữ liệu vào report
        //        cr.SetDataSource(dt);

        //        // Cấu hình viewer
        //        frm.crystalReportViewer2.ReportSource = cr;
        //        frm.crystalReportViewer2.RefreshReport();

        //        // Hiển thị form
        //        frm.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
    
}
