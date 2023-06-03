using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm3IF7_Tab4 : Form
    {
        DataProvider conn = new DataProvider();
        public frm3IF7_Tab4()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        string text;
        private void frm3IF7_Tab3_Tab4_Load(object sender, EventArgs e)
        {
            text = frm3IF7.DL.D1_Tab4;
            string sql = "SELECT DISTINCT COSTB.NR, COSTH.K_NO, COSTB.P_NAME,CONVERT(varchar(100), Cast(COSTB.BQTY as FLOAT)) + 'KG' AS BQTY FROM COSTB,COSTH WHERE COSTB.WS_NO=COSTH.WS_NO and costb.bqty>0  " +
                "AND COSTB.P_NO NOT IN ('BS0002-VT0001','BS0001-VT0001','BS00001','BS00004') AND COSTH.WS_NO='" + text+"' ORDER BY NR";
            DataTable dataTable = new DataTable();
            dataTable = conn.readdata(sql);
            reportViewer1.View(dataTable, "Tab5", "WTERP.WSEXE.Module3._3I.ReportView.Report_Tab4.rdlc");
            //reportViewer1.View(dataTable, "tab5", "WTERP.WSEXE.Module3._3I.ReportView.rv_Form3I_Tab4.rdlc");
            //WSEXE.ReportView.cr_frm3IF7_Tab4 rpt = new WSEXE.ReportView.cr_frm3IF7_Tab4(); Report_Tab4
            //rpt.SetDataSource(dataTable);
            //crystalReportViewer1.ReportSource = rpt;
            this.reportViewer1.RefreshReport();
        }
    }
}
