using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace BIGCarParkSystem.Resources
{
    class MemberClass
    {


        MysqlDB DB = new MysqlDB();
        DataTable dt = new DataTable();
        MySqlDataAdapter adr = new MySqlDataAdapter();


        public DataTable getUserLogin(string username,string password)
        {

            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_account where username=@username and password=@password";
                    MySqlCommand cmd = new MySqlCommand(sql,DB.connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    adr.SelectCommand = cmd;
                    adr.Fill(dt);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return dt;
        }
    }
}
