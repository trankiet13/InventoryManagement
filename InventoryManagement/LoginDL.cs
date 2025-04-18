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
        public bool Login(Account account)
        {
            /// string sql = "SELECT COUNT(username) FROM User WHERE Username ='" + account.Username + "'And PASSWD = '" + account.Password + "'";
            string sql = "SELECT COUNT(USERNAME) FROM tb_SYS_USER WHERE USERNAME = '" + account.Username + "' AND PASSWD = '" + account.Password + "'";

            try
            {
                return ((int)(MyExecuteScalar(sql, CommandType.Text)) > 0);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
