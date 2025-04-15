using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Collections;

using System.Web.UI.WebControls;
using Guna.UI2.WinForms;

namespace DataLayer
{
    public class CategoryDL : DataProvider
    {
        public int id = 0;
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            string sql = "SELECT * FROM dbo.tb_DVT";

            string ID , TEN;
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    ID = reader[0].ToString();
                    TEN = reader[1].ToString();
                    Category category = new Category(ID,TEN);
                    categories.Add(category);
                }
                reader.Close();
                return categories;
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

        public int InsertCategory(string ten)
        {
            string query = "INSERT INTO dbo.tb_DVT (TEN) VALUES (@TEN)";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@TEN", ten);

            cn.Open();
            int rows = cmd.ExecuteNonQuery();
            cn.Close();

            return rows;
        }

        public DataTable LoadCategories()
        {
            string query = "SELECT ID, TEN FROM dbo.tb_DVT";
            SqlDataAdapter da = new SqlDataAdapter(query, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
