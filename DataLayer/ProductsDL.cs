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
            string sql = "SELECT BARCODE, TENHH, TENTAT, DVT, DONGIA, MANCC, MAXX, IDNHOM, MOTA, CREATED_DATE, CREATED_BY, DISABLED " +
                "FROM tb_HANGHOA";

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        BARCODE = reader["BARCODE"].ToString(),
                        TENHH = reader["TENHH"].ToString(),
                        TENTAT = reader["TENTAT"].ToString(),
                        DVT = reader["DVT"].ToString(),
                        DONGIA = reader["DONGIA"] as decimal?,
                        MANCC = (int)(reader["MANCC"] != DBNull.Value ? (int?)Convert.ToInt32(reader["MANCC"]) : null),
                        MAXX = (int)(reader["MAXX"] != DBNull.Value ? (int?)Convert.ToInt32(reader["MAXX"]) : null),
                        IDNHOM = reader["IDNHOM"].ToString(),
                        MOTA = reader["MOTA"].ToString(),
                        CREATED_DATE = reader["CREATED_DATE"] as DateTime?,
                        CREATED_BY = (int)(reader["CREATED_BY"] != DBNull.Value ? (int?)Convert.ToInt32(reader["CREATED_BY"]) : null),
                        DISABLED = reader["DISABLED"] as bool?
                    };

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


        public int AddProduct(Product product)
        {
            string sql = "uspAddProduct";
            List<SqlParameter> parameters = new List<SqlParameter>(); ;
            parameters.Add(new SqlParameter("@BARCODE", product.BARCODE));
            parameters.Add(new SqlParameter("@TENHH",product.TENHH));
            parameters.Add(new SqlParameter("@TENTAT", product.TENTAT));
            parameters.Add(new SqlParameter("@DVT", product.DVT));
            parameters.Add(new SqlParameter("@DONGIA", product.DONGIA));
            parameters.Add(new SqlParameter("@MANCC", product.MANCC));
            parameters.Add(new SqlParameter("@MAXX", product.MAXX));
            parameters.Add(new SqlParameter("@IDNHOM", product.IDNHOM));
            parameters.Add(new SqlParameter("@MOTA", product.MOTA));
            parameters.Add(new SqlParameter("@CREATED_DATE", product.CREATED_DATE));
            parameters.Add(new SqlParameter("@CREATED_BY", product.CREATED_BY));
            parameters.Add(new SqlParameter("@DISABLED", product.DISABLED));

            try
            {
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        protected DataTable MyGetDataTable(string sql, CommandType type, List<SqlParameter> parameters = null)
        {
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.CommandType = type;
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                        cmd.Parameters.Add(param);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }


        public DataTable GetXuatXu()
        {
            string sql = "SELECT ID, TEN FROM tb_XUATXU";
            try
            {
                Connect();
                DataTable dt = MyGetDataTable(sql, CommandType.Text);
                return dt;
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

        public DataTable GetNhaCungCap()
        {
            string sql = "SELECT MANCC, TENNCC, EMAIL, DIENTHOAI, FAX, DIACHI, CREATED_DATE, DISABLED FROM tb_NHACUNGCAP";
            try
            {
                Connect();
                DataTable dt = MyGetDataTable(sql, CommandType.Text);
                return dt;
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

        public DataTable GetDVT()
        {
            string sql = "SELECT ID, TEN FROM tb_DVT";
            try
            {
                Connect();
                DataTable dt = MyGetDataTable(sql, CommandType.Text);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { Disconnect(); }
        }

    }
}
