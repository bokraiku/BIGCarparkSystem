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
    class ObjectiveClass
    {
        MysqlDB DB = new MysqlDB();
        DataTable dt = new DataTable();
        MySqlDataAdapter adr = new MySqlDataAdapter();

        public DataTable getAllObjective()
        {

            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_objective where obt_status=1";
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

        public DataTable getAllContact()
        {

            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_staff_contact where contact_status=1";
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
        public DataTable getContactByID(int ContactID)
        {

            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_staff_contact where contact_status=1 and contact_id=@contact_id";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@contact_id", ContactID);
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
        public DataTable getObjectiveById(int ObjecttiveID)
        {

            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_objective where obt_status=1 and obt_id=@ObjecttiveID";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@ObjecttiveID", ObjecttiveID);
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


        public DataTable getObjectiveByName(string ObjectiveName)
        {

            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_objective where obt_name=@obt_name";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@obt_name", ObjectiveName);
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
        public DataTable getContactByName(string ContactName)
        {

            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_staff_contact where contact_name=@contact_name";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@contact_name", ContactName);
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

        public String InsertContact(String ContactName)
        {
            String returnValue = "";
            try
            {

                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "INSERT INTO `tbl_staff_contact` (`contact_name`, `create_date`, `contact_status`) VALUES (@contact_name, now(), 1);";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@contact_name", ContactName);
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
        public String InsertObjective(String obt_name,string group)
        {
            String returnValue = "";
            try
            {

                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "INSERT INTO `tbl_objective` (`obt_name`,`create_date`, `obt_status`, `group`) VALUES (@obt_name, now(), 1, @group);";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@obt_name", obt_name);
                    cmd.Parameters.AddWithValue("@group", group);
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
        public int UpdateObjectiveByName(string obt_name, string group,string objectiveId)
        {
            int returnValue = 0;
            try
            {

                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "update `tbl_objective` set obt_name=@obt_name,tbl_objective.group=@group where obt_id=@obt_id;";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                  
                    cmd.Parameters.AddWithValue("@obt_name", obt_name);
                    cmd.Parameters.AddWithValue("@group", group);
                    cmd.Parameters.AddWithValue("@obt_id", objectiveId);
                    returnValue = cmd.ExecuteNonQuery();
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return returnValue;
        }
        public int DeleteObjective(String obtId)
        {
            int returnValue = 0;
            try
            {

                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "delete from tbl_objective where obt_id=@obt_id";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@obt_id", obtId);
                    returnValue = cmd.ExecuteNonQuery();
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return returnValue;
        }
    }
}
