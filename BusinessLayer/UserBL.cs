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
        public DataTable GetUsersByName(string keyword)
        {
            return userDL.GetUsersByName(keyword);
        }

        // Lấy chi tiết người dùng theo ID
        public DataTable GetUserById(int userId)
        {
            return userDL.GetUserById(userId);
        }

        // Xoá người dùng
        public int DeleteUser(int id)
        {
            return userDL.DeleteUser(id);
        }
        // Gọi tới DataLayer để lấy danh sách công ty
        public DataTable GetCongTyList()
        {
            return userDL.GetCongTyList();
        }

        // Gọi tới DataLayer để lấy danh sách đơn vị theo mã công ty
        public DataTable GetDonViListByMaCongTy(string maCongTy)
        {
            return userDL.GetDonViListByMaCongTy(maCongTy);
        }

        // Lưu thông tin người dùng
        public int SaveUser(int id, string username, string fullname, string pass, string macty, string madvi, int role, string email)
        {
            if (userDL.IsUsernameExists(username, id == 0 ? (int?)null : id))
            {
                throw new Exception("Username đã tồn tại trong hệ thống!");
            }

            return userDL.InsertOrUpdateUser(id, username, fullname, pass, macty, madvi, role, email);
        }
    }
  }
