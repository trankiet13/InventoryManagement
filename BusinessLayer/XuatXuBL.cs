using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class XuatXuBL
    {
        private readonly XuatXuDL xuatXuDL = new XuatXuDL();

        public DataTable GetXuatXu(string searchText)
        {
            return xuatXuDL.GetXuatXu(searchText);
        }

        public int DeleteXuatXu(int id)
        {
            return xuatXuDL.DeleteXuatXu(id);
        }
        // Lưu danh mục (Thêm hoặc Sửa)
        public int SaveXuatXu(int id, string name)
        {
            if (id == 0)
                return xuatXuDL.InsertXuatXu(name);
            else
                return xuatXuDL.UpdateXuatXu(id, name);
        }

        public DataRow GetXuatXuById(int id)
        {
            return xuatXuDL.GetXuatXuById(id);
        }

    }
}
