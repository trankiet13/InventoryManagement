using DataLayer;
using System.Collections;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class AccountBL
    {
        private readonly AccountDL _accountDL;

        public AccountBL()
        {
            _accountDL = new AccountDL();
        }

        public bool CheckAccount(string username, string email)
        {
            // Có thể thêm logic nghiệp vụ nếu cần
            return _accountDL.CheckAccount(username, email);
        }

        public bool ResetPassword(string username, string newPassword)
        {
            // Thêm logic kiểm tra business nếu cần
            return _accountDL.UpdatePassword(username, newPassword);
        }
    }
}
   
