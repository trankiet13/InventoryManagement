using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using TransferObject;

namespace DataLayer
{
    public class SupplierDL : DataProvider
    {
        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            string sql = "SELECT MANCC, TENNCC, EMAIL, DIENTHOAI, FAX, DIACHI, CREATED_DATE, DISABLED FROM tb_NHACUNGCAP";

            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    Supplier supplier = new Supplier
                    {
                        MANCC = Convert.ToInt32(reader["MANCC"]),
                        TENNCC = reader["TENNCC"].ToString(),
                        EMAIL = reader["EMAIL"]?.ToString(),
                        DIENTHOAI = reader["DIENTHOAI"]?.ToString(),
                        FAX = reader["FAX"]?.ToString(),
                        DIACHI = reader["DIACHI"]?.ToString(),
                        CREATED_DATE = (DateTime)(reader["CREATED_DATE"] as DateTime?),
                        DISABLED = Convert.ToBoolean(reader["DISABLED"])
                    };

                    suppliers.Add(supplier);
                }
                reader.Close();
                return suppliers;
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

        public int InsertSupplier(Supplier supplier)
        {
            string sql = "uspAddSupplier";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@TENNCC", supplier.TENNCC),
                new SqlParameter("@EMAIL", (object)supplier.EMAIL ?? DBNull.Value),
                new SqlParameter("@DIENTHOAI", (object)supplier.DIENTHOAI ?? DBNull.Value),
                new SqlParameter("@FAX", (object)supplier.FAX ?? DBNull.Value),
                new SqlParameter("@DIACHI", (object)supplier.DIACHI ?? DBNull.Value),
                new SqlParameter("@CREATED_DATE", supplier.CREATED_DATE),
                new SqlParameter("@DISABLED", supplier.DISABLED)
            };
            return MyExecuteNonQuery(sql, CommandType.StoredProcedure, parameters);
        }

        public int UpdateSupplier(Supplier supplier)
        {
            string sql = "uspUpdateSupplier";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MANCC", supplier.MANCC),
                new SqlParameter("@TENNCC", supplier.TENNCC),
                new SqlParameter("@EMAIL", (object)supplier.EMAIL ?? DBNull.Value),
                new SqlParameter("@DIENTHOAI", (object)supplier.DIENTHOAI ?? DBNull.Value),
                new SqlParameter("@FAX", (object)supplier.FAX ?? DBNull.Value),
                new SqlParameter("@DIACHI", (object)supplier.DIACHI ?? DBNull.Value),
                new SqlParameter("@CREATED_DATE", supplier.CREATED_DATE),
                new SqlParameter("@DISABLED", supplier.DISABLED)
            };

            try
            {
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int DeleteSupplier(int mancc)
        {
            string sql = "uspDeleteSupplier";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MANCC", mancc)
            };

            try
            {
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Supplier> SearchSupplier(string keyword)
        {
            List<Supplier> suppliers = new List<Supplier>();
            string sql = @"SELECT MANCC, TENNCC, EMAIL, DIENTHOAI, FAX, DIACHI, CREATED_DATE, DISABLED
                   FROM tb_NHACUNGCAP
                   WHERE TENNCC LIKE @keyword OR EMAIL LIKE @keyword OR DIACHI LIKE @keyword";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                Connect();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        suppliers.Add(new Supplier
                        {
                            MANCC = Convert.ToInt32(reader["MANCC"]),
                            TENNCC = reader["TENNCC"].ToString(),
                            EMAIL = reader["EMAIL"]?.ToString(),
                            DIENTHOAI = reader["DIENTHOAI"]?.ToString(),
                            FAX = reader["FAX"]?.ToString(),
                            DIACHI = reader["DIACHI"]?.ToString(),
                            CREATED_DATE = (DateTime)(reader["CREATED_DATE"] as DateTime?),
                            DISABLED = Convert.ToBoolean(reader["DISABLED"])
                        });
                    }
                }
                Disconnect();
            }

            return suppliers;
        }

    }
}
