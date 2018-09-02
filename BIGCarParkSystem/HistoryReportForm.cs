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
    public partial class HistoryReportForm : MetroFramework.Forms.MetroForm
    {
        public DataSet DsReport = new DataSet();

        public HistoryReportForm()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
            HistoryReport rpt = new HistoryReport();
            rpt.Refresh();
            rpt.Database.Tables[0].SetDataSource(this.DsReport.Tables[0]);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

        private void HistoryReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
