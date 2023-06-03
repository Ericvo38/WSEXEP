using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WTERP.WSEXE.ReportView;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace WTERP
{
    public partial class frm2G_Tap7_2 : Form
    {
        DataProvider con = new DataProvider();
        System.Data.DataTable dt = new System.Data.DataTable();
        public frm2G_Tap7_2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            con.CreateButtonToolTipReport(crystalReportViewer1, Export_Excel_Tab7_HangBU);
        }
        int y;
        string CurrenYear, Last1Year, Last2Year, MonthFirs;
        private void Export_Excel_Tab7_HangBU(object sender, EventArgs e)
        {
            Export_Excel_Tab7_HangBU(dt);
        }
        private void frm2G_Tap7_2_Load(object sender, EventArgs e)
        {
            int.TryParse(DateTime.Now.ToString("yyyy"), out y);
            CurrenYear = y + " 年";
            Last1Year = (y - 1) + " 年";
            Last2Year = (y - 2) + " 年";
            MonthFirs = (y - 1) + "/12 月";
            string years = (frm2G.Parameter.YEAR - 1).ToString();
            //WSEXE.ReportView.cr_Form2G_Tap7 rpt = new WSEXE.ReportView.cr_Form2G_Tap7();
            cr_Form2G_Tap7__New rpt = new cr_Form2G_Tap7__New();
            rpt.DataDefinition.FormulaFields["CurrenYear"].Text = "'"+CurrenYear+"'";
            rpt.DataDefinition.FormulaFields["Last1Year"].Text = "'" + Last1Year + "'";
            rpt.DataDefinition.FormulaFields["Last2Year"].Text = "'" + Last2Year + "'";
            rpt.DataDefinition.FormulaFields["MonthFirs"].Text = "'" + MonthFirs + "'";

            string SQL = "proc_2DTab7_HangBu '" + frm2G.Parameter.K_NO + "',N'" + frm2G.Parameter.YEAR + "', N'%" + frm2G.Parameter.KHUVUC + "%','"+ frm2G.Parameter.Months+ "'";
            dt = con.readdata(SQL);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
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
        private static void releaseObject(object obj) // Clear COM Memory  
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public void Export_Excel_Tab7_HangBU(System.Data.DataTable da)
        {
            int ColumnsCount;
            int RowsCount = da.Rows.Count;
            int a = 3;
            if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;

            // Header
            worksheet.Cells[a - 1, 1] = "客戶(Customer)";
            worksheet.Cells[a - 1, 2] = Last2Year;
            worksheet.Cells[a - 1, 3] = Last1Year;
            worksheet.Cells[a - 1, 4] = CurrenYear;
            worksheet.Cells[a - 1, 5] = MonthFirs;
            worksheet.Cells[a - 1, 6] = "1月";
            worksheet.Cells[a - 1, 7] = "2月";
            worksheet.Cells[a - 1, 8] = "3月";
            worksheet.Cells[a - 1, 9] = "4月";
            worksheet.Cells[a - 1, 10] = "5月";
            worksheet.Cells[a - 1, 11] = "6月";
            worksheet.Cells[a - 1, 12] = "7月";
            worksheet.Cells[a - 1, 13] = "8月";
            worksheet.Cells[a - 1, 14] = "9月";
            worksheet.Cells[a - 1, 15] = "10月";
            worksheet.Cells[a - 1, 16] = "11月";
            COMExcel.Range Title = worksheet.get_Range("A" + (a - 1), "P" + (a - 1));
            Title.Font.Size = 14;
            Title.Font.Bold = true;
            Title.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Title.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.DodgerBlue);
            Title.Font.Color = Color.White;


            // Show DataTable 
            object[,] Cells = new object[RowsCount, ColumnsCount];
            for (int i = 0; i < RowsCount; i++)
            {

                COMExcel.Range C_NAME = worksheet.get_Range("A" + a, "A" + a);               
                C_NAME.Value2 = da.Rows[i]["C_NAME"].ToString();

                COMExcel.Range Customer = worksheet.get_Range("A" + a, "P" + a);
                Customer.Merge();
                Title.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                Customer.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Gainsboro);
                Customer.Font.Bold = true;
                Customer.Font.Color = Color.Red;

                COMExcel.Range Y01_Customer = worksheet.get_Range("A" + (a + 1), "A" + (a + 1));
                Y01_Customer.Value2 = "出貨數量";
                COMExcel.Range Y02_Customer = worksheet.get_Range("A" + (a + 2), "A" + (a + 2));
                Y02_Customer.Value2 = "退貨數量";
                COMExcel.Range Y03_Customer = worksheet.get_Range("A" + (a + 3), "A" + (a + 3));
                Y03_Customer.Value2 = "退貨率%";
                COMExcel.Range Y04_Customer = worksheet.get_Range("A" + (a + 4), "A" + (a + 4));
                Y04_Customer.Value2 = "折補數量";
                COMExcel.Range Y05_Customer = worksheet.get_Range("A" + (a + 5), "A" + (a + 5));
                Y05_Customer.Value2 = "折補率%";
              
                COMExcel.Range Y01 = worksheet.get_Range("B" + (a + 1), "B" + (a + 1));
                Y01.NumberFormat = "#,##0.00";
                Y01.Value2 = da.Rows[i]["Y01"].ToString();
                COMExcel.Range Y01C = worksheet.get_Range("B" + (a + 2), "B" + (a + 2));
                Y01C.NumberFormat = "#,##0.00";
                Y01C.Value2 = da.Rows[i]["Y01C"].ToString();
                COMExcel.Range Y01CP = worksheet.get_Range("B" + (a + 3), "B" + (a + 3));
                Y01CP.NumberFormat = "#,##0.00";
                Y01CP.Value2 = da.Rows[i]["Y01CP"].ToString();
                COMExcel.Range Y01T = worksheet.get_Range("B" + (a + 4), "B" + (a + 4));
                Y01T.NumberFormat = "#,##0.00";
                Y01T.Value2 = da.Rows[i]["Y01T"].ToString();
                COMExcel.Range Y01TP = worksheet.get_Range("B" + (a + 5), "B" + (a + 5));
                Y01TP.NumberFormat = "#,##0.00";
                Y01TP.Value2 = da.Rows[i]["Y01TP"].ToString();

                COMExcel.Range Y02 = worksheet.get_Range("C" + (a + 1), "C" + (a + 1));
                Y02.NumberFormat = "#,##0.00";
                Y02.Value2 = da.Rows[i]["Y02"].ToString();
                COMExcel.Range Y02C = worksheet.get_Range("C" + (a + 2), "C" + (a + 2));
                Y02C.NumberFormat = "#,##0.00";
                Y02C.Value2 = da.Rows[i]["Y02C"].ToString();
                COMExcel.Range Y02CP = worksheet.get_Range("C" + (a + 3), "C" + (a + 3));
                Y02CP.NumberFormat = "#,##0.00";
                Y02CP.Value2 = da.Rows[i]["Y02CP"].ToString();
                COMExcel.Range Y02T = worksheet.get_Range("C" + (a + 4), "C" + (a + 4));
                Y02T.NumberFormat = "#,##0.00";
                Y02T.Value2 = da.Rows[i]["Y02T"].ToString();
                COMExcel.Range Y02TP = worksheet.get_Range("C" + (a + 5), "C" + (a + 5));
                Y02TP.NumberFormat = "#,##0.00";
                Y02TP.Value2 = da.Rows[i]["Y02TP"].ToString();

                COMExcel.Range M13 = worksheet.get_Range("D" + (a + 1), "D" + (a + 1));
                M13.NumberFormat = "#,##0.00";
                M13.Value2 = da.Rows[i]["M13"].ToString();
                COMExcel.Range M13C = worksheet.get_Range("D" + (a + 2), "D" + (a + 2));
                M13C.NumberFormat = "#,##0.00";
                M13C.Value2 = da.Rows[i]["M13C"].ToString();
                COMExcel.Range M13CP = worksheet.get_Range("D" + (a + 3), "D" + (a + 3));
                M13CP.NumberFormat = "#,##0.00";
                M13CP.Value2 = da.Rows[i]["M13CP"].ToString();
                COMExcel.Range M13T = worksheet.get_Range("D" + (a + 4), "D" + (a + 4));
                M13T.NumberFormat = "#,##0.00";
                M13T.Value2 = da.Rows[i]["M13T"].ToString();
                COMExcel.Range M13TP = worksheet.get_Range("D" + (a + 5), "D" + (a + 5));
                M13TP.NumberFormat = "#,##0.00";
                M13TP.Value2 = da.Rows[i]["M13TP"].ToString();

                COMExcel.Range M12 = worksheet.get_Range("E" + (a + 1), "E" + (a + 1));
                M12.NumberFormat = "#,##0.00";
                M12.Value2 = da.Rows[i]["M12"].ToString();
                COMExcel.Range M12C = worksheet.get_Range("E" + (a + 2), "E" + (a + 2));
                M12C.NumberFormat = "#,##0.00";
                M12C.Value2 = da.Rows[i]["M12C"].ToString();
                COMExcel.Range M12CP = worksheet.get_Range("E" + (a + 3), "E" + (a + 3));
                M12CP.NumberFormat = "#,##0.00";
                M12CP.Value2 = da.Rows[i]["M12CP"].ToString();
                COMExcel.Range M12T = worksheet.get_Range("E" + (a + 4), "E" + (a + 4));
                M12T.NumberFormat = "#,##0.00";
                M12T.Value2 = da.Rows[i]["M12T"].ToString();
                COMExcel.Range M12TP = worksheet.get_Range("E" + (a + 5), "E" + (a + 5));
                M12TP.NumberFormat = "#,##0.00";
                M12TP.Value2 = da.Rows[i]["M12TP"].ToString();

                COMExcel.Range M01 = worksheet.get_Range("F" + (a + 1), "F" + (a + 1));
                M01.NumberFormat = "#,##0.00";
                M01.Value2 = da.Rows[i]["M01"].ToString();
                COMExcel.Range M01C = worksheet.get_Range("F" + (a + 2), "F" + (a + 2));
                M01C.NumberFormat = "#,##0.00";
                M01C.Value2 = da.Rows[i]["M01C"].ToString();
                COMExcel.Range M01CP = worksheet.get_Range("F" + (a + 3), "F" + (a + 3));
                M01CP.NumberFormat = "#,##0.00";
                M01CP.Value2 = da.Rows[i]["M01CP"].ToString();
                COMExcel.Range M01T = worksheet.get_Range("F" + (a + 4), "F" + (a + 4));
                M01T.NumberFormat = "#,##0.00";
                M01T.Value2 = da.Rows[i]["M01T"].ToString();
                COMExcel.Range M01TP = worksheet.get_Range("F" + (a + 5), "F" + (a + 5));
                M01TP.NumberFormat = "#,##0.00";
                M01TP.Value2 = da.Rows[i]["M01TP"].ToString();

                COMExcel.Range M02 = worksheet.get_Range("G" + (a + 1), "G" + (a + 1));
                M02.NumberFormat = "#,##0.00";
                M02.Value2 = da.Rows[i]["M02"].ToString();
                COMExcel.Range M02C = worksheet.get_Range("G" + (a + 2), "G" + (a + 2));
                M02C.NumberFormat = "#,##0.00";
                M02C.Value2 = da.Rows[i]["M02C"].ToString();
                COMExcel.Range M02CP = worksheet.get_Range("G" + (a + 3), "G" + (a + 3));
                M02CP.NumberFormat = "#,##0.00";
                M02CP.Value2 = da.Rows[i]["M02CP"].ToString();
                COMExcel.Range M02T = worksheet.get_Range("G" + (a + 4), "G" + (a + 4));
                M02T.NumberFormat = "#,##0.00";
                M02T.Value2 = da.Rows[i]["M02T"].ToString();
                COMExcel.Range M02TP = worksheet.get_Range("G" + (a + 5), "G" + (a + 5));
                M02TP.NumberFormat = "#,##0.00";
                M02TP.Value2 = da.Rows[i]["M02TP"].ToString();

                COMExcel.Range M03 = worksheet.get_Range("H" + (a + 1), "H" + (a + 1));
                M03.NumberFormat = "#,##0.00";
                M03.Value2 = da.Rows[i]["M03"].ToString();
                COMExcel.Range M03C = worksheet.get_Range("H" + (a + 2), "H" + (a + 2));
                M03C.NumberFormat = "#,##0.00";
                M03C.Value2 = da.Rows[i]["M03C"].ToString();
                COMExcel.Range M03CP = worksheet.get_Range("H" + (a + 3), "H" + (a + 3));
                M03CP.NumberFormat = "#,##0.00";
                M03CP.Value2 = da.Rows[i]["M03CP"].ToString();
                COMExcel.Range M03T = worksheet.get_Range("H" + (a + 4), "H" + (a + 4));
                M03T.NumberFormat = "#,##0.00";
                M03T.Value2 = da.Rows[i]["M03T"].ToString();
                COMExcel.Range M03TP = worksheet.get_Range("H" + (a + 5), "H" + (a + 5));
                M03TP.NumberFormat = "#,##0.00";
                M03TP.Value2 = da.Rows[i]["M03TP"].ToString();

                COMExcel.Range M04 = worksheet.get_Range("I" + (a + 1), "I" + (a + 1));
                M04.NumberFormat = "#,##0.00";
                M04.Value2 = da.Rows[i]["M04"].ToString();
                COMExcel.Range M04C = worksheet.get_Range("I" + (a + 2), "I" + (a + 2));
                M04C.NumberFormat = "#,##0.00";
                M04C.Value2 = da.Rows[i]["M04C"].ToString();
                COMExcel.Range M04CP = worksheet.get_Range("I" + (a + 3), "I" + (a + 3));
                M04CP.NumberFormat = "#,##0.00";
                M04CP.Value2 = da.Rows[i]["M04CP"].ToString();
                COMExcel.Range M04T = worksheet.get_Range("I" + (a + 4), "I" + (a + 4));
                M04T.NumberFormat = "#,##0.00";
                M04T.Value2 = da.Rows[i]["M04T"].ToString();
                COMExcel.Range M04TP = worksheet.get_Range("I" + (a + 5), "I" + (a + 5));
                M04TP.NumberFormat = "#,##0.00";
                M04TP.Value2 = da.Rows[i]["M04TP"].ToString();

                COMExcel.Range M05 = worksheet.get_Range("J" + (a + 1), "J" + (a + 1));
                M05.NumberFormat = "#,##0.00";
                M05.Value2 = da.Rows[i]["M05"].ToString();
                COMExcel.Range M05C = worksheet.get_Range("J" + (a + 2), "J" + (a + 2));
                M05C.NumberFormat = "#,##0.00";
                M05C.Value2 = da.Rows[i]["M05C"].ToString();
                COMExcel.Range M05CP = worksheet.get_Range("J" + (a + 3), "J" + (a + 3));
                M05CP.NumberFormat = "#,##0.00";
                M05CP.Value2 = da.Rows[i]["M05CP"].ToString();
                COMExcel.Range M05T = worksheet.get_Range("J" + (a + 4), "J" + (a + 4));
                M05T.NumberFormat = "#,##0.00";
                M05T.Value2 = da.Rows[i]["M05T"].ToString();
                COMExcel.Range M05TP = worksheet.get_Range("J" + (a + 5), "J" + (a + 5));
                M05TP.NumberFormat = "#,##0.00";
                M05TP.Value2 = da.Rows[i]["M05TP"].ToString();

                COMExcel.Range M06 = worksheet.get_Range("K" + (a + 1), "K" + (a + 1));
                M06.NumberFormat = "#,##0.00";
                M06.Value2 = da.Rows[i]["M06"].ToString();
                COMExcel.Range M06C = worksheet.get_Range("K" + (a + 2), "K" + (a + 2));
                M06C.NumberFormat = "#,##0.00";
                M06C.Value2 = da.Rows[i]["M06C"].ToString();
                COMExcel.Range M06CP = worksheet.get_Range("K" + (a + 3), "K" + (a + 3));
                M06CP.NumberFormat = "#,##0.00";
                M06CP.Value2 = da.Rows[i]["M06CP"].ToString();
                COMExcel.Range M06T = worksheet.get_Range("K" + (a + 4), "K" + (a + 4));
                M06T.NumberFormat = "#,##0.00";
                M06T.Value2 = da.Rows[i]["M06T"].ToString();
                COMExcel.Range M06TP = worksheet.get_Range("K" + (a + 5), "K" + (a + 5));
                M06TP.NumberFormat = "#,##0.00";
                M06TP.Value2 = da.Rows[i]["M06TP"].ToString();

                COMExcel.Range M07 = worksheet.get_Range("L" + (a + 1), "L" + (a + 1));
                M07.NumberFormat = "#,##0.00";
                M07.Value2 = da.Rows[i]["M07"].ToString();
                COMExcel.Range M07C = worksheet.get_Range("L" + (a + 2), "L" + (a + 2));
                M07C.NumberFormat = "#,##0.00";
                M07C.Value2 = da.Rows[i]["M07C"].ToString();
                COMExcel.Range M07CP = worksheet.get_Range("L" + (a + 3), "L" + (a + 3));
                M07CP.NumberFormat = "#,##0.00";
                M07CP.Value2 = da.Rows[i]["M07CP"].ToString();
                COMExcel.Range M07T = worksheet.get_Range("L" + (a + 4), "L" + (a + 4));
                M07T.NumberFormat = "#,##0.00";
                M07T.Value2 = da.Rows[i]["M07T"].ToString();
                COMExcel.Range M07TP = worksheet.get_Range("L" + (a + 5), "L" + (a + 5));
                M07TP.NumberFormat = "#,##0.00";
                M07TP.Value2 = da.Rows[i]["M07TP"].ToString();

                COMExcel.Range M08 = worksheet.get_Range("M" + (a + 1), "M" + (a + 1));
                M08.NumberFormat = "#,##0.00";
                M08.Value2 = da.Rows[i]["M08"].ToString();
                COMExcel.Range M08C = worksheet.get_Range("M" + (a + 2), "M" + (a + 2));
                M08C.NumberFormat = "#,##0.00";
                M08C.Value2 = da.Rows[i]["M08C"].ToString();
                COMExcel.Range M08CP = worksheet.get_Range("M" + (a + 3), "M" + (a + 3));
                M08CP.NumberFormat = "#,##0.00";
                M08CP.Value2 = da.Rows[i]["M08CP"].ToString();
                COMExcel.Range M08T = worksheet.get_Range("M" + (a + 4), "M" + (a + 4));
                M08T.NumberFormat = "#,##0.00";
                M08T.Value2 = da.Rows[i]["M08T"].ToString();
                COMExcel.Range M08TP = worksheet.get_Range("M" + (a + 5), "M" + (a + 5));
                M08TP.NumberFormat = "#,##0.00";
                M08TP.Value2 = da.Rows[i]["M08TP"].ToString();

                COMExcel.Range M09 = worksheet.get_Range("N" + (a + 1), "N" + (a + 1));
                M09.NumberFormat = "#,##0.00";
                M09.Value2 = da.Rows[i]["M09"].ToString();
                COMExcel.Range M09C = worksheet.get_Range("N" + (a + 2), "N" + (a + 2));
                M09C.NumberFormat = "#,##0.00";
                M09C.Value2 = da.Rows[i]["M09C"].ToString();
                COMExcel.Range M09CP = worksheet.get_Range("N" + (a + 3), "N" + (a + 3));
                M09CP.NumberFormat = "#,##0.00";
                M09CP.Value2 = da.Rows[i]["M09CP"].ToString();
                COMExcel.Range M09T = worksheet.get_Range("N" + (a + 4), "N" + (a + 4));
                M09T.NumberFormat = "#,##0.00";
                M09T.Value2 = da.Rows[i]["M09T"].ToString();
                COMExcel.Range M09TP = worksheet.get_Range("N" + (a + 5), "N" + (a + 5));
                M09TP.NumberFormat = "#,##0.00";
                M09TP.Value2 = da.Rows[i]["M09TP"].ToString();

                COMExcel.Range M10 = worksheet.get_Range("O" + (a + 1), "O" + (a + 1));
                M10.NumberFormat = "#,##0.00";
                M10.Value2 = da.Rows[i]["M10"].ToString();
                COMExcel.Range M10C = worksheet.get_Range("O" + (a + 2), "O" + (a + 2));
                M10C.NumberFormat = "#,##0.00";
                M10C.Value2 = da.Rows[i]["M10C"].ToString();
                COMExcel.Range M10CP = worksheet.get_Range("O" + (a + 3), "O" + (a + 3));
                M10CP.NumberFormat = "#,##0.00";
                M10CP.Value2 = da.Rows[i]["M10CP"].ToString();
                COMExcel.Range M10T = worksheet.get_Range("O" + (a + 4), "O" + (a + 4));
                M10T.NumberFormat = "#,##0.00";
                M10T.Value2 = da.Rows[i]["M10T"].ToString();
                COMExcel.Range M10TP = worksheet.get_Range("O" + (a + 5), "O" + (a + 5));
                M10TP.NumberFormat = "#,##0.00";
                M10TP.Value2 = da.Rows[i]["M10TP"].ToString();

                COMExcel.Range M11 = worksheet.get_Range("P" + (a + 1), "P" + (a + 1));
                M11.NumberFormat = "#,##0.00";
                M11.Value2 = da.Rows[i]["M11"].ToString();
                COMExcel.Range M11C = worksheet.get_Range("P" + (a + 2), "P" + (a + 2));
                M11C.NumberFormat = "#,##0.00";
                M11C.Value2 = da.Rows[i]["M11C"].ToString();
                COMExcel.Range M11CP = worksheet.get_Range("P" + (a + 3), "P" + (a + 3));
                M11CP.NumberFormat = "#,##0.00";
                M11CP.Value2 = da.Rows[i]["M11CP"].ToString();
                COMExcel.Range M11T = worksheet.get_Range("P" + (a + 4), "P" + (a + 4));
                M11T.NumberFormat = "#,##0.00";
                M11T.Value2 = da.Rows[i]["M11T"].ToString();
                COMExcel.Range M11TP = worksheet.get_Range("P" + (a + 5), "P" + (a + 5));
                M11TP.NumberFormat = "#,##0.00";
                M11TP.Value2 = da.Rows[i]["M11TP"].ToString();

                a = a + 6;
            }

            //Kẻ khung toàn bộ
            int hang = RowsCount + a;
            BorderAround(worksheet.get_Range("A2", "P" + a));

            //Auto Size
            worksheet.Columns.AutoFit();
            //}

            //thoát và thu hồi bộ nhớ cho COMy
            app.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);
        }
    }
}
