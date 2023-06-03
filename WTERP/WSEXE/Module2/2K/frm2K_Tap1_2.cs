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
    public partial class frm2K_Tap1_2 : Form
    {

        public frm2K_Tap1_2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            con.CreateButtonToolTipReport(crystalReportViewer1, btnExportExcel_Click);
        }
        DataProvider con = new DataProvider();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        private void frm2K_Tap1_2_Load(object sender, EventArgs e)
        {

            string bien1 = "";
            bool DATE = frm2K.rd_Date;
            bool OR_NO = frm2K.rd_ORNO;

            string Date1 = "";
            if (!string.IsNullOrEmpty(frm2K.Date1))
            {
                Date1 = frm2K.Date1;
            }
            string CNO = frm2K.txt_CNO;
            string NP = frm2K.txt_NP;

            if ((Date1 != string.Empty) && (CNO == string.Empty))
                bien1 = bien1 + " AND A.CAL_YM = '" + con.formatstr2(Date1) + "'";
            if ((CNO != string.Empty) && (Date1 == string.Empty))
                bien1 = bien1 + " AND A.C_NO ='" + CNO + "' ";
            if ((Date1 != string.Empty) && (CNO != string.Empty))
                bien1 = bien1 + " AND  A.CAL_YM = '" + con.formatstr2(Date1) + "' AND A.C_NO ='" + CNO + "'";

            WSEXE.ReportView.cr_From2K_Tap1_2 rpt = new WSEXE.ReportView.cr_From2K_Tap1_2();
            string st = "SELECT A.WS_DATE, A.WS_NO, A.C_NO, A.CAL_YM, A.OR_NO, COLOR, COLOR_C, P_NAME, P_NAME1, P_NAME3, BQTY, PRICE, AMOUNT,B.C_NAME, B.M_TRAN FROM CARB AS A,CARH AS B WHERE A.WS_NO=B.WS_NO " +
                "AND B.OR_NO NOT LIKE '%作廢%' " + bien1 + " ORDER BY A.WS_DATE,A.WS_NO,A.NR";
            dt = con.readdata(st);
            string st2 = "SELECT A.WS_DATE, A.WS_NO, A.C_NO, A.CAL_YM, A.OR_NO, COLOR, COLOR_C, P_NAME, P_NAME1, P_NAME3, (BQTY*-1) as BQTY, PRICE,(AMOUNT*-1) AMOUNT,B.C_NAME, B.M_TRAN FROM GIBB AS A,GIBH AS B WHERE A.WS_KIND <> 'S' " +
                " AND A.WS_NO = B.WS_NO " + bien1 + " ORDER BY A.WS_DATE,A.WS_NO,A.NR";
            dt2 = con.readdata(st2);
            dt.Merge(dt2);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["WS_DATE"] = dr["WS_DATE"].ToString().Substring(4, 4);
                    dr["CAL_YM"] = con.formatstr2(dr["CAL_YM"].ToString());
                }
            }
            rpt.DataDefinition.FormulaFields["cal_ym"].Text = "'" + frm2K.Date1.Substring(0, 4) + "年" + frm2K.Date1.Substring(5, 2) + "月'";
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            int page = 0;
            if ((dt.Rows.Count % 16) == 0)
            {
                page = dt.Rows.Count / 16;
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
                Na1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

                COMExcel.Range Na2 = IV.get_Range("A" + (rowex + 1), "O" + (rowex + 1));
                Na2.Merge();
                Na2.Value2 = "WEI TAI (VIETNAM) LEATHER CO., LTD.";
                Na2.Font.Size = 20;
                Na2.Font.Bold = true;
                Na2.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

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
                Na9.VerticalAlignment = COMExcel.XlVAlign.xlVAlignTop;

                COMExcel.Range Na12 = IV.get_Range("K" + (rowex + 6), "O" + (rowex + 6));
                Na12.Merge();
                Na12.Value2 = "TEL  :84-61-3560886";
                Na12.Font.Size = 8;
                COMExcel.Range Na12_1 = IV.get_Range("K" + (rowex + 7), "O" + (rowex + 7));
                Na12_1.Merge();
                Na12_1.Value2 = "FAX  :84-61-3560883";
                Na12_1.Font.Size = 8;

                COMExcel.Range Na5 = IV.get_Range("E" + (rowex + 3), "I" + (rowex + 4));
                Na5.Merge();
                Na5.Value2 = "請 款 對 帳 單";
                Na5.Font.Size = 20;
                Na5.Font.Bold = true;
                Na5.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

                COMExcel.Range Na10 = IV.get_Range("A" + (rowex + 7), "C" + (rowex + 7));
                Na10.Merge();
                Na10.Value2 = "TEL  :886-4-22116696";
                Na10.Font.Size = 8;

                COMExcel.Range Na_10 = IV.get_Range("A" + (rowex + 8), "C" + (rowex + 8));
                Na_10.Merge();
                Na_10.Value2 = "FAX  :886-4-22116683";
                Na_10.Font.Size = 8;

                COMExcel.Range Na11 = IV.get_Range("A" + (rowex + 5), "E" + (rowex + 5));
                Na11.Merge();
                Na11.Value2 = "SỐ 98 CẢNG 17 phố giáp tay ấp đông chợ đài trung";
                Na11.Font.Size = 8;
                Na11.VerticalAlignment = COMExcel.XlVAlign.xlVAlignTop;

                COMExcel.Range Na13 = IV.get_Range("E" + (rowex + 7), "I" + (rowex + 7));
                Na13.Merge();
                Na13.Value2 = frm2K.Date1.Substring(0, 4) + "年" + frm2K.Date1.Substring(5, 2) + "月 請款對帳單";
                Na13.Font.Size = 12;
                Na13.Font.Bold = true;
                Na13.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

                COMExcel.Range Na14 = IV.get_Range("B" + (rowex + 8), "G" + (rowex + 8));
                Na14.Merge();
                Na14.Value2 = dt.Rows[0]["C_NAME"].ToString();
                Na14.Font.Bold = true;

                COMExcel.Range Na15 = IV.get_Range("H" + (rowex + 8), "J" + (rowex + 8));
                Na15.Merge();
                Na15.Value2 = "幣別:";
                Na15.Font.Bold = true;
                COMExcel.Range Na16 = IV.get_Range("K" + (rowex + 8), "K" + (rowex + 8));
                Na16.Value2 = dt.Rows[0]["M_TRAN"].ToString();

                COMExcel.Range Na15_1 = IV.get_Range("L" + (rowex + 8), "N" + (rowex + 8));
                Na15_1.Merge();
                Na15_1.Value2 = (i + 1) + " OF " + page;
                Na15_1.Font.Bold = true;
                Na15_1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

                COMExcel.Range Na17 = IV.get_Range("A" + (rowex + 9), "A" + (rowex + 9));
                Na17.Merge();
                Na17.Value2 = "日期";
                Na17.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                COMExcel.Range Na18 = IV.get_Range("B" + (rowex + 9), "D" + (rowex + 9));
                Na18.Merge();
                Na18.Value2 = "號  數";
                Na18.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                COMExcel.Range Na19 = IV.get_Range("E" + (rowex + 9), "F" + (rowex + 9));
                Na19.Merge();
                Na19.Value2 = "品名";
                Na19.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                COMExcel.Range Na20 = IV.get_Range("G" + (rowex + 9), "G" + (rowex + 9));
                Na20.Value2 = "規格";
                Na20.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                COMExcel.Range Na21 = IV.get_Range("H" + (rowex + 9), "J" + (rowex + 9));
                Na21.Merge();
                Na21.Value2 = "數量";
                Na21.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                COMExcel.Range Na22 = IV.get_Range("K" + (rowex + 9), "K" + (rowex + 9));
                Na22.Value2 = "單 價";
                Na22.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                COMExcel.Range Na23 = IV.get_Range("L" + (rowex + 9), "N" + (rowex + 9));
                Na23.Merge();
                Na23.Value2 = "金額";
                Na23.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                COMExcel.Range Na24 = IV.get_Range("O" + (rowex + 9), "O" + (rowex + 9));
                Na24.Value2 = "備註";
                Na24.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                for (int j = rowList; j < pagenumber; j++)
                {
                    if (indexrow < dt.Rows.Count)
                    {
                        COMExcel.Range Detail1 = IV.get_Range("A" + (rowex + 10), "A" + (rowex + 11));
                        Detail1.WrapText = true;
                        Detail1.Merge();
                        Detail1.NumberFormat = "@";
                        Detail1.Value2 = dt.Rows[j]["WS_DATE"].ToString();
                        Detail1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        Detail1.ColumnWidth = 5;
                        Detail1.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
                        Detail1.NumberFormat = "Text";

                        COMExcel.Range Detail2 = IV.get_Range("B" + (rowex + 10), "D" + (rowex + 11));
                        Detail2.Merge();
                        Detail2.Value2 = dt.Rows[j]["WS_NO"].ToString() + "\n" + dt.Rows[j]["OR_NO"].ToString();
                        Detail2.WrapText = true;
                        Detail2.ColumnWidth = 6;
                        COMExcel.Range Detail3 = IV.get_Range("E" + (rowex + 10), "F" + (rowex + 11));
                        Detail3.Merge();
                        Detail3.Value2 = dt.Rows[j]["COLOR"].ToString() + "\n" + dt.Rows[j]["P_NAME1"].ToString();
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
                        Detail8.Value2 = "";//dt.Rows[j]["MEMO"].ToString();
                        Detail8.WrapText = true;
                        indexrow++;
                    }
                    else
                    {
                        COMExcel.Range Detail1 = IV.get_Range("A" + (rowex + 10), "A" + (rowex + 11));
                        Detail1.WrapText = true;
                        Detail1.Merge();
                        Detail1.Value2 = "";
                        Detail1.HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                        Detail1.ColumnWidth = 5;
                        Detail1.VerticalAlignment = COMExcel.XlVAlign.xlVAlignCenter;
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
                if (i == page - 1)
                {
                    COMExcel.Range sum = IV.get_Range("H" + (rowex + 10), "J" + (rowex + 10));
                    sum.Merge();
                    sum.Font.Bold = true;
                    sum.NumberFormat = "#,##0.00";
                    sum.Value2 = dt.AsEnumerable().Sum(x => x.Field<double>("BQTY"));

                    COMExcel.Range sum1 = IV.get_Range("L" + (rowex + 10), "N" + (rowex + 10));
                    sum1.Merge();
                    sum1.NumberFormat = "#,##0.00";
                    sum1.Font.Bold = true;
                    sum1.Value2 = dt.AsEnumerable().Sum(x => x.Field<double>("AMOUNT"));
                }

                COMExcel.Range Na25 = IV.get_Range("A" + (rowex + 11), "O" + (rowex + 11));
                Na25.Merge();
                Na25.Value2 = "  核准:___________   覆核:___________   主管:___________   業務會計:___________   製單:___________";
                rowList = rowList + 16;
                rowex = rowex + 12;
                con.BorderAround(worksheet.get_Range("A" + (BorderAround1), "O" + (BorderAround1 + 32)));
                BorderAround1 = BorderAround1 + 44;
            }
        }
    }
}
