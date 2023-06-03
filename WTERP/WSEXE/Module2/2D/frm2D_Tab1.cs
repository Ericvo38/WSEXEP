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
    public partial class Form2D_Tab1 : Form
    {
        DataProvider con = new DataProvider();
        public Form2D_Tab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form2D_Tab1_Load(object sender, EventArgs e)
        {
            LoadR1();
        }
        public void LoadR1()
        {
            bool r1 = Form2D.Tab1.r1t1;
            bool r2 = Form2D.Tab1.r2t1;

            string t1 = Form2D.Tab1.t1t1;
            string t2 = Form2D.Tab1.t2t1;
            string t3 = Form2D.Tab1.t3t1;
            string t4 = Form2D.Tab1.t4t1;

            WSEXE.ReportView.Cr_Form2D_Tab1 rpt = new WSEXE.ReportView.Cr_Form2D_Tab1();
            string st = "";
            st = "SELECT CUST.C_ANAME, QUOB.WS_DATE, QUOB.P_NAME,QUOB.P_NAME3, QUOB.PRICE FROM QUOB LEFT JOIN QUOH ON QUOB.WS_NO = QUOH.WS_NO INNER JOIN CUST ON QUOB.C_NO = CUST.C_NO WHERE QUOH.W_CHECK='Y' ";
            if (!string.IsNullOrEmpty(t1))
            {
                st = st + " AND QUOB.C_NO >= '" + t1 + "'";
            }
            if (!string.IsNullOrEmpty(t2))
            {
                st = st + " AND QUOB.C_NO <= '" + t2 + "'";
            }
            if (!string.IsNullOrEmpty(t3))
            {
                st = st + " AND QUOB.P_NO >= '" + t3 + "'";
            }
            if (!string.IsNullOrEmpty(t4))
            {
                st = st + " AND QUOB.P_NO <= '" + t4 + "'";
            }
            //cách sắp xếp
            if (r1 == true)
            {
                st = st + " ORDER BY QUOB.C_NO ASC";
            }
            else if (r2 == true)
            {
                st = st + " ORDER BY QUOB.P_NO ASC";
            }
            DataTable dt = con.readdata(st);
            foreach (DataRow item in dt.Rows)
            {
                item["WS_DATE"] = con.formatstr2(item["WS_DATE"].ToString());
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }
    }
}
