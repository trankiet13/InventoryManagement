using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Collections;

namespace DataLayer
{
    public class UserDL : DataProvider
    {
        public List<Account> GetAllUsers()
        {
            List<Account> accounts = new List<Account>();
            string sql = "SELECT  USERNAME, PASSWD,FULLNAME, MADVI FROM dbo.tb_SYS_USER ";

            string USERNAME, PASSWD, FULLNAME, MACTY;
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    USERNAME = reader[0].ToString();
                    PASSWD = reader[1].ToString();
                    FULLNAME = reader[2].ToString();
                    MACTY = reader[3].ToString();
                    Account account = new Account(USERNAME, PASSWD, MACTY, FULLNAME);
                    accounts.Add(account);
                }
                reader.Close();
                return accounts;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
        public int InsertUser(string username, string password, string fullname, string madvi, string macty)
        {
            string query = @"INSERT INTO dbo.tb_SYS_USER (USERNAME, PASSWD, FULLNAME, MADVI, MACTY) 
                         VALUES (@UserName, @PASSWD, @FULLNAME, @MADVI, @MACTY)";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@PASSWD", password);
            cmd.Parameters.AddWithValue("@FULLNAME", fullname);
            cmd.Parameters.AddWithValue("@MADVI", madvi);
            cmd.Parameters.AddWithValue("@MACTY", macty);

            cn.Open();
            int rows = cmd.ExecuteNonQuery();
            cn.Close();

            return rows;
        }

        public int UpdateUser(int id, string username, string password, string fullname, string madvi, string macty)
        {
            string query = @"UPDATE dbo.tb_SYS_USER 
                         SET USERNAME = @UserName, PASSWD = @PASSWD, FULLNAME = @FULLNAME, MADVI = @MADVI, MACTY = @MACTY
                         WHERE ID = @ID";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@UserName", username);
            cmd.Parameters.AddWithValue("@PASSWD", password);
            cmd.Parameters.AddWithValue("@FULLNAME", fullname);
            cmd.Parameters.AddWithValue("@MADVI", madvi);
            cmd.Parameters.AddWithValue("@MACTY", macty);

            cn.Open();
            int rows = cmd.ExecuteNonQuery();
            cn.Close();

            return rows;
        }
        public DataTable GetUsers()
        {
            string query = @"SELECT  USERNAME, FULLNAME, MADVI, MACTY FROM dbo.tb_SYS_USER";
            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            cn.Open();
            da.Fill(dt);
            cn.Close();

            return dt;
        }
        public DataTable GetUsersByName(string keyword)
        {
            string query = @"
                SELECT IDUSER, USERNAME, PASSWD, FULLNAME, MACTY, MADVI, LAST_PWD_CHANGED, DISABLED, ISGROUP, Email
                FROM tb_SYS_USER
                WHERE USERNAME LIKE @keyword
                ORDER BY IDUSER";

            Hashtable parameters = new Hashtable();
            parameters.Add("@keyword", $"%{keyword}%");

            return GetDataTable(query, parameters);
        }
        // Trả về người dùng theo ID
        public DataTable GetUserById(int userId)
        {
            string query = "SELECT * FROM tb_SYS_USER WHERE IDUSER = @userId";
            Hashtable parameters = new Hashtable();
            parameters.Add("@userId", userId);
            return GetDataTable(query, parameters);
        }

        // Xoá người dùng theo ID
        public int DeleteUser(int id)
        {
            string sql = "DELETE FROM tb_SYS_USER WHERE IDUSER = @id";
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            return MyExecuteNonQuery(sql, ht);
        }

        // Lấy danh sách công ty
        public DataTable GetCongTyList()
        {
            string sql = "SELECT MACTY, TENCTY FROM tb_CONGTY";
            return GetDataTable(sql);  // Gọi phương thức GetDataTable trong UserDL để lấy kết quả dưới dạng DataTable
        }

        // Lấy danh sách đơn vị theo mã công ty
        public DataTable GetDonViListByMaCongTy(string maCongTy)
        {
            string sql = "SELECT MADVI, TENDVI FROM tb_DONVI WHERE MACTY = @maCongTy";
            Hashtable ht = new Hashtable();
            ht.Add("@maCongTy", maCongTy);
            return GetDataTable(sql, ht);  // Gọi phương thức GetDataTable và truyền tham số Hashtable
        }




        // Thêm hoặc cập nhật người dùng
        public int InsertOrUpdateUser(int id, string username, string fullname, string pass, string macty, string madvi, int role, string email)
        {
            string sql = id == 0 ?
                "INSERT INTO tb_SYS_USER (USERNAME, FULLNAME, PASSWD, MACTY, MADVI, ISGROUP, Email) VALUES (@username, @fullname, @pass, @macty, @madvi, @role, @email)" :
                "UPDATE tb_SYS_USER SET USERNAME = @username, FULLNAME = @fullname, PASSWD = @pass, MACTY = @macty, MADVI = @madvi, ISGROUP = @role, Email = @email WHERE IDUSER = @id";

            Hashtable ht = new Hashtable();
            ht.Add("@username", username);
            ht.Add("@fullname", fullname);
            ht.Add("@pass", pass);
            ht.Add("@macty", macty);
            ht.Add("@madvi", madvi);
            ht.Add("@role", role);
            ht.Add("@email", email);
            if (id != 0) ht.Add("@id", id);

            return MyExecuteNonQuery(sql, ht);
        }


        // Kiểm tra username đã tồn tại chưa (trừ user hiện tại)
        public bool IsUsernameExists(string username, int? currentUserId = null)
        {
            string query = "SELECT COUNT(*) FROM tb_SYS_USER WHERE USERNAME = @username";
            Hashtable parameters = new Hashtable();
            parameters.Add("@username", username);

            if (currentUserId != null)
            {
                query += " AND IDUSER != @currentUserId";
                parameters.Add("@currentUserId", currentUserId.Value);
            }

            int count = Convert.ToInt32(MyExecuteScalar(query, CommandType.Text, parameters));
            return count > 0;
        }

        // Truy xuất dữ liệu chung
        public DataTable GetDataTable(string query, Hashtable parameters = null)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;

                if (parameters != null)
                {
                    foreach (DictionaryEntry item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải dữ liệu", ex);
            }
            finally
            {
                Disconnect();
            }
        }
    }
}