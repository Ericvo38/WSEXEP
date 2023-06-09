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
    public partial class Form1DF7_Tab3 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab3()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1DF7_Tab3_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string s1 = Form1DF7.DLT.t1t3;
            string s2 = Form1DF7.DLT.t2t3;
        
            string st = "";
            if ((s1.ToString() == "") && (s2.ToString() == ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2 FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO ";

            if ((s1.ToString() != "") && (s2.ToString() == ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2 FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO WHERE PROD1C.K_NO BETWEEN '" + s1.ToString() + "' AND (select Top(1) PROD1C.K_NO from PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO ORDER BY PROD1C.K_NO DESC)";

            if ((s1.ToString() == "") && (s2.ToString() != ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2 FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO WHERE PROD1C.K_NO BETWEEN (select Top(1) PROD1C.K_NO from PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO ORDER BY PROD1C.K_NO ASC) AND '"+s2.ToString()+"'";

            if ((s1.ToString() != "") && (s2.ToString() != ""))
                st = "select (PROD1C.K_NO) as KA1, (KIND1C.K_NAME) as KA2 FROM PROD1C LEFT JOIN KIND1C ON PROD1C.K_NO = KIND1C.K_NO WHERE PROD1C.K_NO BETWEEN '" + s1.ToString() + "' AND '"+s2.ToString()+"'";

            WSEXE.ReportView.cr_Form1DF7_Tab3 rpt = new WSEXE.ReportView.cr_Form1DF7_Tab3();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }
    }
}
