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

            if(UserInfo.UserRole != "1")
            {
                delete_history_bt.Visible = false;
            }
            else
            {
                delete_history_bt.Visible = true;
            }
            blacklist_logo_pb.Visible = false;
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
                 
                    out_carid_tb.Text = visitorDT.Rows[0]["car_id"].ToString();
                    out_company_tb.Text = visitorDT.Rows[0]["com_name"].ToString();
                    out_cartype_tb.Text = visitorDT.Rows[0]["cartype_name"].ToString();
                    out_objective_tb.Text = visitorDT.Rows[0]["obt_name"].ToString();
                    out_contact_tb.Text = visitorDT.Rows[0]["contact_name"].ToString();
                    out_comment_tb.Text = visitorDT.Rows[0]["comment"].ToString();
                    visitor_amount_tb.Text = visitorDT.Rows[0]["visitor_amount"].ToString();

                    if (visitorDT.Rows[0]["image_1"].ToString() != "")
                    {
                        if(System.IO.File.Exists(VariableDB.PathImage + visitorDT.Rows[0]["image_1"].ToString())){
                            Image img = fn.resizeImage(Image.FromFile(VariableDB.PathImage + visitorDT.Rows[0]["image_1"].ToString()), new Size(450, 350));
                            Image imgClone = (Image)img.Clone();
                            out_image1_pb.Image = img;


                        }
                      
                    }
                    //if (visitorDT.Rows[0]["image_2"].ToString() != "")
                    //{
                    //    out_image2_pb.Image = Image.FromFile(VariableDB.PathImage + visitorDT.Rows[0]["image_2"].ToString());
                    //}
                    if (visitorDT.Rows[0]["idcard_image"].ToString() != "")
                    {
                        if (System.IO.File.Exists(VariableDB.PathImage + visitorDT.Rows[0]["image_1"].ToString()))
                        {
                            out_idcardpic_pb.Image = Image.FromFile(VariableDB.PathIdCardImage + visitorDT.Rows[0]["idcard_image"].ToString());
                        }
                    }

                    DataTable blDT = vc.checkBlacklist(visitorDT.Rows[0]["id_card"].ToString());
                    if(blDT.Rows.Count > 0)
                    {
                        blacklist_logo_pb.Visible = true;
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

        private void delete_history_bt_Click(object sender, EventArgs e)
        {
            if (ViewVisitHistoryForm.VisitID != "")
            {
                VisitorClass vc = new VisitorClass();
                int rowCount = vc.DeleteVisitor(ViewVisitHistoryForm.VisitID);
                if (rowCount == 0)
                {
                    MessageBox.Show(this, "ไม่สามารถลบข้อมูลได้ กรุณาตรวจสอบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(this, "ลบข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void black_list_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("คุณต้องการบันทึกข้อมูลหรือไม่", "ยืนยันการบันทึก", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                VisitorClass vc = new VisitorClass();
                DataTable visitorDT = vc.getVisitorInfoById(VisitID);
                if (visitorDT.Rows.Count > 0)
                {
                    string fullname = visitorDT.Rows[0]["visit_name"].ToString();
                    string id_card = visitorDT.Rows[0]["id_card"].ToString();
                    DataTable blDT = vc.checkBlacklist(id_card);
                    if (blDT.Rows.Count < 1)
                    {
                        int rowCount = vc.InsertBlacklist(id_card, fullname);
                        if (rowCount > 0)
                        {
                            MessageBox.Show(this, "บันทึกแบล็คลิสสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "บุคคลนี้เคยมีในรายชื่อแบล็คลิสแล้ว", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(this, "ไม่พบข้อมูลในระบบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void ViewVisitHistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            out_idcardpic_pb = null;
            
        }
    }
}
