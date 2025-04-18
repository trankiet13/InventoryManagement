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
    public class UserDL : DataProvider
    {
        //Trả về datatable hiện thị cho dgv
        public DataTable GetDataTable(string query)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Disconnect();
                return dt;
            }
            catch (Exception ex)
            {
                Disconnect();
                throw new Exception("Lỗi khi tải dữ liệu", ex);
            }
        }
        //  Dùng để thêm user
        private DataProvider dp = new DataProvider();
        public int InsertOrUpdateUser(int id, string username, string fullname, string pass, string macty, string madvi, int role)
        {
            string sql = id == 0 ?
                "INSERT INTO tb_SYS_USER (USERNAME, FULLNAME, PASSWD, MACTY, MADVI, ISGROUP) VALUES (@username, @fullname, @pass, @macty, @madvi, @role)" :
                "UPDATE tb_SYS_USER SET USERNAME = @username, FULLNAME = @fullname, PASSWD = @pass, MACTY = @macty, MADVI = @madvi, ISGROUP = @role WHERE IDUSER = @id";

            Hashtable ht = new Hashtable();
            ht.Add("@username", username);
            ht.Add("@fullname", fullname);
            ht.Add("@pass", pass);
            ht.Add("@macty", macty);
            ht.Add("@madvi", madvi);
            ht.Add("@role", role);

            if (id != 0) ht.Add("@id", id);

            return MyExecuteNonQuery(sql, ht);
        }





    }
}

