using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class ProductsBL
    {
        private ProductsDL productsDL;
        public ProductsBL()
        {
            productsDL = new ProductsDL();
        }
        public List<Product> GetAllProducts()
        {
            return productsDL.GetAllProducts();
        }

    }
}
