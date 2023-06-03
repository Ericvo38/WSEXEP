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

namespace WTERP
{
    public partial class frm1IF7_Tab1_1 : Form
    {
        DataProvider connect = new DataProvider();
        public frm1IF7_Tab1_1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            connect.CreateButtonToolTipReport(crystalReportViewer1, ExportExcel_Click);
        }
        private string getData(string key)
        {
            string date = "";
            string sql = "getDate_1I '" + key + "'";
            System.Data.DataTable data = new System.Data.DataTable();
            data = connect.readdata(sql);
            if (data.Rows.Count > 0)
            {
                date = data.Rows[0]["DATE"].ToString();
            }
            return date;
        }
        private void ExportExcel_Click(object sender, EventArgs e)
        {
            string workbookPath = connect.LinkTemplate + "1I_Tab1_1.xls";
            string filePath = connect.LinkTemplate_SAVE + "1I_Tab1_1.xls";

            if (connect.CheckFileOpen(filePath))
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
                    System.IO.Directory.CreateDirectory(connect.LinkTemplate_SAVE);
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

                int countdt = dt.Rows.Count;
                int page = ((countdt) % 21 == 0 ? (int)((double)(countdt) / (double)21) : (int)((double)(countdt) / (double)21) + 1);

                COMExcel.Worksheet IV = (COMExcel.Worksheet)book.Worksheets[1];

                COMExcel.Range Na1 = IV.get_Range("B8", "E8");
                Na1.Value2 = dt.Rows[0]["C_NAME"].ToString();

                COMExcel.Range Na2 = IV.get_Range("B9", "C9");
                Na2.Value2 = dt.Rows[0]["SPEAK"].ToString();

                COMExcel.Range Na3 = IV.get_Range("E7", "G7");
                Na3.NumberFormat = "Text";
                Na3.Value2 = getData(DateTime.Now.ToString("yyyyMMdd"));

                COMExcel.Range Na4 = IV.get_Range("J8", "K8");
                Na4.Value2 = dt.Rows[0]["C_NO"].ToString();

                COMExcel.Range Na5 = IV.get_Range("J9", "K9");
                Na5.Value2 = dt.Rows[0]["WS_NO"].ToString();

                COMExcel.Range Na6 = IV.get_Range("E9", "F9");
                Na6.Value2 = dt.Rows[0]["SPEAK_CC"].ToString();

                COMExcel.Range Page_Number = IV.get_Range("J7", "K7");
                Page_Number.Merge();
                Page_Number.Value2 = "1 OF " + page;

                int a = 13;
                int gr = 15;
                int index = 0;
                int border = 13;
                for (int r = 1; r <= page; r++)
                {
                    for (int i = 0; i <= gr; i++)
                    {
                        if (index < dt.Rows.Count)
                        {
                            COMExcel.Range P_NO = IV.get_Range("A" + a, "B" + a);
                            P_NO.Merge();
                            P_NO.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            P_NO.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            P_NO.RowHeight = 28.8;
                            P_NO.WrapText = true;
                            P_NO.Value2 = dt.Rows[index]["P_NO"].ToString();

                            COMExcel.Range P_NAME = IV.get_Range("C" + a, "E" + a);
                            P_NAME.Merge();
                            P_NAME.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            P_NAME.WrapText = true;
                            P_NAME.Value2 = GetNameCustomer(int.Parse(dt.Rows[index]["RB"].ToString()), dt.Rows[index]["P_NAME"].ToString(), dt.Rows[index]["P_NAME1"].ToString(), dt.Rows[index]["P_NAME2"].ToString());

                            COMExcel.Range PBT01 = IV.get_Range("F" + a, "F" + a);
                            PBT01.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            PBT01.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            PBT01.Value2 = dt.Rows[index]["PBT01"].ToString();

                            COMExcel.Range PBT02 = IV.get_Range("G" + a, "G" + a);
                            PBT02.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            PBT02.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            PBT02.Value2 = dt.Rows[index]["PBT02"].ToString();

                            COMExcel.Range PBT03 = IV.get_Range("H" + a, "H" + a);
                            PBT03.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            PBT03.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            PBT03.Value2 = dt.Rows[index]["PBT03"].ToString();

                            COMExcel.Range PBT04 = IV.get_Range("I" + a, "I" + a);
                            PBT04.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            PBT04.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            PBT04.NumberFormat = "Text";
                            PBT04.Value2 = "'" + dt.Rows[index]["PBT04"].ToString();

                            COMExcel.Range P_NAME3 = IV.get_Range("J" + a, "J" + a);
                            P_NAME3.Merge();
                            P_NAME3.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            P_NAME3.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            P_NAME3.Value2 = dt.Rows[index]["P_NAME3"].ToString();

                            COMExcel.Range PRICE = IV.get_Range("K" + a, "K" + a);
                            PRICE.Merge();
                            PRICE.VerticalAlignment = XlVAlign.xlVAlignCenter;
                            PRICE.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            PRICE.Value2 = dt.Rows[index]["PRICE"].ToString();
                            index++;
                            a++;
                        }
                    }
                    gr = 21;

                    if (r < page)
                    {
                        COMExcel.Range C_ANAME2 = IV.get_Range("A" + (a + 1), "G" + (a + 1));
                        C_ANAME2.Merge();
                        C_ANAME2.Value2 = "TO : " + dt.Rows[0]["C_ANAME2"].ToString();

                        COMExcel.Range TitlePages = IV.get_Range("H" + (a + 1), "I" + (a + 1));
                        TitlePages.Merge();
                        TitlePages.Value2 = "Số trang 頁 數：";

                        COMExcel.Range Pages = IV.get_Range("J" + (a + 1), "K" + (a + 1));
                        Pages.Merge();
                        Pages.Value2 = (r + 1) + " OF " + page;

                        COMExcel.Range Hearder1 = IV.get_Range("A" + (a + 2), "B" + (a + 3));
                        Hearder1.Merge();
                        Hearder1.Value2 = "MÃ SỐ SẢN PHẨM \n 品名編號";

                        COMExcel.Range Hearder2 = IV.get_Range("C" + (a + 2), "E" + (a + 3));
                        Hearder2.Merge();
                        Hearder2.VerticalAlignment = XlVAlign.xlVAlignCenter;
                        Hearder2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        Hearder2.Value2 = "MẶT HÀNG \n 品 名";

                        COMExcel.Range Hearder3 = IV.get_Range("F" + (a + 2), "F" + (a + 3));
                        Hearder3.Merge();
                        Hearder3.Value2 = "顏色";

                        COMExcel.Range Hearder4 = IV.get_Range("G" + (a + 2), "G" + (a + 3));
                        Hearder4.Merge();
                        Hearder4.WrapText = true;
                        Hearder4.Font.Size = 8;
                        Hearder4.Value2 = "QC% Cutting Vakue";

                        COMExcel.Range Hearder5 = IV.get_Range("H" + (a + 2), "H" + (a + 3));
                        Hearder5.Merge();
                        Hearder5.Font.Size = 8;
                        Hearder5.Value2 = "Softness";

                        COMExcel.Range Hearder6 = IV.get_Range("I" + (a + 2), "I" + (a + 3));
                        Hearder6.Merge();
                        Hearder6.Font.Size = 8;
                        Hearder6.WrapText = true;
                        Hearder6.Value2 = "Average Skin Size";

                        COMExcel.Range Hearder7 = IV.get_Range("J" + (a + 2), "J" + (a + 3));
                        Hearder7.Merge();
                        Hearder7.WrapText = true;
                        Hearder7.Font.Size = 8;
                        Hearder7.Value2 = "ĐỘ DẦY \n 厚 度(MM)";

                        COMExcel.Range Hearder8 = IV.get_Range("K" + (a + 2), "K" + (a + 3));
                        Hearder8.Merge();
                        Hearder8.WrapText = true;
                        Hearder8.Font.Size = 8;
                        Hearder8.Value2 = "ĐƠN GIÁ \n 單 價(USD/ SF)";

                        a = a + 3;
                        connect.BorderAround(IV.get_Range("A" + border, "K" + (a - 4)));
                        border = (a - 1);
                    }
                    connect.BorderAround(IV.get_Range("A" + border, "K" + (a - 1)));
                    border = (a - 1);
                }

                //connect.BorderAround(IV.get_Range("A13", "K" + (a - 1)));

                COMExcel.Range GHICHU = IV.get_Range("A" + a, "B" + a);
                GHICHU.Merge();
                GHICHU.Value2 = "Ghi chú 備:";

                COMExcel.Range MEMO1 = IV.get_Range("A" + (a + 1), "K" + (a + 1));
                MEMO1.Merge();
                MEMO1.Value2 = dt.Rows[0]["MEMO1"].ToString();

                COMExcel.Range MEMO2 = IV.get_Range("A" + (a + 2), "K" + (a + 2));
                MEMO2.Merge();
                MEMO2.Value2 = dt.Rows[0]["MEMO2"].ToString();

                COMExcel.Range MEMO3 = IV.get_Range("A" + (a + 3), "K" + (a + 3));
                MEMO3.Merge();
                MEMO3.Value2 = dt.Rows[0]["MEMO3"].ToString();

                COMExcel.Range MEMO4 = IV.get_Range("A" + (a + 4), "K" + (a + 4));
                MEMO4.Merge();
                MEMO4.Value2 = dt.Rows[0]["MEMO4"].ToString();

                COMExcel.Range MEMO5 = IV.get_Range("A" + (a + 5), "K" + (a + 5));
                MEMO5.Merge();
                MEMO5.Value2 = dt.Rows[0]["MEMO5"].ToString();

                COMExcel.Range MEMO6 = IV.get_Range("A" + (a + 6), "K" + (a + 6));
                MEMO6.Merge();
                MEMO6.Value2 = dt.Rows[0]["MEMO6"].ToString();

                COMExcel.Range MEMO101 = IV.get_Range("A" + (a + 7), "D" + (a + 7));
                MEMO101.Merge();
                MEMO101.RowHeight = 28;
                MEMO101.Font.Size = 11;
                MEMO101.WrapText = true;
                MEMO101.Value2 = dt.Rows[0]["MEMO101"].ToString();
                COMExcel.Range MEMO201 = IV.get_Range("E" + (a + 7), "H" + (a + 7));
                MEMO201.Merge();
                MEMO201.Font.Size = 11;
                MEMO201.Value2 = dt.Rows[0]["MEMO201"].ToString();
                COMExcel.Range MEMO301 = IV.get_Range("I" + (a + 7), "K" + (a + 7));
                MEMO301.Merge();
                MEMO301.Font.Size = 11;
                MEMO301.Value2 = dt.Rows[0]["MEMO301"].ToString();

                COMExcel.Range MEMO102 = IV.get_Range("A" + (a + 8), "D" + (a + 8));
                MEMO102.Merge();
                MEMO102.Font.Size = 11;
                MEMO102.Value2 = dt.Rows[0]["MEMO102"].ToString();
                COMExcel.Range MEMO202 = IV.get_Range("E" + (a + 8), "H" + (a + 8));
                MEMO202.Merge();
                MEMO202.Font.Size = 11;
                MEMO202.Value2 = dt.Rows[0]["MEMO202"].ToString();
                COMExcel.Range MEMO302 = IV.get_Range("I" + (a + 8), "K" + (a + 8));
                MEMO302.Merge();
                MEMO302.Font.Size = 11;
                MEMO302.Value2 = dt.Rows[0]["MEMO302"].ToString();

                COMExcel.Range MEMO103 = IV.get_Range("A" + (a + 9), "D" + (a + 9));
                MEMO103.Merge();
                MEMO103.Font.Size = 11;
                MEMO103.Value2 = dt.Rows[0]["MEMO103"].ToString();
                COMExcel.Range MEMO203 = IV.get_Range("E" + (a + 9), "H" + (a + 9));
                MEMO203.Merge();
                MEMO203.Font.Size = 11;
                MEMO203.Value2 = dt.Rows[0]["MEMO203"].ToString();
                COMExcel.Range MEMO303 = IV.get_Range("I" + (a + 9), "K" + (a + 9));
                MEMO303.Merge();
                MEMO303.Font.Size = 11;
                MEMO303.Value2 = dt.Rows[0]["MEMO303"].ToString();

                COMExcel.Range MEMO104 = IV.get_Range("A" + (a + 10), "D" + (a + 10));
                MEMO104.Merge();
                MEMO104.Font.Size = 11;
                MEMO104.Value2 = dt.Rows[0]["MEMO104"].ToString();
                COMExcel.Range MEMO204 = IV.get_Range("E" + (a + 10), "H" + (a + 10));
                MEMO204.Merge();
                MEMO204.Font.Size = 11;
                MEMO204.Value2 = dt.Rows[0]["MEMO204"].ToString();

                COMExcel.Range MEMO304 = IV.get_Range("I" + (a + 10), "K" + (a + 10));
                MEMO304.Merge();
                MEMO304.Font.Size = 11;
                MEMO304.Value2 = dt.Rows[0]["MEMO304"].ToString();

                COMExcel.Range MEMO105 = IV.get_Range("A" + (a + 11), "D" + (a + 11));
                MEMO105.Merge();
                MEMO105.Font.Size = 11;
                MEMO105.Value2 = dt.Rows[0]["MEMO105"].ToString();

                COMExcel.Range MEMO205 = IV.get_Range("E" + (a + 11), "H" + (a + 11));
                MEMO205.Merge();
                MEMO205.Font.Size = 11;
                MEMO205.Value2 = dt.Rows[0]["MEMO205"].ToString();
                COMExcel.Range MEMO305 = IV.get_Range("I" + (a + 11), "K" + (a + 11));
                MEMO305.Merge();
                MEMO305.Font.Size = 11;
                MEMO305.Value2 = dt.Rows[0]["MEMO305"].ToString();
                //row 12
                COMExcel.Range MEMO106 = IV.get_Range("A" + (a + 12), "D" + (a + 12));
                MEMO106.Merge();
                MEMO106.Font.Size = 11;
                MEMO106.Value2 = dt.Rows[0]["MEMO106"].ToString();

                COMExcel.Range PAY_COND = IV.get_Range("E" + (a + 12), "H" + (a + 12));
                PAY_COND.Merge();
                PAY_COND.Font.Size = 11;
                PAY_COND.Value2 = "付款方式: " + dt.Rows[0]["PAY_COND"].ToString();

                COMExcel.Range MEMO306 = IV.get_Range("I" + (a + 12), "K" + (a + 12));
                MEMO306.Merge();
                MEMO306.Font.Size = 11; 
                MEMO306.Value2 = dt.Rows[0]["MEMO306"].ToString();

                //row 13
                COMExcel.Range MEMO107 = IV.get_Range("A" + (a + 13), "D" + (a + 13));
                MEMO107.Merge();
                MEMO107.WrapText = true;
                MEMO107.Font.Size = 10;
                MEMO107.Value2 = dt.Rows[0]["MEMO107"].ToString();
          
                COMExcel.Range PS = IV.get_Range("E" + (a + 13), "H" + (a + 13));
                PS.Merge();
                PS.Font.Size = 11;
                PS.Value2 = "PS: " + dt.Rows[0]["PS01"].ToString();

                COMExcel.Range PS2 = IV.get_Range("E" + (a + 14), "H" + (a + 14));
                PS2.Merge();
                PS2.Font.Size = 11;
                PS2.Value2 = "PS: " + dt.Rows[0]["PS02"].ToString();

                COMExcel.Range PS3 = IV.get_Range("E" + (a + 15), "H" + (a + 15));
                PS3.Merge();
                PS3.Font.Size = 11;
                PS3.Value2 = "PS: " + dt.Rows[0]["PS03"].ToString();


                COMExcel.Range MEMO307 = IV.get_Range("I" + (a + 13), "K" + (a + 13));
                MEMO307.Merge();
                MEMO307.Font.Size = 11;
                MEMO307.Value2 = dt.Rows[0]["MEMO307"].ToString();

                //row 14

                COMExcel.Range MEMO108 = IV.get_Range("A" + (a + 14), "D" + (a + 14));
                MEMO108.Merge();

                MEMO108.WrapText = true;
                MEMO108.Font.Size = 10;
                MEMO108.Value2 = dt.Rows[0]["MEMO108"].ToString();

                COMExcel.Range MEMO308 = IV.get_Range("I" + (a + 14), "K" + (a + 14));
                MEMO308.Merge();
                MEMO308.Font.Size = 11;
                MEMO308.Value2 = dt.Rows[0]["MEMO308"].ToString();

                //row 15 

                COMExcel.Range MEMO109 = IV.get_Range("A" + (a + 15), "D" + (a + 15));
                MEMO109.Merge();
                MEMO109.Font.Size = 11;
                MEMO109.Value2 = dt.Rows[0]["MEMO109"].ToString();

                //row 16
                COMExcel.Range MEMO110 = IV.get_Range("A" + (a + 16), "D" + (a + 16));
                MEMO110.Merge();
                MEMO110.Font.Size = 11;
                MEMO110.Value2 = dt.Rows[0]["MEMO110"].ToString();


                COMExcel.Range MEMO209 = IV.get_Range("E" + (a + 16), "H" + (a + 16));
                MEMO209.Merge();
                MEMO209.Font.Size = 11;
                MEMO209.Value2 = dt.Rows[0]["MEMO209"].ToString();

                COMExcel.Range MEMO309 = IV.get_Range("I" + (a + 15), "K" + (a + 15));
                MEMO309.Merge();
                MEMO309.Font.Size = 11;
                MEMO309.Value2 = dt.Rows[0]["MEMO309"].ToString();

               
                COMExcel.Range MEMO210 = IV.get_Range("E" + (a + 16), "H" + (a + 16));
                MEMO210.Merge();
                MEMO210.Font.Size = 11;
                MEMO210.Value2 = dt.Rows[0]["MEMO210"].ToString();
                COMExcel.Range MEMO310 = IV.get_Range("I" + (a + 16), "K" + (a + 16));
                MEMO310.Merge();
                MEMO310.Font.Size = 11;
                MEMO310.Value2 = dt.Rows[0]["MEMO310"].ToString();

                COMExcel.Range Chuc = IV.get_Range("B" + (a + 17), "C" + (a + 17));
                Chuc.Merge();
                Chuc.HorizontalAlignment = XlHAlign.xlHAlignRight;
                Chuc.Font.Size = 11;
                Chuc.Value2 = "chúc 祝";
                COMExcel.Range thank = IV.get_Range("D" + (a + 18), "G" + (a + 18));
                thank.Merge();
                thank.Font.Size = 11;
                thank.Value2 = "商    祺 chân thành cảm ơn";

                COMExcel.Range d = IV.get_Range("A" + (a + 19), "F" + (a + 19));
                d.Merge();
                d.Font.Size = 11;
                d.Value2 = "xin vui lòng Ký xác nhận và fax trở lại /";
                COMExcel.Range da = IV.get_Range("A" + (a + 20), "F" + (a + 20));
                da.Merge();
                da.Font.Size = 11;
                da.Value2 = "Trong vòng 3 ngày không ký và xác nhận trả lời";
                COMExcel.Range ads = IV.get_Range("A" + (a + 21), "F" + (a + 21));
                ads.Merge();
                ads.Font.Size = 11;
                ads.Value2 = "Xem như đồng ý báo giá này.";
                COMExcel.Range eq = IV.get_Range("A" + (a + 22), "F" + (a + 22));
                eq.Merge();
                eq.Value2 = "請簽回/三天內未簽回者視同接受此";

                COMExcel.Range FOT8 = IV.get_Range("A" + (a + 23), "C" + (a + 23));
                FOT8.Merge();
                FOT8.Value2 = "Signature";
                COMExcel.Range FOT14 = IV.get_Range("D" + (a + 24), "H" + (a + 26));
                FOT14.Merge();
                FOT14.Value2 = "";
                COMExcel.Range FOT15 = IV.get_Range("I" + (a + 24), "K" + (a + 26));
                FOT15.Merge();
                FOT15.Value2 = "";
                COMExcel.Range FOT9 = IV.get_Range("D" + (a + 23), "H" + (a + 23));
                FOT9.Merge();
                FOT9.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                FOT9.Value2 = "CTY TNHH DA THUỘC WEI TAI VIỆT NAM";
                FOT9.Font.Name = "Arial";

                COMExcel.Range FOT16 = IV.get_Range("A" + (a + 24), "C" + (a + 26));
                FOT16.Merge();
                FOT16.Value2 = "";


                COMExcel.Range FOT10 = IV.get_Range("A" + (a + 27), "C" + (a + 27));
                FOT10.Merge();
                FOT10.Font.Size = 10;
                FOT10.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                FOT10.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                FOT10.Value2 = dt.Rows[0]["C_NAME"].ToString();

                COMExcel.Range FOT11 = IV.get_Range("D" + (a + 27), "H" + (a + 27));
                FOT11.Merge();
                FOT11.Font.Size = 10;
                FOT11.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                FOT11.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                FOT11.Value2 = "WEI TAI (VIETNAM) LEATHER CO.,LTD";

                COMExcel.Range FOT12 = IV.get_Range("I" + (a + 27), "K" + (a + 27));
                FOT12.Merge();
                FOT12.Font.Size = 10;
                FOT12.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                FOT12.Borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
                FOT12.Value2 = "TOPPING INTERNATION CO,.LTD";

                COMExcel.Range FOT13 = IV.get_Range("D" + (a + 28), "H" + (a + 28));
                FOT13.Merge();
                FOT13.Font.Size = 10;
                FOT13.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                FOT13.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                FOT13.Value2 = "越南緯達皮革有限公司";

                app.Quit();
                connect.releaseObject(book);
                connect.releaseObject(book);
                connect.releaseObject(app);
            }
        }

        System.Data.DataTable dt = new System.Data.DataTable();
        private void frm1IF7_Tab1_1_Load(object sender, EventArgs e)
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
                st = "select H.*,B.*,1 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1,C.C_ANAME2 FROM QUOH H JOIN QUOB B ON H.WS_NO = B.WS_NO JOIN CUST C ON H.C_NO = C.C_NO where H.WS_NO = '" + S + "'";
            }
            else if (R2 == true)
            {
                st = "select H.*,B.*,2 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1,C.C_ANAME2 FROM QUOH H JOIN QUOB B ON H.WS_NO = B.WS_NO JOIN CUST C ON H.C_NO = C.C_NO where H.WS_NO = '" + S + "'";
            }
            else if (R3 == true)
            {
                st = "select H.*,B.*,3 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1,C.C_ANAME2 FROM QUOH H JOIN QUOB B ON H.WS_NO = B.WS_NO JOIN CUST C ON H.C_NO = C.C_NO where H.WS_NO = '" + S + "'";
            }
            else if (R4 == true)
            {
                st = "select H.*,B.*,4 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1,C.C_ANAME2 FROM QUOH H JOIN QUOB B ON H.WS_NO = B.WS_NO JOIN CUST C ON H.C_NO = C.C_NO where H.WS_NO = '" + S + "'";
            }
            else if (R5 == true)
            {
                st = "select H.*,B.*,5 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1,C.C_ANAME2 FROM QUOH H JOIN QUOB B ON H.WS_NO = B.WS_NO JOIN CUST C ON H.C_NO = C.C_NO where H.WS_NO = '" + S + "'";
            }
            else if (R6 == true)
            {
                st = "select H.*,B.*,6 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1,C.C_ANAME2 FROM QUOH H JOIN QUOB B ON H.WS_NO = B.WS_NO JOIN CUST C ON H.C_NO = C.C_NO where H.WS_NO = '" + S + "'";
            }
            else if (R7 == true)
            {
                st = "select H.*,B.*,7 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1,C.C_ANAME2 FROM QUOH H JOIN QUOB B ON H.WS_NO = B.WS_NO JOIN CUST C ON H.C_NO = C.C_NO where H.WS_NO = '" + S + "'";
            }
            else if (R8 == true)
            {
                st = "select H.*,B.*,8 as RB,convert(varchar, getdate(), 107) as UPDATEKIND1,C.C_ANAME2 FROM QUOH H JOIN QUOB B ON H.WS_NO = B.WS_NO JOIN CUST C ON H.C_NO = C.C_NO where H.WS_NO = '" + S + "'";
            }
            WSEXE.ReportView.cr_Form1I_Tab1_1 rpt = new WSEXE.ReportView.cr_Form1I_Tab1_1();

            dt = connect.readdata(st);
            rpt.SetDataSource(dt);

            crystalReportViewer1.ReportSource = rpt;
        }
        public string GetNameCustomer(int RB, string P_NAME, string P_NAME1, string MEMO21)
        {
            string resuce = "";
            if (RB == 1)
            {
                resuce = P_NAME + " " + P_NAME1 + " " + MEMO21;
            }
            else if (RB == 2)
            {
                resuce = P_NAME + " " + MEMO21;
            }
            else if (RB == 3)
            {
                resuce = P_NAME1 + " " + MEMO21;
            }
            else if (RB == 4)
            {
                resuce = P_NAME + " " + MEMO21;
            }
            else if (RB == 5)
            {
                resuce = P_NAME1 + " " + MEMO21;
            }
            else if (RB == 6)
            {
                resuce = MEMO21;
            }
            else if (RB == 7)
            {
                resuce = P_NAME1 + " " + MEMO21;
            }
            else if (RB == 8)
            {
                resuce = MEMO21;
            }
            return resuce;
        }
    }
}
