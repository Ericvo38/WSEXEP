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
    public partial class Form1AF7_Tab4 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1AF7_Tab4()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1AF7_Tab4_Load(object sender, EventArgs e)
        {
            bool r1 = Form1AF7.RD.rd1t4;
            bool r2 = Form1AF7.RD.rd2t4;
            bool r3 = Form1AF7.RD.rd3t4;
            bool r4 = Form1AF7.RD.rd4t4;

            bool rdht1 = Form1AF7.RD.rdpbt4;
            bool rdht2 = Form1AF7.RD.rdnhant4;
            bool rdht3 = Form1AF7.RD.rdhtt4;

            if (rdht1 == true)
            {
                if ((r1 == true) || (r2 == true) || (r3 == true))
                {
                    Load1();

                }
                else if (r4 == true)
                {

                    Load2();
                }

            }
            else if (rdht2 == true)
            {
                if ((r1 == true) || (r2 == true) || (r3 == true) ||(r4 == true))
                {

                    Load3();
                }
             
            }
            else if (rdht3 == true)
            {
                if ((r1 == true) || (r2 == true) || (r3 == true))
                {
                    Load4();
                }
                else if (r4 == true)
                {

                    Load5();
                }

            }
        }
        public void Load1()
        {
            string s1 = Form1AF7.DL.t1T4;
            string s2 = Form1AF7.DL.t2T4;
            string s3 = Form1AF7.DL.t3T4;

            if (s3 == "N")
            {
                WSEXE.ReportView.cr_Form1AF7_Tab4_1 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab4_1();
                string st = "select ADR1, C_NAME FROM CUST WHERE";

                if ((s1.ToString() == "") && (s2.ToString() == ""))
                    st = "select ADR1, C_NAME FROM CUST";

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
            string s1 = Form1AF7.DL.t1T4;
            string s2 = Form1AF7.DL.t2T4;
            string s3 = Form1AF7.DL.t3T4;

            if (s3 == "N")
            {
                WSEXE.ReportView.cr_Form1AF7_Tab4_1 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab4_1(); 

                string st = "select C_NAME FROM CUST WHERE";

                if ((s1.ToString() == "") && (s2.ToString() == ""))
                    st = "select C_NAME FROM CUST";

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

        public void Load3()
        {
            string s1 = Form1AF7.DL.t1T4;
            string s2 = Form1AF7.DL.t2T4;
            string s3 = Form1AF7.DL.t3T4;

            if (s3 == "N")
            {
                WSEXE.ReportView.cr_Form1AF7_Tab4_2 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab4_2();
                

                string st = "select C_NO FROM CUST WHERE";

                if ((s1.ToString() == "") && (s2.ToString() == ""))
                    st = "select C_NO FROM CUST";

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

        public void Load4()
        {
            string s1 = Form1AF7.DL.t1T4;
            string s2 = Form1AF7.DL.t2T4;
            string s3 = Form1AF7.DL.t3T4;

            if (s3 == "N")
            {
                WSEXE.ReportView.cr_Form1AF7_Tab4_3 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab4_3();
                
                string st = "select ADR1,C_NAME, TEL1 FROM CUST WHERE";


                if ((s1.ToString() == "") && (s2.ToString() == ""))
                    st = "select ADR1,C_NAME, TEL1 FROM CUST";

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

        public void Load5()
        {
            string s1 = Form1AF7.DL.t1T4;
            string s2 = Form1AF7.DL.t2T4;
            string s3 = Form1AF7.DL.t3T4;

            if (s3 == "N")
            {
                WSEXE.ReportView.cr_Form1AF7_Tab4_3 rpt = new WSEXE.ReportView.cr_Form1AF7_Tab4_3();
                SqlConnection conn = new SqlConnection(CN.str);
                conn.Open();

                string st = "select C_NAME, TEL1 FROM CUST WHERE";

                if ((s1.ToString() == "") && (s2.ToString() == ""))
                    st = "select C_NAME, TEL1 FROM CUST";

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
