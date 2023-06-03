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
    public partial class frm3H_Tap2 : Form
    {
        public frm3H_Tap2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        DataProvider con = new DataProvider();
        private void frm3H_Tap2_Load(object sender, EventArgs e)
        { 
            string txtWS_NO1 = frm3H.SEND.WS_NO1;
            string txtWS_NO2 = frm3H.SEND.WS_NO2;
            string txtDate1 = frm3H.SEND.D1;
            string txtDate2 = frm3H.SEND.D2;

            WSEXE.ReportView.cr_Form3H_Tap2 rpt = new WSEXE.ReportView.cr_Form3H_Tap2();
            string st = "select WS_DATE, WS_NO, OR_NO, C_NAME, MEMO05, USR_NAME, MEMO08, '' as KT from PRDMK2 where 1=1";
            if ((txtWS_NO1 != string.Empty) && (txtWS_NO2 != string.Empty))
                st = st + " AND WS_NO BETWEEN '" + txtWS_NO1 + "' AND '" + txtWS_NO2 + "'";
            else if ((txtDate1 != string.Empty) && (txtDate2 != string.Empty))
                st = st + " and WS_DATE BETWEEN '" + con.formatstr2(txtDate1) + "' AND '" + con.formatstr2(txtDate2) + "'";
            else if ((txtWS_NO1 != string.Empty) && (txtWS_NO2 != string.Empty) || (txtDate1 != string.Empty) ||(txtDate2 != string.Empty))
                st = st + " AND WS_NO BETWEEN '" + txtWS_NO1 + "' AND '" + txtWS_NO2 + "'";

            DataTable dt = con.readdata(st);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
