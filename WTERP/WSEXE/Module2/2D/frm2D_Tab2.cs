using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WTERP
{
    public partial class Form2D_Tab2 : Form
    {
        DataProvider con = new DataProvider();
        public Form2D_Tab2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        string t1 = Form2D.Tab2.t1t2;
        string t2 = Form2D.Tab2.t2t2;
        string t3 = Form2D.Tab2.t3t2;
        string t4 = Form2D.Tab2.t4t2;
        string t5 = Form2D.Tab2.t5t2;
        private void Form2D_Tab2_Load(object sender, EventArgs e)
        {
            bool r1 = Form2D.Tab2.r1t2;
            bool r2 = Form2D.Tab2.r2t2;
            bool b3 = Form2D.Tab2.r3t2;
            try
            {
                if (r1 == true)
                {
                    Loadr1();
                }
                else if (r2 == true)
                {
                    Loadr2();
                }
                else if (b3 == true)
                {
                    Loadr3();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string CheckWhere(string sql)
        {
            if (!string.IsNullOrEmpty(t1))
            {
                sql = sql + " AND B.WS_NO >= '" + t1 + "'";
            }
            if (!string.IsNullOrEmpty(t2))
            {
                sql = sql + " AND B.WS_NO <= '" + t2 + "'";
            }
            if (!string.IsNullOrEmpty(t3))
            {
                sql = sql + " AND B.WS_DATE >= '" + con.formatstr2(t3) + "'";
            }
            if (!string.IsNullOrEmpty(t4))
            {
                sql = sql + " AND B.WS_DATE <= '" + con.formatstr2(t4) + "'";
            }
            if (!string.IsNullOrEmpty(t5))
            {
                sql = sql + " AND B.WS_DATE >= '" + con.formatstr2(t5) + "'";
            }
            return sql;
        }
        public void Loadr1()
        {
            WSEXE.ReportView.Cr_Form2D_Tab2_1 rpt = new WSEXE.ReportView.Cr_Form2D_Tab2_1();
            string st = "select B.C_NO,B.WS_NO,B.NR,B.WS_DATE,B.P_NAME3,B.BQTY,(B.COLOR + '' + B.P_NAME1) AS P1,C.C_ANAME as C_ANAME2,B.COLOR_C FROM CARH C, CARB B WHERE C.WS_NO = B.WS_NO AND B.PRICE = 0 AND C.OR_NO LIKE '%贈送%' ";
            string st2 = "select B.C_NO,B.WS_NO,B.NR,B.WS_DATE,B.P_NAME3,(-1)*B.BQTY AS BQTY,(B.COLOR + '' + B.P_NAME1) AS P1,C.C_ANAME as C_ANAME2,B.COLOR_C FROM GIBH C, GIBB B WHERE C.WS_NO = B.WS_NO AND B.PRICE = 0 AND B.MEMO LIKE '%贈送%'";
            string st3 = CheckWhere(st) + " UNION " + CheckWhere(st2) + " ORDER BY B.C_NO,B.WS_NO,B.NR";

            DataTable dt = con.readdata(st3);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
        public void Loadr2()
        {
            string st = "SELECT C_ANAME AS C_ANAME_O,WS_DATE,WS_NO FROM CARH AS B WHERE OR_NO LIKE '%作廢%'";
            st = CheckWhere(st) + " ORDER BY WS_NO";
            WSEXE.ReportView.cr_Form2DF7_Tab2_2 rpt = new WSEXE.ReportView.cr_Form2DF7_Tab2_2();
            DataTable dt = con.readdata(st);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
        public void Loadr3()
        {
            WSEXE.ReportView.cr_Form2DF7_Tab2_3 rpt = new WSEXE.ReportView.cr_Form2DF7_Tab2_3();
            string st = "select C.C_ANAME as C_ANAME2, B.WS_DATE, B.WS_NO, (B.COLOR_C +''+ B.P_NAME1) as P1, B.P_NAME3, B.BQTY FROM CARH C,CARB B WHERE C.WS_NO = B.WS_NO AND C.OR_NO LIKE '%改單%'";
            st = CheckWhere(st) + " ORDER BY B.C_NO,B.WS_NO,B.NR";
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
