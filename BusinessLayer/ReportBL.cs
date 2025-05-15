using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ReportBL
    {
        public class ReportBLL
        {
            private ReportDL reportDAL = new ReportDL();

            public DataTable GetStockReportData()
            {
                return reportDAL.GetStockReport();
            }

            public DataTable GetSalesReportData()
            {
                return reportDAL.GetSalesReport();
            }
        }
    }
}
