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

namespace WTERP.WSEXE
{
    public partial class frm2D_Tab3 : Form
    {
        DataProvider con = new DataProvider();
        public frm2D_Tab3()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        // tạo dữ liệu
        string txt3_1;
        string txt3_2;
        string txt3_3;
        string txt3_4;
        string txt3_5;
        string txt3_6;
        string txt3_7;
        string txt3_8;
        string txt3_9;
        //1
        bool rdold;
        bool rdNew1;
        bool rdNew2;

        //2
        bool rd32_1;
        bool rd32_2;
        bool rd32_3;
        bool rd32_4;

        //3
        bool rd33_1;
        bool rd33_2;
        bool rd33_3;
        //SQL
        string SQL = "";
        int check_tab;
        private void frm2D_Tab3_Load(object sender, EventArgs e)
        {
            getDL();
            ProcesTab3();
            DataTable dt = con.readdata(SQL);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                    dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            }
            if (check_tab == 1 || check_tab == 4)
            {
                Cr_2D_Tab3 rp = new Cr_2D_Tab3();
                rp.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rp;
            }
            if (check_tab == 2 || check_tab == 3)
            {
                Cr_2D_Tab3_2 rp = new Cr_2D_Tab3_2();
                rp.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rp;
            }
        }
        void ProcesTab3()
        {
            //tất cả
            if (rd32_1 == true)
            {
                check_tab = 1;
                if (rdold == true)
                {
                    SQL = "SELECT WS_DATE1, WS_DATE, WS_NO, CARH.USR_NAME,C_ANAME2 as C_ANAME_O, OVER0, OR_NO from CARH INNER JOIN CUST ON CUST.C_NO = CARH.C_NO WHERE 1=1 ";
                    if (!string.IsNullOrEmpty(txt3_1))
                        SQL = SQL + " AND WS_NO >= '" + txt3_1 + "' ";
                    if (!string.IsNullOrEmpty(txt3_2))
                        SQL = SQL + " AND WS_NO <= '" + txt3_2 + "'";
                    if (!string.IsNullOrEmpty(txt3_7))
                        SQL = SQL + " AND CAL_YM = '" + con.formatstr2(txt3_7) + "'";
                    SQL = SQL + " ORDER BY CARH.WS_NO";
                }
            }
            if (rd32_2 == true)
            {
                check_tab = 2;
                SQL = "SELECT CARB.WS_DATE,CARB.WS_NO, CARB.OR_NO, CARH.USR_NAME, CARH.C_ANAME,CARH.OR_NO,CARB.BQTY,CARB.COLOR + '' + CARB.P_NAME1 from CARH,CARB where CARH.WS_NO = CARB.WS_NO AND" +
             " (CARH.OR_NO not like '%作廢%' and CARH.OR_NO not like '%改單%') AND CARH.WS_DATE <> ''";
                if (!string.IsNullOrEmpty(txt3_1))
                    SQL = SQL + " AND CARH.WS_NO >= '" + txt3_1 + "' ";
                if (!string.IsNullOrEmpty(txt3_2))
                    SQL = SQL + " AND CARH.WS_NO <= '" + txt3_2 + "'";
                if (!string.IsNullOrEmpty(txt3_3))
                    SQL = SQL + " AND CARH.WS_DATE <= '" + con.formatstr2(txt3_3) + "'";
                if (!string.IsNullOrEmpty(txt3_4))
                    SQL = SQL + " AND CARH.WS_DATE <= '" + con.formatstr2(txt3_4) + "'";
                if (!string.IsNullOrEmpty(txt3_5))
                    SQL = SQL + " AND CARH.C_NO <= '" + txt3_5 + "'";
                if (!string.IsNullOrEmpty(txt3_6))
                    SQL = SQL + " AND CARH.C_NO <= '" + txt3_6 + "'";
                if (!string.IsNullOrEmpty(txt3_9))
                    SQL = SQL + " AND CARH.MEMO4 = '" + txt3_9 + "'";
                if (rd33_2 == true)
                    SQL = SQL + " AND CARB.K_NO IN ('1','2')";
                if (rd33_3 == true)
                    SQL = SQL + " AND CARB.K_NO IN ('3','4')";
                SQL = SQL + "  ORDER BY CARH.WS_NO";
            }
            if (rd32_3 == true)
            {
                check_tab = 3;
                SQL = "SELECT CARB.WS_DATE,CARB.WS_NO, CARB.OR_NO, CARH.USR_NAME, CARH.C_ANAME,CARH.OR_NO,CARB.BQTY,CARB.COLOR + '' + CARB.P_NAME1 from CARH,CARB where CARH.WS_NO = CARB.WS_NO AND" +
           " CARH.C_NO <> ''";
                if (!string.IsNullOrEmpty(txt3_1))
                    SQL = SQL + " AND CARH.WS_NO >= '" + txt3_1 + "' ";
                if (!string.IsNullOrEmpty(txt3_2))
                    SQL = SQL + " AND CARH.WS_NO <= '" + txt3_2 + "'";
                if (!string.IsNullOrEmpty(txt3_3))
                    SQL = SQL + " AND CARH.WS_DATE <= '" + con.formatstr2(txt3_3) + "'";
                if (!string.IsNullOrEmpty(txt3_4))
                    SQL = SQL + " AND CARH.WS_DATE <= '" + con.formatstr2(txt3_4) + "'";
                if (!string.IsNullOrEmpty(txt3_5))
                    SQL = SQL + " AND CARH.C_NO <= '" + txt3_5 + "'";
                if (!string.IsNullOrEmpty(txt3_6))
                    SQL = SQL + " AND CARH.C_NO <= '" + txt3_6 + "'";
                if (!string.IsNullOrEmpty(txt3_8))
                    SQL = SQL + " AND CARH.WS_DATE1 <= '" + con.formatstr2(txt3_8) + "'";
                if (!string.IsNullOrEmpty(txt3_9))
                    SQL = SQL + " AND CARH.MEMO4 = '" + txt3_9 + "'";
                if (rd33_2 == true)
                    SQL = SQL + " AND CARB.K_NO IN ('1','2')";
                if (rd33_3 == true)
                    SQL = SQL + " AND CARB.K_NO IN ('3','4')";
                SQL = SQL + "  ORDER BY CARH.WS_NO";
            }
            if (rd32_4 == true)
            {
                check_tab = 4;
                SQL = "SELECT WS_DATE1, WS_DATE, WS_NO, CARH.USR_NAME,C_ANAME2 as C_ANAME_O, OVER0, OR_NO from CARH INNER JOIN CUST ON CUST.C_NO = CARH.C_NO WHERE 1=1 ";
                if (!string.IsNullOrEmpty(txt3_1))
                    SQL = SQL + " AND WS_NO >= '" + txt3_1 + "' ";
                if (!string.IsNullOrEmpty(txt3_2))
                    SQL = SQL + " AND WS_NO <= '" + txt3_2 + "'";
                SQL = SQL + "  ORDER BY CARH.WS_NO";
            }
        }
        public void getDL()
        {
            txt3_1 = Form2D.Tab3.txt3_1;
            txt3_2 = Form2D.Tab3.txt3_2;
            txt3_3 = Form2D.Tab3.txt3_3;
            txt3_4 = Form2D.Tab3.txt3_4;
            txt3_5 = Form2D.Tab3.txt3_5;
            txt3_6 = Form2D.Tab3.txt3_6;
            txt3_7 = Form2D.Tab3.txt3_7;
            txt3_8 = Form2D.Tab3.txt3_8;
            txt3_9 = Form2D.Tab3.txt3_9;

            //1
            rdold = Form2D.Tab3.rdold;
            rdNew1 = Form2D.Tab3.rdNew1;
            rdNew2 = Form2D.Tab3.rdNew2;

            //2
            rd32_1 = Form2D.Tab3.rd32_1;
            rd32_2 = Form2D.Tab3.rd32_2;
            rd32_3 = Form2D.Tab3.rd32_3;
            rd32_4 = Form2D.Tab3.rd32_4;

            //3
            rd33_1 = Form2D.Tab3.rd33_1;
            rd33_2 = Form2D.Tab3.rd33_2;
            rd33_3 = Form2D.Tab3.rd33_3;
        }
    }
}
