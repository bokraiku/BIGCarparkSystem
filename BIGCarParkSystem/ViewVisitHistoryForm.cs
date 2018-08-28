using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using DarrenLee.Media;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using RDNIDWRAPPER;
using BIGCarParkSystem.Class;

namespace BIGCarParkSystem
{
    public partial class ViewVisitHistoryForm : MetroFramework.Forms.MetroForm
    {
        public static string VisitID = "";
        public ViewVisitHistoryForm()
        {
            InitializeComponent();
            this.transparent_bg();
        }

        private void ViewVisitHistoryForm_Load(object sender, EventArgs e)
        {
           
            if (ViewVisitHistoryForm.VisitID != "")
            {

                
                FunctionClass fn = new FunctionClass();
                VisitorClass vc = new VisitorClass();
                DataTable visitorDT = vc.getVisitorInfoById(VisitID);
                if (visitorDT.Rows.Count < 1)
                {
                    MessageBox.Show(this, "ไม่พบข้อมูลที่ค้นหา กรุณาตรวจสอบอีกครั้ง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }
                else
                {


                    //this.OutVisitID = visitorDT.Rows[0]["visit_id"].ToString();
                    out_visitid_tb.Text = visitorDT.Rows[0]["visit_id"].ToString();
                    out_indate_tb.Text = fn.ConvertDate(visitorDT.Rows[0]["visit_datetime_in"].ToString());
                    if(visitorDT.Rows[0]["visit_datetime_out"].ToString() == "")
                    {
                        out_dateout_tb.Text = "-";
                    }
                    else
                    {
                        out_dateout_tb.Text = fn.ConvertDate(visitorDT.Rows[0]["visit_datetime_out"].ToString());
                    }
                   
                    out_fullname_tb.Text = visitorDT.Rows[0]["visit_name"].ToString();
                    out_idcard_tb.Text = visitorDT.Rows[0]["id_card"].ToString();
                    out_tel_tb.Text = visitorDT.Rows[0]["tel"].ToString();
                    out_carid_tb.Text = visitorDT.Rows[0]["car_id"].ToString();
                    out_company_tb.Text = visitorDT.Rows[0]["com_name"].ToString();
                    out_cartype_tb.Text = visitorDT.Rows[0]["cartype_name"].ToString();
                    out_objective_tb.Text = visitorDT.Rows[0]["obt_name"].ToString();
                    out_contact_tb.Text = visitorDT.Rows[0]["contact_name"].ToString();
                    out_comment_tb.Text = visitorDT.Rows[0]["comment"].ToString();

                    if (visitorDT.Rows[0]["image_1"].ToString() != "")
                    {
                        out_image1_pb.Image = Image.FromFile(VariableDB.PathImage + visitorDT.Rows[0]["image_1"].ToString());
                    }
                    if (visitorDT.Rows[0]["image_2"].ToString() != "")
                    {
                        out_image2_pb.Image = Image.FromFile(VariableDB.PathImage + visitorDT.Rows[0]["image_2"].ToString());
                    }
                    if (visitorDT.Rows[0]["idcard_image"].ToString() != "")
                    {
                        out_idcardpic_pb.Image = Image.FromFile(VariableDB.PathIdCardImage + visitorDT.Rows[0]["idcard_image"].ToString());
                    }
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            // print bill
            VisitorClass vc = new VisitorClass();
            VisitorReportForm cf = new VisitorReportForm();
            DataSet dst = new DataSet();
            DataTable vcdt = vc.getVisitorInfoById(ViewVisitHistoryForm.VisitID);
            dst.Tables.Add(vcdt);
            cf.DsReport = dst;

            cf.ShowDialog();
        }

        private void transparent_bg()
        {
           
            panelMain.BackColor = Color.FromArgb(100, 255, 255, 255);
        }
    }
}
