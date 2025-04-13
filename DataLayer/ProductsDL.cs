using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TransferObject;

namespace DataLayer
{
    public class ProductsDL : DataProvider
    {
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            // string sql = "SELECT BARCODE, TENHH, TENTAT, DVT, DONGIA, MANCC, XUATXU, CREATED_DATE, CREATED_BY, DISABLED FROM tb_HANGHOA";
            string sql = "SELECT  TENHH, TENTAT, DVT, DONGIA FROM tb_HANGHOA";

            string tenhh, tentat, dvt, donggia;
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    tenhh = reader[0].ToString();
                    tentat = reader[1].ToString();
                    dvt = reader[2].ToString();
                    Product product = new Product(tenhh, tentat, dvt);
                    products.Add(product);
                }
                reader.Close();
                return products;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }

        }
    }
}
