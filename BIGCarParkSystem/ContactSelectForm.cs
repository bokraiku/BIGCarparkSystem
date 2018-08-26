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
    public partial class ContactSelectForm :  MetroFramework.Forms.MetroForm
    {
        public ContactSelectForm()
        {
            InitializeComponent();
        }

        private void ContactSelectForm_Load(object sender, EventArgs e)
        {
            ObjectiveClass cn = new ObjectiveClass();
            DataTable dt = cn.getAllContact();

            DataRow drContact = dt.NewRow();
            drContact["contact_name"] = "กรุณาเลือกผู้มาติดต่อ";
            drContact["contact_id"] = "0";

            dt.Rows.Add(drContact);
            contact_cb.DisplayMember = "contact_name";
            contact_cb.ValueMember = "contact_id";
            contact_cb.DataSource = dt;
            contact_cb.SelectedValue = "0";
        }

        private void contact_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (contact_cb.SelectedValue != null && contact_cb.SelectedValue.ToString() != "0")
            {
                //MessageBox.Show(contact_cb.SelectedValue.ToString());
               
            }
        }

        private void select_company_btn_Click(object sender, EventArgs e)
        {
            if (contact_cb.SelectedValue != null && contact_cb.SelectedValue.ToString() != "0")
            {
                MainForm.ContactId = Int32.Parse(contact_cb.SelectedValue.ToString());
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("กรุณาเลือกผู้มาติดต่อ");
            }
        }
    }
}
