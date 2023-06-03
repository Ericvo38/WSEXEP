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
    public partial class Form1AF7_Tab2 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1AF7_Tab2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1AF7_Tab2_Load(object sender, EventArgs e)
        {
            bool r1 = Form1AF7.RD.rd1t2;
            bool r2 = Form1AF7.RD.rd2t2;
            bool r3 = Form1AF7.RD.rd3t2;
            bool r4 = Form1AF7.RD.rd4t2;

            bool rdin1 = Form1AF7.RD.rdin1t2;
            bool rdin2 = Form1AF7.RD.rdin2t2;

            if(rdin1 == true)
            {
                if((r1 == true) || (r2 == true) || (r3 == true) || (r4 == true))
                {
                    Load1();
                }

            }
            else if(rdin2 == true)
            {
                if ((r1 == true) || (r2 == true) || (r3 == true) || (r4 == true))
                {
                    Load2();
                }

            }

        }

        public void Load1()
        {
            string s1 = Form1AF7.DL.t1T2;
            string s2 = Form1AF7.DL.t2T2;
            string s3 = Form1AF7.DL.t3T2;

            if (s3 == "N")
            {
                WSEXE.ReportView.cr_Form1AF7_Tab2 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab2();
                string st = "select ADR3, C_NAME_E, TEL1 FROM CUST WHERE";
                if ((s1.ToString() == "") && (s2.ToString() == ""))
                    st = "select ADR3, C_NAME_E, TEL1 FROM CUST";

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
            else if (s3 == "Y")
            {
                MessageBox.Show("Vui Lòng Chọn Lại Lựa Chọn Cá Nhân", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        public void Load2()
        {
            string s1 = Form1AF7.DL.t1T2;
            string s2 = Form1AF7.DL.t2T2;
            string s3 = Form1AF7.DL.t3T2;

            if (s3 == "N")
            {
                WSEXE.ReportView.cr_Form1AF7_Tab2_2 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab2_2();

                string st = "select ADR3, C_NAME_E, TEL1 FROM CUST WHERE";
                if ((s1.ToString() == "") && (s2.ToString() == ""))
                    st = "select ADR3, C_NAME_E, TEL1 FROM CUST";
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
            else if (s3 == "Y")
            {
                MessageBox.Show("Vui Lòng Chọn Lại Lựa Chọn Cá Nhân", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
