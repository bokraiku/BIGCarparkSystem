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
    class VisitorClass
    {
        MysqlDB DB = new MysqlDB();
        DataTable dt = new DataTable();
        MySqlDataAdapter adr = new MySqlDataAdapter();


        public String InsertVisitData(string staff_id,string cartype_id,string company_id,string obt_id,string visit_name,string car_id,string id_card,string tel,string comment,string contact_id,string image_1)
        {
            String returnValue = "";
            try
            {
                if (DB.OpenConnection() == true)
                {

                  
                    string sql = "INSERT INTO `tbl_visitor` (`visit_datetime_in`, `visit_datetime_out`, `staff_id`, `cartype_id`, `company_id`, `obt_id`, `visit_name`, `car_id`, `id_card`, `tel`, `comment`,contact_id,image_1)" +
                        " VALUES (now(), NULL, @staff_id, @cartype_id, @company_id, @obt_id, @visitor_name, @car_id, @id_card, @tel, @comment,@contact_id,@image_1);";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@staff_id", staff_id);
                    cmd.Parameters.AddWithValue("@cartype_id", cartype_id);
                    cmd.Parameters.AddWithValue("@company_id", company_id);
                    cmd.Parameters.AddWithValue("@obt_id", obt_id);
                    cmd.Parameters.AddWithValue("@visitor_name", visit_name);
                    cmd.Parameters.AddWithValue("@car_id", car_id);
                    cmd.Parameters.AddWithValue("@id_card", id_card);
                    cmd.Parameters.AddWithValue("@tel", tel);
                    cmd.Parameters.AddWithValue("@comment", comment);
                    cmd.Parameters.AddWithValue("@contact_id", contact_id);
                    cmd.Parameters.AddWithValue("@image_1", image_1);

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

    }
}
