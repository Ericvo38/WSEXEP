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
using System.IO;
using COMExcel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace WTERP
{
    public partial class frm1IF7_Tab1_21 : Form
    {
        DataProvider connect = new DataProvider();
        public frm1IF7_Tab1_21()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            connect.CreateButtonToolTipReport(crystalReportViewer1, ExportExcel_Click);
        }

        private void ExportExcel_Click(object sender, EventArgs e)
        {
            decimal page = (decimal.Parse(dt.Rows.Count.ToString()) / 9);
            int pagenumber = 0;
            if (page % 9 != 0)
            {
                pagenumber = pagenumber + 1;
            }
            string w_Path = connect.CopyTemplateExcel("1I_F7_Tab1_22.xls");
            if (w_Path == "")
            {
                return;
            }

            COMExcel.Application app = new COMExcel.Application();
            object valueMissing = System.Reflection.Missing.Value;

            COMExcel.Workbook book = app.Workbooks.Open(w_Path, valueMissing,
            false, valueMissing, valueMissing, valueMissing, valueMissing,
            COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
            valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);

            app.Visible = true;

            int ColumnsCount;
            if (dt == null || (ColumnsCount = dt.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");

            COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

            COMExcel.Range Na1 = IV.get_Range("B6", "D6");
            Na1.Value2 = dt.Rows[0]["C_NAME"].ToString();

            COMExcel.Range Na2 = IV.get_Range("B7", "D7");
            Na2.Value2 = dt.Rows[0]["SPEAK"].ToString();

            COMExcel.Range Na3 = IV.get_Range("B8", "D8");
            Na3.Value2 = dt.Rows[0]["SPEAK_CC"].ToString();

            COMExcel.Range Na4 = IV.get_Range("G6", "I6");
            Na4.Value2 = dt.Rows[0]["W_FROM"].ToString();

            COMExcel.Range Na5 = IV.get_Range("G7", "I7");
            Na5.Value2 = dt.Rows[0]["W_CC"].ToString();

            COMExcel.Range Na10 = IV.get_Range("H9", "I9");
            Na10.Value2 = pagenumber + " OF " + pagenumber;

            COMExcel.Range Na6 = IV.get_Range("H10", "I10");
            Na6.Value2 = dt.Rows[0]["C_NO"].ToString();

            COMExcel.Range Na7 = IV.get_Range("H11", "I11");
            Na7.Value2 = dt.Rows[0]["WS_NO"].ToString();

            COMExcel.Range Na8 = IV.get_Range("H12", "I12");
            Na8.Value2 = dt.Rows[0]["MEMO20"].ToString();

            COMExcel.Range Na9 = IV.get_Range("D12", "E12");
            Na9.Value2 = DateTime.Now.ToString("dd/MM/yyyy");

            int a = 14;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                COMExcel.Range P_NO = IV.get_Range("A" + a, "A" + a);
                P_NO.Value2 = dt.Rows[i]["P_NO"].ToString();
                P_NO.RowHeight = 28.8;
                P_NO.VerticalAlignment = XlVAlign.xlVAlignCenter;
                COMExcel.Range P_NAME = IV.get_Range("B" + a, "C" + a);
                P_NAME.Merge();
                P_NAME.Value2 = GetNameCustomer(int.Parse(dt.Rows[i]["RB"].ToString()), dt.Rows[i]["P_NAME"].ToString(), dt.Rows[i]["P_NAME1"].ToString(), dt.Rows[i]["P_NAME2"].ToString());
                P_NAME.VerticalAlignment = XlVAlign.xlVAlignCenter;
                P_NAME.WrapText = true;
                COMExcel.Range PBT01 = IV.get_Range("D" + a, "D" + a);
                PBT01.Value2 = dt.Rows[i]["PBT01"].ToString();
                PBT01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                PBT01.WrapText = true;
                PBT01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range PBT02 = IV.get_Range("E" + a, "E" + a);
                PBT02.Value2 = dt.Rows[i]["PBT02"].ToString();
                PBT02.VerticalAlignment = XlVAlign.xlVAlignCenter;
                PBT02.WrapText = true;
                PBT02.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range PBT03 = IV.get_Range("F" + a, "F" + a);
                PBT03.Value2 = dt.Rows[i]["PBT03"].ToString();
                PBT03.VerticalAlignment = XlVAlign.xlVAlignCenter;
                PBT03.WrapText = true;
                PBT03.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range PBT04 = IV.get_Range("G" + a, "G" + a);
                PBT04.Value2 = dt.Rows[i]["PBT04"].ToString();
                PBT04.VerticalAlignment = XlVAlign.xlVAlignCenter;
                PBT04.WrapText = true;
                PBT04.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range P_NAME3 = IV.get_Range("H" + a, "H" + a);
                P_NAME3.Value2 = dt.Rows[i]["P_NAME3"].ToString();
                P_NAME3.VerticalAlignment = XlVAlign.xlVAlignCenter;
                P_NAME3.WrapText = true;
                P_NAME3.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                COMExcel.Range PRICE = IV.get_Range("I" + a, "I" + a);
                PRICE.Value2 = dt.Rows[i]["PRICE"].ToString();
                PRICE.VerticalAlignment = XlVAlign.xlVAlignCenter;
                PRICE.WrapText = true;
                PRICE.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                a++;
            }
            BorderAround(IV.get_Range("A14", "I" + (13 + dt.Rows.Count)));

            int numfot = dt.Rows.Count + 14;
            COMExcel.Range FOT = IV.get_Range("A" + numfot, "B" + numfot);
            FOT.Merge();
            FOT.Value2 = "REMARKS:";
            COMExcel.Range FOT2 = IV.get_Range("A" + (numfot + 1), "I" + (numfot + 1));
            FOT2.Merge();
            FOT2.Value2 = dt.Rows[0]["MEMO1"].ToString(); ;
            COMExcel.Range FOT3 = IV.get_Range("A" + (numfot + 2), "I" + (numfot + 2));
            FOT3.Merge();
            FOT3.Value2 = dt.Rows[0]["MEMO2"].ToString();
            COMExcel.Range FOT4 = IV.get_Range("A" + (numfot + 3), "I" + (numfot + 3));
            FOT4.Merge();
            FOT4.Value2 = dt.Rows[0]["MEMO3"].ToString();
            COMExcel.Range FOT5 = IV.get_Range("A" + (numfot + 4), "I" + (numfot + 4));
            FOT5.Merge();
            FOT5.Value2 = dt.Rows[0]["MEMO4"].ToString();
            COMExcel.Range FOT6 = IV.get_Range("A" + (numfot + 5), "I" + (numfot + 5));
            FOT6.Merge();
            FOT6.Value2 = dt.Rows[0]["MEMO5"].ToString();
            COMExcel.Range FOT7 = IV.get_Range("A" + (numfot + 6), "I" + (numfot + 6));
            FOT7.Merge();
            FOT7.Value2 = dt.Rows[0]["MEMO6"].ToString();

            numfot = (numfot + 6);
            if (numfot < (39 - (dt.Rows.Count)))
            {
                for (int i = numfot + 1; i <= (39 - (dt.Rows.Count)); i++)
                {
                    COMExcel.Range i1 = IV.get_Range("A" + i, "A" + i);
                    i1.Value2 = "";
                    numfot++;
                }
            }

            int g = 0;
            if (dt.Rows.Count >= 10 && dt.Rows.Count <= 13)
            {
                g = (g + 6);
            }

            COMExcel.Range FOT8 = IV.get_Range("A" + (numfot + (g + 1)), "B" + (numfot + (g + 1)));
            FOT8.Merge();
            FOT8.Value2 = "Signature";
            COMExcel.Range FOT14 = IV.get_Range("C" + (numfot + (g + 2)), "F" + (numfot + (g + 4)));
            FOT14.Merge();
            FOT14.Value2 = "";
            COMExcel.Range FOT15 = IV.get_Range("G" + (numfot + (g + 2)), "I" + (numfot + (g + 4)));
            FOT15.Merge();
            FOT15.Value2 = "";
            COMExcel.Range FOT16 = IV.get_Range("A" + (numfot + (g + 2)), "B" + (numfot + (g + 4)));
            FOT16.Merge();
            FOT16.Value2 = "";

            COMExcel.Range FOT10 = IV.get_Range("A" + (numfot + (g + 5)), "B" + (numfot + (g + 5)));
            FOT10.Merge();
            FOT10.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            FOT10.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            FOT10.Value2 = dt.Rows[0]["C_NAME"].ToString();
            COMExcel.Range FOT11 = IV.get_Range("C" + (numfot + (g + 5)), "F" + (numfot + (g + 5)));
            FOT11.Merge();
            FOT11.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            FOT11.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            FOT11.Value2 = "WEI TAI (VIETNAM) LEATHER CO.,LTD";
            COMExcel.Range FOT12 = IV.get_Range("G" + (numfot + (g + 5)), "I" + (numfot + (g + 5)));
            FOT12.Merge();
            FOT12.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            FOT12.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            FOT12.Value2 = "TOPPING INTERNATION CO,.LTD";

            app.Quit();
            releaseObject(book);
            releaseObject(book);
            releaseObject(app);
        }

        DataTable dt;
        private void frm1IF7_Tab1_21_Load(object sender, EventArgs e)
        {
            bool R1 = Form1IF7.RD.R1;
            bool R2 = Form1IF7.RD.R2;
            bool R3 = Form1IF7.RD.R3;
            bool R4 = Form1IF7.RD.R4;
            bool R5 = Form1IF7.RD.R5;
            bool R6 = Form1IF7.RD.R6;
            bool R7 = Form1IF7.RD.R7;
            bool R8 = Form1IF7.RD.R8;
            string S = Form1IF7.DL.S1;

            string st = "";
            if (R1 == true)
            {
                st = "select *,1 as RB,convert(varchar, getdate(), 107) as Dates from QUOH JOIN QUOB ON QUOH.WS_NO = QUOB.WS_NO where QUOH.WS_NO = '" + S + "'";
            }
            else if (R2 == true)
            {
                st = "select *,2 as RB,convert(varchar, getdate(), 107) as Dates from QUOH JOIN QUOB ON QUOH.WS_NO = QUOB.WS_NO where QUOH.WS_NO = '" + S + "'";
            }
            else if (R3 == true)
            {
                st = "select *,3 as RB,convert(varchar, getdate(), 107) as Dates from QUOH JOIN QUOB ON QUOH.WS_NO = QUOB.WS_NO where QUOH.WS_NO = '" + S + "'";
            }
            else if (R4 == true)
            {
                st = "select *,4 as RB,convert(varchar, getdate(), 107) as Dates from QUOH JOIN QUOB ON QUOH.WS_NO = QUOB.WS_NO where QUOH.WS_NO = '" + S + "'";
            }
            else if (R5 == true)
            {
                st = "select *,5 as RB,convert(varchar, getdate(), 107) as Dates from QUOH JOIN QUOB ON QUOH.WS_NO = QUOB.WS_NO where QUOH.WS_NO = '" + S + "'";
            }
            else if (R6 == true)
            {
                st = "select *,6 as RB,convert(varchar, getdate(), 107) as Dates from QUOH JOIN QUOB ON QUOH.WS_NO = QUOB.WS_NO where QUOH.WS_NO = '" + S + "'";
            }
            else if (R7 == true)
            {
                st = "select *,7 as RB,convert(varchar, getdate(), 107) as Dates from QUOH JOIN QUOB ON QUOH.WS_NO = QUOB.WS_NO where QUOH.WS_NO = '" + S + "'";
            }
            else if (R8 == true)
            {
                st = "select *,8 as RB,convert(varchar, getdate(), 107) as Dates from QUOH JOIN QUOB ON QUOH.WS_NO = QUOB.WS_NO where QUOH.WS_NO = '" + S + "'";
            }
            WSEXE.ReportView.cr_Form1I_Tab1_21 rpt = new WSEXE.ReportView.cr_Form1I_Tab1_21();
            dt = connect.readdata(st);
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
        public string GetNameCustomer(int RB,string P_NAME,string P_NAME1,string P_NAME2)
        {
            string resuce = "";
            if (RB == 1){
                resuce = P_NAME + " " + P_NAME1;
            }else if(RB ==2)
            {
                resuce = P_NAME + " " + P_NAME2;
            }else if(RB == 3)
            {
                resuce = P_NAME1 + " " + P_NAME2;
            }else if (RB== 4)
            {
                resuce = P_NAME;
            }else if(RB == 5)
            {
                resuce = P_NAME1;
            }else if(RB == 6)
            {
                resuce = P_NAME2;
            }else if(RB == 7)
            {
                resuce = P_NAME1;
            }
            else if(RB== 8) {
                resuce = P_NAME2;
            }
            return resuce;
        }
    }
}
