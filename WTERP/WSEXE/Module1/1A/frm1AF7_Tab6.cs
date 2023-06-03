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
    public partial class Form1AF7_Tab6 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1AF7_Tab6()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1AF7_Tab6_Load(object sender, EventArgs e)
        {
            bool r1 = Form1AF7.RD.rdin1t6;
            bool r2 = Form1AF7.RD.rdin2t6;

            if (r1 == true)
            {
                Load1();
            }
            else if (r2 == true)
            {
                Load2();
            }
        }

        public void Load1()
        {
            string s1 = Form1AF7.DL.t1T6;
            string s2 = Form1AF7.DL.t2T6;
            string s3 = Form1AF7.DL.t3T6;


            WSEXE.ReportView.cr_Form1AF7_Tab6_1 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab6_1();

            //int a = int.Parse(s3);
            string st = "select C_NAME, TEL1 FROM CUST WHERE";

            if ((s1.ToString() == "") && (s2.ToString() == ""))
                st = "select C_NAME, TEL1 FROM CUST";

            if ((s1.ToString() != "") && (s2.ToString() == ""))
                st = st + " C_NO = '" + s1.ToString() + "'";

            if ((s1.ToString() == "") && (s2.ToString() != ""))
                st = st + " C_NO = '" + s2.ToString() + "'";

            if ((s1.ToString() != "") && (s2.ToString() != ""))
                st = st + " C_NO = '" + s1.ToString() + "'";


            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }

        public void Load2()
        {
            string s1 = Form1AF7.DL.t1T6;
            string s2 = Form1AF7.DL.t2T6;
            string s3 = Form1AF7.DL.t3T6;


            WSEXE.ReportView.cr_Form1AF7_Tab6_2 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab6_2();

            string st = "select C_NAME, TEL1 FROM CUST WHERE";

            if ((s1.ToString() == "") && (s2.ToString() == ""))
                st = "select C_NAME, TEL1 FROM CUST";

            if ((s1.ToString() != "") && (s2.ToString() == ""))
                st = st + " C_NO = '" + s1.ToString() + "'";

            if ((s1.ToString() == "") && (s2.ToString() != ""))
                st = st + " C_NO = '" + s2.ToString() + "'";

            if ((s1.ToString() != "") && (s2.ToString() != ""))
                st = st + " C_NO = '" + s1.ToString() + "'";

            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
