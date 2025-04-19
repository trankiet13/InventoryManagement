using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class LoginDL : DataProvider
    {
        public Account GetAccount(string username, string password)
        {
            string sql = @"SELECT IDUSER, USERNAME, PASSWD, ISGROUP
                   FROM tb_SYS_USER
                   WHERE USERNAME = @username AND PASSWD = @password";

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Account acc = new Account
                    {
                        UserID = Convert.ToInt32(reader["IDUSER"]),
                        Username = reader["USERNAME"].ToString(),
                        Password = reader["PASSWD"].ToString(),
                        IsGroup = Convert.ToInt32(reader["ISGROUP"])
                    };
                    reader.Close();
                    Disconnect();
                    return acc;
                }

                reader.Close();
                Disconnect();
                return null;
            }
            catch (SqlException ex)
            {
                Disconnect();
                throw ex;
            }
        }


    }
}
