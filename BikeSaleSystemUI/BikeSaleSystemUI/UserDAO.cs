using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BikeSaleSystemUI
{
    //tạo kết nối với DB
    internal class UserDAO
    {
        public static void checkLogin(string us, string pw)
        {
            SqlConnection con = DBHelper.ConnectDB();
            try
            {
                con.Open();
                string sql = "SELECT username," +
                                    "password " +
                             "FROM Account " +
                             "WHERE username = '" + us + "'" +
                             "AND password = '" + pw + "'";

                // Tạo một đối tượng Command với 2 tham số: Command Text & Connection.
                SqlCommand cmd = new SqlCommand(sql, con);
                //đọc sql
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read() == true)
                {
                    MessageBox.Show("Login success.");
                }
                else
                {
                    MessageBox.Show("Login failed.");
                }
            }
            finally
            {
                con.Close();
            }
        }

        public static void createUser(string username, string re_password, string fullname)
        {
            SqlConnection con = DBHelper.ConnectDB();
            try
            {
                con.Open();
                // Câu lệnh Insert.
                string sql = "INSERT INTO Account (username, " +
                                                     "password, " +
                                                     "fullname , " +
                                                     "isAdmin) " +
                             "VALUES (@username, " +
                                    "@password, " +
                                    "@fullname , " +
                                    "@isAdmin)";
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;

                // Tạo một đối tượng Parameter.
                cmd.Parameters.Add("@username", SqlDbType.NChar).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.NChar).Value = re_password;
                cmd.Parameters.Add("@fullname", SqlDbType.NVarChar).Value = fullname;
                cmd.Parameters.Add("@isAdmin", SqlDbType.Bit).Value = false;

                // Thực thi Command (Dùng cho delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
    }
}