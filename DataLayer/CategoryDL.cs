using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class CategoryDL : DataProvider
    {
        // Lấy danh sách danh mục theo từ khóa tìm kiếm
        public DataTable GetCategories(string searchText)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM dbo.tb_DVT WHERE TEN LIKE @searchText ORDER BY ID DESC";

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

        // Xóa danh mục theo ID
        public int DeleteCategory(int id)
        {
            string query = "DELETE FROM dbo.tb_DVT WHERE ID = @id";
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            return MyExecuteNonQuery(query, ht);
        }
        // Thêm danh mục
        public int InsertCategory(string name)
        {
            string query = "INSERT INTO dbo.tb_DVT (TEN) VALUES (@TEN)";
            Hashtable ht = new Hashtable();
            ht.Add("@TEN", name);
            return MyExecuteNonQuery(query, ht);
        }

        // Sửa danh mục
        public int UpdateCategory(int id, string name)
        {
            string query = "UPDATE dbo.tb_DVT SET TEN = @TEN WHERE ID = @ID";
            Hashtable ht = new Hashtable();
            ht.Add("@ID", id);
            ht.Add("@TEN", name);
            return MyExecuteNonQuery(query, ht);
        }
    }
}