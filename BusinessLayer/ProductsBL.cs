using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
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

        public int AddProduct(Product product)
        {
            try
            {
                return (productsDL.AddProduct(product));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public DataTable LoadXuatXu()
        {
            return productsDL.GetXuatXu();
        }

        public DataTable LoadNhaCungCap()
        {
            return productsDL.GetNhaCungCap();
        }

        public DataTable LoadDVT()
        {
            return productsDL.GetDVT();
        }
    }
}
