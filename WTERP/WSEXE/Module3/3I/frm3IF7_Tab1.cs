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
using Microsoft.Reporting.WinForms;

namespace WTERP
{
    public partial class frm3IF7_Tab1 : Form
    {
        DataProvider con = new DataProvider();
        public int valuerdb { get; set; }
        public string ROWID, ROWID1;
        public string s { get; set; }

        public frm3IF7_Tab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        private void frm3IF7_Tab1_Load(object sender, EventArgs e)
        {
            if (valuerdb == 1)
            {
                ROWID = "ROWID between 1 and 36";
                ROWID1 = "ROWID between 37 and 72";
            }
            else
            {
                ROWID = "ROWID between 73 and 108";
                ROWID1 = "ROWID between 109 and 144";
            }

            string sql = "SELECT MK_NOA,WS_DATE,C_NAME,COSTH.P_NAME,SOURCE,THICK,CAST(WKG AS VARCHAR(Max))+ 'KG' AS WKG,PSF,SUM(BQTY) AS BQTY,K_NO,USR_NAME,CLRCARD,CAST(YEAR(WS_DATE) AS INT) AS Years," +
                        " CASE WHEN LEN(MONTH(WS_DATE)) = 1 THEN '0' + CAST(MONTH(CONVERT(NVARCHAR, WS_DATE, 103)) AS NVARCHAR) ELSE CAST(MONTH(CONVERT(NVARCHAR, WS_DATE,103)) AS NVARCHAR) END Months," +
                        " CASE WHEN LEN(DAY(WS_DATE)) = 1 THEN '0' + CAST(DAY(CONVERT(NVARCHAR, WS_DATE, 103)) AS NVARCHAR) ELSE CAST(DAY(CONVERT(NVARCHAR, WS_DATE,103)) AS NVARCHAR) END Days" +
                        " FROM dbo.COSTB,COSTH" +
                        " WHERE COSTB.WS_NO = COSTH.WS_NO AND COSTH.WS_NO = '" + s + "'" +
                        " GROUP BY MK_NOA,WS_DATE,C_NAME,COSTH.P_NAME,SOURCE,THICK,WKG,PSF,K_NO,USR_NAME,CLRCARD";

            string st1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY COSTH.WS_NO) AS ROWID,QTY,COSTB.P_NAME,BUNIT,BQTY,W_CHK,BMEMO,COSTB.P_NO" +
                        " FROM COSTB, COSTH" +
                        " WHERE COSTB.WS_NO = COSTH.WS_NO AND COSTH.WS_NO = '" + s + "') a" +
                        " WHERE "+ROWID+"";

            string st2= "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY COSTH.WS_NO) AS ROWID,QTY,COSTB.P_NAME,BUNIT,BQTY,W_CHK,BMEMO,COSTB.P_NO" +
                        " FROM COSTB, COSTH" +
                        " WHERE COSTB.WS_NO = COSTH.WS_NO AND COSTH.WS_NO = '" + s + "') a" +
                        " WHERE " + ROWID1 + "";

            DataTable dt = new DataTable();
            dt = con.readdata(sql);
            DataTable dt1 = new DataTable();
            dt1 = con.readdata(st1);
            DataTable dt2 = new DataTable();
            dt2 = con.readdata(st2);

            //reportViewer1.LocalReport.ReportEmbeddedResource = "WTERP.WSEXE.Module3._3I.ReportView.rv_Form3I_Tab1.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = "WTERP.WSEXE.Module3._3I.ReportView.Report_Tab1.rdlc";

            ReportDataSource rdb = new ReportDataSource("DataSet1", dt);
            ReportDataSource rdb1 = new ReportDataSource("DataSet2", dt1);
            ReportDataSource rdb2 = new ReportDataSource("DataSet3", dt2);

            reportViewer1.LocalReport.DataSources.Add(rdb);
            reportViewer1.LocalReport.DataSources.Add(rdb1);
            reportViewer1.LocalReport.DataSources.Add(rdb2);

            

            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 50;
            this.reportViewer1.RefreshReport();
        }
    }
}
