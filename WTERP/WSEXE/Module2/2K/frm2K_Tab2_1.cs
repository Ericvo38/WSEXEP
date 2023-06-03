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
    public partial class frm2K_Tab2 : Form
    {
        public frm2K_Tab2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        DataProvider con = new DataProvider();

        private void frm2K_Tab2_Load(object sender, EventArgs e)
        {
            string C_NO1 = frm2K.txt_CNO1_2;
            string C_NO2 = frm2K.txt_CNO2_2;
            string WS_NOC1 = frm2K.txt_WSNO_1_3;
            string WS_NOC2 = frm2K.txt_WSNO_1_3;
            string Date1 = frm2K.Date1_2;
            string Date2 = frm2K.Date2_2;
            string Date3 = frm2K.Date3_2;

            WSEXE.ReportView.cr_From2K_Tap2_2 rpt = new WSEXE.ReportView.cr_From2K_Tap2_2();
            string SQL1 = "select CUST.C_ANAME2, CARB.WS_NO, CARB.OR_NO, SUBSTRING(SUBSTRING(CARB.WS_DATE,5,4),0,3)+'/'+SUBSTRING(SUBSTRING(CARB.WS_DATE,5,4),3,2) AS WS_DATE," +
                "CARB.COLOR_C,CARB.COLOR,CARB.P_NAME1,CARB.C_OR_NO,P_NAME2,'' AS PNAME,CARB.P_NAME3, CARB.BQTY, CARB.PRICE, CARB.AMOUNT from CARH,CARB " +
                "INNER JOIN CUST ON CARB.C_NO = CUST.C_NO where CARH.WS_NO = CARB.WS_NO AND CARH.OR_NO NOT LIKE'%作廢%' AND 1=1 ";

            if (!string.IsNullOrEmpty(C_NO1))
            {
                SQL1 = SQL1 + " AND CARB.C_NO >='" + C_NO1 + "'";
            }
            if (!string.IsNullOrEmpty(C_NO2))
            {
                SQL1 = SQL1 + " AND CARB.C_NO <='" + C_NO2 + "'";
            }
            if (!string.IsNullOrEmpty(WS_NOC1))
            {
                SQL1 = SQL1 + " AND CARB.WS_NO>='" + WS_NOC1 + "'";
            }
            if (!string.IsNullOrEmpty(WS_NOC2))
            {
                SQL1 = SQL1 + " AND CARB.WS_NO<='" + WS_NOC2 + "'";
            }
            if (!string.IsNullOrEmpty(Date1))
            {
                SQL1 = SQL1 + " AND CARB.WS_DATE >='" + con.formatstr2(Date1) + "'";
            }
            if (!string.IsNullOrEmpty(Date2))
            {
                SQL1 = SQL1 + " AND CARB.WS_DATE <='" + con.formatstr2(Date2) + "'";
            }
            if (!string.IsNullOrEmpty(Date3))
            {
                SQL1 = SQL1 + " AND CARB.CAL_YM > '" + con.formatstr2(Date3) + "'";
            }
            SQL1 = SQL1 + " ORDER BY CARB.C_NO,CARB.WS_NO,CARB.NR";

            DataTable dt = con.readdata(SQL1);
            foreach (DataRow dr in dt.Rows)
            {
                dr["PNAME"] = dr["COLOR_C"].ToString() + " " + dr["COLOR"].ToString() + " " + dr["P_NAME1"].ToString() + " " + dr["C_OR_NO"].ToString() + " " + dr["P_NAME2"].ToString();
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }
    }
}
