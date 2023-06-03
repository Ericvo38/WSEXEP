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
    public partial class frm3H_Tab3 : Form
    {
        public frm3H_Tab3()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        DataProvider con = new DataProvider();
        private void frm3H_Tab3_Load(object sender, EventArgs e)
        {
            string txtWS_NO1 = frm3H.SEND.WS_NO3;
            string txtWS_NO2 = frm3H.SEND.WS_NO4;
            string txtDate1 = frm3H.SEND.D3;
            string txtDate2 = frm3H.SEND.D4;

            WSEXE.ReportView.cr_Form3H_Tab3 rpt = new WSEXE.ReportView.cr_Form3H_Tab3();
            string st = "select WS_DATE, C_NAME, MEMO05, OR_NO, C_OR_NO, P_C, MEMO01, BQTY, FOB_DATE, '' as Date2 from PRDMK2 where 1 =1";
            if ((txtWS_NO1 != string.Empty) && (txtWS_NO2 != string.Empty))
                st = st + " AND WS_NO BETWEEN '" + txtWS_NO1 + "' AND '" + txtWS_NO2 + "'";
            else if ((txtDate1 != string.Empty) && (txtDate2 != string.Empty))
                st = st + " and WS_DATE BETWEEN '" + con.formatstr2(txtDate1) + "' AND '" + con.formatstr2(txtDate2) + "'";
            else if ((txtWS_NO1 != string.Empty) && (txtWS_NO2 != string.Empty) || (txtDate1 != string.Empty) || (txtDate2 != string.Empty))
                st = st + " AND WS_NO BETWEEN '" + txtWS_NO1 + "' AND '" + txtWS_NO2 + "'";

            DataTable dt = con.readdata(st);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
                dr["FOB_DATE"] = con.formatstr2(dr["FOB_DATE"].ToString());
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
