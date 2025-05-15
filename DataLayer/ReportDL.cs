using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ReportDL : DataProvider
    {
        public DataTable GetStockReport()
        {
            string qry = @"SELECT 
                            P.BARCODE,
                            P.TENHH,
                            ISNULL(SUM(CASE WHEN M.mType = 'NH' THEN D.qty ELSE 0 END), 0)
                            - ISNULL(SUM(CASE WHEN M.mType = 'XH' THEN D.qty ELSE 0 END), 0) AS TonKho
                        FROM dbo.tb_HANGHOA P
                        LEFT JOIN tblDetails D ON CAST(P.BARCODE AS INT) = D.productID
                        LEFT JOIN tblMian M ON D.dMainID = M.MainId
                        GROUP BY P.BARCODE, P.TENHH
                        ORDER BY P.BARCODE";

            using (SqlCommand cmd = new SqlCommand(qry,con))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetSalesReport()
        {
            string qry = @"SELECT M.mdate AS [Date],
                                  H.TENHH AS [Product Name],
                                  ISNULL(C.cusName, 'Cash') AS [Customer Name],
                                  D.qty AS [Qty],
                                  D.price AS [Price],
                                  D.amount AS [Amount]
                          FROM tblMian M
                          INNER JOIN tblDetails D ON M.MainId = D.dMainID
                          INNER JOIN tb_HANGHOA H ON D.productID = H.BARCODE
                          LEFT JOIN Customer C ON M.mSupCusID = C.cusID
                          ORDER BY M.mdate, H.TENHH;";

            using (SqlCommand cmd = new SqlCommand(qry,con))
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }
    }
}
