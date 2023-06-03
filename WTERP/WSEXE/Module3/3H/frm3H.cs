using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office;
using WTERP.WSEXE;
using System.Net;
using System.Net.Sockets;
using LibraryCalender;

namespace WTERP
{
    public partial class frm3H : Form
    {
        DataProvider con = new DataProvider();
        public frm3H()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
       
        string Date1 = "";
        string Date2 = "";
        string Date3 = "";
        string Date4 = "";

        string Date1_2 = "";
        string Date2_2 = "";
        string Date1_3 = "";
        string Date2_3 = "";
        string SQL = "";
        private void frm3H_Load(object sender, EventArgs e)
        {
            getInfo();
        }
        public void getInfo()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            string UID = frmLogin.ID_USER;
            lbUserName.Text = con.getUser(UID);
            lbNamePC.Text = System.Environment.MachineName;
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        public void Test_MaskedText()
        {
            if (con.Check_MaskedText(txtDATE1) == true)
                Date1 = txtDATE1.Text;
            if (con.Check_MaskedText(txtDATE2) == true)
                Date2 = txtDATE2.Text;
            if (con.Check_MaskedText(txtDATE3) == true)
                Date3 = txtDATE3.Text;
            if (con.Check_MaskedText(txtDATE4) == true)
                Date4 = txtDATE4.Text;
            if (con.Check_MaskedText(txtDate1_2) == true)
                Date1_2 = txtDate1_2.Text;
            if (con.Check_MaskedText(txtDate2_2) == true)
                Date2_2 = txtDate2_2.Text;
            if (con.Check_MaskedText(txtDate1_3) == true)
                Date1_3 = txtDate1_3.Text;
            if (con.Check_MaskedText(txtDate2_3) == true)
                Date2_3 = txtDate2_3.Text;
        }
        public class SEND
        {
            public static string WS_NO1;
            public static string WS_NO2;
            public static string WS_NO3;
            public static string WS_NO4;

            public static string D1;
            public static string D2;
            public static string D3;
            public static string D4;
           
