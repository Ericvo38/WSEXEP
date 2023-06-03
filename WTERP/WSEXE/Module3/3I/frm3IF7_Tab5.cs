using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP.WSEXE
{
    public partial class frm3IF7_Tab5 : Form
    {
        DataProvider conn = new DataProvider();
        public frm3IF7_Tab5()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        string text;
        private void frm3IF7_Tab5_Load(object sender, EventArgs e)
        {
            text = frm3IF7.DL.D1_Tab5;
            string sql = "SELECT COSTB.P_NAME,CONVERT(varchar(100), Cast(COSTB.BQTY as FLOAT)) + 'KG' AS BQTY,COSTB.BUNIT,COSTB.BMEMO,COSTB.WS_NO,COSTH.MK_NOA,COSTH.K_NO FROM COSTB,COSTH WHERE COSTB.WS_NO=COSTH.WS_NO " +
                "AND costb.bqty > 0  AND COSTB.P_NO NOT IN('BS0002-VT0001', 'BS0001-VT0001', 'BS00001', 'BS00004') AND COSTH.WS_NO = '"+text+"'";
            DataTable dataTable = new DataTable();
            dataTable = conn.readdata(sql);
            WSEXE.ReportView.cr_frm3IF7_Tab5 rpt = new WSEXE.ReportView.cr_frm3IF7_Tab5();
            rpt.SetDataSource(dataTable);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
