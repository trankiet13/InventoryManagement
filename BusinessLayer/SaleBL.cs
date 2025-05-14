using DataLayer;
using System;
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
        // Trong UserBL.cs
        public DataTable GetAccounts()
        {
            return saleDL.LoadAccountsData(); // Gọi phương thức từ Data Layer
        }

        public int SaveSale(int mainID, DateTime date, int cusID)
        {
            return saleDL.SaveSale(mainID, date, cusID);
        }

        public DataTable GetProducts()
        {
            return saleDL.LoadProducts();
        }

        public int SaveSaleDetail(int detailID, int mainID, int productID, int qty, int price, int cost)
        {
            return saleDL.SaveSaleDetail(detailID, mainID, productID, qty, price, cost);
        }
        public DataTable GetCustomers()
        {
            return saleDL.GetCustomers();
        }

        public DataTable GetSaleByID(int mainID)
        {
            return saleDL.GetSaleByID(mainID);
        }
    }
}