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
    public partial class Form1BF7_Tab6 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1BF7_Tab6()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1BF7_Tab6_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string t1 = Form1BF7.DL.t1t6;
            string t2 = Form1BF7.DL.t2t6;
            //string t3 = Form1BF7.DL.t3t6;

            WSEXE.ReportView.cr_Form1BF7_Tab6_1 rpt = new WSEXE.ReportView.cr_Form1BF7_Tab6_1();
            

            string st = "select C_NO, C_NAME, TEL1 from VENDC where ";

            if ((t1.ToString() == "") && (t2.ToString() == ""))
                st = "select C_NO, C_NAME, TEL1 from VENDC";

            if ((t1.ToString() != "") && (t2.ToString() == ""))
                st = st + "C_NO = '"+t1.ToString()+"'";
            if ((t1.ToString() == "") && (t2.ToString() != ""))
                st = st + "C_NO = '" + t1.ToString() + "'";
            if ((t1.ToString() != "") && (t2.ToString() != ""))
                st = st + "C_NO = '" + t1.ToString() + "'";


            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
