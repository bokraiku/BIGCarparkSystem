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
        public static DataSet VisitDS = new DataSet();


        public DataTable getAllVisitorInfoHistory(string input)
        {
            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_visitor vs inner join tbl_cartype ct on vs.cartype_id=ct.cartype_id" +
                            " inner join tbl_company cp on vs.company_id = cp.com_id" +
                            " inner join tbl_objective obt on vs.obt_id = obt.obt_id" +
                            " inner join tbl_staff_contact sc on vs.contact_id = sc.contact_id" +
                            " inner join tbl_account acc on vs.staff_id = acc.id " +
                            " where vs.car_id like '%"+ input + "%' or vs.id_card like '%" + input + "%' or  cp.com_name like '%" + input + "%' or vs.visit_name like '%" + input + "%' or vs.visit_datetime_in like '%" + input + "%'  or vs.visit_datetime_out like '%" + input + "%' " +
                            " order by vs.visit_datetime_in desc";
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

        public DataTable getAllVisitorInfo()
        {
            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_visitor vs inner join tbl_cartype ct on vs.cartype_id=ct.cartype_id" +
                            " inner join tbl_company cp on vs.company_id = cp.com_id" +
                            " inner join tbl_objective obt on vs.obt_id = obt.obt_id" +
                            " inner join tbl_staff_contact sc on vs.contact_id = sc.contact_id" +
                            " inner join tbl_account acc on vs.staff_id = acc.id " +
                            " order by vs.visit_datetime_in desc";
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

        public DataTable getVisitorInfoById(string VisitId)
        {
            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_visitor vs inner join tbl_cartype ct on vs.cartype_id=ct.cartype_id" +
                            " inner join tbl_company cp on vs.company_id = cp.com_id" +
                            " inner join tbl_objective obt on vs.obt_id = obt.obt_id" +
                            " inner join tbl_staff_contact sc on vs.contact_id = sc.contact_id" +
                            " inner join tbl_account acc on vs.staff_id = acc.id " +
                            " where vs.visit_id=@visit_id ";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@visit_id", VisitId);
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

        public DataTable getVisitorInfo(string input)
        {
            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_visitor vs inner join tbl_cartype ct on vs.cartype_id=ct.cartype_id"+
                            " inner join tbl_company cp on vs.company_id = cp.com_id" +
                            " inner join tbl_objective obt on vs.obt_id = obt.obt_id" +
                            " inner join tbl_staff_contact sc on vs.contact_id = sc.contact_id" +
                            " inner join tbl_account acc on vs.staff_id = acc.id " +
                            " where (vs.id_card=@input or vs.barcode_id=@input) and vs.visit_status=1 order by vs.visit_datetime_in desc limit 1 ";
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@input", input);
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
        public DataTable getVisitByID(string visitid)
        {
            try
            {
                if (DB.OpenConnection() == true)
                {

                    dt.Clear();
                    string sql = "select * from tbl_visitor where visit_id=@visit_id and visit_status=1";
                         
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@visit_id", visitid);
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

        public int UpdateVisitInfo(string visitId)
        {
            int rowCount = 0;
            try
            {
                if (DB.OpenConnection() == true)
                {


                    string sql = "update tbl_visitor set visit_datetime_out=now(),visit_status=2 where visit_id=@visit_id";
                        
                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@visit_id", visitId);

                    rowCount = cmd.ExecuteNonQuery();

                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return rowCount;
        }
        public int DeleteVisitor(string visitId)
        {
            int rowCount = 0;
            try
            {
                if (DB.OpenConnection() == true)
                {


                    string sql = "delete from tbl_visitor where visit_id=@visit_id";

                    MySqlCommand cmd = new MySqlCommand(sql, DB.connection);
                    cmd.Parameters.AddWithValue("@visit_id", visitId);

                    rowCount = cmd.ExecuteNonQuery();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }
            DB.CloseConnection();
            return rowCount;
        }



        public String InsertVisitData(string staff_id,string cartype_id,string company_id,string obt_id,string visit_name,string car_id,string id_card,string tel,string comment,string contact_id,string image_1, string idcard_image,string barcode_id,string visitor_amount)
        {
            String returnValue = "";
            try
            {
                if (DB.OpenConnection() == true)
                {

                  
                    string sql = "INSERT INTO `tbl_visitor` (`visit_datetime_in`, `visit_datetime_out`, `staff_id`, `cartype_id`, `company_id`, `obt_id`, `visit_name`, `car_id`, `id_card`, `tel`, `comment`,contact_id,image_1,idcard_image,barcode_id,visitor_amount)" +
                        " VALUES (now(), NULL, @staff_id, @cartype_id, @company_id, @obt_id, @visitor_name, @car_id, @id_card, @tel, @comment,@contact_id,@image_1,@idcard_image,@barcode_id,@visitor_amount);";
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
                    cmd.Parameters.AddWithValue("@idcard_image", idcard_image);
                    cmd.Parameters.AddWithValue("@barcode_id", barcode_id);
                    cmd.Parameters.AddWithValue("@visitor_amount", visitor_amount);


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
