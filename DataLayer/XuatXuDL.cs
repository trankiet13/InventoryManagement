using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class XuatXuDL : DataProvider
    {
        public DataTable GetXuatXu(string searchText)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM dbo.tb_XUATXU WHERE TEN LIKE @searchText ORDER BY ID DESC";

            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn dữ liệu: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return dt;
        }

        // Xóa theo ID
        public int DeleteXuatXu(int id)
        {
            string query = "DELETE FROM dbo.tb_XUATXU WHERE ID = @id";
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            return MyExecuteNonQuery(query, ht);
        }
        // Thêm 
        public int InsertXuatXu(string name)
        {
            string query = "INSERT INTO dbo.tb_XUATXU (TEN) VALUES (@TEN)";
            Hashtable ht = new Hashtable();
            ht.Add("@TEN", name);
            return MyExecuteNonQuery(query, ht);
        }

        // Sửa 
        public int UpdateXuatXu(int id, string name)
        {
            string query = "UPDATE dbo.tb_XUATXU SET TEN = @TEN WHERE ID = @ID";
            Hashtable ht = new Hashtable();
            ht.Add("@ID", id);
            ht.Add("@TEN", name);
            return MyExecuteNonQuery(query, ht);
        }

        public DataRow GetXuatXuById(int id)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM dbo.tb_XUATXU WHERE ID = @ID";

            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn theo ID: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }
}
