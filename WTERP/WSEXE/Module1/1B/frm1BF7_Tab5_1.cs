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
    public partial class Form1BF7_Tab5_1 : Form
    {
        DataProvider con = new DataProvider();
        public Form1BF7_Tab5_1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1BF7_Tab5_1_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string t1 = Form1BF7.DL.t1t5;
            string t2 = Form1BF7.DL.t2t5;

            string st = "select C_NO, C_ANAME from VENDC where";

            if ((t1.ToString() == "") && (t2.ToString() == ""))
                st = "select C_NO, C_ANAME from VENDC";

            if ((t1.ToString() != "") && (t2.ToString() == ""))
                st = st + " C_NO between '" + t1.ToString() + "' and (SELECT C_NO FROM VENDC WHERE C_NO not in (SELECT TOP(SELECT COUNT(1) - 1  FROM VENDC) C_NO FROM VENDC))";


            if ((t1.ToString() == "") && (t2.ToString() != ""))
                st = st + " C_NO BETWEEN (select TOP(1) C_NO FROM VENDC)  AND '" + t2.ToString() + "'";

            if ((t1.ToString() != "") && (t2.ToString() != ""))
                st = st + " C_NO BETWEEN '" + t1.ToString() + "'  AND '" + t2.ToString() + "'";

            WSEXE.ReportView.cr_Form1BF7_Tab5 rpt = new WSEXE.ReportView.cr_Form1BF7_Tab5();
            DataTable dt = con.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
