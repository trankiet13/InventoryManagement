using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class UserBL
    {
        private UserDL userDL;
        public UserBL()
        {
            userDL = new UserDL();
        }
        public List<Account> GetAccounts()
        {
            return userDL.GetAllUsers();
        }
        UserDL dal = new UserDL();

        public int SaveUser(int id, string username, string password, string fullname, string madvi, string macty)
        {
            if (id == 0)
            {
                return userDL.InsertUser(username, password, fullname, madvi, macty);
            }
            else
            {
                return userDL.UpdateUser(id, username, password, fullname, madvi, macty);
            }
        }
        public DataTable LoadUsers()
        {
            return userDL.GetUsers();
        }
    }
  }
