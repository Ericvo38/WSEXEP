using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2G_Tab6_1 : Form
    {
        public frm2G_Tab6_1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        private void frm2G_Tab6_1_Load(object sender, EventArgs e)
        {
            WSEXE.ReportView.cr_From2G_Tap5 rpt = new WSEXE.ReportView.cr_From2G_Tap5();
            string SQL1 = "dbo.proc_2DTab7_DaHeo '" + frm2G.Parameter.K_NO + "',N'" + frm2G.Parameter.YEAR + "','%"+ frm2G.Parameter.KHUVUC+"%','"+ frm2G.Parameter.Months+"'";
            DataTable dt = con.readdata(SQL1);  
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
