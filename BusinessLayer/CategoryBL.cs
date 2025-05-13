using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class CategoryBL
    {
        private readonly CategoryDL categoryDL = new CategoryDL();

        public DataTable GetCategories(string searchText)
        {
            return categoryDL.GetCategories(searchText);
        }

        public int DeleteCategory(int id)
        {
            return categoryDL.DeleteCategory(id);
        }
        // Lưu danh mục (Thêm hoặc Sửa)
        public int SaveCategory(int id, string name)
        {
            if (id == 0)
                return categoryDL.InsertCategory(name);
            else
                return categoryDL.UpdateCategory(id, name);
        }
    }
}