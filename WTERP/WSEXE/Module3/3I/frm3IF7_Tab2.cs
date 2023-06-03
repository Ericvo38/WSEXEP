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
    public partial class frm3IF7_Tab2 : Form
    {
        DataProvider con = new DataProvider();
        public string WS_NO { get; set; }
        public int valuerdb { get; set; }
        public string ROWID, ROWID1;
        public int type { get; set; }
        public frm3IF7_Tab2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }


        private void frm3IF7_Tab2_Load(object sender, EventArgs e)
        {
            //string st = "select WS_DATE, C_NAME, P_NAME, CLRCARD, MK_NO, SOURCE, THICK, K_NO, WKG from COSTH where WS_NO ='" + s + "'";
            //string st = "SELECT COSTB.*,COSTH.* "+
            //            " FROM COSTB, COSTH"+
            //            " WHERE COSTB.WS_NO = COSTH.WS_NO AND COSTH.WS_NO = '"+ WS_NO + "'"+
            //            " ORDER BY COSTH.WS_NO";
            //WSEXE.ReportView.cr_Form3I_Tab2 rpt = new WSEXE.ReportView.cr_Form3I_Tab2();
            //DataTable dt = con.readdata(st);
            //rpt.SetDataSource(dt);
            //crystalReportViewer1.ReportSource = rpt;
            if(type == 1)
            {
                if (valuerdb == 1)
                {
                    ROWID = "ROWID between 1 and 35";
                    ROWID1 = "ROWID between 36 and 55";
                }
                else
                {
                    ROWID = "ROWID between 56 and 91";
                    ROWID1 = "ROWID between 92 and 112";
                }
                string sql = "SELECT MK_NOA,WS_DATE,C_NAME,COSTH.P_NAME,SOURCE,THICK,WKG,PSF,SUM(BQTY) AS BQTY" +
                            " FROM dbo.COSTB,COSTH" +
                            " WHERE COSTB.WS_NO = COSTH.WS_NO AND COSTH.WS_NO = '" + WS_NO + "'" +
                            " GROUP BY MK_NOA,WS_DATE,C_NAME,COSTH.P_NAME,SOURCE,THICK,WKG,PSF";

                string st1 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY COSTH.WS_NO) AS ROWID,QTY,COSTH.P_NAME,UNIT,BUNIT,BQTY,PRICE,AMOUNT,COSTB.P_NO" +
                            " FROM COSTB, COSTH" +
                            " WHERE COSTB.WS_NO = COSTH.WS_NO AND COSTH.WS_NO = '" + WS_NO + "') a" +
                            " WHERE " + ROWID + "";

                string st2 = "SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY COSTH.WS_NO) AS ROWID,QTY,COSTH.P_NAME,UNIT,BUNIT,BQTY,PRICE,AMOUNT,COSTB.P_NO" +
                            " FROM COSTB, COSTH" +
                            " WHERE COSTB.WS_NO = COSTH.WS_NO AND COSTH.WS_NO = '" + WS_NO + "') a" +
                            " WHERE " + ROWID1 + "";

                DataTable dt = new DataTable();
                dt = con.readdata(sql);
                DataTable dt1 = new DataTable();
                dt1 = con.readdata(st1);
                DataTable dt2 = new DataTable();
                dt2 = con.readdata(st2);

                reportViewer1.LocalReport.ReportEmbeddedResource = "WTERP.WSEXE.Module3._3I.ReportView.rv_Form3I_Tab2.rdlc";

                ReportDataSource rdb = new ReportDataSource("DataSet1", dt);
                ReportDataSource rdb1 = new ReportDataSource("DataSet2", dt1);
                ReportDataSource rdb2 = new ReportDataSource("DataSet3", dt2);

                reportViewer1.LocalReport.DataSources.Add(rdb);
                reportViewer1.LocalReport.DataSources.Add(rdb1);
                reportViewer1.LocalReport.DataSources.Add(rdb2);
            }
            else
            {
                string st = "SELECT COSTB.*,COSTH.*,0 as RowID" +
                            " FROM COSTB, COSTH" +
                            " WHERE COSTB.WS_NO = COSTH.WS_NO AND COSTH.WS_NO = '" + WS_NO + "'" +
                            " ORDER BY COSTH.WS_NO";
                DataTable dt = new DataTable();
                dt = con.readdata(st);

                int size = 1;
                int index = 1;
                for(int i = 1; i <= dt.Rows.Count ; i++)
                {
                    dt.Rows[i-1]["RowID"] = index;
                    index = index + 2;
                    if (size >=3)
                    {
                        if (i == size * 45)
                        {
                            size++;
                            if (size % 2 == 0)
                            {
                                index = (i - 44) + 1;
                            }
                            else
                            {
                                index = i + 1;
                            }
                        }
                    }
                    else
                    {
                        if (i == size * 35)
                        {
                            size++;
                            if (size % 2 == 0)
                            {
                                index = (i - 34) + 1;
                            }
                            else
                            {
                                index = i + 1;
                            }
                        }
                    }
                }

                reportViewer1.LocalReport.ReportEmbeddedResource = "WTERP.WSEXE.Module3._3I.ReportView.rv_Form3I_Tab2_2.rdlc";
                ReportDataSource rdb = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rdb);
            }


            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            this.reportViewer1.RefreshReport();
        }
    }
}
