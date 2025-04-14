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
                    Category category = new Category(TEN);
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
        public bool AddCategory(Category category)
        {
            string sql = "INSERT INTO dbo.tb_DTV values(@Name)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            //cmd.Parameters.AddWithValue("@ID", category.id);
            cmd.Parameters.AddWithValue("@Name", category.name);
            try
            {
                Connect();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(SqlException ex)
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
