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
    public partial class frm1IF7_Tab1_2 : Form
    {
        DataProvider conn = new DataProvider();
        public frm1IF7_Tab1_2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            conn.CreateButtonToolTipReport(crystalReportViewer1, ExportExcel_Click);
        }
        private void export_excel(string workbookPath, string filePath)
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

                COMExcel.Range Na1 = IV.get_Range("B8", "f8");
                Na1.Value2 = dt.Rows[0]["C_NAME"].ToString();

                COMExcel.Range Na2 = IV.get_Range("B9", "C9");
                Na2.Value2 = dt.Rows[0]["SPEAK"].ToString();

                COMExcel.Range Na3 = IV.get_Range("D7", "H7");
                Na3.Value2 = DateTime.Now.ToString("dd/MM/yyyy");

                COMExcel.Range Na4 = IV.get_Range("K8", "l8");
                Na4.Value2 = dt.Rows[0]["C_NO"].ToString();

                COMExcel.Range Na5 = IV.get_Range("K9", "L9");
                Na5.Value2 = dt.Rows[0]["WS_NO"].ToString();

                COMExcel.Range Na6 = IV.get_Range("E9", "F9");
                Na6.Value2 = dt.Rows[0]["SPEAK_CC"].ToString();

                COMExcel.Range NUMBERRPAGE = IV.get_Range("K7", "L7");
                NUMBERRPAGE.Value2 = "1 OF 1";

                int a = 13;
                foreach (DataRow item in dt.Rows)
                {
                    COMExcel.Range P_NO = IV.get_Range("A" + a, "B" + a);
                    P_NO.Merge();
                    // P_NO.RowHeight = 28.8;
                    P_NO.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    P_NO.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    P_NO.Value2 = item["P_NO"].ToString();

                    COMExcel.Range P_NAME = IV.get_Range("C" + a, "E" + a);
                    P_NAME.Merge();
                    P_NAME.WrapText = true;
                    P_NAME.Value2 = GetP_NAME(item["P_NAME"].ToString(), item["P_NAME1"].ToString(), item["P_NAME2"].ToString());
                    P_NAME.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

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
                    PBT04.Value2 = "'" + item["PBT04"].ToString();

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

                    COMExcel.Range Percent = IV.get_Range("L" + a, "L" + a);
                    Percent.Merge();
                    Percent.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    Percent.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    Percent.Value2 = (string.IsNullOrEmpty(item["AVGCQ"].ToString()) ? "0" : item["AVGCQ"].ToString()) + "%";
                    a++;
                }

                conn.BorderAround(IV.get_Range("A13", "L" + (a - 1)));

                COMExcel.Range GHICHU = IV.get_Range("A" + a, "A" + a);
                GHICHU.Font.Size = 12;
                GHICHU.Font.Bold = true;
                GHICHU.Font.Name = "Arial";
                GHICHU.Value2 = "Ghi chú 備:";

                COMExcel.Range MEMO1 = IV.get_Range("A" + (a + 1), "L" + (a + 1));
                MEMO1.Merge();
                MEMO1.Font.Size = 12;
                MEMO1.Font.Name = "Arial";
                MEMO1.Value2 = dt.Rows[0]["MEMO111"].ToString();

                COMExcel.Range MEMO2 = IV.get_Range("A" + (a + 2), "L" + (a + 2));
                MEMO2.Merge();
                MEMO2.Font.Size = 12;
                MEMO2.Font.Name = "Arial";
                MEMO2.Value2 = dt.Rows[0]["MEMO21"].ToString();

                COMExcel.Range MEMO3 = IV.get_Range("A" + (a + 3), "L" + (a + 3));
                MEMO3.Merge();
                MEMO3.Font.Size = 12;
                MEMO3.Font.Name = "Arial";
                MEMO3.Value2 = dt.Rows[0]["MEMO31"].ToString();

                COMExcel.Range MEMO4 = IV.get_Range("A" + (a + 4), "L" + (a + 4));
                MEMO4.Merge();
                MEMO4.Font.Size = 12;
                MEMO4.Font.Name = "Arial";
                MEMO4.Value2 = dt.Rows[0]["MEMO41"].ToString();

                COMExcel.Range MEMO5 = IV.get_Range("A" + (a + 5), "L" + (a + 5));
                MEMO5.Merge();
                MEMO5.Font.Size = 12;
                MEMO5.Font.Name = "Arial";
                MEMO5.Value2 = dt.Rows[0]["MEMO5"].ToString();

                COMExcel.Range MEMO6 = IV.get_Range("A" + (a + 6), "L" + (a + 6));
                MEMO6.Merge();
                MEMO6.Font.Size = 12;
                MEMO6.Font.Name = "Arial";
                MEMO6.Value2 = dt.Rows[0]["MEMO6"].ToString();

                COMExcel.Range MEMO101 = IV.get_Range("A" + (a + 7), "D" + (a + 7));
                MEMO101.Merge();
                MEMO101.Font.Size = 11;
                MEMO101.WrapText = true;
                MEMO101.Value2 = dt.Rows[0]["MEMO101"].ToString();
                MEMO101.Rows.AutoFit();

                COMExcel.Range MEMO201 = IV.get_Range("E" + (a + 7), "H" + (a + 7));
                MEMO201.Merge();
                MEMO201.Font.Size = 11;
                MEMO201.Font.Name = "Arial";
                MEMO201.Value2 = dt.Rows[0]["MEMO201"].ToString();

                COMExcel.Range MEMO301 = IV.get_Range("I" + (a + 7), "L" + (a + 7));
                MEMO301.Merge();
                MEMO301.Value2 = dt.Rows[0]["MEMO301"].ToString();

                COMExcel.Range MEMO102 = IV.get_Range("A" + (a + 8), "D" + (a + 8));
                MEMO102.Merge();
                MEMO102.Font.Size = 11;
                MEMO102.Font.Name = "Arial";
                MEMO102.Value2 = dt.Rows[0]["MEMO102"].ToString();

                COMExcel.Range MEMO202 = IV.get_Range("E" + (a + 8), "H" + (a + 8));
                MEMO202.Merge();
                MEMO202.Font.Size = 11;
                MEMO202.Font.Name = "Arial";
                MEMO202.Value2 = dt.Rows[0]["MEMO202"].ToString();

                COMExcel.Range MEMO302 = IV.get_Range("I" + (a + 8), "L" + (a + 8));
                MEMO302.Merge();
                MEMO302.Font.Size = 11;
                MEMO302.Font.Name = "Arial";
                MEMO302.Value2 = dt.Rows[0]["MEMO302"].ToString();

                COMExcel.Range MEMO103 = IV.get_Range("A" + (a + 9), "D" + (a + 9));
                MEMO103.Merge();
                MEMO103.Font.Size = 11;
                MEMO103.Font.Name = "Arial";
                MEMO103.Value2 = dt.Rows[0]["MEMO103"].ToString();

                COMExcel.Range MEMO203 = IV.get_Range("E" + (a + 9), "H" + (a + 9));
                MEMO203.Merge();
                MEMO203.Font.Size = 11;
                MEMO203.Font.Name = "Arial";

                MEMO203.Value2 = dt.Rows[0]["MEMO203"].ToString();
                COMExcel.Range MEMO303 = IV.get_Range("I" + (a + 9), "L" + (a + 9));
                MEMO303.Merge();
                MEMO303.Font.Size = 11;
                MEMO303.Font.Name = "Arial";
                MEMO303.Value2 = dt.Rows[0]["MEMO303"].ToString();

                COMExcel.Range MEMO104 = IV.get_Range("A" + (a + 10), "D" + (a + 10));
                MEMO104.Merge();
                MEMO104.Font.Size = 11;
                MEMO104.Font.Name = "Arial";
                MEMO104.Value2 = dt.Rows[0]["MEMO104"].ToString();

                COMExcel.Range MEMO204 = IV.get_Range("E" + (a + 10), "H" + (a + 10));
                MEMO204.Merge();
                MEMO204.Font.Size = 11;
                MEMO204.Font.Name = "Arial";
                MEMO204.Value2 = dt.Rows[0]["MEMO204"].ToString();

                COMExcel.Range MEMO304 = IV.get_Range("I" + (a + 10), "L" + (a + 10));
                MEMO304.Merge();
                MEMO304.Font.Size = 11;
                MEMO304.Font.Name = "Arial";
                MEMO304.Font.Size = 8;
                MEMO304.Value2 = dt.Rows[0]["MEMO304"].ToString();

                COMExcel.Range MEMO105 = IV.get_Range("A" + (a + 11), "D" + (a + 11));
                MEMO105.Merge();
                MEMO105.Font.Size = 11;
                MEMO105.Font.Name = "Arial";
                MEMO105.Value2 = dt.Rows[0]["MEMO105"].ToString();

                COMExcel.Range MEMO205 = IV.get_Range("E" + (a + 11), "H" + (a + 11));
                MEMO205.Merge();
                MEMO205.Font.Size = 11;
                MEMO205.Font.Name = "Arial";
                MEMO205.Value2 = dt.Rows[0]["MEMO205"].ToString();

                COMExcel.Range MEMO305 = IV.get_Range("I" + (a + 11), "L" + (a + 11));
                MEMO305.Merge();
                MEMO305.Font.Size = 11;
                MEMO305.Font.Name = "Arial";
                MEMO305.Value2 = dt.Rows[0]["MEMO305"].ToString();

                COMExcel.Range MEMO106 = IV.get_Range("A" + (a + 12), "D" + (a + 12));
                MEMO106.Merge();
                MEMO106.Font.Size = 11;
                MEMO106.Font.Name = "Arial";
                MEMO106.Value2 = dt.Rows[0]["MEMO106"].ToString();

                COMExcel.Range MEMO206 = IV.get_Range("E" + (a + 12), "H" + (a + 12));
                MEMO206.Merge();
                MEMO206.Font.Size = 11;
                MEMO206.Font.Name = "Arial";
                MEMO206.Value2 = dt.Rows[0]["MEMO206"].ToString();

                COMExcel.Range MEMO306 = IV.get_Range("I" + (a + 12), "L" + (a + 12));
                MEMO306.Merge();
                MEMO306.Font.Size = 11;
                MEMO306.Font.Name = "Arial";
                MEMO306.Value2 = dt.Rows[0]["MEMO306"].ToString();

                COMExcel.Range MEMO107 = IV.get_Range("A" + (a + 13), "D" + (a + 13));
                MEMO107.Merge();
                MEMO107.Font.Size = 11;
                MEMO107.Font.Name = "Arial";
                MEMO107.Value2 = dt.Rows[0]["MEMO107"].ToString();

                COMExcel.Range PAY_COND = IV.get_Range("E" + (a + 13), "H" + (a + 13));
                PAY_COND.Merge();
                PAY_COND.Font.Size = 11;
                PAY_COND.Font.Name = "Arial";
                PAY_COND.Value2 = "付款方式:  " + dt.Rows[0]["PAY_COND"].ToString(); ;

                //COMExcel.Range MEMO207 = IV.get_Range("E" + (a + 13), "H" + (a + 13));
                //MEMO207.Merge();
                //MEMO207.Font.Size = 11;
                //MEMO207.Font.Name = "Arial";
                //MEMO207.Value2 = dt.Rows[0]["MEMO207"].ToString();

                COMExcel.Range MEMO307 = IV.get_Range("I" + (a + 13), "L" + (a + 13));
                MEMO307.Merge();
                MEMO307.Font.Size = 11;
                MEMO307.Font.Name = "Arial";
                MEMO307.Value2 = dt.Rows[0]["MEMO307"].ToString();


                COMExcel.Range MEMO108 = IV.get_Range("A" + (a + 14), "D" + (a + 14));
                MEMO108.Merge();
                MEMO108.Font.Size = 11;
                MEMO108.Font.Name = "Arial";
                MEMO108.Value2 = dt.Rows[0]["MEMO108"].ToString();

                //COMExcel.Range MEMO208 = IV.get_Range("E" + (a + 14), "H" + (a + 14));
                //MEMO208.Merge();
                //MEMO208.Font.Size = 11;
                //MEMO208.Font.Name = "Arial";
                //MEMO208.Value2 = dt.Rows[0]["MEMO208"].ToString();

                COMExcel.Range MEMO308 = IV.get_Range("I" + (a + 14), "L" + (a + 14));
                MEMO308.Merge();
                MEMO308.Font.Size = 11;
                MEMO308.Font.Name = "Arial";
                MEMO308.Value2 = dt.Rows[0]["MEMO308"].ToString();

                COMExcel.Range PS = IV.get_Range("E" + (a + 14), "H" + (a + 14));
                PS.Merge();
                PS.Font.Size = 11;
                PS.Font.Name = "Arial";
                PS.Value2 = "PS:" + dt.Rows[0]["PS01"].ToString();

                COMExcel.Range MEMO209 = IV.get_Range("E" + (a + 15), "H" + (a + 15));
                MEMO209.Merge();
                MEMO209.Font.Size = 11;
                MEMO209.Font.Name = "Arial";
                MEMO209.Value2 = dt.Rows[0]["PS02"].ToString();

                COMExcel.Range MEMO210 = IV.get_Range("E" + (a + 16), "H" + (a + 16));
                MEMO210.Merge();
                MEMO210.Font.Size = 11;
                MEMO210.Font.Name = "Arial";
                MEMO210.Value2 = dt.Rows[0]["PS03"].ToString();


                COMExcel.Range MEMO109 = IV.get_Range("A" + (a + 15), "D" + (a + 15));
                MEMO109.Merge();
                MEMO109.Font.Size = 11;
                MEMO109.Font.Name = "Arial";
                MEMO109.Value2 = dt.Rows[0]["MEMO109"].ToString();

                COMExcel.Range MEMO110 = IV.get_Range("A" + (a + 16), "D" + (a + 16));
                MEMO110.Merge();
                MEMO110.Font.Size = 11;
                MEMO110.Font.Name = "Arial";
                MEMO110.Value2 = dt.Rows[0]["MEMO110"].ToString();

                COMExcel.Range Chuc = IV.get_Range("C" + (a + 17), "D" + (a + 17));
                Chuc.Merge();
                Chuc.Font.Size = 11;
                Chuc.Font.Name = "Arial";
                Chuc.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                Chuc.Value2 = "chúc 祝";

                COMExcel.Range thank = IV.get_Range("E" + (a + 18), "I" + (a + 18));
                thank.Merge();
                thank.Font.Size = 11;
                thank.Font.Name = "Arial";
                thank.Value2 = "商 祺 chân thành cảm ơn";

                COMExcel.Range d = IV.get_Range("A" + (a + 19), "F" + (a + 19));
                d.Merge();
                d.Font.Size = 11;
                d.Font.Name = "Arial";
                d.Value2 = "xin vui lòng Ký xác nhận và fax trở lại /";

                COMExcel.Range da = IV.get_Range("A" + (a + 20), "F" + (a + 20));
                da.Merge();
                da.Font.Size = 11;
                da.Font.Name = "Arial";
                da.Value2 = "Trong vòng 3 ngày không ký và xác nhận trả lời";

                COMExcel.Range ads = IV.get_Range("A" + (a + 21), "F" + (a + 21));
                ads.Merge();
                ads.Font.Size = 11;
                ads.Font.Name = "Arial";
                ads.Value2 = "Xem như đồng ý báo giá này.";

                COMExcel.Range eq = IV.get_Range("A" + (a + 22), "F" + (a + 22));
                eq.Merge();
                eq.Font.Size = 11;
                eq.Font.Name = "Arial";
                eq.Value2 = "請簽回/三天內未簽回者視同接受此";

                COMExcel.Range FOT8 = IV.get_Range("A" + (a + 23), "C" + (a + 23));
                FOT8.Merge();
                FOT8.Font.Size = 11;
                FOT8.Font.Name = "Arial";
                FOT8.Value2 = "Signature";

                COMExcel.Range FOT14 = IV.get_Range("D" + (a + 24), "H" + (a + 26));
                FOT14.Merge();
                FOT14.Font.Size = 11;
                FOT14.Font.Name = "Arial";
                FOT14.Value2 = "";

                COMExcel.Range FOT15 = IV.get_Range("I" + (a + 24), "L" + (a + 26));
                FOT15.Merge();
                FOT15.Font.Size = 11;
                FOT15.Font.Name = "Arial";
                FOT15.Value2 = "";

                COMExcel.Range FOT9 = IV.get_Range("D" + (a + 23), "H" + (a + 23));
                FOT9.Merge();
                FOT9.Font.Size = 11;
                FOT9.Font.Name = "Arial";
                FOT9.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                FOT9.Value2 = "CTY TNHH DA THUỘC WEI TAI VIỆT NAM";
                FOT9.WrapText = true;
                FOT9.Rows.AutoFit();

                COMExcel.Range FOT16 = IV.get_Range("A" + (a + 24), "C" + (a + 26));
                FOT16.Merge();
                FOT16.Font.Size = 11;
                FOT16.Font.Name = "Arial";
                FOT16.Value2 = "";

                COMExcel.Range FOT10 = IV.get_Range("A" + (a + 27), "C" + (a + 27));
                FOT10.Merge();
                FOT10.Font.Size = 11;
                FOT10.Font.Name = "Arial";
                FOT10.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                FOT10.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                FOT10.Value2 = dt.Rows[0]["C_NAME"].ToString();
                FOT10.WrapText = true;
                FOT10.Rows.AutoFit();

                COMExcel.Range FOT11 = IV.get_Range("D" + (a + 27), "H" + (a + 27));
                FOT11.Merge();
                FOT11.Font.Size = 11;
                FOT11.Font.Name = "Arial";
                FOT11.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                FOT11.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                FOT11.Value2 = "WEI TAI (VIETNAM) LEATHER CO.,LTD";
                FOT11.WrapText = true;
                FOT11.Rows.AutoFit();


                COMExcel.Range FOT12 = IV.get_Range("I" + (a + 27), "L" + (a + 27));
                FOT12.Merge();
                FOT12.Font.Size = 11;
                FOT12.Font.Name = "Arial";
                FOT12.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                FOT12.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                FOT12.Value2 = "TOPPING INTERNATION CO,.LTD";
                FOT12.WrapText = true;
                FOT12.Rows.AutoFit();

                COMExcel.Range FOT13 = IV.get_Range("D" + (a + 28), "H" + (a + 28));
                FOT13.Merge();
                FOT13.Font.Size = 11;
                FOT13.Font.Name = "Arial";
                FOT13.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                FOT13.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                FOT13.Value2 = "越南緯達皮革有限公司";


                app.Quit();
                conn.releaseObject(book);
                conn.releaseObject(book);
                conn.releaseObject(app);
            }
        }
        private void ExportExcel_Click(object sender, EventArgs e)
        {
            string workbookPath = conn.LinkTemplate + "1I_Tab1_2.xls";
            string filePath = conn.LinkTemplate_SAVE + "1I_Tab1_2.xls";
            export_excel(workbookPath, filePath);
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
        bool RdN = Form1IF7.RD.rdN;
        private void frm1IF7_Tab1_2_Load(object sender, EventArgs e)
        {
            string S = Form1IF7.DL.S1;

            string st = "";
            if (R1 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,1 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1 FROM QUOB,QUOH,CUST " +
                    "WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R2 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,2 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1 FROM QUOB,QUOH,CUST " +
                    "WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R3 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,3 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1 FROM QUOB,QUOH,CUST " +
                    "WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R4 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,4 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1 FROM QUOB,QUOH,CUST " +
                    "WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R5 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,5 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1 FROM QUOB,QUOH,CUST " +
                    "WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R6 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,6 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1 FROM QUOB,QUOH,CUST " +
                    "WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R7 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,7 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1 FROM QUOB,QUOH,CUST " +
                    "WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            else if (R8 == true)
            {
                st = "SELECT QUOB.*,QUOH.*,CUST.C_ANAME2,8 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1 FROM QUOB,QUOH,CUST " +
                    "WHERE QUOB.WS_NO=QUOH.WS_NO AND QUOH.C_NO=CUST.C_NO AND QUOH.WS_NO = '" + S + "'";
            }
            st = st + " ORDER BY QUOH.WS_NO";
            WSEXE.ReportView.cr_Form1I_Tab1_2 rpt = new WSEXE.ReportView.cr_Form1I_Tab1_2();
            dt = conn.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
        public string GetP_NAME(string P_NAME, string P_NAME1, string P_NAME2)
        {
            string P_NAMES = "";
            if (R1 == true)
            {
                P_NAMES = P_NAME + P_NAME1;
            }
            else if (R2 == true)
            {
                P_NAMES = P_NAME + P_NAME2;
            }
            else if (R3 == true)
            {
                P_NAMES = P_NAME1 + P_NAME2;
            }
            else if (R4 == true)
            {
                P_NAMES = P_NAME;
            }
            else if (R5 == true || R7 == true)
            {
                P_NAMES = P_NAME1;
            }
            else if (R6 == true || R8 == true)
            {
                P_NAMES = P_NAME2;
            }
            return P_NAMES;
        }
    }
}
