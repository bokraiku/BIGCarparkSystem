using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework;
using System.Windows.Forms;
using BIGCarParkSystem.Class;


namespace BIGCarParkSystem
{

   
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        private int isTest = 1;
        FunctionClass fn = new FunctionClass();
        MemberClass member = new MemberClass();
       
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            MysqlDB DB = new MysqlDB();
            this.Text = "Login";

            //connect DB
            if(DB.OpenConnection() == false)
            {
               
                MetroMessageBox.Show(this,"Cannot Connect DB");
                return;
            }
            login_panel_bg.BackColor = Color.FromArgb(200, 255, 255, 255);



        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Username = username_tbx.Text;
            string Password = fn.MD5Hash(password_tbx.Text);
            if (this.isTest == 1)
            {
                Username = "admin";
                Password = fn.MD5Hash("142536");
            }

            if (Username == null || Password == null)
            {
                MetroMessageBox.Show(this, "กรูณากรอกข้อมูลให้ครบ!");
                return;
            }

            DataTable dt = member.getUserLogin(Username, Password);

            if (dt.Rows.Count < 1)
            {
                MetroMessageBox.Show(this, "Username หรือ Password ไม่ถูกต้อง !!");
                return;
            }

            if (dt.Rows.Count > 0)
            {
                UserInfo.UserId = dt.Rows[0]["id"].ToString();
                UserInfo.Username = dt.Rows[0]["username"].ToString();
                UserInfo.UserRole = dt.Rows[0]["role_id"].ToString();
                UserInfo.LoginTime = fn.getDateNow();
                member.InsertLoginLog(UserInfo.UserId);
                this.Hide();
                MainForm mf = new MainForm();
                mf.ShowDialog();

            }
        }

        private void password_tbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void login_panel_bg_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
