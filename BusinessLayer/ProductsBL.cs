using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public List<Product> SearchProduct(string keyword)
        {
            return productsDL.SearchProduct(keyword);
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
        public int UpdateProduct(Product product)
        {
            try
            {
                return productsDL.UpdateProduct(product);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int DeleteProduct(string barcode)
        {
            try
            {
                return productsDL.DeleteProduct(barcode);
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

        public DataTable LoadNhomSanPham()
        {
            return productsDL.GetNhomSanPham();
        }

        public List<GroupProduct> GetAll()
        {
            var dt = productsDL.GetNhomSanPham();
            List<GroupProduct> list = new List<GroupProduct>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new GroupProduct
                {
                    IDNHOM = row["IDNHOM"].ToString(),
                    TENNHOM = row["TENNHOM"].ToString()
                });
            }

            return list;
        }
    }
}
