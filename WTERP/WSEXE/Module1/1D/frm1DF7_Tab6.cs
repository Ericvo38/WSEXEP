﻿using System;
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
    public partial class Form1DF7_Tab6 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab6()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1DF7_Tab6_Load(object sender, EventArgs e)
        {
            bool r1 = Form1DF7.RD.r1t6;
            bool r2 = Form1DF7.RD.r2t6;
            bool r3 = Form1DF7.RD.r3t6;

            if(r1 == true)
            {
                Load1();
            }
            else if (r2 == true)
            {
                Load2();
            }
            else if (r3 == true)
            {
                Load3();
            }
        }

        public void Load1()
        {
            string st = "Select P_NAME from PROD1C";
            WSEXE.ReportView.cr_Form1DF7_Tab6 rpt = new WSEXE.ReportView.cr_Form1DF7_Tab6();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }

        public void Load2()
        {
            string s1 = Form1DF7.DLT.t1t6;
            string s2 = Form1DF7.DLT.t2t6;
            string s3 = Form1DF7.DLT.t3t6;
            string s4 = Form1DF7.DLT.t4t6;
            string s5 = Form1DF7.DLT.t5t6;
            string s6 = Form1DF7.DLT.t6t6;
        
            string st = "";
            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == ""))
                st = "Select P_NAME from PROD1C";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() != "") && (s4.ToString() != "") && (s5.ToString() == "") && (s6.ToString() == ""))
                st = "select P_NO, QTYSTORE, QTYSTORE_BB from PROD1C WHERE (P_NO BETWEEN '"+s3.ToString()+"' AND '"+s4.ToString()+"') AND (QTYSTORE != 0 OR QTYSTORE_BB != 0) ORDER BY P_NO ASC";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() != "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == ""))
                st = "select P_NO, QTYSTORE, QTYSTORE_BB from PROD1C WHERE (P_NO BETWEEN '" + s3.ToString() + "' AND (select Top (1) P_NO from PROD1C ORDER BY P_NO DESC)) AND (QTYSTORE != 0 OR QTYSTORE_BB != 0) ORDER BY P_NO ASC";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() != "") && (s5.ToString() == "") && (s6.ToString() == ""))
                st = "select P_NO, QTYSTORE, QTYSTORE_BB from PROD1C WHERE (P_NO BETWEEN (select Top(1) P_NO from PROD1C ORDER BY P_NO ASC) AND '" + s4.ToString() + "') AND (QTYSTORE != 0 OR QTYSTORE_BB != 0) ORDER BY P_NO ASC";

            if ((s1.ToString() != "") || (s2.ToString() != "") || (s5.ToString() != "") || (s6.ToString() != ""))
                st = "Select P_NAME from PROD1C";

            WSEXE.ReportView.cr_Form1DF7_Tab6 rpt = new WSEXE.ReportView.cr_Form1DF7_Tab6();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }

        public void Load3()
        {
            WSEXE.ReportView.cr_Form1DF7_Tab6 rpt = new WSEXE.ReportView.cr_Form1DF7_Tab6();
            string st = "Select P_NAME from PROD1C";
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }



    }
}
