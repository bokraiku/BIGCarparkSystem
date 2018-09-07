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
using Newtonsoft.Json;

namespace BIGCarParkSystem
{
    public partial class AlertMessage : MetroFramework.Forms.MetroForm
    {
        public AlertMessage()
        {
            InitializeComponent();
        }

        private void AlertMessage_Load(object sender, EventArgs e)
        {
            showuser_panel.BackColor = Color.FromArgb(100, 255, 255, 255);
            VisitorClass vc = new VisitorClass();
            DataTable visitorOut = vc.checkVititorNotOut();
            FunctionClass fn = new FunctionClass();
            string Message = "";
            if (visitorOut.Rows.Count > 0)
            {
                foreach (DataRow v in visitorOut.Rows)
                {
                    Message = "ชื่อ " + v["visit_name"] + ", เวลาเข้า " + fn.ConvertDate(v["visit_datetime_in"].ToString()) + ", เลขที่ "  + v["visit_id"] + "\r\n";
                    showList.Items.Add(Message);
                }
                if (Message != "")
                {
                    Message = "ยังไม่มีเวลาออก กรุณาตรวจสอบ";
                    showList.Items.Add(Message);
                   

                }
            }
            
        }
    }
}
