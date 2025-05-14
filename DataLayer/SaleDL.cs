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
        // Trong UserDL.cs
        public DataTable LoadAccountsData()
        {
            string qry = "SELECT * FROM Accounts"; // Thay đổi query theo CSDL thực tế
            DataTable dt = new DataTable();

            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải tài khoản: " + ex.Message);
            }

            return dt;
        }
        // Thêm phương thức để thêm/cập nhật đơn hàng
        public int SaveSale(int mainID, DateTime date, int cusID)
        {
            string qry = (mainID == 0) ?
                @"INSERT INTO tblMian (mdate, mType, mSupCusID) 
          VALUES (@date, 'SAL', @cusID); 
          SELECT SCOPE_IDENTITY();" : // Lấy ID mới tạo
                @"UPDATE tblMian SET mdate = @date, mSupCusID = @cusID 
          WHERE MainID = @mainID";

            Hashtable ht = new Hashtable();
            ht.Add("@date", date);
            ht.Add("@cusID", cusID);
            if (mainID != 0) ht.Add("@mainID", mainID);

            // Thực thi và xử lý kết quả
            if (mainID == 0)
            {
                // INSERT và lấy ID mới
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {
                    cmd.CommandType = CommandType.Text;
                    foreach (DictionaryEntry item in ht)
                    {
                        cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                    }
                    con.Open();
                    object result = cmd.ExecuteScalar(); // Lấy SCOPE_IDENTITY()
                    con.Close();
                    return Convert.ToInt32(result);
                }
            }
            else
            {
                // UPDATE
                int rowsAffected = SQL(qry, ht);
                return (rowsAffected > 0) ? mainID : 0;
            }
        }
        public DataTable GetCustomers()
        {
            string qry = "SELECT cusID, cusName FROM Customer";
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi tải danh sách khách hàng: " + ex.Message);
            }
            return dt;
        }

        // Thêm phương thức để lấy danh sách sản phẩm
        public DataTable LoadProducts()
        {
            string qry = "SELECT BARCODE, TENHH, DONGIA, pImage FROM tb_HANGHOA";
            DataTable dt = new DataTable();
            try
            {
                // Sử dụng SqlDataAdapter như code gốc
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message);
            }
            return dt;
        }
        // Thêm phương thức lưu chi tiết đơn hàng
        public int SaveSaleDetail(int detailID, int mainID, int productID, int qty, int price, int cost)
        {
            string qry = (detailID == 0) ?
                @"INSERT INTO tblDetails (dMainID, productID, qty, price, cost, amount) 
          VALUES (@mainID, @productID, @qty, @price, @cost, @amount)" :
                @"UPDATE tblDetails SET 
            qty = @qty, 
            price = @price, 
            cost = @cost, 
            amount = @amount 
          WHERE detailID = @detailID";

            Hashtable ht = new Hashtable();
            ht.Add("@mainID", mainID);
            ht.Add("@productID", productID);
            ht.Add("@qty", qty);
            ht.Add("@price", price);
            ht.Add("@cost", cost);
            ht.Add("@amount", qty * price);
            if (detailID != 0) ht.Add("@detailID", detailID);

            return SQL(qry, ht);
        }
        // Lấy id để load dữ liệu cũ
        public DataTable GetSaleByID(int mainID)
        {
            string qry = @"SELECT m.mdate, m.mSupCusID, d.productID, d.qty, d.price, d.cost 
                   FROM tblMian m 
                   INNER JOIN tblDetails d ON m.MainID = d.dMainID 
                   WHERE m.MainID = @mainID";
            Hashtable ht = new Hashtable();
            ht.Add("@mainID", mainID);
            return ExecuteQuery(qry, ht);
        }

        private DataTable ExecuteQuery(string qry, Hashtable ht)
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand(qry, con))
            {
                cmd.CommandType = CommandType.Text;
                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
