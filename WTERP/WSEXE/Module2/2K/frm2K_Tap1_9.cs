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
    public partial class frm2K_Tap1_9 : Form
    {
        public frm2K_Tap1_9()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        private void frm2K_Tap1_9_Load(object sender, EventArgs e)
        {
            bool DATE = frm2K.rd_Date;
            bool OR_NO = frm2K.rd_ORNO;

            string ST_DATE = "";
            string ST_OR_NO = "";

            if (DATE == true)
                ST_DATE = " ORDER BY A.WS_NO ASC";
            if (OR_NO == true)
                ST_OR_NO = " ORDER BY A.OR_NO ASC";

            string Date1 = frm2K.Date1;
            string CNO = frm2K.txt_CNO;
            // string NP = frm2K.txt_NP;

            WSEXE.ReportView.cr_From2K_Tap1_9 rpt = new WSEXE.ReportView.cr_From2K_Tap1_9();
            string st = " select A.*, CARH.C_NAME, CARH.M_TRAN FROM (SELECT WS_DATE, WS_NO, C_NO, CAL_YM, OR_NO, COLOR, COLOR_C, P_NAME, P_NAME1, P_NAME3, BQTY, PRICE, AMOUNT FROM CARB UNION SELECT WS_DATE, WS_NO, C_NO, CAL_YM, OR_NO, COLOR, COLOR_C, P_NAME, P_NAME1, P_NAME3, BQTY, PRICE, AMOUNT FROM GIBB) AS A Left JOIN CARH ON A.WS_NO = CARH.WS_NO WHERE 1=1";

            if ((Date1 != string.Empty) && (CNO == string.Empty))
                st = st + " AND  A.CAL_YM = '" + con.formatstr2(Date1) + "'";
            if ((CNO != string.Empty) && (Date1 == string.Empty))
                st = st + " AND A.C_NO ='" + CNO + "' ";
            if ((Date1 != string.Empty) && (CNO != string.Empty))
                st = st + " AND  A.CAL_YM = '" + con.formatstr2(Date1) + "' AND A.C_NO ='" + CNO + "'";

            if (DATE == true)
                st = st + ST_DATE;
            else if (OR_NO == true)
                st = st + ST_OR_NO;

            // MessageBox.Show(st);


            DataTable dt = con.readdata(st);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
                dr["CAL_YM"] = con.formatstr2(dr["CAL_YM"].ToString());
            }
            foreach (DataRow dr in dt.Rows)
            {
                string AD = dr["WS_NO"].ToString();
                string BB = AD.Substring(0, 2);
                if (BB == "TV" || BB == "CV")
                {
                    dr["BQTY"] = -float.Parse(dr["BQTY"].ToString());
                }
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
