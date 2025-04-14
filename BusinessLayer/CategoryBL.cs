using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;
    
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
        public bool AddCategory(Category category)
        {
            return categoryDL.AddCategory(category);
        }
    }
}
