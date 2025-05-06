using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLayer.SaleDL;

namespace BusinessLayer
{
    public class SaleBL
    {
        public class SaleBLL
        {
            SaleDAL dal = new SaleDAL();

            public bool DeleteSale(int id)
            {
                // Xoá cả main và details
                int deletedMain = dal.DeleteMainRecord(id);
                int deletedDetails = dal.DeleteDetailsByMainId(id);

                return deletedMain > 0 || deletedDetails > 0;
            }
        }

    }
}
