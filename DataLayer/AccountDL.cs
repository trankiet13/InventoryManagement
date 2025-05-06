using DataLayer;
using System.Collections;
using System.Data;
using System;

public class AccountDL : DataProvider
{
    public bool CheckAccount(string username, string email)
    {
        string sql = "SELECT COUNT(*) FROM tb_SYS_USER WHERE USERNAME = @username AND Email = @Email";
        Hashtable ht = new Hashtable
        {
            ["@username"] = username,
            ["@Email"] = email
        };
        int count = Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text, ht));
        return count > 0;
    }

    public bool UpdatePassword(string username, string newPassword)
    {
        try
        {
            string sql = "UPDATE tb_SYS_USER SET PASSWD = @Password WHERE USERNAME = @username";
            Hashtable parameters = new Hashtable
            {
                { "@username", username },
                { "@Password", newPassword }
            };

            int rowsAffected = MyExecuteNonQuery(sql, parameters);
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Lỗi khi cập nhật mật khẩu: " + ex.Message);
        }
    }

}