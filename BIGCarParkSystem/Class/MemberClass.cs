using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace BIGCarParkSystem.Class
{
    class MemberClass
    {


        MysqlDB DB = new MysqlDB();
        DataTable dt = new DataTable();
        MySqlDataAdapter adr = new MySqlDataAdapter();

        public String InsertLoginLog(String Userid)
        {
            String returnValue = "";
            try
            {

                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "INSERT INTO `tbl_login_log` (`userid`, `create_date`) VALUES (@userid, now());";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@userid", Userid);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        returnValue = cmd.LastInsertedId.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return returnValue;
        }
        public int EditUser(String Userid,String Username,String RoleId,String Status,String Password = "")
        {
            int returnValue = 0;
            try
            {

                if (DB.OpenConnection() == true)
                {

                    if(Password == "")
                    {
                        string sql = "update tbl_account set role_id=@role_id,account_status=@account_status where id=@id";
                        MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                        cmd.Parameters.AddWithValue("@role_id", RoleId);
                        cmd.Parameters.AddWithValue("@account_status", Status);
                        cmd.Parameters.AddWithValue("@id", Userid);
                        returnValue = cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string sql = "update tbl_account set role_id=@role_id,account_status=@account_status,password=@password where id=@id";
                        MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                        cmd.Parameters.AddWithValue("@role_id", RoleId);
                        cmd.Parameters.AddWithValue("@account_status", Status);
                        cmd.Parameters.AddWithValue("@id", Userid);
                        cmd.Parameters.AddWithValue("@password", Password);
        
                        returnValue = cmd.ExecuteNonQuery();
                    }
                  

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return returnValue;
        }

        public String InsertAccount(String username,String password, String role_id)
        {
            String returnValue = "";
            try
            {

                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "INSERT INTO `tbl_account` (`username`, `password`, `role_id`, `account_status`, `create_date`) VALUES (@username, @password, @role_id, 1, now());";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role_id", role_id);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        returnValue = cmd.LastInsertedId.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return returnValue;
        }

        public DataTable checkUsername(string username)
        {

            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_account where username=@username";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@username", username);
        
                    adr.SelectCommand = cmd;
                    adr.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return dt;
        }
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
        public DataTable getUserLoginByID(string userID)
        {

            try
            {
                if (DB.OpenConnection() == true)
                {

                    //dt.Clear();
                    this.dt.Clear();
                    string sql = "select * from tbl_account where id=@userID";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@userID", userID);
         
                    adr.SelectCommand = cmd;
                    adr.Fill(this.dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return this.dt;
        }
        public DataTable getAllRole()
        {

            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_role order by role_id asc";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
     
                    adr.SelectCommand = cmd;
                    adr.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return dt;
        }
        public DataTable getAllUser()
        {

            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select *,acc.id as acc_id from tbl_account acc inner join tbl_role ro on acc.role_id=ro.role_id order by acc.id asc";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);

                    adr.SelectCommand = cmd;
                    adr.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return dt;
        }
    }
}
