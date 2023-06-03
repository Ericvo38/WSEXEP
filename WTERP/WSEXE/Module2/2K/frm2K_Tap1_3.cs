using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WTERP
{
    public partial class frm2K_Tap1_3 : Form
    {
        public frm2K_Tap1_3()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            con.CreateButtonToolTipReport(crystalReportViewer1,btnExportExcel_Click);
        }
        protected void Page_Init(object sender, EventArgs e)
        {
        }

        DataProvider con = new DataProvider();
        System.Data.DataTable dt;
        private void frm2K_Tap1_3_Load(object sender, EventArgs e)
        {
            string Date1 = con.formatstr2(frm2K.Date1);
            string CNO = frm2K.txt_CNO;
            // string NP = frm2K.txt_NP;
            string year = Date1.Substring(0, 4);
            string month = Date1.Substring(4, 2);
            bool a = frm2K.rd_HN;
            bool b = frm2K.rd_KHN;
            string st;
            dt = new System.Data.DataTable();

            string cust = "SELECT * FROM dbo.CUST WHERE C_NO1 = '"+ CNO + "'";
            System.Data.DataTable datacust = new System.Data.DataTable();
            datacust = con.readdata(cust);
            string wherecust = "";
            string wherecustGIBB = "";
            string wherecustCATB = "";
            int stt = 0;
            if (datacust.Rows.Count > 0)
            {
                foreach(DataRow item in datacust.Rows)
                {
                    if(stt == 0)
                    {
                        wherecust = wherecust + " AND (CARB.C_NO='" + item["C_NO"].ToString() + "'";
                        wherecustGIBB = wherecustGIBB + " AND (GIBB.C_NO='" + item["C_NO"].ToString() + "'";
                        wherecustCATB = wherecustCATB + " AND (CATB.C_NO='" + item["C_NO"].ToString() + "'";
                    }
                    else
                    {
                        wherecust = wherecust + " or CARB.C_NO='" + item["C_NO"].ToString() + "'";
                        wherecustGIBB = wherecustGIBB + " or GIBB.C_NO='" + item["C_NO"].ToString() + "'";
                        wherecustCATB = wherecustCATB + " or CATB.C_NO='" + item["C_NO"].ToString() + "'";
                    }
                    stt++;
                }
                wherecust = wherecust + ")";
                wherecustGIBB = wherecustGIBB + ")";
                wherecustCATB = wherecustCATB + ")";
            }
            if (b == true)
            {
                st = "SELECT '" + year + "年" + month + "月' as Date,WS_DATE,WS_NO,COLOR,P_NAME3,BQTY,PRICE,AMOUNT,MEMO,CUST.C_ANAME2 from (select a.* from (SELECT RIGHT(CATB.WS_DATE,4) as WS_DATE,CATB.WS_NO + ' ' + CATB.OR_NO as WS_NO,COLOR_C + ' ' + COLOR + '' + P_NAME1 + ' '+P_NAME2 as COLOR,P_NAME3,BQTY,PRICE,AMOUNT,'' as MEMO,CATB.C_NO,'" + frm2K.Username + "' as NR FROM CATB,CATH " +
               "WHERE CATB.WS_NO = CATH.WS_NO  AND CATB.CAL_YM = '" + Date1 + "' AND CATB.C_NO = '" + CNO + "') a " +
               "union ALL " +
               "select b.* from(SELECT RIGHT(CARB.WS_DATE, 4) as WS_DATE, CARB.WS_NO + ' ' + CARB.OR_NO as WS_NO,COLOR_C + ' ' + COLOR + '' + P_NAME1 + ' '+P_NAME2 as COLOR, P_NAME3, BQTY, PRICE, AMOUNT, '' as MEMO, CARB.C_NO,'" + frm2K.Username + "' as NR FROM CARB, CARH " +
               "WHERE CARB.WS_NO = CARH.WS_NO AND CARH.OR_NO NOT LIKE'%作廢%' AND CARB.CAL_YM = '" + Date1 + "' AND CARB.C_NO = '" + CNO + "') b " +
               "union ALL " +
               "Select c.* from(SELECT RIGHT(GIBB.WS_DATE, 4) as WS_DATE, GIBB.WS_NO + ' ' + GIBB.OR_NO as WS_NO,COLOR_C + ' ' + COLOR + '' + P_NAME1 + ' '+P_NAME2 as COLOR, P_NAME3, CASE WHEN BQTY > 0 THEN -BQTY ELSE 0 END AS BQTY,PRICE,CASE WHEN AMOUNT > 0 THEN -AMOUNT ELSE 0 END AS AMOUNT, '' as MEMO, GIBB.C_NO, " +
               " '" + frm2K.Username + "' as NR FROM GIBB, GIBH WHERE GIBH.WS_KIND <> 'S' AND GIBB.WS_NO = GIBH.WS_NO AND GIBB.CAL_YM = '" + Date1 + "' AND GIBB.C_NO = '" + CNO + "') c " +
               ") as d inner join CUST on d.C_NO = CUST.C_NO";
                dt = con.readdata(st);
            }
            if (a == true)
            {
                string st2 = "SELECT '" + year + "年" + month + "月' as Date,WS_DATE,WS_NO,COLOR,P_NAME3,BQTY,PRICE,AMOUNT,MEMO,(SELECT C_ANAME2 FROM CUST WHERE C_NO = '" + CNO + "') as C_ANAME2,'" + frm2K.Username + "' as NR FROM ( SELECT RIGHT(CATB.WS_DATE,4) as WS_DATE,CATB.WS_NO + ' ' + CATB.OR_NO as WS_NO,ISNULL(COLOR_C,'') + ' ' + ISNULL(COLOR,'') + ' ' + ISNULL(P_NAME1,'') + ' '+ISNULL(P_NAME2,'') as COLOR,P_NAME3,BQTY,PRICE,AMOUNT,'' as MEMO,CATB.C_NO,'" + frm2K.Username + "' as NR FROM CATB,CATH WHERE CATB.WS_NO = CATH.WS_NO AND CATB.CAL_YM = '" + Date1 + "' "+wherecustCATB+"" +
                    " union" +
                    " SELECT RIGHT(CARB.WS_DATE, 4) as WS_DATE, CARB.WS_NO + ' ' + CARB.OR_NO as WS_NO,COLOR_C + ' ' + COLOR + '' + P_NAME1 + ' '+P_NAME2 as COLOR, P_NAME3, BQTY, PRICE, AMOUNT, '' as MEMO, CARB.C_NO,'" + frm2K.Username + "' as NR FROM CARB, CARH WHERE CARB.WS_NO = CARH.WS_NO AND CARH.OR_NO NOT LIKE '%作廢%' AND CARB.CAL_YM = '" + Date1 + "' "+ wherecust +") as a order by WS_DATE,WS_NO,NR";
                dt = con.readdata(st2);
                string st3 = "SELECT '" + year + "年" + month + "月' as Date,RIGHT(GIBB.WS_DATE, 4) as WS_DATE, GIBB.WS_NO + ' ' + GIBB.OR_NO as WS_NO,ISNULL(COLOR_C,'') + ' ' + ISNULL(COLOR,'') + ' ' + ISNULL(P_NAME1,'') + ' '+ISNULL(P_NAME2,'') as COLOR, P_NAME3, CASE WHEN BQTY > 0 THEN -BQTY ELSE 0 END AS BQTY,PRICE,CASE WHEN AMOUNT > 0 THEN -AMOUNT ELSE 0 END AS AMOUNT, '' as MEMO, (SELECT C_ANAME2 FROM CUST WHERE C_NO = '" + CNO + "') as C_ANAME2,'" + frm2K.Username + "' as NR FROM GIBB,GIBH WHERE GIBH.WS_KIND<>'S' AND GIBB.WS_NO=GIBH.WS_NO  AND GIBB.CAL_YM='" + Date1 + "' "+ wherecustGIBB +" order by GIBB.K_NO,GIBB.WS_NO ASC";
                System.Data.DataTable dt2 = con.readdata(st3);
                dt.Merge(dt2);
            }
            WSEXE.ReportView.cr_From2K_Tap1_3 rpt = new WSEXE.ReportView.cr_From2K_Tap1_3();
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }

        private void crystalReportViewer1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void crystalReportViewer1_ContextMenuStripChanged(object sender, EventArgs e)
        {
        }
        private void BorderAround(Range range) // Create Boder style Excel File  
        {
            Borders borders = range.Borders;
            borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            borders.Color = Color.Black;
            borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
            borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            string C_ANAME2 = "";
            string DEFA_MONEY = "";
            string sql1 = "SELECT a.C_ANAME2,CASE WHEN a.DEFA_MONEY = (SELECT TOP 1 M_NO FROM dbo.MONEYT WHERE M_NO = a.DEFA_MONEY) THEN a.DEFA_MONEY ELSE ''" +
                " END as DEFA_MONEY FROM CUST a WHERE 1=1";
            if(!string.IsNullOrEmpty(frm2K.txt_CNO))
            {
                sql1 = sql1 + "and c_no = '" + frm2K.txt_CNO + "'";
            }

            System.Data.DataTable dt1 = con.readdata(sql1);
            if (dt1.Rows.Count > 0)
            {
                C_ANAME2 = dt1.Rows[0]["C_ANAME2"].ToString();
                DEFA_MONEY = dt1.Rows[0]["DEFA_MONEY"].ToString();
            }

            int page = 0;
            if ((dt.Rows.Count % 16) == 0)
            {
                page = dt.Rows.Count/16;
            }
            else
            {
                page = (dt.Rows.Count / 16) + 1;
            }
            int pagenumber = 0;
            int rowex = 1;
            int rowList = 0;
            int BorderAround1 = 10;
            int indexrow = 0;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel |*.xls";

            int ColumnsCount;
            if (dt == null || (ColumnsCount = dt.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;

            for (int i = 0; i < page; i++)
            {
                pagenumber = pagenumber + 16;
                // Header
                COMExcel.Worksheet IV = (COMExcel.Worksheet)workbook.Worksheets[1];
                COMExcel.Range Na1 = IV.get_Range("A" + rowex, "O" + rowex);
                Na1.Merge();
                Na1.Value2 = "TOPPING INTERNATIONAL CO.,LTD.";
                Na1.Font.Size = 28;
                Na1.Font.Bold = true;
                Na1.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                COMExcel.Range Na2 = IV.get_Range("A" + (rowex + 1), "O" + (rowex + 1));
                Na2.Merge();
                Na2.Value2 = "WEI TAI (VIETNAM) LEATHER CO., LTD.";
                Na2.Font.Size = 20;
                Na2.Font.Bold = true;
                Na2.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                COMExcel.Range Na3 = IV.get_Range("A" + (rowex + 2), "D" + (rowex + 2));
                Na3.Merge();
                Na3.Value2 = "TWN: CTY TNHH Da Thuộc WEITAI";
                Na3.Font.Size = 8;

                COMExcel.Range Na4 = IV.get_Range("A" + (rowex + 3), "D" + (rowex + 3));
                Na4.Merge();
                Na4.Value2 = "臺灣 :緯達皮革有限公司";
                Na4.Font.Size = 8;

                COMExcel.Range Na6 = IV.get_Range("J" + (rowex + 2), "O" + (rowex + 2));
                Na6.Merge();
                Na6.Value2 = "Việt Nam:công ty TNHH thuộc da wei tai";
                Na6.Font.Size = 8;

                COMExcel.Range Na7 = IV.get_Range("J" + (rowex + 3), "O" + (rowex + 3));
                Na7.Merge();
                Na7.Value2 = "越南：越南緯達皮革有限公司";
                Na7.Font.Size = 8;

                COMExcel.Range Na8 = IV.get_Range("J" + (rowex + 4), "O" + (rowex + 4));
                Na8.Merge();
                Na8.Value2 = "同柰省仁澤縣協福社仁澤3工業區";
                Na8.Font.Size = 8;

                COMExcel.Range Na9 = IV.get_Range("J" + (rowex + 5), "O" + (rowex + 5));
                Na9.Merge();
                Na9.Value2 = "khu công nghiệp nhơn trạch, huyện nhơn trạch,tỉnh đồng nai";
                Na9.Font.Size = 8;
                Na9.RowHeight = 23;
                Na9.WrapText = true;
                Na9.VerticalAlignment = XlVAlign.xlVAlignTop;

                COMExcel.Range Na12 = IV.get_Range("A" + (rowex + 6), "C" + (rowex + 6));
                Na12.Merge();
                Na12.Value2 = "TEL  :84-61-3560886";
                Na12.Font.Size = 8;
                COMExcel.Range Na12_1 = IV.get_Range("A" + (rowex + 7), "C" + (rowex + 7));
                Na12_1.Merge();
                Na12_1.Value2 = "FAX  :886-4-22116683";
                Na12_1.Font.Size = 8;

                COMExcel.Range Na5 = IV.get_Range("E" + (rowex + 3), "I" + (rowex + 4));
                Na5.Merge();
                Na5.Value2 = "請 款 對 帳 單";
                Na5.Font.Size = 20;
                Na5.Font.Bold = true;
                Na5.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                COMExcel.Range Na10 = IV.get_Range("A" + (rowex + 7), "C" + (rowex + 7));
                Na10.Merge();
                Na10.Value2 = "TEL  :886-4-22116696";
                Na10.Font.Size = 8;

                COMExcel.Range Na11 = IV.get_Range("A" + (rowex + 5), "E" + (rowex + 5));
                Na11.Merge();
                Na11.Value2 = "SỐ 98 CẢNG 17 phố giáp tay ấp đông chợ đài trung";
                Na11.Font.Size = 8;
                Na11.VerticalAlignment = XlVAlign.xlVAlignTop;

                COMExcel.Range Na13 = IV.get_Range("E" + (rowex + 7), "I" + (rowex + 7));
                Na13.Merge();
                Na13.Value2 = frm2K.Month_Year.Substring(0, 4) + "年" + frm2K.Month_Year.Substring(5, 2) + "月 請款對帳單";
                Na13.Font.Size = 12;
                Na13.Font.Bold = true;
                Na13.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                COMExcel.Range Na14 = IV.get_Range("B" + (rowex + 8), "G" + (rowex + 8));
                Na14.Merge();
                Na14.Value2 = "" + C_ANAME2 + "";
                Na14.Font.Bold = true;

                COMExcel.Range Na15 = IV.get_Range("H" + (rowex + 8), "J" + (rowex + 8));
                Na15.Merge();
                Na15.Value2 = "幣別:";
                Na15.Font.Bold = true;
                COMExcel.Range Na16 = IV.get_Range("K" + (rowex + 8), "K" + (rowex + 8));
                Na16.Value2 = "" + DEFA_MONEY + "";

                COMExcel.Range Na15_1 = IV.get_Range("L" + (rowex + 8), "N" + (rowex + 8));
                Na15_1.Merge();
                Na15_1.Value2 = (i + 1) + " OF " + page;
                Na15_1.Font.Bold = true;
                Na15_1.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                COMExcel.Range Na17 = IV.get_Range("A" + (rowex + 9), "A" + (rowex + 9));
                Na17.Merge();
                Na17.Value2 = "日期";
                Na17.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range Na18 = IV.get_Range("B" + (rowex + 9), "D" + (rowex + 9));
                Na18.Merge();
                Na18.Value2 = "號  數";
                Na18.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range Na19 = IV.get_Range("E" + (rowex + 9), "F" + (rowex + 9));
                Na19.Merge();
                Na19.Value2 = "品名";
                Na19.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range Na20 = IV.get_Range("G" + (rowex + 9), "G" + (rowex + 9));
                Na20.Value2 = "規格";
                Na20.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range Na21 = IV.get_Range("H" + (rowex + 9), "J" + (rowex + 9));
                Na21.Merge();
                Na21.Value2 = "數量";
                Na21.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range Na22 = IV.get_Range("K" + (rowex + 9), "K" + (rowex + 9));
                Na22.Value2 = "單 價";
                Na22.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range Na23 = IV.get_Range("L" + (rowex + 9), "N" + (rowex + 9));
                Na23.Merge();
                Na23.Value2 = "金額";
                Na23.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range Na24 = IV.get_Range("O" + (rowex + 9), "O" + (rowex + 9));
                Na24.Value2 = "備註";
                Na24.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                for (int j = rowList; j < pagenumber; j++)
                {
                    if (indexrow < dt.Rows.Count)
                    {
                        COMExcel.Range Detail1 = IV.get_Range("A" + (rowex + 10), "A" + (rowex + 11));
                        Detail1.WrapText = true;
                        Detail1.Merge();
                        Detail1.Value2 = dt.Rows[j]["WS_DATE"].ToString();
                        Detail1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        Detail1.ColumnWidth = 5;
                        Detail1.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        COMExcel.Range Detail2 = IV.get_Range("B" + (rowex + 10), "D" + (rowex + 11));
                        Detail2.Merge();
                        Detail2.Value2 = dt.Rows[j]["WS_NO"].ToString();
                        Detail2.WrapText = true;
                        Detail2.ColumnWidth = 6;
                        COMExcel.Range Detail3 = IV.get_Range("E" + (rowex + 10), "F" + (rowex + 11));
                        Detail3.Merge();
                        Detail3.Value2 = dt.Rows[j]["COLOR"].ToString();
                        Detail3.WrapText = true;
                        COMExcel.Range Detail4 = IV.get_Range("G" + (rowex + 10), "G" + (rowex + 11));
                        Detail4.Merge();
                        Detail4.Value2 = dt.Rows[j]["P_NAME3"].ToString();
                        Detail4.WrapText = true;
                        COMExcel.Range Detail5 = IV.get_Range("H" + (rowex + 10), "J" + (rowex + 11));
                        Detail5.Merge();
                        Detail5.Value2 = dt.Rows[j]["BQTY"].ToString();
                        Detail5.WrapText = true;
                        Detail5.ColumnWidth = 2;
                        COMExcel.Range Detail6 = IV.get_Range("K" + (rowex + 10), "K" + (rowex + 11));
                        Detail6.Merge();
                        Detail6.Value2 = dt.Rows[j]["PRICE"].ToString();
                        Detail6.WrapText = true;
                        COMExcel.Range Detail7 = IV.get_Range("L" + (rowex + 10), "N" + (rowex + 11));
                        Detail7.Merge();
                        Detail7.Value2 = dt.Rows[j]["AMOUNT"].ToString();
                        Detail7.WrapText = true;
                        Detail7.ColumnWidth = 3;
                        COMExcel.Range Detail8 = IV.get_Range("O" + (rowex + 10), "O" + (rowex + 11));
                        Detail8.Merge();
                        Detail8.Value2 = dt.Rows[j]["MEMO"].ToString();
                        Detail8.WrapText = true;
                        indexrow++;
                    }
                    else
                    {
                        COMExcel.Range Detail1 = IV.get_Range("A" + (rowex + 10), "A" + (rowex + 11));
                        Detail1.WrapText = true;
                        Detail1.Merge();
                        Detail1.Value2 = "";
                        Detail1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        Detail1.ColumnWidth = 5;
                        Detail1.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        COMExcel.Range Detail2 = IV.get_Range("B" + (rowex + 10), "D" + (rowex + 11));
                        Detail2.Merge();
                        Detail2.Value2 = "";
                        Detail2.WrapText = true;
                        Detail2.ColumnWidth = 6;
                        COMExcel.Range Detail3 = IV.get_Range("E" + (rowex + 10), "F" + (rowex + 11));
                        Detail3.Merge();
                        Detail3.Value2 = "";
                        Detail3.WrapText = true;
                        COMExcel.Range Detail4 = IV.get_Range("G" + (rowex + 10), "G" + (rowex + 11));
                        Detail4.Merge();
                        Detail4.Value2 = "";
                        Detail4.WrapText = true;
                        COMExcel.Range Detail5 = IV.get_Range("H" + (rowex + 10), "J" + (rowex + 11));
                        Detail5.Merge();
                        Detail5.Value2 = "";
                        Detail5.WrapText = true;
                        Detail5.ColumnWidth = 2;
                        COMExcel.Range Detail6 = IV.get_Range("K" + (rowex + 10), "K" + (rowex + 11));
                        Detail6.Merge();
                        Detail6.Value2 = "";
                        Detail6.WrapText = true;
                        COMExcel.Range Detail7 = IV.get_Range("L" + (rowex + 10), "N" + (rowex + 11));
                        Detail7.Merge();
                        Detail7.Value2 = "";
                        Detail7.WrapText = true;
                        Detail7.ColumnWidth = 3;
                        COMExcel.Range Detail8 = IV.get_Range("O" + (rowex + 10), "O" + (rowex + 11));
                        Detail8.Merge();
                        Detail8.Value2 = "";
                        Detail8.WrapText = true;
                    }
                    rowex = rowex + 2;
                }
                COMExcel.Range Na25 = IV.get_Range("A" + (rowex + 10), "O" + (rowex + 10));
                Na25.Merge();
                Na25.Value2 = "  核准:___________   覆核:___________   主管:___________   業務會計:___________   製單:___________";
                rowList = rowList + 16;
                rowex = rowex + 12;
                BorderAround(worksheet.get_Range("A" + (BorderAround1), "O" + (BorderAround1 + 32)));
                BorderAround1 = BorderAround1 + 44;

            }
        }
    }
}
