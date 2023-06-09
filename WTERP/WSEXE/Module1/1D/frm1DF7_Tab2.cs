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
    public partial class Form1DF7_Tab2 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1DF7_Tab2_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string s1 = Form1DF7.DLT.t1t2;
            string s2 = Form1DF7.DLT.t2t2;
            string s3 = Form1DF7.DLT.t3t2;
            string s4 = Form1DF7.DLT.t4t2;
            string s5 = Form1DF7.DLT.t5t2;
            string s6 = Form1DF7.DLT.t6t2;

            

            string st = "";
            if((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2, PROD1C.P_NO, PROD1C.P_NAME1, PROD1C.P_NAME3, PROD1C.UNIT FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO ORDER BY P_NO ASC";

            if ((s1.ToString() != "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2, PROD1C.P_NO, PROD1C.P_NAME1, PROD1C.P_NAME3, PROD1C.UNIT FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO WHERE PROD1C.K_NO='" + s1.ToString() + "' ORDER BY P_NO ASC";

            if ((s1.ToString() == "") && (s2.ToString() != "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2, PROD1C.P_NO, PROD1C.P_NAME1, PROD1C.P_NAME3, PROD1C.UNIT FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO WHERE PROD1C.K_NO='" + s2.ToString() + "' ORDER BY P_NO ASC";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() != "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2, PROD1C.P_NO, PROD1C.P_NAME1, PROD1C.P_NAME3, PROD1C.UNIT FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO ORDER BY P_NO ASC";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() != "") && (s5.ToString() == "") && (s6.ToString() == ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2, PROD1C.P_NO, PROD1C.P_NAME1, PROD1C.P_NAME3, PROD1C.UNIT FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO ORDER BY P_NO ASC";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() != "") && (s6.ToString() == ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2, PROD1C.P_NO, PROD1C.P_NAME1, PROD1C.P_NAME3, PROD1C.UNIT FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO WHERE PROD1C.P_NO BETWEEN '"+s5.ToString()+"' AND (select Top(1) P_NO from PROD1C ORDER BY P_NO DESC) ORDER BY P_NO ASC";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() != ""))
                st = "select(PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2, PROD1C.P_NO, PROD1C.P_NAME1, PROD1C.P_NAME3, PROD1C.UNIT FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO WHERE PROD1C.P_NO BETWEEN(select Top(1) P_NO from PROD1C PROD1C ORDER BY P_NO ASC) AND '"+s6.ToString()+"' ORDER BY P_NO ASC";

            if ((s1.ToString() != "") && (s2.ToString() != "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() == "") && (s6.ToString() == ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2, PROD1C.P_NO, PROD1C.P_NAME1, PROD1C.P_NAME3, PROD1C.UNIT FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO ORDER BY P_NO ASC";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() != "") && (s4.ToString() != "") && (s5.ToString() == "") && (s6.ToString() == ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2, PROD1C.P_NO, PROD1C.P_NAME1, PROD1C.P_NAME3, PROD1C.UNIT FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO ORDER BY P_NO ASC";

            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == "") && (s5.ToString() != "") && (s6.ToString() != ""))
                st = "select(PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2, PROD1C.P_NO, PROD1C.P_NAME1, PROD1C.P_NAME3, PROD1C.UNIT FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO WHERE PROD1C.P_NO BETWEEN '"+s5.ToString()+"' AND '" + s6.ToString() + "' ORDER BY P_NO ASC";

            WSEXE.ReportView.cr_Form1DF7_Tab2 rpt = new WSEXE.ReportView.cr_Form1DF7_Tab2();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }
    }
}
