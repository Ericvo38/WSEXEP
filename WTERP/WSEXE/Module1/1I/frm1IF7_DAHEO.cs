using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm1IF7_DAHEO : Form
    {
        public frm1IF7_DAHEO()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        DataProvider connect = new DataProvider();

        private void frm1IF7_DAHEO_Load(object sender, EventArgs e)
        {
            string S = Form1IF7.DL.S1;
            string st = "";
            st = "select QUOH.WS_NO, QUOH.C_NO, QUOH. C_NAME, QUOH.SPEAK, QUOH.SPEAK_CC, QUOH.MEMO1, QUOH.MEMO2, QUOH.MEMO3, QUOH.MEMO4, QUOH.MEMO5, QUOH.MEMO6, QUOH.MEMO101, QUOH.MEMO102, QUOH.MEMO103, QUOH.MEMO104, QUOH.MEMO105, QUOH.MEMO106, QUOH.MEMO107, QUOH.MEMO108, QUOH.MEMO109, QUOH.MEMO110, " +
                    "QUOH.MEMO201, QUOH.MEMO202, QUOH.MEMO203, QUOH.MEMO204, QUOH.MEMO205, QUOH.MEMO206, QUOH.MEMO207, QUOH.MEMO208, QUOH.MEMO209, QUOH.MEMO210, QUOH.MEMO301, QUOH.MEMO302, QUOH.MEMO303, QUOH.MEMO304, QUOH.MEMO305, QUOH.MEMO306, QUOH.MEMO307, QUOH.MEMO308, QUOH.MEMO309, QUOH.MEMO310," +
                    " QUOH.PAY_COND, QUOH.PS01, QUOB.P_NO, QUOB.P_NAME, QUOB.P_NAME1,''as COLOR_N, QUOB.PBT04, QUOB.PBT02, QUOB.PBT01, QUOB.P_NAME3, QUOB.PRICE from QUOH JOIN QUOB ON QUOH.WS_NO = QUOB.WS_NO where QUOH.WS_NO = '" + S + "'  ";
          
           
            WSEXE.ReportView.cr_Form1I_Tab1_Daheo rpt = new WSEXE.ReportView.cr_Form1I_Tab1_Daheo();

            DataTable dt = connect.readdata(st);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["PBT01"].ToString() == "BLACK")
                    dr["COLOR_N"] = "黑色";
                else if(dr["PBT01"].ToString() == "COLOR")
                    dr["COLOR_N"] = "顏色";
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
    
}
