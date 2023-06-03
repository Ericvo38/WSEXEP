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
    public partial class Form1BF7_Tab1 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1BF7_Tab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1BF7_Tab1_Load(object sender, EventArgs e)
        {
            bool r1 = Form1BF7.RD.r1t1;
            bool r2 = Form1BF7.RD.r2t1;

            if(r1 == true)
            {
                Load1();
            }
            else if(r2 == true)
            {
                Load2();
            }
        }
        public void Load1()
        {
            string t1 = Form1BF7.DL.t1t1;
            string t2 = Form1BF7.DL.t2t1;
            string t3 = Form1BF7.DL.t3t2;

            WSEXE.ReportView.cr_Form1BF7_Tab1_1_New rpt = new WSEXE.ReportView.cr_Form1BF7_Tab1_1_New();

            string st = "select * from VENDC where 1=1";

            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == ""))
                st = st + "";

            if ((t1.ToString() != "") && (t2.ToString() == "") && (t3.ToString() == ""))
                st = st + " AND C_NO between '"+t1.ToString()+"' and (SELECT C_NO FROM VENDC WHERE C_NO not in (SELECT TOP(SELECT COUNT(1) - 1  FROM VENDC) C_NO FROM VENDC))";
              

            if ((t1.ToString() == "") && (t2.ToString() != "") && (t3.ToString() == ""))
                st = st + " AND C_NO BETWEEN (select TOP(1) C_NO FROM VENDC)  AND '" + t2.ToString() + "'";

            if ((t1.ToString() != "") && (t2.ToString() != "") && (t3.ToString() == ""))
                st = st + " AND C_NO BETWEEN '" + t1.ToString() + "'  AND '" + t2.ToString() + "'";

            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }

        public void Load2()
        {
            string t1 = Form1BF7.DL.t1t1;
            string t2 = Form1BF7.DL.t2t1;
            string t3 = Form1BF7.DL.t3t2;

            string st = "select C_NO, C_NAME, TEL1, FAX, NUMBER, ADR1 from VENDC where 1=1";

            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == ""))
                st = st + "";

            if ((t1.ToString() != "") && (t2.ToString() == "") && (t3.ToString() == ""))
                st = st + " AND C_NO between '" + t1.ToString() + "' and (SELECT C_NO FROM VENDC WHERE C_NO not in (SELECT TOP(SELECT COUNT(1) - 1  FROM VENDC) C_NO FROM VENDC))";


            if ((t1.ToString() == "") && (t2.ToString() != "") && (t3.ToString() == ""))
                st = st + " AND C_NO BETWEEN (select TOP(1) C_NO FROM VENDC)  AND '" + t2.ToString() + "'";

            if ((t1.ToString() != "") && (t2.ToString() != "") && (t3.ToString() == ""))
                st = st + " AND C_NO BETWEEN '" + t1.ToString() + "'  AND '" + t2.ToString() + "'";

            DataTable dt = connect.readdata(st);
            WSEXE.ReportView.cr_Form1BF7_Tab1_2 rpt = new WSEXE.ReportView.cr_Form1BF7_Tab1_2();
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }

    }
}
