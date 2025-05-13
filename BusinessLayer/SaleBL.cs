using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class SaleBL
    {
        private SaleDL saleDL = new SaleDL();

        public DataTable GetSalesData(string searchText)
        {
            return saleDL.LoadSalesData(searchText);
        }

        public bool DeleteSale(int saleID)
        {
            return saleDL.DeleteSale(saleID);
        }
    }
}