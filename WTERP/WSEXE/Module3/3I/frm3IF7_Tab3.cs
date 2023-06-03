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
    public partial class frm3IF7_Tab3 : Form
    {
        DataProvider conn = new DataProvider();
        public frm3IF7_Tab3()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        string text1;
        string text2;
        private void frm3IF7_Tab3_Load(object sender, EventArgs e)
        {
            text1 = frm3IF7.DL.D1_Tab3;
            text2 = frm3IF7.DL.D2_Tab3;
            string sql = "SELECT WS_DATE,USR_NAME,WS_NO,MK_NO,C_NAME,P_NAME,SOURCE,THICK,K_NO,WKG,PSF,CLRCARD FROM COSTH WHERE 2>1 AND WS_DATE BETWEEN '"+ text1 + "' AND '"+ text2 + "' ORDER BY WS_DATE";
            DataTable dataTable = new DataTable();
            dataTable = conn.readdata(sql);
            foreach (DataRow item in dataTable.Rows)
            {
                item["WS_DATE"] = conn.formatstr2(item["WS_DATE"].ToString());
            }
            WSEXE.ReportView.cr_frm3IF7_Tab3 rpt = new WSEXE.ReportView.cr_frm3IF7_Tab3();
            rpt.SetDataSource(dataTable);
            crystalReportViewer1.ReportSource = rpt; crystalReportViewer1.Show();
        }
    }
}
