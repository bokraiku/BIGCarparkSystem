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

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using RDNIDWRAPPER;
using BIGCarParkSystem.Class;

namespace BIGCarParkSystem
{
    public partial class CompanySelectForm : MetroFramework.Forms.MetroForm
    {
        public CompanySelectForm()
        {
            InitializeComponent();
        }

        private void CompanySelectForm_Load(object sender, EventArgs e)
        {
            CompanyClass cn = new CompanyClass();

            DataTable dt = cn.getAllCompany();

            foreach(DataRow d in dt.Rows)
            {
                Button bt = new Button();
                bt.Tag = d["com_id"];
                bt.BackColor = Color.DodgerBlue; //Color.FromArgb(0, 0, 180, 255);
                bt.ForeColor = Color.White;
                bt.Font = new Font("Tahoma", 10, FontStyle.Bold);
                bt.Cursor = Cursors.Hand;
                bt.FlatStyle = FlatStyle.Flat;
                bt.Width = 250;
                bt.Padding = new Padding(5,5,5,5);
                bt.AutoSize = true;
                bt.Text = d["com_name"].ToString();
                bt.Click += Bt_Click;
                flowLayoutPanel1.Controls.Add(bt);
            }
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            //CompanyClass cp = new CompanyClass();
            //cp.CompanySelectdId = Int32.Parse(bt.Tag.ToString());
            MainForm.CompanySelectedID = Int32.Parse(bt.Tag.ToString());
            this.Close();
            return;

        }
    }
}
