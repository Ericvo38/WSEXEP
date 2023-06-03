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
    public partial class Form1AF7_Tab5 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1AF7_Tab5()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1AF7_Tab5_Load(object sender, EventArgs e)
        {
            bool r1 = Form1AF7.RD.rdDlt5;
            bool r2 = Form1AF7.RD.rdTQt5;

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
            string s1 = Form1AF7.DL.t1T5;
            string s2 = Form1AF7.DL.t2T5;
     
         
             WSEXE.ReportView.cr_Form1AF7_Tab5_1 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab5_1();
             string st = "select C_NO, C_ANAME FROM CUST WHERE";

            if ((s1.ToString() == "") && (s2.ToString() == ""))
                st = "select C_NO, C_ANAME FROM CUST";

            if ((s1.ToString() != "") && (s2.ToString() == ""))
                st = st + " C_NO BETWEEN '" + s1.ToString() + "' AND (SELECT C_NO FROM CUST WHERE C_NO not in (SELECT TOP(SELECT COUNT(1) - 1  FROM CUST) C_NO FROM CUST)) ";

             if ((s1.ToString() == "") && (s2.ToString() != ""))
                    st = st + " C_NO BETWEEN (select TOP(1) C_NO FROM CUST)  AND '" + s2.ToString() + "'";

             if ((s1.ToString() != "") && (s2.ToString() != ""))
                    st = st + " C_NO BETWEEN '" + s1.ToString() + "'  AND '" + s2.ToString() + "'";

            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
             crystalReportViewer1.ReportSource = rpt;
       
        }

        public void Load2()
        {
            string s1 = Form1AF7.DL.t1T5;
            string s2 = Form1AF7.DL.t2T5;


            WSEXE.ReportView.cr_Form1AF7_Tab5_2 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab5_2();

            string st = "select C_NO, C_ANAME2 FROM CUST WHERE";

            if ((s1.ToString() != "") && (s2.ToString() == ""))
                st = "select C_NO, C_ANAME2 FROM CUST";

            if ((s1.ToString() != "") && (s2.ToString() == ""))
                st = st + " C_NO BETWEEN '" + s1.ToString() + "' AND (SELECT C_NO FROM CUST WHERE C_NO not in (SELECT TOP(SELECT COUNT(1) - 1  FROM CUST) C_NO FROM CUST)) ";

            if ((s1.ToString() == "") && (s2.ToString() != ""))
                st = st + " C_NO BETWEEN (select TOP(1) C_NO FROM CUST)  AND '" + s2.ToString() + "'";

            if ((s1.ToString() != "") && (s2.ToString() != ""))
                st = st + " C_NO BETWEEN '" + s1.ToString() + "'  AND '" + s2.ToString() + "'";

            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }

    }
}
