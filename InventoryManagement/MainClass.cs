using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public static class MainClass
    {
        public static int id = 0;
        public static bool Validation(Form f)
        {
            bool isValid = true;
            int count = 0;
            foreach (Control c in f.Controls)
            {
                if (Convert.ToString(c.Tag) != "" && Convert.ToString(c.Tag) != null)
                {
                    if (c is Guna.UI2.WinForms.Guna2TextBox)
                    {
                        Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
                        if (t.Text.Trim() == "")
                        {
                            t.BorderColor = Color.Red;
                            t.FocusedState.BorderColor = Color.Red;
                            t.HoverState.BorderColor = Color.Red;
                            count++;
                        }
                        else
                        {
                            t.BorderColor = Color.FromArgb(95, 69, 204);
                            t.FocusedState.BorderColor = Color.Red;
                            t.HoverState.BorderColor = Color.Red;
                        }
                    }
                }
                if (count == 0)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            return isValid;
        }
        //public void SQL(string qry, Hashtable ht)
        //{
        //    int res = 0;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(qry, cn);
        //        cmd.CommandType = CommandType.Text;
        //        foreach (DictionaryEntry item in ht)
        //        {
        //            cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
        //        }
        //        if (cn.State == ConnectionState.Closed) { cn.Open(); }
        //        res = cmd.ExecuteNonQuery();
        //        if (cn.State == ConnectionState.Open) { cn.Close(); }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //        cn.Close();
        //    }
        //}
    }
}
