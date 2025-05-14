using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class PurchaseDL : DataProvider
    {
        // Lấy danh sách đơn mua hàng
        public DataTable GetPurchases(string searchText)
        {
            string qry = @"SELECT dMainID, mdate, m.mSupCusId, s.TENNCC, SUM(d.amount) AS TotalAmount
                          FROM tblMian m 
                          INNER JOIN tblDetails d ON d.dMainID = m.MainID 
                          INNER JOIN dbo.tb_NHACUNGCAP s ON s.MANCC = m.mSupCusID 
                          WHERE m.mType = 'PUR' AND TENNCC LIKE @SearchText
                          GROUP BY dMainID, mdate, m.mSupCusID, s.TENNCC";

            Hashtable ht = new Hashtable();
            ht.Add("@SearchText", "%" + searchText + "%");

            return ExecuteQuery(qry, ht);
        }

        // Xóa đơn mua hàng
        public int DeletePurchase(int mainID)
        {
            string qryMain = "DELETE FROM tblMian WHERE MainID = @MainID";
            string qryDetails = "DELETE FROM tblDetails WHERE dMainID = @MainID";

            Hashtable ht = new Hashtable();
            ht.Add("@MainID", mainID);

            // Thực thi trong transaction để đảm bảo toàn vẹn dữ liệu
            int result = 0;
            try
            {
                Connect();
                using (SqlTransaction transaction = cn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand(qryDetails, cn, transaction);
                    cmd.Parameters.AddWithValue("@MainID", mainID);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = qryMain;
                    result = cmd.ExecuteNonQuery();

                    transaction.Commit();
                    return result;
                }
            }
            finally
            {
                Disconnect();
            }
        }

        // Hỗ trợ thực thi truy vấn và trả về DataTable
        private DataTable ExecuteQuery(string query, Hashtable parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;

                if (parameters != null)
                {
                    foreach (DictionaryEntry param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key.ToString(), param.Value);
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch
            {
                throw;
            }
            return dt;
        }
        // Lấy danh sách nhà cung cấp
        public DataTable GetSuppliers()
        {
            string qry = "SELECT MANCC AS 'id', TENNCC AS 'name' FROM dbo.tb_NHACUNGCAP";
            return ExecuteQuery(qry, null);
        }

        // Lấy sản phẩm theo nhà cung cấp

        public DataTable GetProductsBySupplier(int supplierID)
        {
            // Đảm bảo tên cột trả về là "id" và "name"
            string qry = "SELECT BARCODE AS id, TENHH AS name FROM tb_HANGHOA WHERE MANCC = @mancc";
            Hashtable ht = new Hashtable();
            ht.Add("@mancc", supplierID);
            return ExecuteQuery(qry, ht);
        }

        // Lấy thông tin sản phẩm theo barcode
        public DataTable GetProductDetails(int productID)
        {
            string qry = "SELECT * FROM dbo.tb_HANGHOA WHERE BARCODE = @barcode";
            Hashtable ht = new Hashtable();
            ht.Add("@barcode", productID);
            return ExecuteQuery(qry, ht);
        }

        // Thêm/Xóa đơn mua hàng (Main và Details)
        public int SavePurchase(int mainID, DateTime date, int supplierID, DataTable dtDetails)
        {
            try
            {
                Connect();
                using (SqlTransaction transaction = cn.BeginTransaction())
                {
                    // Xử lý tblMain
                    string qryMain = (mainID == 0) ?
                        "INSERT INTO tblMian (mdate, mType, mSupCusID) VALUES (@date, 'PUR', @supID); SELECT SCOPE_IDENTITY();" :
                        "UPDATE tblMian SET mdate = @date, mSupCusID = @supID WHERE MainID = @id";

                    SqlCommand cmdMain = new SqlCommand(qryMain, cn, transaction);
                    cmdMain.Parameters.AddWithValue("@date", date);
                    cmdMain.Parameters.AddWithValue("@supID", supplierID);
                    if (mainID != 0) cmdMain.Parameters.AddWithValue("@id", mainID);

                    // Lấy MainID mới nếu là thêm mới
                    if (mainID == 0)
                        mainID = Convert.ToInt32(cmdMain.ExecuteScalar());
                    else
                        cmdMain.ExecuteNonQuery();

                    // Xử lý tblDetails
                    foreach (DataRow row in dtDetails.Rows)
                    {
                        string qryDetails = (row["detailID"].ToString() == "0") ?
                            "INSERT INTO tblDetails (dMainID, productID, qty, price, amount) VALUES (@mID, @proID, @qty, @price, @amount)" :
                            "UPDATE tblDetails SET productID = @proID, qty = @qty, price = @price, amount = @amount WHERE detailID = @id";

                        SqlCommand cmdDetails = new SqlCommand(qryDetails, cn, transaction);
                        cmdDetails.Parameters.AddWithValue("@mID", mainID);
                        cmdDetails.Parameters.AddWithValue("@proID", row["productID"]);
                        cmdDetails.Parameters.AddWithValue("@qty", row["qty"]);
                        cmdDetails.Parameters.AddWithValue("@price", row["price"]);
                        cmdDetails.Parameters.AddWithValue("@amount", row["amount"]);
                        if (row["detailID"].ToString() != "0")
                            cmdDetails.Parameters.AddWithValue("@id", row["detailID"]);

                        cmdDetails.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return mainID;
                }
            }
            finally
            {
                Disconnect();
            }
        }
    }
}