using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PurchaseDL : DataProvider
    {
        //public int InsertMain(DateTime date, string type, int supID)
        //{
        //    string qry = "INSERT INTO tblMian VALUES (@date, @type, @supID); SELECT SCOPE_IDENTITY();";
        //    using (SqlCommand cmd = new SqlCommand(qry, con))
        //    {
        //        cmd.Parameters.AddWithValue("@date", date);
        //        cmd.Parameters.AddWithValue("@type", type);
        //        cmd.Parameters.AddWithValue("@supID", supID);

        //        if (con.State == ConnectionState.Closed)
        //            con.Open();

        //        return Convert.ToInt32(cmd.ExecuteScalar());
        //    }
        //}

        //public void UpdateMain(int id, DateTime date, string type, int supID)
        //{
        //    string qry = "UPDATE tblMian SET mdate = @date, mType = @type, mSupCusID = @supID WHERE MainID = @id";
        //    using (SqlCommand cmd = new SqlCommand(qry, con))
        //    {
        //        cmd.Parameters.AddWithValue("@id", id);
        //        cmd.Parameters.AddWithValue("@date", date);
        //        cmd.Parameters.AddWithValue("@type", type);
        //        cmd.Parameters.AddWithValue("@supID", supID);

        //        if (con.State == ConnectionState.Closed)
        //            con.Open();

        //        cmd.ExecuteNonQuery();
        //    }
        //}

        //public int InsertOrUpdateDetail(int did, int mID, string proID, int qty, double cost, double amount)
        //{
        //    string qry;
        //    if (did == 0)
        //    {
        //        qry = "INSERT INTO tblDetails VALUES(@mID,@proID,@qty,@price,@amount,@cost)";
        //    }
        //    else
        //    {
        //        qry = "UPDATE tblDetails SET dMainID = @mID, productID = @proID, qty = @qty, price = @price, amount = @amount, cost = @cost WHERE detailID = @id";
        //    }

        //    using (SqlCommand cmd = new SqlCommand(qry, con))
        //    {
        //        cmd.Parameters.AddWithValue("@id", did);
        //        cmd.Parameters.AddWithValue("@mID", mID);
        //        cmd.Parameters.AddWithValue("@proID", proID);
        //        cmd.Parameters.AddWithValue("@qty", qty);
        //        cmd.Parameters.AddWithValue("@price", cost);
        //        cmd.Parameters.AddWithValue("@amount", amount);
        //        cmd.Parameters.AddWithValue("@cost", cost);

        //        if (con.State == ConnectionState.Closed)
        //            con.Open();

        //        return cmd.ExecuteNonQuery();
        //    }
        //}

        //public void DeleteMainAndDetails(int mainID)
        //{
        //    string qry1 = "DELETE FROM tblDetails WHERE dMainID = @id";
        //    string qry2 = "DELETE FROM tblMian WHERE MainID = @id";
        //    using (SqlCommand cmd1 = new SqlCommand(qry1, con))
        //    using (SqlCommand cmd2 = new SqlCommand(qry2, con))
        //    {
        //        cmd1.Parameters.AddWithValue("@id", mainID);
        //        cmd2.Parameters.AddWithValue("@id", mainID);

        //        if (con.State == ConnectionState.Closed)
        //            con.Open();

        //        cmd1.ExecuteNonQuery();
        //        cmd2.ExecuteNonQuery();
        //    }
        //}
        //public DataTable GetAllPurchases()
        //{
        //    string qry = "SELECT dMainID, mdate, m.mSupCusId, s.TENNCC, SUM(d.amount) AS TotalAmount\r\nFROM tblMian m\r\nINNER JOIN tblDetails d ON d.dMainID = m.MainID\r\nINNER JOIN dbo.tb_NHACUNGCAP s ON s.MANCC = m.mSupCusID\r\nWHERE m.mType = 'PUR'\r\nGROUP BY dMainID, mdate, m.mSupCusID, s.TENNCC;";

        //    using (SqlCommand cmd = new SqlCommand(qry, con))
        //    {
        //        if (con.State == ConnectionState.Closed)
        //            con.Open();

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //}

        //public DataTable GetPurchaseDetails(int mainID)
        //{
        //    //    string qry = @"
        //    //SELECT d.detailID, p.proName, d.qty, d.price, d.amount
        //    //FROM tblDetails d
        //    //INNER JOIN product p ON p.proID = d.productID
        //    //WHERE d.dMainID = @mainID";
        //    string qry = "SELECT dMainID, mdate, m.mSupCusId, s.TENNCC, SUM(d.amount) AS TotalAmount\r\nFROM tblMian m\r\nINNER JOIN tblDetails d ON d.dMainID = m.MainID\r\nINNER JOIN dbo.tb_NHACUNGCAP s ON s.MANCC = m.mSupCusID\r\nWHERE m.mType = 'PUR'\r\nGROUP BY dMainID, mdate, m.mSupCusID, s.TENNCC;";

        //    using (SqlCommand cmd = new SqlCommand(qry, con))
        //    {
        //        cmd.Parameters.AddWithValue("@mainID", mainID);

        //        if (con.State == ConnectionState.Closed)
        //            con.Open();

        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //}

    }
}
