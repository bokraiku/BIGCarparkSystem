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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            MemberClass member = new MemberClass();
            DataTable dt = member.getAllRole();
            DataRow drRole = dt.NewRow();
            drRole["role_name"] = "กรุณาเลือกสิทธิ์การใช้งาน";
            drRole["role_id"] = "0";

            dt.Rows.Add(drRole);
            edit_role_cb.DisplayMember = "role_name";
            edit_role_cb.ValueMember = "role_id";

            edit_role_cb.DataSource = dt;
            edit_role_cb.SelectedValue = "0";
        }
    }
}
