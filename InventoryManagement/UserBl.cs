using DataLayer;
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
            string query = $@"
                SELECT IDUSER, USERNAME, PASSWD, FULLNAME, MACTY,MADVI, LAST_PWD_CHANGED,DISABLED,ISGROUP 
                FROM tb_SYS_USER 
                WHERE USERNAME LIKE '%{keyword}%' 
                ORDER BY IDUSER";
            return userDL.GetDataTable(query);
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

            return userDL.InsertOrUpdateUser(id, username, fullname, pass, macty, madvi, role);
        }
        //public int SaveUser(int id, string username, string password, string fullname, string madvi, string macty)
        //{
        //    if (id == 0)
        //    {
        //        return userDL.InsertUser(username, password, fullname, madvi, macty);
        //    }
        //    else
        //    {
        //        return userDL.UpdateUser(id, username, password, fullname, madvi, macty);
        //    }
        //}



    }

}
