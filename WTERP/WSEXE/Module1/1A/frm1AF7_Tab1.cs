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
    public partial class Form1AF7_Tab1 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1AF7_Tab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        private void Form1AF7_Tab1_Load(object sender, EventArgs e)
        {
            bool r1 = Form1AF7.RD.rd1t1;
            bool r2 = Form1AF7.RD.rd2t1;
            bool r3 = Form1AF7.RD.rd3t1;
            bool r4 = Form1AF7.RD.rd4t1;
            if((r1== true) || (r2== true) || (r3== true))
            {
                Load_t1();
            }
            else if(r4 == true)
            {
                Load_t2();
            }
            
        }

        public void Load_t1()
        {
            string s1 = Form1AF7.DL.t1T1;
            string s2 = Form1AF7.DL.t2T1;
            string s3 = Form1AF7.DL.t3T1;

            WSEXE.ReportView.Cr_1AF7_Tab1 rpt = new WSEXE.ReportView.Cr_1AF7_Tab1();
           
            string st = "select C_NO, C_NAME2, TEL3, FAX2, ADR3 FROM CUST WHERE";
            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == ""))
                st = "select C_NO, C_NAME2, TEL3, FAX2, ADR3 FROM CUST";  

            if ((s1.ToString() != "") && (s2.ToString() == "") && (s3.ToString() == ""))
              st = st + " C_NO BETWEEN '"+s1.ToString()+"' AND (SELECT C_NO FROM CUST WHERE C_NO not in (SELECT TOP(SELECT COUNT(1) - 1  FROM CUST) C_NO FROM CUST)) ";

            if ((s1.ToString() == "") && (s2.ToString() != "") && (s3.ToString() == ""))
                st = st + " C_NO BETWEEN (select TOP(1) C_NO FROM CUST)  AND '"+s2.ToString()+"'";

            if ((s1.ToString() != "") && (s2.ToString() != "") && (s3.ToString() == ""))
                st = st + " C_NO BETWEEN '"+s1.ToString()+"'  AND '" + s2.ToString() + "'";

            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }
       
        public void Load_t2()
        {
            string s1 = Form1AF7.DL.t1T1;
            string s2 = Form1AF7.DL.t2T1;
            string s3 = Form1AF7.DL.t3T1;

            WSEXE.ReportView.cr_Form1AF7_Tab1_2 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab1_2();

            string st = "select C_NO, C_NAME2, TEL3, C_NAME, ADR1, C_NAME1, ADR2 FROM CUST WHERE";
            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == ""))
                st = "select C_NO, C_NAME2, TEL3, FAX2, ADR3 FROM CUST";

            if ((s1.ToString() != "") && (s2.ToString() == "") && (s3.ToString() == ""))
                st = st + " C_NO BETWEEN '" + s1.ToString() + "' AND (SELECT C_NO FROM CUST WHERE C_NO not in (SELECT TOP(SELECT COUNT(1) - 1  FROM CUST) C_NO FROM CUST)) ";

            if ((s1.ToString() == "") && (s2.ToString() != "") && (s3.ToString() == ""))
                st = st + " C_NO BETWEEN (select TOP(1) C_NO FROM CUST)  AND '" + s2.ToString() + "'";

            if ((s1.ToString() != "") && (s2.ToString() != "") && (s3.ToString() == ""))
                st = st + " C_NO BETWEEN '" + s1.ToString() + "'  AND '" + s2.ToString() + "'";

            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }
    }
}
