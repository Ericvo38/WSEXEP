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
    public partial class Form1DF7_Tab1 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1DF7_Tab1_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string t1 = Form1DF7.DLT.t1t1;
            string t2 = Form1DF7.DLT.t2t1;
            string t3 = Form1DF7.DLT.t3t1;
            string t4 = Form1DF7.DLT.t4t1;
            string t5 = Form1DF7.DLT.t5t1;
            string t6 = Form1DF7.DLT.t6t1;
            string t7 = Form1DF7.DLT.t7t1;
            string t8 = Form1DF7.DLT.t8t1;

           

            string st = "";
            if((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st= "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE*PRICE) as TICH1, (QTYSTORE*COST_NEW) as TICH2 From PROD1C";

            if ((t1.ToString() != "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE * PRICE) as TICH1, (QTYSTORE * COST_NEW) as TICH2 From PROD1C where P_NO  BETWEEN(select TOP(1) P_NO from PROD1C Where P_NO LIKE N'%" + t1.ToString() + "%') AND(SELECT P_NO FROM PROD1C WHERE P_NO not in (SELECT TOP(SELECT COUNT(1) - 1  FROM PROD1C) P_NO FROM PROD1C)) ORDER BY P_NO ASC";

            if ((t1.ToString() == "") && (t2.ToString() != "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE*PRICE) as TICH1, (QTYSTORE*COST_NEW) as TICH2 From PROD1C WHERE P_NO  BETWEEN(select TOP(1) P_NO from PROD1C) AND(select TOP(1) P_NO from PROD1C Where K_NO = '"+t2.ToString()+"' ORDER BY P_NO DESC)";

            if ((t1.ToString() != "") && (t2.ToString() != "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE*PRICE) as TICH1, (QTYSTORE*COST_NEW) as TICH2 From PROD1C WHERE P_NO  BETWEEN(select TOP(1) P_NO from PROD1C where K_NO = '"+t1.ToString()+"' ORDER BY P_NO ASC) AND(select TOP(1) P_NO from PROD1C Where K_NO = '"+t2.ToString()+"' ORDER BY P_NO DESC)";

            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() != "") && (t4.ToString() == "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE * PRICE) as TICH1, (QTYSTORE * COST_NEW) as TICH2 From PROD1C where P_NO BETWEEN '" + t3.ToString() + "' AND (SELECT P_NO FROM PROD1C WHERE P_NO not in (SELECT TOP(SELECT COUNT(1) - 1  FROM PROD1C) P_NO FROM PROD1C))";

            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() != "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE * PRICE) as TICH1, (QTYSTORE * COST_NEW) as TICH2 From PROD1C where P_NO  BETWEEN (select TOP(1) P_NO from PROD1C) AND '"+t4.ToString()+"'";

            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() != "") && (t4.ToString() != "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE * PRICE) as TICH1, (QTYSTORE * COST_NEW) as TICH2 From PROD1C where P_NO BETWEEN '"+t3.ToString()+"' AND '" + t4.ToString() + "'";
           
            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() != "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE*PRICE) as TICH1, (QTYSTORE*COST_NEW) as TICH2 From PROD1C";

            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() == "") && (t6.ToString() != "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE*PRICE) as TICH1, (QTYSTORE*COST_NEW) as TICH2 From PROD1C";

            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() != "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE*PRICE) as TICH1, (QTYSTORE*COST_NEW) as TICH2 From PROD1C";

            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() != ""))
                st = "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE*PRICE) as TICH1, (QTYSTORE*COST_NEW) as TICH2 From PROD1C";

            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() == "") || (t5.ToString() != "") || (t6.ToString() != "") || (t7.ToString() != "") || (t8.ToString() != ""))
                st = "select P_NO, P_NAME1, UNIT, QTYSTORE, PRICE, COST_AVG, P_NAME, P_NAME3, QTYSAF, COST, COST_NEW, (QTYSTORE*PRICE) as TICH1, (QTYSTORE*COST_NEW) as TICH2 From PROD1C";

            WSEXE.ReportView.cr_Form1DF7_Tab1 rpt = new WSEXE.ReportView.cr_Form1DF7_Tab1();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
