using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIGCarParkSystem.Class;
using MetroFramework;

namespace BIGCarParkSystem
{
    public partial class VisitorReportForm : MetroFramework.Forms.MetroForm
    {
        public DataSet DsReport = new DataSet();
        public VisitorReportForm()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            //this.WindowState = FormWindowState.Maximized;
            VisitorReport rpt = new VisitorReport();
            VisitorClass vc = new VisitorClass();
            rpt.Refresh();
            rpt.Database.Tables[0].SetDataSource(this.DsReport.Tables[0]);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
