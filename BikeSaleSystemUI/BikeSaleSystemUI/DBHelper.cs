using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BikeSaleSystemUI
{
    internal class DBHelper
    {
        //mở cổng kết nối DB
        public static SqlConnection ConnectDB()
        {
            SqlConnection con = new SqlConnection(@"Data Source=HOADD\SQLEXPRESS;Initial Catalog=BikeSaleDB;User ID=sa;Password=sa123456");
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Can't connect to Database.");
            }
            finally
            {
                con.Close();
            }
            return con;
        }
    }
}