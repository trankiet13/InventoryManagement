using DataLayer;
using System;
using System.Collections;
using System.Data;

namespace BusinessLayer
{
    public class UserBL
    {
        private UserDL userDL = new UserDL();

        // Hàm lọc người dùng (chứa nghiệp vụ tìm kiếm dữ liệu)
        public DataTable GetUsersByName(string keyword)
        {
            string query = @"
        SELECT IDUSER, USERNAME, PASSWD, FULLNAME, MACTY, MADVI, LAST_PWD_CHANGED, DISABLED, ISGROUP 
        FROM tb_SYS_USER 
        WHERE USERNAME LIKE @keyword 
        ORDER BY IDUSER";

            Hashtable parameters = new Hashtable();
            parameters.Add("@keyword", $"%{keyword}%");

            return userDL.GetDataTable(query, parameters);
        }
        public DataTable GetUserById(int userId)
        {
            string query = "SELECT * FROM tb_SYS_USER WHERE IDUSER = @userId";
            Hashtable parameters = new Hashtable();
            parameters.Add("@userId", userId);
            return userDL.GetDataTable(query, parameters);
        }
        public int DeleteUser(int id)
        {
            string sql = "DELETE FROM tb_SYS_USER WHERE IDUSER = @id";
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            return userDL.MyExecuteNonQuery(sql, ht);
        }

        public int SaveUser(int id, string username, string fullname, string pass, string macty, string madvi, int role)
        {
            if (IsUsernameExists(username, id == 0 ? (int?)null : id))
            {
                throw new Exception("Username đã tồn tại trong hệ thống!");
            }
            return userDL.InsertOrUpdateUser(id, username, fullname, pass, macty, madvi, role);
        }
        public bool IsUsernameExists(string username, int? currentUserId = null)
        {
            string query = "SELECT COUNT(*) FROM tb_SYS_USER WHERE USERNAME = @username";

            if (currentUserId != null)
            {
                query += " AND IDUSER != @currentUserId"; // Loại trừ user hiện tại khi cập nhật
            }

            Hashtable parameters = new Hashtable();
            parameters.Add("@username", username);

            if (currentUserId != null)
            {
                parameters.Add("@currentUserId", currentUserId.Value);
            }

            int count = Convert.ToInt32(userDL.MyExecuteScalar(query, CommandType.Text, parameters));
            return count > 0;
        }



    }

}
