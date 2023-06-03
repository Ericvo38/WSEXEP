using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTERP.WSEXE.ReportView;

namespace WTERP
{
    public partial class frm2NF7_Print : Form
    {
        DataProvider con = new DataProvider();
        public frm2NF7_Print()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void frm2NF7_Print_Load(object sender, EventArgs e)
        {
            string WS_NO = frm2NF7.getSTR.WS_NO;
            string C_NO = frm2NF7.getSTR.C_NO;
            string EM =frm2NF7.getSTR.EM;
            string WS_DATE =frm2NF7.getSTR.WS_DATE;

            String SQL = "SELECT STOBC.WS_NO, STOBC.WS_DATE, STOBC.C_NAME, STOBC.WS_TIME, STOHC.USR_NAME, STOBC.CAROUT_C, STOBC.ORDOUT_C, STOHC.MEMO FROM STOBC INNER JOIN STOHC ON STOBC.WS_NO = STOHC.WS_NO WHERE 1=1 ";
            SQL = SQL + WS_NO + C_NO + EM + WS_DATE;
            DataTable dt = con.readdata(SQL);
            CrystalReport2NF7 rp = new CrystalReport2NF7();
            rp.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rp;
        }
    }
}
