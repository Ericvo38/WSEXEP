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
    public partial class Form1CF7_Tab1 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1CF7_Tab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1CF7_Tab1_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string t1 = Form1CF7.GUI.t1t1;
            string t2 = Form1CF7.GUI.t2t1;
            string t3 = Form1CF7.GUI.t3t1;
            string t4 = Form1CF7.GUI.t4t1;
            string t5 = Form1CF7.GUI.t5t1;
            string t6 = Form1CF7.GUI.t6t1;
            string t7 = Form1CF7.GUI.t7t1;
            string t8 = Form1CF7.GUI.t8t1;

            WSEXE.ReportView.cr_Form1CF7_Tab1 rpt = new WSEXE.ReportView.cr_Form1CF7_Tab1();
            SqlConnection conn = new SqlConnection(CN.str);
            conn.Open();

            string st = "";
            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP";
            if ((t1.ToString() != "") && (t2.ToString() != "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP";
            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() != "") && (t4.ToString() != "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP WHERE P_NO BETWEEN '" + t3.ToString() + "'  AND '" + t4.ToString() + "'";
            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() != "") && (t6.ToString() != "") && (t7.ToString() == "") && (t8.ToString() == ""))
                st = "select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP";
            if ((t1.ToString() == "") && (t2.ToString() == "") && (t3.ToString() == "") && (t4.ToString() == "") && (t5.ToString() == "") && (t6.ToString() == "") && (t7.ToString() != "") && (t8.ToString() != ""))
                st = "select P_NO, P_NAME, THICK, MK_NO1, SH_NO, C_NAME, OR_NO, OR_NR, SH_NAME1, K_NAME, QTYPIC, QTYKG, QTYFT from PSHQTYP";

            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
