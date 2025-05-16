using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class NhomHHBL
    {
        private readonly NhomHHDL nhomHHDL = new NhomHHDL();

        public DataTable GetNhomHH(string searchText)
        {
            return nhomHHDL.GetNhomHH(searchText);
        }

        public int DeleteCategory(int id)
        {
            return nhomHHDL.DeleteNhomHH(id);
        }
        // Lưu danh mục (Thêm hoặc Sửa)
        public int SaveCategory(int id, string name)
        {
            if (id == 0)
                return nhomHHDL.InsertNhomHH(name);
            else
                return nhomHHDL.UpdateNhomHH(id, name);
        }

        public DataRow GetNhomHHById(int id)
        {
            return nhomHHDL.GetNhomHHById(id);
        }


    }
}
