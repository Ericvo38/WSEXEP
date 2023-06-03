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

namespace WTERP
{
    public partial class frm1IF7_Tab1_3 : Form
    {
        DataProvider conn = new DataProvider();
        public frm1IF7_Tab1_3()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            conn.CreateButtonToolTipReport(crystalReportViewer1, ExportExcel_Click);
        }
        private void expoxrt_excel(string workbookPath, string filePath)
        {
            if (conn.CheckFileOpen(filePath))
            {
                MessageBox.Show("Excel đang mở, vui lòng đóng!!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                else
                {
                    System.IO.Directory.CreateDirectory(conn.LinkTemplate_SAVE);
                }
                if (!string.IsNullOrEmpty(filePath))
                {
                    File.Copy(workbookPath, filePath, true);
                }
                else
                {
                    MessageBox.Show("Bạn chưa lưu file excel");
                    return;
                }
                COMExcel.Application app = new COMExcel.Application();
                object valueMissing = System.Reflection.Missing.Value;

                COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
                false, valueMissing, valueMissing, valueMissing, valueMissing,
                COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
                valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);

                app.Visible = true;

                int ColumnsCount;
                if (dt == null || (ColumnsCount = dt.Columns.Count) == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                COMExcel.Range Na1 = IV.get_Range("D7", "H7");
                Na1.Value2 = DateTime.Now.ToString("dd/MM/yyyy");

                COMExcel.Range Na2 = IV.get_Range("B8", "F8");
                Na2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                Na2.Value2 = dt.Rows[0]["C_NAME"].ToString();

                COMExcel.Range Na3 = IV.get_Range("B9", "D9");
                Na3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                Na3.Value2 = dt.Rows[0]["SPEAK"].ToString();

                COMExcel.Range Na4 = IV.get_Range("F9", "G9");
                Na4.Value2 = dt.Rows[0]["SPEAK_CC"].ToString();

                COMExcel.Range Na5 = IV.get_Range("K8", "L8");
                Na5.Value2 = dt.Rows[0]["C_NO"].ToString();

                COMExcel.Range Na6 = IV.get_Range("K9", "L9");
                Na6.Value2 = dt.Rows[0]["WS_NO"].ToString();

                int a = 13;
                foreach (DataRow item in dt.Rows)
                {
                    COMExcel.Range P_NO = IV.get_Range("A" + a, "B" + a);
                    P_NO.Merge();
                    P_NO.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    P_NO.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    P_NO.Value2 = item["P_NO"].ToString();

                    COMExcel.Range P_NAME = IV.get_Range("C" + a, "E" + a);
                    P_NAME.Merge();
                    P_NAME.WrapText = true;
                    P_NAME.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    P_NAME.Value2 = GetNameCustomer(int.Parse(item["RB"].ToString()), item["P_NAME"].ToString(), item["P_NAME1"].ToString(), item["P_NAME2"].ToString());
                    P_NAME.Rows.AutoFit();

                    COMExcel.Range PBT01 = IV.get_Range("F" + a, "F" + a);
                    PBT01.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    PBT01.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    PBT01.Value2 = item["PBT01"].ToString();

                    COMExcel.Range PBT02 = IV.get_Range("G" + a, "G" + a);
                    PBT02.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    PBT02.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    PBT02.Value2 = item["PBT02"].ToString();

                    COMExcel.Range PBT03 = IV.get_Range("H" + a, "H" + a);
                    PBT03.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    PBT03.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    PBT03.Value2 = item["PBT03"].ToString();

                    COMExcel.Range PBT04 = IV.get_Range("I" + a, "I" + a);
                    PBT04.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    PBT04.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    PBT04.Value2 ="'" + item["PBT04"].ToString();

                    COMExcel.Range P_NAME3 = IV.get_Range("J" + a, "J" + a);
                    P_NAME3.Merge();
                    P_NAME3.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    P_NAME3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    P_NAME3.Value2 = item["P_NAME3"].ToString();

                    COMExcel.Range PRICE = IV.get_Range("K" + a, "K" + a);
                    PRICE.Merge();
                    PRICE.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    PRICE.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    PRICE.Value2 = item["PRICE"].ToString();

                    a++;
                }
                conn.BorderAround(IV.get_Range("A13", "L" + (a - 1)));

                app.Quit();
                conn.releaseObject(book);
                conn.releaseObject(book);
                conn.releaseObject(app);
            }
        }
        private void ExportExcel_Click(object sender, EventArgs e)
        {
            string workbookPath = conn.LinkTemplate + "1I_Tab1_3.xls";
            string filePath = conn.LinkTemplate_SAVE + "1I_Tab1_3.xls";
            expoxrt_excel(workbookPath, filePath);
        }
        DataTable dt = new DataTable();
        bool R1 = Form1IF7.RD.R1;
        bool R2 = Form1IF7.RD.R2;
        bool R3 = Form1IF7.RD.R3;
        bool R4 = Form1IF7.RD.R4;
        bool R5 = Form1IF7.RD.R5;
        bool R6 = Form1IF7.RD.R6;
        bool R7 = Form1IF7.RD.R7;
        bool R8 = Form1IF7.RD.R8;
        private void frm1IF7_Tab1_3_Load(object sender, EventArgs e)
        {
            string S = Form1IF7.DL.S1;

            string st = "";
            if (R1 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,1 as RB,convert(varchar, getdate(), 107) as Dates FROM QUOB,QUOH,CUST WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R2 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,2 as RB,convert(varchar, getdate(), 107) as Dates FROM QUOB,QUOH,CUST WHERE QUOB.WS_NO = QUOH.WS_NO AND QUOH.C_NO = CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R3 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,3 as RB,convert(varchar, getdate(), 107) as Dates FROM QUOB,QUOH,CUST WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R4 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,4 as RB,convert(varchar, getdate(), 107) as Dates FROM QUOB,QUOH,CUST WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R5 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,5 as RB,convert(varchar, getdate(), 107) as Dates FROM QUOB,QUOH,CUST WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R6 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,6 as RB,convert(varchar, getdate(), 107) as Dates FROM QUOB,QUOH,CUST WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R7 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,7 as RB,convert(varchar, getdate(), 107) as Dates FROM QUOB,QUOH,CUST WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R8 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,8 as RB,convert(varchar, getdate(), 107) as Dates FROM QUOB,QUOH,CUST WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            WSEXE.ReportView.cr_Form1I_Tab1_3 rpt = new WSEXE.ReportView.cr_Form1I_Tab1_3();
            dt = conn.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
        public string GetNameCustomer(int RB, string P_NAME, string P_NAME1, string P_NAME2)
        {
            string resuce = "";
            if (RB == 1)
            {
                resuce = P_NAME + " " + P_NAME1;
            }
            else if (RB == 2)
            {
                resuce = P_NAME + " " + P_NAME2;
            }
            else if (RB == 3)
            {
                resuce = P_NAME1 + " " + P_NAME2;
            }
            else if (RB == 4)
            {
                resuce = P_NAME;
            }
            else if (RB == 5 || RB == 7)
            {
                resuce = P_NAME1;
            }
            else if (RB == 6 || RB == 8)
            {
                resuce = P_NAME2;
            }
            return resuce;
        }
    }
}
