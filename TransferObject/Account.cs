using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string IDCompany { get; set; }
        public string FullName { get; set; }
        public Account(string user, string passs)
        {
            this.Username = user;
            this.Password = passs;
        }

        public Account(string username, string password, string iDCompany, string fullName) : this(username, password)
        {
            IDCompany = iDCompany;
            FullName = fullName;
        }
    }
}
