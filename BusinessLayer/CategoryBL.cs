using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;
using System.Data;

namespace BusinessLayer
{
    public class CategoryBL
    {
        private CategoryDL categoryDL;
        public CategoryBL()
        {
            categoryDL = new CategoryDL();
        }
        public List<Category> GetAllCategories()
        {
            return categoryDL.GetAllCategories();
        }
        public int SaveCategory(string ten)
        {
            return categoryDL.InsertCategory(ten);
        }
        public DataTable GetCategories()
        {
            return categoryDL.LoadCategories();
        }
    }
}