            public static string SQL_Tab1;
            public static string Tilteee;
 
        }
        public void SEND_DL()
        {
            SEND.WS_NO1 = txtWS_NO1.Text;
            SEND.WS_NO2 = txtWS_NO2.Text;
            SEND.WS_NO3 = txtWS_NO1_3.Text;
            SEND.WS_NO4 = txtWS_NO2_3.Text;

            SEND.D1 = Date1_2;
            SEND.D2 = Date2_2;
            SEND.D3 = Date1_3;
            SEND.D4 = Date2_3;
            SEND.SQL_Tab1 = SQL;
        }
        public void getDataSQL()
        {
            if (!string.IsNullOrEmpty(Date1) || !string.IsNullOrEmpty(Date2))
            {
                if (!string.IsNullOrEmpty(Date1) && string.IsNullOrEmpty(Date2))
                {
                    SQL = SQL + " AND ORDB.WS_DATE BETWEEN '" + con.formatstr1(Date1) + "' AND (SELECT TOP 1 WS_DATE FROM ORDB ORDER BY WS_DATE DESC)";
                } 
                else if (string.IsNullOrEmpty(Date1) && !string.IsNullOrEmpty(Date2))
                {
                    SQL = SQL + " AND (ORDB.WS_DATE BETWEEN (SELECT TOP 1 WS_DATE FROM ORDB ORDER BY WS_DATE ASC) AND '" + con.formatstr1(Date2) + "') ";
                }   
                else
                {
                    SQL = SQL + " AND (ORDB.WS_DATE BETWEEN '" + con.formatstr1(Date1) + "' AND '" + con.formatstr1(Date2) + "') ";
                }    
            }  
            if(!string.IsNullOrEmpty(txtC_NO.Text))
            {
                SQL = SQL + " AND ORDB.C_NO = '" + txtC_NO.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtP_NO.Text))
            {
                SQL = SQL + " AND ORDB.P_NO = '" + txtP_NO.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtBRAND.Text))
            {
                SQL = SQL + " AND ORDB.BRAND = '" + txtBRAND.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtCOLOR.Text))
            {
                SQL = SQL + " AND ORDB.COLOR_E = '" + txtCOLOR.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                SQL = SQL + " AND ORDB.C_NO = '" + txtC_NO.Text + "'";
            }
            if (!string.IsNullOrEmpty(Date3) || !string.IsNullOrEmpty(Date4))
            {
                SQL = SQL + "";
            }
        }
        private void btnXemTruoc_Click(object sender, EventArgs e)
        {
            Test_MaskedText();
            SEND_DL();
            if(tabControl1.SelectedIndex == 0)
            {
                view1();
            }
            else if(tabControl1.SelectedIndex == 1)
            {
               view2();
            }
            else if(tabControl1.SelectedIndex == 2)
            {
               view3();
            }
        }
        private void f9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDong.PerformClick();
        }
        public void Export_Excel2(System.Data.DataTable da)
        {
            try
            {
                string Dat1 = con.formatstr1(Date1);
                string title = "";
                if (rdHANGMAU.Checked == true)
                {
                    // string result = Dat1.Insert(0, "20");
                    title =  " 榔皮樣品未派工表    Sample of Split Report ";
                }
                else if (rdHANGSX.Checked == true)
                {
                    title = " 榔皮量產未派工表 Split Mass Production Report ";
                }    

                int ColumnsCount = da.Columns.Count;

                //Khoi tao Excel
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // Khoi tao WorkBook
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                //khoi tao worksheet
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                worksheet = workbook.Worksheets[1];
                app.Visible = true;

                Range Row_TieuDe = worksheet.get_Range("A2", "L2");
                Row_TieuDe.Merge();
                Row_TieuDe.Font.Name = "Times New Roman";
                Row_TieuDe.Font.Size = 18;
                Row_TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                Row_TieuDe.Value2 = title;
                //Header
                Range row_header = worksheet.get_Range("A4", "L5");
                row_header.Font.Size = 12;
                row_header.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row_header.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightYellow);


                Range item1 = worksheet.get_Range("A4", "A5");
                //item1.Merge();
                item1.Font.Name = "Times New Roman";
                item1.Font.Size = 12;
                item1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                item1.VerticalAlignment = XlVAlign.xlVAlignCenter;
                //item1.Value2 = "#";
                //item1.ColumnWidth = 3;

                worksheet.Cells[3, 1] = "起迄日期:" + txtDATE1.Text + "-" + txtDATE2.Text + "";

                worksheet.Cells[4, 1] = "下單日期";
                worksheet.Cells[4, 2] = "客戶名稱";
                worksheet.Cells[4, 3] = "訂單號碼";
                worksheet.Cells[4, 4] = "貿易商.品牌";
                worksheet.Cells[4, 5] = "鞋型";
                worksheet.Cells[4, 6] = "材料名稱";
                worksheet.Cells[4, 7] = "紋路";
                worksheet.Cells[4, 8] = "顏色";
                worksheet.Cells[4, 9] = "厚度";
                worksheet.Cells[4, 10] = "數量";
                worksheet.Cells[4, 11] = "樣品指令";
                worksheet.Cells[4, 12] = "";


                worksheet.Cells[5, 1] = "DATE";
                worksheet.Cells[5, 2] = "CUST.";
                worksheet.Cells[5, 3] = "PO#";
                worksheet.Cells[5, 4] = "BRAND";
                worksheet.Cells[5, 5] = "MODEL#";
                worksheet.Cells[5, 6] = "MATERIAL NAME";
                worksheet.Cells[5, 7] = "PATT#";
                worksheet.Cells[5, 8] = "COLOR";
                worksheet.Cells[5, 9] = "THICK";
                worksheet.Cells[5, 10] = "QTY";
                worksheet.Cells[5, 11] = "";
                worksheet.Cells[5, 12] = "";

                //Auto Size
                worksheet.Columns.AutoFit();
                // Show DataTable 
                int RowsCount = da.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];
                for (int j = 0; j <= RowsCount - 1; j++)
                    for (int i = 0; i <= ColumnsCount - 1; i++)
                        Cells[j, i] = da.Rows[j][i];
                worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[6, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 5, ColumnsCount])).Value2 = Cells;
                //thoát và thu hồi bộ nhớ cho COM
                app.Quit();
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(app);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void Export_Excel3(System.Data.DataTable da)
        {
            try
            {
                string Dat1 = con.formatstr1(Date1);
                string title = "";
               if (rdHANGMAU.Checked == true)
                {
                    // string result = Dat1.Insert(0, "20");
                    title =  " 榔皮樣品未派工表    Sample of Split Report ";
                }
                else if (rdHANGSX.Checked == true)
                {
                    title = " 榔皮量產未派工表 Split Mass Production Report ";
                }    
                int ColumnsCount = da.Columns.Count;
                if (da == null || ColumnsCount == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");
                //Khoi tao Excel
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // Khoi tao WorkBook
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                //khoi tao worksheet
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                worksheet = workbook.Worksheets[1];
                app.Visible = true;

                Range Row_TieuDe = worksheet.get_Range("A2", "L2");
                Row_TieuDe.Merge();
                Row_TieuDe.Font.Name = "Times New Roman";
                Row_TieuDe.Font.Size = 18;
                Row_TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                Row_TieuDe.Value2 = title;

                //Header
                Range row_header = worksheet.get_Range("A4", "L5");
                row_header.Font.Size = 12;
                row_header.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row_header.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightYellow);


                Range item1 = worksheet.get_Range("A4", "A5");
                //item1.Merge();
                item1.Font.Name = "Times New Roman";
                item1.Font.Size = 12;
                item1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                item1.VerticalAlignment = XlVAlign.xlVAlignCenter;
                //item1.Value2 = "#";
                //item1.ColumnWidth = 3;

                worksheet.Cells[3, 1] = "起迄日期:" + txtDATE1.Text + "-" + txtDATE2.Text + "";
                worksheet.Cells[4, 1] = "下單日期";
                worksheet.Cells[4, 2] = "客戶名稱";
                worksheet.Cells[4, 3] = "訂單號碼";
                worksheet.Cells[4, 4] = "貿易商.品牌";
                worksheet.Cells[4, 5] = "鞋型";
                worksheet.Cells[4, 6] = "材料名稱";
                worksheet.Cells[4, 7] = "紋路";
                worksheet.Cells[4, 8] = "顏色";
                worksheet.Cells[4, 9] = "厚度";
                worksheet.Cells[4, 10] = "數量";
                worksheet.Cells[4, 11] = "樣品指令";
                worksheet.Cells[4, 12] = "";


                worksheet.Cells[5, 1] = "DATE";
                worksheet.Cells[5, 2] = "CUST.";
                worksheet.Cells[5, 3] = "PO#";
                worksheet.Cells[5, 4] = "BRAND";
                worksheet.Cells[5, 5] = "MODEL#";
                worksheet.Cells[5, 6] = "MATERIAL NAME";
                worksheet.Cells[5, 7] = "PATT#";
                worksheet.Cells[5, 8] = "COLOR";
                worksheet.Cells[5, 9] = "THICK";
                worksheet.Cells[5, 10] = "QTY";
                worksheet.Cells[5, 11] = "";
                worksheet.Cells[5, 12] = "";

                //Auto Size
                worksheet.Columns.AutoFit();
                // Show DataTable 
                int RowsCount = da.Rows.Count;
                object[,] Cells = new object[RowsCount, ColumnsCount];
                for (int j = 0; j <= RowsCount - 1; j++)
                    for (int i = 0; i <= ColumnsCount - 1; i++)
                        Cells[j, i] = da.Rows[j][i];
                worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[6, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 5, ColumnsCount])).Value2 = Cells;


                //thoát và thu hồi bộ nhớ cho COM
                app.Quit();
                releaseObject(worksheet);
                releaseObject(workbook);
                releaseObject(app);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        public void view1()
        {
            //excel
           // hàng mẫu
            if(rdEXCLE.Checked == true && rdHANGMAU.Checked == true)
            {
                if (rdKGUI.Checked == true)
                {
                    SQL = "SELECT ORDB.WS_DATE + '/' + ORDB.NR AS DATE, CUST.C_ANAME2, ORDB.OR_NO, ORDB.BRAND, ORDB.MODEL_E, ORDB.P_NAME_E, ORDB.PATT_C, ORDB.COLOR_E, ORDB.THICK, ORDB.QTY,PRDMK1.WS_NO, ORDB.OVER1" +
                    " FROM ORDB left join PRDMK1 on PRDMK1.WS_DATE1 = ORDB.WS_DATE AND PRDMK1.NR = ORDB.NR AND PRDMK1.K_NO = ORDB.K_NO inner join CUST on CUST.C_NO = ORDB.C_NO WHERE 1=1";
                    getDataSQL();
                    SQL = SQL + " AND ORDB.QTY<>0 AND ORDB.K_NO='1' and purchaser<>'台灣制作' AND (PRDMK1.OVER0 = 'N' or PRDMK1.OVER0 IS NULL) ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR";
                    System.Data.DataTable dt = con.readdata(SQL);
                    Export_Excel2(dt);
                }
                if (rdGUI.Checked == true)
                {
                    SQL = "SELECT ORDB.WS_DATE + '/' + ORDB.NR AS DATE, CUST.C_ANAME2, ORDB.OR_NO, ORDB.BRAND, ORDB.MODEL_E, ORDB.P_NAME_E, ORDB.PATT_C, ORDB.COLOR_E, ORDB.THICK, ORDB.QTY,PRDMK1.WS_NO, PRDMK1.OVER0" +
                    " FROM ORDB left join PRDMK1 on PRDMK1.WS_DATE1 = ORDB.WS_DATE AND PRDMK1.NR = ORDB.NR AND PRDMK1.K_NO = ORDB.K_NO inner join CUST on CUST.C_NO = ORDB.C_NO WHERE 1=1";
                    getDataSQL();
                    SQL = SQL + " AND ORDB.QTY<>0 AND ORDB.K_NO='1' and purchaser<>'台灣制作' AND (PRDMK1.OVER0 = 'Y') ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR";
                    System.Data.DataTable dt = con.readdata(SQL);
                    Export_Excel3(dt);
                }    
            }
            //Hàng sx
            if (rdEXCLE.Checked == true && rdHANGSX.Checked == true)
            {
                if (rdKGUI.Checked == true)
                {
                    SQL = "SELECT ORDB.WS_DATE + '/' + cast(ROW_NUMBER() OVER (ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR) as varchar) AS DATE, CUST.C_ANAME2, ORDB.OR_NO, ORDB.BRAND, ORDB.MODEL_E, ORDB.P_NAME_E, ORDB.PATT_C, ORDB.COLOR_E, ORDB.THICK, ORDB.QTY,PRDMK2.WS_NO, ORDB.OVER1" +
                    " FROM ORDB left join PRDMK2 on PRDMK2.WS_DATE1 = ORDB.WS_DATE AND PRDMK2.NR = ORDB.NR AND PRDMK2.K_NO = ORDB.K_NO inner join CUST on CUST.C_NO = ORDB.C_NO WHERE 1=1";
                    getDataSQL();
                    SQL = SQL + " AND ORDB.QTY<>0 AND ORDB.K_NO='3' AND (PRDMK2.OVER0 = 'N' or PRDMK2.OVER0 IS NULL) ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR";
                    System.Data.DataTable dt = con.readdata(SQL);
                    Export_Excel2(dt);
                }
                if (rdGUI.Checked == true)
                {
                    SQL = "SELECT ORDB.WS_DATE + '/' + cast(ROW_NUMBER() OVER (ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR) as varchar) AS DATE, CUST.C_ANAME2, ORDB.OR_NO, ORDB.BRAND, ORDB.MODEL_E, ORDB.P_NAME_E, ORDB.PATT_C, ORDB.COLOR_E, ORDB.THICK, ORDB.QTY,PRDMK2.WS_NO, PRDMK2.OVER0" +
                    " FROM ORDB left join PRDMK2 on PRDMK2.WS_DATE1 = ORDB.WS_DATE AND PRDMK2.NR = ORDB.NR AND PRDMK2.K_NO = ORDB.K_NO inner join CUST on CUST.C_NO = ORDB.C_NO WHERE 1=1";
                    getDataSQL();
                    SQL = SQL + " AND ORDB.QTY<>0 AND ORDB.K_NO='3' AND (PRDMK2.OVER0 = 'Y') ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR";
                    System.Data.DataTable dt = con.readdata(SQL);
                    Export_Excel3(dt);
                }
            }
            //Report
            // hàng mẫu
            if (rdBAOCAO.Checked == true && rdHANGMAU.Checked == true)
            {
                if (rdKGUI.Checked == true)
                {
                    SQL = "SELECT ORDB.WS_DATE AS DATE, CUST.C_ANAME2, ORDB.OR_NO, ORDB.BRAND, ORDB.MODEL_E, ORDB.P_NAME_E, ORDB.PATT_C, ORDB.COLOR_E, ORDB.THICK, ORDB.QTY,PRDMK1.WS_NO, ORDB.OVER1" +
                    " FROM ORDB left join PRDMK1 on PRDMK1.WS_DATE1 = ORDB.WS_DATE AND PRDMK1.NR = ORDB.NR AND PRDMK1.K_NO = ORDB.K_NO inner join CUST on CUST.C_NO = ORDB.C_NO WHERE 1=1";
                    getDataSQL();
                    SQL = SQL + " AND ORDB.QTY<>0 AND ORDB.K_NO='1' and purchaser<>'台灣制作' AND (PRDMK1.OVER0 = 'N' or PRDMK1.OVER0 IS NULL) ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR";
                }
                if (rdGUI.Checked == true)
                {
                    SQL = "SELECT ORDB.WS_DATE AS DATE, CUST.C_ANAME2, ORDB.OR_NO, ORDB.BRAND, ORDB.MODEL_E, ORDB.P_NAME_E, ORDB.PATT_C, ORDB.COLOR_E, ORDB.THICK, ORDB.QTY,PRDMK1.WS_NO, PRDMK1.OVER0" +
                    " FROM ORDB left join PRDMK1 on PRDMK1.WS_DATE1 = ORDB.WS_DATE AND PRDMK1.NR = ORDB.NR AND PRDMK1.K_NO = ORDB.K_NO inner join CUST on CUST.C_NO = ORDB.C_NO WHERE 1=1";
                    getDataSQL();
                    SQL = SQL + " AND ORDB.QTY<>0 AND ORDB.K_NO='1' and purchaser<>'台灣制作' AND (PRDMK1.OVER0 = 'Y') ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR";
                }
                SEND.SQL_Tab1 = SQL;
                if (rdHANGMAU.Checked == true)
                {
                    // string result = Dat1.Insert(0, "20");
                    SEND.Tilteee = " 榔皮樣品未派工表    Sample of Split Report ";
                }
                else if (rdHANGSX.Checked == true)
                {
                    SEND.Tilteee = " 榔皮量產未派工表 Split Mass Production Report ";
                }
                frm3HF7_Tab1 fr1 = new frm3HF7_Tab1();
                fr1.ShowDialog();
            }
            //Hàng sx
            if (rdBAOCAO.Checked == true && rdHANGSX.Checked == true)
            {
                if (rdKGUI.Checked == true)
                {
                    SQL = "SELECT ORDB.WS_DATE + '/' + cast(ROW_NUMBER() OVER (ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR) as varchar) AS DATE, CUST.C_ANAME2, ORDB.OR_NO, ORDB.BRAND, ORDB.MODEL_E, ORDB.P_NAME_E, ORDB.PATT_C, ORDB.COLOR_E, ORDB.THICK, ORDB.QTY,PRDMK2.WS_NO, ORDB.OVER1" +
                    " FROM ORDB left join PRDMK2 on PRDMK2.WS_DATE1 = ORDB.WS_DATE AND PRDMK2.NR = ORDB.NR AND PRDMK2.K_NO = ORDB.K_NO inner join CUST on CUST.C_NO = ORDB.C_NO WHERE 1=1";
                    getDataSQL();
                    SQL = SQL + " AND ORDB.QTY<>0 AND ORDB.K_NO='3' AND (PRDMK2.OVER0 = 'N' or PRDMK2.OVER0 IS NULL) ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR";
                }
                if (rdGUI.Checked == true)
                {
                    SQL = "SELECT ORDB.WS_DATE + '/' + cast(ROW_NUMBER() OVER (ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR) as varchar) AS DATE, CUST.C_ANAME2, ORDB.OR_NO, ORDB.BRAND, ORDB.MODEL_E, ORDB.P_NAME_E, ORDB.PATT_C, ORDB.COLOR_E, ORDB.THICK, ORDB.QTY,PRDMK2.WS_NO, PRDMK2.OVER0" +
                    " FROM ORDB left join PRDMK2 on PRDMK2.WS_DATE1 = ORDB.WS_DATE AND PRDMK2.NR = ORDB.NR AND PRDMK2.K_NO = ORDB.K_NO inner join CUST on CUST.C_NO = ORDB.C_NO WHERE 1=1";
                    getDataSQL();
                    SQL = SQL + " AND ORDB.QTY<>0 AND ORDB.K_NO='3' AND (PRDMK2.OVER0 = 'Y') ORDER BY ORDB.WS_DATE,ORDB.C_NO,ORDB.NR";
                }
                SEND.SQL_Tab1 = SQL;
                if (rdHANGMAU.Checked == true)
                {
                    // string result = Dat1.Insert(0, "20");
                    SEND.Tilteee = " 榔皮樣品未派工表    Sample of Split Report ";
                }
                else if (rdHANGSX.Checked == true)
                {
                    SEND.Tilteee = " 榔皮量產未派工表 Split Mass Production Report ";
                }
                frm3HF7_Tab1 fr1 = new frm3HF7_Tab1();
                fr1.ShowDialog();
            }
           
        }
        public void view2()
        {
            frm3H_Tap2 fr1 = new frm3H_Tap2();
            fr1.ShowDialog();
        }
        public void view3()
        {
            frm3H_Tab3 fr2 = new frm3H_Tab3();
            fr2.ShowDialog();
        }

        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr = new frm2CustSearch();
            fr.ShowDialog();
            string DL = frm2CustSearch.ID.ID_CUST;
            if (DL != string.Empty)
            {
                txtC_NO.Text = DL;
            }
            else
                txtC_NO.Text = "";
        }

        private void txtP_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchMaterial2 fr1 = new FormSearchMaterial2();
            fr1.ShowDialog();
            string DL = FormSearchMaterial2.ID.ID_P_NO;
            if (DL != string.Empty)
            {
                txtP_NO.Text = DL;
            }
            else
                txtP_NO.Text = "";
        }

        private void txtBRAND_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fr3 = new FormSearchBrand();
            fr3.ShowDialog();
            string DL = FormSearchBrand.ID.B_NO;
            if (DL != string.Empty)
            {
                txtBRAND.Text = DL;
            }
            else
                txtBRAND.Text = "";

        }

        private void txtWS_NO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form3EF5 fr1 = new Form3EF5();
            fr1.ShowDialog();
            string DL = Form3EF5.getInfo.WS_NO;
            if (DL != string.Empty)
            {
                txtWS_NO1.Text = DL;
            }
            else
                txtWS_NO1.Text = "";
        }

        private void txtWS_NO2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form3EF5 fr2 = new Form3EF5();
            fr2.ShowDialog();
            string DL = Form3EF5.getInfo.WS_NO;
            if (DL != string.Empty)
            {
                txtWS_NO2.Text = DL;
            }
            else
                txtWS_NO2.Text = "";
        }

        private void txtWS_NO1_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form3EF5 fr3 = new Form3EF5();
            fr3.ShowDialog();
            string DL = Form3EF5.getInfo.WS_NO;
            if (DL != string.Empty)
            {
                txtWS_NO1_3.Text = DL;
            }
            else
                txtWS_NO1_3.Text = "";
        }

        private void txtWS_NO2_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form3EF5 fr4 = new Form3EF5();
            fr4.ShowDialog();
            string DL = Form3EF5.getInfo.WS_NO;
            if (DL != string.Empty)
            {
                txtWS_NO2_3.Text = DL;
            }
            else
                txtWS_NO2_3.Text = "";
        }

        private void txtDATE1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE1.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txtDATE2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE2.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txtDATE3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE3.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txtDATE4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDATE4.Text = FromCalender.getDate.ToString("yyMMdd");
        }

        private void txtDate1_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate1_2.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtDate2_2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate2_2.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtDate1_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate1_3.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtDate2_3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate2_3.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtDATE1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtDATE4, txtDATE2, sender, e);
        }

        private void txtDATE2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDATE1, txtC_NO, sender, e);
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDATE2, txtP_NO, sender, e);
        }

        private void txtP_NO_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtC_NO, txtBRAND, sender, e);
        }

        private void txtBRAND_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtP_NO, txtCOLOR, sender, e);
        }

        private void txtCOLOR_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtBRAND, txtDATE3, sender, e);
        }

        private void txtDATE3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtCOLOR, txtDATE4, sender, e);
        }

        private void txtDATE4_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtDATE3, txtDATE1, sender, e);
        }

        private void txtWS_NO1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate2_2, txtWS_NO2, sender, e);
        }

        private void txtWS_NO2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtWS_NO1, txtWS_NO1, sender, e);
        }

        private void txtWS_NO1_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate2_3, txtWS_NO2_3, sender, e);
        }

        private void txtWS_NO2_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtWS_NO1_3, txtDate1_3, sender, e);
        }

        private void txtDate1_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtWS_NO2_3, txtDate2_3, sender, e);
        }

        private void txtDate2_3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate1_3, txtWS_NO1_3, sender, e);
        }
    }
}
