using LibraryCalender;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2J : Form
    {
        DataProvider con = new DataProvider();
        public frm2J()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        //khai báo biến
        string a = "";
        string b = "";
        string c = "";
        string d = "";
        string f = "";
        string h = "";
        private void button2_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                this.Close();
        }
        private void frm2J_Load(object sender, EventArgs e)
        {
            getInfo();
        }
        public void getInfo() //Method getIP,ID, User...  
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)  // get IP Local  
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    lbIP.Text = address.ToString();
            }
            string UID = frmLogin.ID_USER; // get ID User 
            lbUserName.Text = con.getUser(UID);// get UserName 
            lbNamePC.Text = System.Environment.MachineName; //get Name PC
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                View1();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
              //  MessageBox.Show("Chức năng đang được phát triển");
            }
            else if (tabControl1.SelectedIndex == 2)
            {
              //  MessageBox.Show("Chức năng đang được phát triển");
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                //MessageBox.Show("Chức năng đang được phát triển");
            }
        }

        private void View1()
        {
            
        }
        #region Tab1
        public void checktab_1()
        {
           if (con.Check_MaskedText(txtWS_DATE1_S) == true)
            {
                a = con.formatstr1(txtWS_DATE1_S.Text);
            }
            if (con.Check_MaskedText(txtWS_DATE1_E) == true)
            {
                b = con.formatstr1(txtWS_DATE1_E.Text);
            }
        }
        private void ReportView_Tab1()
        {
            checktab_1();
            string SQL = "";
            //điều kiện
            System.Data.DataTable dt = con.readdata(SQL);
            Export_Excel_tab_1(dt);
        }
        public void Export_Excel_tab_1(System.Data.DataTable da)
        {
            string title = "Production Open Order (量產接單數)"; 

            int ColumnsCount;
            if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;

            Range Row_TieuDe = worksheet.get_Range("A5", "E5");
            Row_TieuDe.Merge();
            Row_TieuDe.Font.Name = "Times New Roman";
            Row_TieuDe.Font.Size = 18;
            Row_TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Row_TieuDe.Value2 = title;

            //Header
            Range row_header = worksheet.get_Range("A4", "P5");
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
            // tiêu đề
            worksheet.Cells[1, 1] = "TANNERY: Wel Tai Leather Co.,Ltd (制革廠:緯達皮革有限公司)";
            worksheet.Cells[2, 1] = "TOTAL OPEN ORDER NOT SHIPPED YET:";
            worksheet.Cells[3, 1] = "Blanket Balance:";

            worksheet.Cells[6, 1] = "Factory(鞋廠)";
            worksheet.Cells[6, 2] = "Factory PO#(鞋廠訂單)";
            worksheet.Cells[6, 3] = "Date PO Received from Factory(接單日)";
            worksheet.Cells[6, 4] = "PART#(ex:01234)";
            worksheet.Cells[6, 5] = "TANNAGE(材料)";
            worksheet.Cells[6, 6] = "COLOR(顏色)";
            worksheet.Cells[6, 7] = "GRADE(ex:TR or LG)(等級)";
            worksheet.Cells[6, 8] = "WGT(ex:1.6-1.8)(厚度)";
            worksheet.Cells[6, 9] = "Footage Ordered Sq.ft.(接單數量)";
            worksheet.Cells[6, 10] = "Confirmed X-Tannery Date (確認交期)";
            worksheet.Cells[6, 11] = "Balance DUE(延遲交貨原因)";
            worksheet.Cells[6, 12] = "Comments(改進方法)";
            worksheet.Cells[6, 13] = "ACCUMU LATIVE TOTAL(總的接單數量)";
            worksheet.Cells[6, 14] = "Blanket BALANCE(未下完總的預告單數量)";
           

            //Auto Size
            worksheet.Columns.AutoFit();
            // Show DataTable 
            int RowsCount = da.Rows.Count;
            object[,] Cells = new object[RowsCount, ColumnsCount];
            for (int j = 0; j < RowsCount; j++)
                for (int i = 0; i < ColumnsCount; i++)
                    Cells[j, i] = da.Rows[j][i];
            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[6, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 5, ColumnsCount])).Value2 = Cells;


            //thoát và thu hồi bộ nhớ cho COM
            app.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);

        }
        #endregion
        #region Tab2
        public void checktab_2()
        {
            if (con.Check_MaskedText(txtWS_DATE2_S) == true)
            {
                c = con.formatstr1(txtWS_DATE2_S.Text);
            }
            if (con.Check_MaskedText(txtWS_DATE2_E) == true)
            {
                d = con.formatstr1(txtWS_DATE2_E.Text);
            }
        }
        private void ReportView_Tab2()
        {
            checktab_2();
            string SQL = "";
            //điều kiện
            System.Data.DataTable dt = con.readdata(SQL);
            Export_Excel_tab_2(dt);
        }
        public void Export_Excel_tab_2(System.Data.DataTable da)
        {
            //string Date12 = con.formatstr1(txtDate1.Text);
            //// string Start = con.formatstr1(txtStart.Text);
            //// string End = con.formatstr1(txtEnd.Text);
            //string result = Date12.Insert(0, "20");
            string title = "abc"; //txtAchi2.Text + " D  " + "ABC" + " ORDER REPORT(業績表)";

            int ColumnsCount;
            if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;

            Range Row_TieuDe = worksheet.get_Range("A2", "P2");
            Row_TieuDe.Merge();
            Row_TieuDe.Font.Name = "Times New Roman";
            Row_TieuDe.Font.Size = 18;
            Row_TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Row_TieuDe.Value2 = title;

            //Header
            Range row_header = worksheet.get_Range("A4", "P5");
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


            worksheet.Cells[4, 1] = "下單日期";
            worksheet.Cells[4, 2] = "客戶名稱";
            worksheet.Cells[4, 3] = "訂單號碼";
            worksheet.Cells[4, 4] = "貿易商.品牌";
            worksheet.Cells[4, 5] = "鞋型";
            worksheet.Cells[4, 6] = "顏色";
            worksheet.Cells[4, 7] = "材料名稱材料名稱";
            worksheet.Cells[4, 8] = "厚度";
            worksheet.Cells[4, 9] = "數量";
            worksheet.Cells[4, 10] = "單價";
            worksheet.Cells[4, 11] = "";
            worksheet.Cells[4, 12] = "訂單數量";
            worksheet.Cells[4, 13] = "實際出貨數量";
            worksheet.Cells[4, 14] = "出貨數量";
            worksheet.Cells[4, 15] = "入帳月";
            worksheet.Cells[4, 16] = "協理複查";


            worksheet.Cells[5, 1] = "DATE";
            worksheet.Cells[5, 2] = "CUST.";
            worksheet.Cells[5, 3] = "PO#";
            worksheet.Cells[5, 4] = "BRAND";
            worksheet.Cells[5, 5] = "MODEL#";
            worksheet.Cells[5, 6] = "COLOR";
            worksheet.Cells[5, 7] = "METERIAL NAME";
            worksheet.Cells[5, 8] = "THICK";
            worksheet.Cells[5, 9] = "QTY";
            worksheet.Cells[5, 10] = "PRICE";
            worksheet.Cells[5, 11] = "%";
            worksheet.Cells[5, 12] = "ORDER QTY";
            worksheet.Cells[5, 13] = "QTY";
            worksheet.Cells[5, 14] = "QTY SHIPPED";
            worksheet.Cells[5, 15] = "MONTH OF ACCOUNT";
            worksheet.Cells[5, 16] = "REVIEWED";
            //Auto Size
            worksheet.Columns.AutoFit();
            // Show DataTable 
            int RowsCount = da.Rows.Count;
            object[,] Cells = new object[RowsCount, ColumnsCount];
            for (int j = 0; j < RowsCount; j++)
                for (int i = 0; i < ColumnsCount; i++)
                    Cells[j, i] = da.Rows[j][i];
            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[6, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 5, ColumnsCount])).Value2 = Cells;


            //thoát và thu hồi bộ nhớ cho COM
            app.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);

        }
        #endregion
        #region Tab3
        public void checktab_3()
        {
            if (con.Check_MaskedText(txtWS_DATE3_S) == true)
            {
                f = con.formatstr1(txtWS_DATE3_S.Text);
            }
            if (con.Check_MaskedText(txtWS_DATE3_E) == true)
            {
                h = con.formatstr1(txtWS_DATE3_E.Text);
            }
        }
        private void ReportView_Tab3()
        {
            checktab_3();
            string SQL = "";
            //điều kiện
            System.Data.DataTable dt = con.readdata(SQL);
            Export_Excel_tab_3(dt);
        }
        public void Export_Excel_tab_3(System.Data.DataTable da)
        {
            //string Date12 = con.formatstr1(txtDate1.Text);
            //// string Start = con.formatstr1(txtStart.Text);
            //// string End = con.formatstr1(txtEnd.Text);
            //string result = Date12.Insert(0, "20");
            string title = "abc"; //txtAchi2.Text + " D  " + "ABC" + " ORDER REPORT(業績表)";

            int ColumnsCount;
            if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;

            Range Row_TieuDe = worksheet.get_Range("A2", "P2");
            Row_TieuDe.Merge();
            Row_TieuDe.Font.Name = "Times New Roman";
            Row_TieuDe.Font.Size = 18;
            Row_TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Row_TieuDe.Value2 = title;

            //Header
            Range row_header = worksheet.get_Range("A4", "P5");
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


            worksheet.Cells[4, 1] = "下單日期";
            worksheet.Cells[4, 2] = "客戶名稱";
            worksheet.Cells[4, 3] = "訂單號碼";
            worksheet.Cells[4, 4] = "貿易商.品牌";
            worksheet.Cells[4, 5] = "鞋型";
            worksheet.Cells[4, 6] = "顏色";
            worksheet.Cells[4, 7] = "材料名稱材料名稱";
            worksheet.Cells[4, 8] = "厚度";
            worksheet.Cells[4, 9] = "數量";
            worksheet.Cells[4, 10] = "單價";
            worksheet.Cells[4, 11] = "";
            worksheet.Cells[4, 12] = "訂單數量";
            worksheet.Cells[4, 13] = "實際出貨數量";
            worksheet.Cells[4, 14] = "出貨數量";
            worksheet.Cells[4, 15] = "入帳月";
            worksheet.Cells[4, 16] = "協理複查";


            worksheet.Cells[5, 1] = "DATE";
            worksheet.Cells[5, 2] = "CUST.";
            worksheet.Cells[5, 3] = "PO#";
            worksheet.Cells[5, 4] = "BRAND";
            worksheet.Cells[5, 5] = "MODEL#";
            worksheet.Cells[5, 6] = "COLOR";
            worksheet.Cells[5, 7] = "METERIAL NAME";
            worksheet.Cells[5, 8] = "THICK";
            worksheet.Cells[5, 9] = "QTY";
            worksheet.Cells[5, 10] = "PRICE";
            worksheet.Cells[5, 11] = "%";
            worksheet.Cells[5, 12] = "ORDER QTY";
            worksheet.Cells[5, 13] = "QTY";
            worksheet.Cells[5, 14] = "QTY SHIPPED";
            worksheet.Cells[5, 15] = "MONTH OF ACCOUNT";
            worksheet.Cells[5, 16] = "REVIEWED";
            //Auto Size
            worksheet.Columns.AutoFit();
            // Show DataTable 
            int RowsCount = da.Rows.Count;
            object[,] Cells = new object[RowsCount, ColumnsCount];
            for (int j = 0; j < RowsCount; j++)
                for (int i = 0; i < ColumnsCount; i++)
                    Cells[j, i] = da.Rows[j][i];
            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[6, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 5, ColumnsCount])).Value2 = Cells;


            //thoát và thu hồi bộ nhớ cho COM
            app.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);

        }
        #endregion
        #region Tab4
        public void checktab_4()
        {
            if (con.Check_MaskedText(txtWS_DATE4) == true)
            {
                h = con.formatstr1(txtWS_DATE4.Text);
            }
           
        }
        private void ReportView_Tab4()
        {
            checktab_4();
            string SQL = "";
            //điều kiện
            System.Data.DataTable dt = con.readdata(SQL);
            Export_Excel_tab_4(dt);
        }
        public void Export_Excel_tab_4(System.Data.DataTable da)
        {
            //string Date12 = con.formatstr1(txtDate1.Text);
            //// string Start = con.formatstr1(txtStart.Text);
            //// string End = con.formatstr1(txtEnd.Text);
            //string result = Date12.Insert(0, "20");
            string title = "abc"; //txtAchi2.Text + " D  " + "ABC" + " ORDER REPORT(業績表)";

            int ColumnsCount;
            if (da == null || (ColumnsCount = da.Columns.Count) == 0)
                throw new Exception("ExportToExcel: Null or empty input table!\n");
            //Khoi tao Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // Khoi tao WorkBook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //khoi tao worksheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Worksheets[1];
            app.Visible = true;

            Range Row_TieuDe = worksheet.get_Range("A2", "P2");
            Row_TieuDe.Merge();
            Row_TieuDe.Font.Name = "Times New Roman";
            Row_TieuDe.Font.Size = 18;
            Row_TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Row_TieuDe.Value2 = title;

            //Header
            Range row_header = worksheet.get_Range("A4", "P5");
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


            worksheet.Cells[4, 1] = "下單日期";
            worksheet.Cells[4, 2] = "客戶名稱";
            worksheet.Cells[4, 3] = "訂單號碼";
            worksheet.Cells[4, 4] = "貿易商.品牌";
            worksheet.Cells[4, 5] = "鞋型";
            worksheet.Cells[4, 6] = "顏色";
            worksheet.Cells[4, 7] = "材料名稱材料名稱";
            worksheet.Cells[4, 8] = "厚度";
            worksheet.Cells[4, 9] = "數量";
            worksheet.Cells[4, 10] = "單價";
            worksheet.Cells[4, 11] = "";
            worksheet.Cells[4, 12] = "訂單數量";
            worksheet.Cells[4, 13] = "實際出貨數量";
            worksheet.Cells[4, 14] = "出貨數量";
            worksheet.Cells[4, 15] = "入帳月";
            worksheet.Cells[4, 16] = "協理複查";


            worksheet.Cells[5, 1] = "DATE";
            worksheet.Cells[5, 2] = "CUST.";
            worksheet.Cells[5, 3] = "PO#";
            worksheet.Cells[5, 4] = "BRAND";
            worksheet.Cells[5, 5] = "MODEL#";
            worksheet.Cells[5, 6] = "COLOR";
            worksheet.Cells[5, 7] = "METERIAL NAME";
            worksheet.Cells[5, 8] = "THICK";
            worksheet.Cells[5, 9] = "QTY";
            worksheet.Cells[5, 10] = "PRICE";
            worksheet.Cells[5, 11] = "%";
            worksheet.Cells[5, 12] = "ORDER QTY";
            worksheet.Cells[5, 13] = "QTY";
            worksheet.Cells[5, 14] = "QTY SHIPPED";
            worksheet.Cells[5, 15] = "MONTH OF ACCOUNT";
            worksheet.Cells[5, 16] = "REVIEWED";
            //Auto Size
            worksheet.Columns.AutoFit();
            // Show DataTable 
            int RowsCount = da.Rows.Count;
            object[,] Cells = new object[RowsCount, ColumnsCount];
            for (int j = 0; j < RowsCount; j++)
                for (int i = 0; i < ColumnsCount; i++)
                    Cells[j, i] = da.Rows[j][i];
            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[6, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 5, ColumnsCount])).Value2 = Cells;


            //thoát và thu hồi bộ nhớ cho COM
            app.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);

        }
        #endregion
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

        private void txtWS_DATE1_S_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender dateTime = new FromCalender();
            dateTime.ShowDialog();
            txtWS_DATE1_S.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtWS_DATE1_E_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender dateTime = new FromCalender();
            dateTime.ShowDialog();
            txtWS_DATE1_S.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtWS_DATE2_S_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender dateTime = new FromCalender();
            dateTime.ShowDialog();
            txtWS_DATE1_S.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtWS_DATE2_E_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender dateTime = new FromCalender();
            dateTime.ShowDialog();
            txtWS_DATE1_S.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtWS_DATE3_S_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender dateTime = new FromCalender();
            dateTime.ShowDialog();
            txtWS_DATE1_S.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtWS_DATE3_E_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender dateTime = new FromCalender();
            dateTime.ShowDialog();
            txtWS_DATE1_S.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtWS_DATE4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender dateTime = new FromCalender();
            dateTime.ShowDialog();
            txtWS_DATE1_S.Text = FromCalender.getDate.ToString("yy/MM");
        }

        private void txtWS_DATE1_S_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtWS_DATE1_E, txtWS_DATE1_E, sender, e);
        }

        private void txtWS_DATE1_E_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtWS_DATE1_S, txtWS_DATE1_S, sender, e);
        }

        private void txtWS_DATE2_S_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtWS_DATE2_E, txtWS_DATE2_E, sender, e);
        }

        private void txtWS_DATE2_E_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtWS_DATE2_S, txtWS_DATE2_S, sender, e);
        }

        private void txtWS_DATE3_S_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtWS_DATE3_E, txtWS_DATE3_E, sender, e);
        }

        private void txtWS_DATE3_E_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtWS_DATE3_S, txtWS_DATE3_S, sender, e);
        }
    }
}
