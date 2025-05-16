using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataLayer
{
    public class NhomHHDL : DataProvider
    {
        // Lấy danh sách danh mục theo từ khóa tìm kiếm
        public DataTable GetNhomHH(string searchText)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM dbo.tb_NHOMHH WHERE TENNHOM LIKE @searchText ORDER BY IDNHOM DESC";

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
        public int DeleteNhomHH(int id)
        {
            string query = "DELETE FROM dbo.tb_NHOMHH WHERE IDNHOM = @id";
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            return MyExecuteNonQuery(query, ht);
        }
        // Thêm 
        public int InsertNhomHH(string name)
        {
            string query = "INSERT INTO dbo.tb_NHOMHH (TENNHOM) VALUES (@TENNHOM)";
            Hashtable ht = new Hashtable();
            ht.Add("@TENNHOM", name);
            return MyExecuteNonQuery(query, ht);
        }

        // Sửa
        public int UpdateNhomHH(int id, string name)
        {
            string query = "UPDATE dbo.tb_NHOMHH SET TENNHOM = @TENNHOM WHERE IDNHOM = @IDNHOM";
            Hashtable ht = new Hashtable();
            ht.Add("@IDNHOM", id);
            ht.Add("@TENNHOM", name);
            return MyExecuteNonQuery(query, ht);
        }

        // Lấy một nhóm hàng hóa theo ID
        public DataRow GetNhomHHById(int id)
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM dbo.tb_NHOMHH WHERE IDNHOM = @IDNHOM";

            try
            {
                Connect();
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IDNHOM", id);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn dữ liệu theo ID: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }

            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }

    }
}
