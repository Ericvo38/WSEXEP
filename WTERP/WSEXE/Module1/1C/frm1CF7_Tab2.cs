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
    public partial class Form1CF7_Tab2 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1CF7_Tab2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1CF7_Tab2_Load(object sender, EventArgs e)
        {
            Load1();
        }

        public void Load1()
        {
            string t1 = Form1CF7.GUI.t1t2;
            string t2 = Form1CF7.GUI.t2t2;
            string t3 = Form1CF7.GUI.t3t2;
            string t4 = Form1CF7.GUI.t4t2;

            string st = "";
            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() == ""))
                st = "select P_NO, P_NAME, P_NAME1, UNIT from PROD";
            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() != "") && (t4.ToString() != "") )
                st = "select P_NO, P_NAME, P_NAME1, UNIT from PROD WHERE P_NO BETWEEN '" + t3.ToString() + "'  AND '" + t4.ToString() + "'";
            if ((t1.ToString() != "") || (t2.ToString() != "") && (t3.ToString() == "") && (t4.ToString() == ""))
                st = "select P_NO, P_NAME, P_NAME1, UNIT from PROD";
            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() != "") && (t4.ToString() == ""))
                st = "select P_NO, P_NAME, P_NAME1, UNIT from PROD WHERE P_NO = '" + t3.ToString() + "'";
            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() != ""))
                st = "select P_NO, P_NAME, P_NAME1, UNIT from PROD WHERE P_NO = '" + t4.ToString() + "'";

            WSEXE.ReportView.cr_Form1CF7_Tab2 rpt = new WSEXE.ReportView.cr_Form1CF7_Tab2();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
