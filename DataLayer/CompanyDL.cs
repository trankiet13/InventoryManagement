using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TransferObject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace DataLayer
{
    public class CompanyDL : DataProvider
    {
        // Thêm mới công ty
        public int InsertCompany(CompanyTO company)
        {
            string query = "INSERT INTO tb_CONGTY (MACTY, TENCTY, DIACHI, DIENTHOAI, EMAIL, FAX, DISABLED) " +
                           "VALUES (@MACTY, @TENCTY, @DIACHI, @DIENTHOAI, @EMAIL, @FAX, @DISABLED)";
            Hashtable ht = new Hashtable
    {
        {"@MACTY", company.MACTY},
        {"@TENCTY", company.TENCTY},
        {"@DIACHI", company.DIACHI},
        {"@DIENTHOAI", company.DIENTHOAI},
        {"@EMAIL", company.EMAIL},
        {"@FAX", company.FAX},
        {"@DISABLED", company.DISABLED}
    };
            return MyExecuteNonQuery(query, ht);
        }
        // Phương thức kiểm tra tên công ty đã tồn tại
        public bool IsCompanyNameExists(string tenCty, string macty = "")
        {
            string query = "SELECT COUNT(*) FROM tb_CONGTY WHERE TENCTY = @TENCTY";
            if (!string.IsNullOrEmpty(macty))
            {
                query += " AND MACTY != @MACTY"; // Đảm bảo kiểm tra ngoại trừ công ty hiện tại khi chỉnh sửa
            }

            Hashtable ht = new Hashtable
    {
        {"@TENCTY", tenCty}
    };

            if (!string.IsNullOrEmpty(macty))
            {
                ht.Add("@MACTY", macty);
            }

            int count = Convert.ToInt32(MyExecuteScalar(query, CommandType.Text, ht));
            return count > 0;
        }
        public bool IsCompanyIDExists(string macty)
        {
            string query = "SELECT COUNT(*) FROM tb_CONGTY WHERE MACTY = @MACTY";
            Hashtable ht = new Hashtable { { "@MACTY", macty } };
            int count = Convert.ToInt32(MyExecuteScalar(query, CommandType.Text, ht));
            return count > 0;
        }
        //Tạo mã CTY0000

        public string GetNextCompanyID()
        {
            string query = "SELECT ISNULL(MAX(CAST(SUBSTRING(MACTY, 4, LEN(MACTY)-3) AS INT)), 0) FROM tb_CONGTY WHERE MACTY LIKE 'CTY%'";
            object result = MyExecuteScalar(query, CommandType.Text);
            int nextID = Convert.ToInt32(result) + 1;
            return $"CTY{nextID:0000}";
        }

        //Tạo mã DV0000
        // Trong lớp CompanyDL.cs
        public string GetNextBranchID()
        {
            string query = "SELECT ISNULL(MAX(CAST(SUBSTRING(MADVI, 5, LEN(MADVI)-4) AS INT)), 0) FROM tb_DONVI WHERE MADVI LIKE 'DV00%'";
            object result = MyExecuteScalar(query, CommandType.Text);
            int nextID = Convert.ToInt32(result) + 1;
            return $"DV00{nextID:0000}";
        }

        public bool IsBranchIDExists(string madvi)
        {
            string query = "SELECT COUNT(*) FROM tb_DONVI WHERE MADVI = @MADVI";
            Hashtable ht = new Hashtable { { "@MADVI", madvi } };
            int count = Convert.ToInt32(MyExecuteScalar(query, CommandType.Text, ht));
            return count > 0;
        }



        // Thêm mới đơn vị
        public int InsertBranch(BranchTO branch)
        {
            string query = "INSERT INTO tb_DONVI (MADVI, TENDVI, DIENTHOAI, FAX, EMAIL, DIACHI, MACTY) " +
                           "VALUES (@MADVI, @TENDVI, @DIENTHOAI, @FAX, @EMAIL, @DIACHI, @MACTY)";
            Hashtable ht = new Hashtable
            {
                {"@MADVI", branch.MADVI},
                {"@TENDVI", branch.TENDVI},
                {"@DIENTHOAI", branch.DIENTHOAI},
                {"@FAX", branch.FAX},
                {"@EMAIL", branch.EMAIL},
                {"@DIACHI", branch.DIACHI},
                {"@MACTY", branch.MACTY},
                {"@DISABLED", branch.DISABLED}
            };
            return MyExecuteNonQuery(query, ht);
        }

        // Lấy danh sách đơn vị theo mã công ty
        public DataTable GetBranchesByCompany(string macty)
        {
            string query = "SELECT * FROM tb_DONVI WHERE MACTY = @MACTY AND DISABLED = 0";
            Hashtable ht = new Hashtable { { "@MACTY", macty } };
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                foreach (DictionaryEntry param in ht)
                {
                    da.SelectCommand.Parameters.AddWithValue(param.Key.ToString(), param.Value);
                }
                da.Fill(dt);
            }
            return dt;
        }
    }
}
