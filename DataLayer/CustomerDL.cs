using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace DataLayer
{
    public class CustomerDL
    {
        public class CustomerDAL : DataProvider
        {

            public int InsertCustomer(Hashtable ht)
            {
                string qry = "INSERT INTO Customer VALUES(@name, @phone, @Email)";
                return SQL(qry, ht);
            }

            public int UpdateCustomer(Hashtable ht)
            {
                string qry = "UPDATE Customer SET cusName = @name, cusPhone = @phone, cusEmail = @Email WHERE cusID = @id";
                return SQL(qry, ht);
            }

            public int DeleteCustomer(int id)
            {
                string qry = "DELETE FROM Customer WHERE cusID = " + id;
                return SQL(qry, new Hashtable());
            }

            public void LoadCustomers(string searchText, DataGridView dgv, ListBox lb)
            {
                string qry = $"SELECT * FROM Customer WHERE cusName LIKE '%{searchText}%' ORDER BY cusID DESC";
                LoadData(qry, dgv, lb);
            }
        }
    }
}
