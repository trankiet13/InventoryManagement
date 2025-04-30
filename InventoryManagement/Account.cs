using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Account
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IDCompany { get; set; }
        public string FullName { get; set; }
        public int IsGroup { get; set; }
        public string Email { get; set; }

        public Account() { }

        // Constructor có ID và quyền


        // Constructor không có ID (dùng khi thêm mới)
        public Account(string username, string password)
        {
            Username = username;
            Password = password;
        }

    

        public Account(string username, string password, string iDCompany, string fullName) : this(username, password)
        {
            IDCompany = iDCompany;
            FullName = fullName;
        }
    }
}
