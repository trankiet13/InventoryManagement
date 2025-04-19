using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataLayer
{
    public class DataProvider
    {
        public SqlConnection cn;
        public DataProvider()
        {
            string cnStr = "Data Source=.;Initial Catalog=QuanLy_Kho;Integrated Security=True;Encrypt=False";
            cn = new SqlConnection(cnStr);
        }

        public int MyExecuteNonQuery(string sql, Hashtable ht)   // Hàm trả lại số dòng bị thay đổi để thực thi các câu lệnh SQL
        {
            int res = 0; // dùng để đếm số dòng đã được thay đổi trong cơ sở dữ liệu
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;

                if (ht != null)

                {
                    foreach (DictionaryEntry item in ht)
                    {
                        cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value); //tên tham số,giá trị của tham số đó do người dùng nhập
                    }
                }

                Connect();
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
            return res;
        }

        public void Connect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Disconnect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        //Hàm sử dụng khi chỉ cần 1 giá trị (COUNT, MAX...) 1dong 1 cột, một giá trị duy nhất (object)
        public object MyExecuteScalar(string sql, CommandType type)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                return (cmd.ExecuteScalar());
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
        // Trả về nhiều dòng(SqlDataReader),khi đọc dữ liệu lớn, xử lý từng dòng
        public object MyExecuteScalar(string sql, CommandType type, Hashtable parameters = null)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;

                // Thêm parameters nếu có
                if (parameters != null)
                {
                    foreach (DictionaryEntry item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                    }
                }

                return cmd.ExecuteScalar();
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
