using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;
using System;

namespace DataLayer
{
    public class SaleDL : DataProvider
    {
        public DataTable LoadSalesData(string searchText)
        {
            string qry = @"SELECT dMainID, mdate, m.mSupCusId, c.cusName, SUM(d.amount) AS TotalAmount
                          FROM tblMian m 
                          INNER JOIN tblDetails d ON d.dMainID = m.MainID 
                          INNER JOIN Customer c ON c.cusID = m.mSupCusID 
                          WHERE m.mType = 'SAL' AND c.cusName LIKE '%' + @searchText + '%'
                          GROUP BY dMainID, mdate, m.mSupCusID, c.cusName";

            Hashtable ht = new Hashtable();
            ht.Add("@searchText", searchText);

            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            return dt;
        }

        public bool DeleteSale(int saleID)
        {
            string qryMain = "DELETE FROM tblMian WHERE MainID = @id";
            string qryDetails = "DELETE FROM tblDetails WHERE dMainID = @id";

            Hashtable ht = new Hashtable();
            ht.Add("@id", saleID);

            try
            {
                int rowsAffectedMain = SQL(qryMain, ht);
                int rowsAffectedDetails = SQL(qryDetails, ht);
                return (rowsAffectedMain > 0 || rowsAffectedDetails > 0);
            }
            catch
            {
                return false;
            }
        }
        public DataTable LoadCustomers()
        {
            string qry = "SELECT cusID 'id', cusName 'name' FROM Customer";
            return ExecuteQuery(qry);
        }

        public DataTable LoadProducts()
        {
            string qry = "SELECT BARCODE, TENHH, DONGIA, pImage FROM tb_HANGHOA";
            return ExecuteQuery(qry);
        }

        public int SaveMainSale(DateTime date, string type, int customerID, int saleID = 0)
        {
            string qry = saleID == 0
                ? @"INSERT INTO tblMian (mdate, mType, mSupCusID) 
                   VALUES (@Date, @Type, @CustomerID);
                   SELECT SCOPE_IDENTITY();"
                : @"UPDATE tblMian SET mdate = @Date, 
                   mSupCusID = @CustomerID 
                   WHERE MainID = @SaleID";

            Hashtable ht = new Hashtable();
            ht.Add("@Date", date.Date);
            ht.Add("@Type", type);
            ht.Add("@CustomerID", customerID);
            if (saleID > 0) ht.Add("@SaleID", saleID);

            return Convert.ToInt32(MyExecuteScalar(qry, CommandType.Text, ht));
        }

        public int SaveSaleDetail(int saleID, DataGridViewRow row)
        {
            string qry = row.Cells["dgvId"].Value.ToString() == "0"
                ? @"INSERT INTO tblDetails (dMainID, productID, qty, price, amount, cost) 
                   VALUES (@SaleID, @ProductID, @Qty, @Price, @Amount, @Cost)"
                : @"UPDATE tblDetails SET 
                   productID = @ProductID,
                   qty = @Qty,
                   price = @Price,
                   amount = @Amount,
                   cost = @Cost
                   WHERE detailID = @DetailID";

            Hashtable ht = new Hashtable();
            ht.Add("@SaleID", saleID);
            ht.Add("@ProductID", Convert.ToInt32(row.Cells["dgvproid"].Value));
            ht.Add("@Qty", Convert.ToInt32(row.Cells["dgvQty"].Value));
            ht.Add("@Price", Convert.ToDecimal(row.Cells["dgvPrice"].Value));
            ht.Add("@Amount", Convert.ToDecimal(row.Cells["dgvAmount"].Value));
            ht.Add("@Cost", Convert.ToDecimal(row.Cells["dgvCost"].Value));
            if (row.Cells["dgvId"].Value.ToString() != "0")
                ht.Add("@DetailID", Convert.ToInt32(row.Cells["dgvId"].Value));

            return MyExecuteNonQuery(qry, ht);
        }

        private DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
            }
            return dt;
        }
    }
}
