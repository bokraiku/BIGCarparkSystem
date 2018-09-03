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
    public partial class EditUserForm : MetroFramework.Forms.MetroForm
    {
        public static string UserID;
        
        public EditUserForm()
        {
            InitializeComponent();
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {


            if (EditUserForm.UserID != "")
            {


                MemberClass member = new MemberClass();
                DataTable RoleDT = member.getAllRole();
                DataRow drRole = RoleDT.NewRow();
                drRole["role_name"] = "กรุณาเลือกสิทธิ์การใช้งาน";
                drRole["role_id"] = "0";

                RoleDT.Rows.Add(drRole);
                edit_role_cb.DisplayMember = "role_name";
                edit_role_cb.ValueMember = "role_id";

                edit_role_cb.DataSource = RoleDT;
                edit_role_cb.SelectedValue = "0";
                MemberClass mem = new MemberClass();
                DataTable UserDT = mem.getUserLoginByID(EditUserForm.UserID);
                if (UserDT.Rows.Count > 0)
                {
                    admin_username_tb.Text = UserDT.Rows[0]["username"].ToString();

                    edit_role_cb.SelectedValue = UserDT.Rows[0]["role_id"].ToString();

                    if (UserDT.Rows[0]["account_status"].ToString() == "1")
                    {
                        active_user_rb.Checked = true;
                    }
                    else
                    {
                        disable_user_rb.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบ User ID ในระบบ");

                }
            }
        }
                /*




                DataTable UserDT = member.getUserLoginByID(EditUserForm.UserID);
                if(UserDT.Rows.Count > 0)
                {
                    admin_username_tb.Text = UserDT.Rows[0]["username"].ToString();

                    edit_role_cb.SelectedValue = UserDT.Rows[0]["role_id"].ToString();

                    if(UserDT.Rows[0]["account_status"].ToString() == "1")
                    {
                        active_user_rb.Checked = true;
                    }
                    else
                    {
                        disable_user_rb.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบ User ID ในระบบ");

                }

            }
            */
             

        private void admin_save_bt_Click(object sender, EventArgs e)
        {
               
            MemberClass member = new MemberClass();
            string username = admin_username_tb.Text.Trim();
            string password = "" ;
            string conPassword = "";
            string roleId = edit_role_cb.SelectedValue.ToString();
            bool isChange = edit_pass_checkbox.Checked;
            string userstatus = "0";


            if (username.Equals(string.Empty) )
            {
                MessageBox.Show(this, "กรุณากรอกข้อมูลให้ครบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (isChange)
            {
                password = admin_password_tb.Text;
                conPassword = admin_conpass_tb.Text;
                if (password.Equals(string.Empty) || conPassword.Equals(string.Empty))
                {
                    MessageBox.Show(this, "กรุณากรอกข้อมูลให้ครบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
               
                if (password != conPassword)
                {
                    MessageBox.Show(this, "กรุณากรอกรหัสผ่านให้ตรงกัน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (roleId == null || roleId == "0")
            {
                MessageBox.Show(this, "กรุณาเลือกสิทธิ์การใช้งาน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (active_user_rb.Checked)
            {
                userstatus = "1";
            }


            FunctionClass fn = new FunctionClass();
            string md5Pass = fn.MD5Hash(password);
            
            DataTable adminDT = member.checkUsername(username);
            if (adminDT.Rows.Count < 1)
            {
                MessageBox.Show(this, "Username ไม่มีในระบบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int rowCount = member.EditUser(EditUserForm.UserID, username, roleId, userstatus, md5Pass);
            if(rowCount > 0)
            {
                MessageBox.Show(this, "บันทึกข้อมูลสำเร็จ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show(this, "ไม่สามารถแก้ไขข้อมูลได้ กรุณาตรวจสอบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }
    }
}
