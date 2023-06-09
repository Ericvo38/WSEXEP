﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class Form1DF7_Tab4 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab4()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1DF7_Tab4_Load(object sender, EventArgs e)
        {
            bool r1 = Form1DF7.RD.r1t4;
            bool r2 = Form1DF7.RD.r2t4;
            
            if(r1 == true)
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
            string s1 = Form1DF7.DLT.t1t4;
            string s2 = Form1DF7.DLT.t2t4;
            string s3 = Form1DF7.DLT.t3t4;
            string s4 = Form1DF7.DLT.t4t4;


            string st = "";
            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE (QTYSAF - QTYSTORE) > 0 ORDER BY P_NO ASC";
            if ((s1.ToString() != "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE (P_NO BETWEEN (select Top(1) P_NO from PROD1C ORDER BY P_NO ASC) AND '"+s1.ToString()+"') AND (QTYSAF - QTYSTORE) > 0 ORDER BY P_NO ASC";
            if ((s1.ToString() == "") && (s2.ToString() != "") && (s3.ToString() == "") && (s4.ToString() == ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE (P_NO BETWEEN '"+s2.ToString()+"' AND (select Top(1) P_NO from PROD1C ORDER BY P_NO DESC)) AND (QTYSAF - QTYSTORE) > 0 ORDER BY P_NO ASC";
            if ((s1.ToString() != "") && (s2.ToString() != "") && (s3.ToString() == "") && (s4.ToString() == ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE (P_NO BETWEEN '" + s1.ToString() + "' AND '"+s2.ToString()+"') AND(QTYSAF - QTYSTORE) > 0 ORDER BY P_NO ASC";
            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() != "") || (s4.ToString() != ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE (QTYSAF - QTYSTORE) > 0 ORDER BY P_NO ASC";
            if ((s1.ToString() != "") && (s2.ToString() != "") && (s3.ToString() != "") && (s4.ToString() != ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE (K_NO BETWEEN '" + s3.ToString() + "' AND '" + s4.ToString() + "') AND(QTYSAF - QTYSTORE) > 0 ORDER BY P_NO ASC";


            WSEXE.ReportView.cr_Form1DF7_Tab4 rpt = new WSEXE.ReportView.cr_Form1DF7_Tab4();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }

        public void Load2()
        {
            string s1 = Form1DF7.DLT.t1t4;
            string s2 = Form1DF7.DLT.t2t4;
            string s3 = Form1DF7.DLT.t3t4;
            string s4 = Form1DF7.DLT.t4t4;

           

            string st = "";
            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C ORDER BY P_NO ASC";
            if ((s1.ToString() != "") && (s2.ToString() == "") && (s3.ToString() == "") && (s4.ToString() == ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE (P_NO BETWEEN (select Top(1) P_NO from PROD1C ORDER BY P_NO ASC) AND '" + s1.ToString() + "')  ORDER BY P_NO ASC";
            if ((s1.ToString() == "") && (s2.ToString() != "") && (s3.ToString() == "") && (s4.ToString() == ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE (P_NO BETWEEN '" + s2.ToString() + "' AND (select Top(1) P_NO from PROD1C ORDER BY P_NO DESC))  ORDER BY P_NO ASC";
            if ((s1.ToString() != "") && (s2.ToString() != "") && (s3.ToString() == "") && (s4.ToString() == ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE (P_NO BETWEEN '" + s1.ToString() + "' AND '" + s2.ToString() + "')  ORDER BY P_NO ASC";
            if ((s1.ToString() == "") && (s2.ToString() == "") && (s3.ToString() != "") || (s4.ToString() != ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE (QTYSAF - QTYSTORE) > 0 ORDER BY P_NO ASC";
            if ((s1.ToString() != "") && (s2.ToString() != "") && (s3.ToString() != "") && (s4.ToString() != ""))
                st = "select P_NO, P_NAME, P_NAME3, QTYSTORE, QTYSAF, BUNIT, (QTYSAF - QTYSTORE) AS QA1 FROM PROD1C WHERE (K_NO BETWEEN '" + s3.ToString() + "' AND '" + s4.ToString() + "')  ORDER BY P_NO ASC";

            WSEXE.ReportView.cr_Form1DF7_Tab4 rpt = new WSEXE.ReportView.cr_Form1DF7_Tab4();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
