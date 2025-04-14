using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

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
    }
}