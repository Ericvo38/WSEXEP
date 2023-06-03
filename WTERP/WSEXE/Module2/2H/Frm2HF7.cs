using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office;
using LibraryCalender;

namespace WTERP
{
    public partial class frm2HF7 : Form
        
    {
        DataProvider con = new DataProvider();
        public frm2HF7()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }

        string Date1 = "";
        string Start = "";
        string End = "";
        string result = "";
        string title = "";
        string K_NO1 = "1";
        string K_NO2 = "2";
        string K_NO3 = "3";
        string K_NO4 = "4";
        string SQL = "";
        public void check()
        {
            if (con.Check_MaskedText(txtDate2) == true)
            {
                Date1 = con.formatstr1(txtDate2.Text);
            }
            if (con.Check_MaskedText(txtStart) == true)
            {
                Start = con.formatstr1(txtStart.Text);
            }
            if (con.Check_MaskedText(txtEnd) == true)
            {
                End = con.formatstr1(txtEnd.Text);
            }
            result = Date1.Insert(0, "20");
            title = txtAchi2.Text + " D  " + result + " ORDER REPORT(業績表)";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchEfficiency fr = new FormSearchEfficiency();
            fr.ShowDialog();

            string DL = FormSearchEfficiency.ID.M_NAME;
            if (DL != "")
                txtAchi1.Text = DL;
            else
                txtAchi1.Text = txtAchi1.Text.Trim();
        }
        
        private void frm2HF7_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if(rdbMauChung1.Checked == true)
                { 
                    Proces1();
                }
                if(rdbNganGon1.Checked == true)
                {
                    Proces_tab1();
                }                
            }
            else if (tabControl1.SelectedIndex == 1)
                Viewtab2();
            else if (tabControl1.SelectedIndex == 2)
                Viewtab3();
        }


        private void Proces1()
        {
            check();
            SQL = "SELECT WS_DATE, C_NAME_C, OR_NO, BRAND, MODEL_E, COLOR_E, P_NAME_E, THICK, QTY, PRICE, PER_S, QTY_ORD, QTY_OUT_T, QTY_OUT, ACT_MONTH, RV_PLACE FROM ORDB WHERE 1=1";
            if (Date1 != "")
                SQL = SQL + " AND WS_DATE LIKE '%" + Date1 + "%' ";
            if (txtAchi1.Text != "")
                SQL = SQL + " AND ACHI LIKE '%" + txtAchi1.Text + "%' ";
            if (Start != "" && End != "")
                SQL = SQL + " AND WS_DATE BETWEEN '" + Start + "' AND '" + End + "' ";
            if (txtKinhDoanh1.Text != "")
                SQL = SQL + " AND PURCHASER LIKE '" + txtKinhDoanh1.Text + "' ";
            if (rdbMau1.Checked == true)
            {
                SQL = SQL + " AND K_NO IN('" + K_NO1 + "','" + K_NO2 + "')";
            }
            else if (rdbSanXuat1.Checked == true)
            {
                SQL = SQL + " AND K_NO IN('" + K_NO3 + "','" + K_NO4 +"')";
            }
            System.Data.DataTable dt = con.readdata(SQL);
            Export_Excel1(dt);
        }

        private void Proces_tab1()
        {
                check();
                SQL = "SELECT WS_DATE, BRAND, MODEL_E, COLOR_E, P_NAME_E, THICK, PRICE, PER_S, QTY_ORD, QTY_OUT, ACT_MONTH, RV_PLACE FROM ORDB WHERE 1=1";
                if (Date1 != "")
                    SQL = SQL + " AND WS_DATE LIKE '%" + Date1 + "%' ";
                if (txtAchi1.Text != "")
                    SQL = SQL + " AND ACHI LIKE '%" + txtAchi1.Text + "%' ";
                if (Start != "" && End != "")
                    SQL = SQL + " AND WS_DATE BETWEEN '" + Start + "' AND '" + End + "' ";
                if (txtKinhDoanh1.Text != "")
  
            if (rdbMau1.Checked == true)
            {
                SQL = SQL + " AND K_NO IN('" + K_NO1 + "','" + K_NO2 + "')";
            }
            else if (rdbSanXuat1.Checked == true)
            {
                SQL = SQL + " AND K_NO IN('" + K_NO3 + "','" + K_NO4 + "')";
            }

            System.Data.DataTable dt = con.readdata(SQL);
            Export_Excel2(dt);
        }

        public void Viewtab2() //TabPage 2  
        {
            string Date2 = "";
            if (con.Check_MaskedText(txtDate2) == true)
            {
                Date2 = con.formatstr1(txtDate2.Text);
            }    

            SQL = "SELECT WS_DATE, C_NAME_C, OR_NO, BRAND, P_NAME_E, COLOR_E, THICK, QTY, PRICE, QTY_ORD, TOTAL, ACT_MONTH, MODEL_E, QTY_ORD, QTY_OUT_T, QTY_OUT FROM ORDB WHERE 1=1";
            if(Date2 != "")
                    SQL = SQL + " AND ACT_MONTH LIKE '%" + Date2 + "%' ";
            if (txtAchi2.Text != "")
                SQL = SQL + " AND ACHI LIKE '%" + txtAchi2.Text + "%' ";  
            if (txtKinhDoanh2.Text != "")
                SQL = SQL + " AND PURCHASER LIKE '" + txtKinhDoanh2.Text + "' ";
            System.Data.DataTable dt = con.readdata(SQL);
            Export_Excel_Tab2(dt);
        }

        private void Viewtab3() //Tabpage 3  
        {
            string where = "";
            string Date3 = "";
            if (con.Check_MaskedText(txtDate3) == true)
            {
                Date3 = con.formatstr1(txtDate3.Text);
            }
            if (Date3 != "") { where = where + " AND B.CAL_YM = '20" + Date3 + "' "; }
            if (txtAchi3.Text != "") { where = where + " AND H.ACHI LIKE '%" + txtAchi3.Text + "%' "; }
            if (txtKinhDoanh3.Text != "") { where = where + " AND H.SALES LIKE '" + txtKinhDoanh3.Text + "' "; }
            if(rdbHangMau3.Checked == true)
            {
                where = where + " AND(H.K_NO = '1' OR H.K_NO = '2')";
            }
            else
            {
                where = where + " AND(H.K_NO = '3' OR H.K_NO = '4')";
            }

            //SQL = "SELECT WS_DATE, C_NAME_C, OR_NO, BRAND, COLOR_E, P_NAME_E, THICK, QTY, PRICE, QTY_OUT, QTY_OUT_T, ACT_MONTH, PAY_M FROM ORDB WHERE 1=1";
            SQL = "SELECT a.WS_DATE,a.C_NAME_C,a.OR_NO,a.T_NAME,a.COLOR_E,a.P_NAME_E,a.THICK,a.QTY,a.PRICE,SUM(b.BQTY) ShippedQty,a.QTY_OUT,a.ACT_MONTH,a.PAY_M"+
                " FROM("+
                " SELECT H.WS_DATE, H.C_NAME_C, H.OR_NO, H.T_NAME, H.COLOR_E, H.P_NAME_E, H.THICK, H.QTY_ORD, H.PRICE, H.QTY, H.QTY_OUT, H.ACT_MONTH, H.PAY_M, B.OR_NR, B.K_NO, H.NR" +
                " FROM CARB B, ORDB H, CARH O" +
                " WHERE B.WS_NO = O.WS_NO AND B.OR_NO = H.OR_NO AND B.K_NO = H.K_NO AND B.OR_NR = H.NR AND H.OVER0 = 'Y'" +
                " AND b.memo not like '%補%' and(O.OR_NO not like '%作廢%' and O.OR_NO not like '%改單%') "+where+"" +
                " GROUP BY H.WS_DATE, H.C_NAME_C, H.OR_NO, H.T_NAME, H.COLOR_E, H.P_NAME_E, H.THICK, H.QTY_ORD, H.PRICE, H.QTY, H.QTY_OUT, H.PAY_M, H.ACT_MONTH, H.NR, H.K_NO, B.OR_NR, B.K_NO" +
                ")a" +
                " JOIN" +
                "(" +
                " SELECT CARB.WS_NO, CARB.WS_DATE, CARB.BQTY, CARB.OR_NO, OR_NR, ORD_DATE, K_NO" +
                " FROM CARB, CARH" +
                " WHERE CARH.WS_NO = CARB.WS_NO" +
                " UNION" +
                " SELECT GIBB.WS_NO, GIBB.WS_DATE, GIBB.BQTY * (-1), GIBB.OR_NO, OR_NR, ORD_DATE, K_NO" +
                " FROM GIBB, GIBH" +
                " WHERE GIBH.WS_NO = GIBB.WS_NO" +
                ")b" +
                " ON b.OR_NO = a.OR_NO AND b.OR_NR = a.OR_NR AND b.ORD_DATE = a.WS_DATE AND b.K_NO = a.K_NO" +
                " GROUP BY a.WS_DATE,a.C_NAME_C,a.OR_NO,a.T_NAME,a.COLOR_E,a.P_NAME_E,a.THICK,a.QTY_ORD,a.PRICE,a.QTY,a.QTY_OUT,a.ACT_MONTH,a.PAY_M,a.OR_NR,a.NR" +
                " ORDER BY a.WS_DATE,a.NR";
           
            System.Data.DataTable dt = con.readdata(SQL);
            Export_Excel_Tab3(dt);

        }

        private void txtDate1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate2.Text = FromCalender.getDate.ToString("yy/MM");
        }

        private void txtStart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtStart.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtEnd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtEnd.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtDate2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate2.Text = FromCalender.getDate.ToString("yy/MM");
        }

        private void txtAchi2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchEfficiency fr = new FormSearchEfficiency();
            fr.ShowDialog();

            string DL = FormSearchEfficiency.ID.M_NAME;
            if (DL != "")
                txtAchi2.Text = DL;
            else
                txtAchi2.Text = txtAchi1.Text.Trim();
        }

        public void Export_Excel1(System.Data.DataTable da)
        {
            string txtAchi;

            if (tabControl1.SelectedIndex ==0)
            {
                txtAchi = txtAchi1.Text;
            }else if(tabControl1.SelectedIndex == 1)
            {
                txtAchi = txtAchi2.Text;
            }
            else
            {
                txtAchi = txtAchi3.Text;
            }
            string Date12 = con.formatstr1(txtDate1.Text);
           // string Start = con.formatstr1(txtStart.Text);
           // string End = con.formatstr1(txtEnd.Text);
            string result = Date12.Insert(0, "20");
            //string title = txtAchi1.Text + " D  " + result + " ORDER REPORT(業績表)";
            string title;
            if (rdbMau1.Checked == true)
            {
                title = txtAchi + " D  " + result + " ORDER REPORT(業績表)";
            }
            else
            {
                title = txtAchi + " P  " + result + " ORDER REPORT(業績表)";
            }

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
            for (int j = 0; j < RowsCount ; j++)
                for (int i = 0; i < ColumnsCount ; i++)
                    Cells[j, i] = da.Rows[j][i];
            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[6, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 5, ColumnsCount])).Value2 = Cells;


            //thoát và thu hồi bộ nhớ cho COM
            app.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);

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

        public void Export_Excel2(System.Data.DataTable da)
        {
            string Date12 = con.formatstr1(txtDate1.Text);
            // string Start = con.formatstr1(txtStart.Text);
            // string End = con.formatstr1(txtEnd.Text);
            string result = Date12.Insert(0, "20");
            string title = txtAchi2.Text + " D  " + result + " ORDER REPORT(業績表)";

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
            worksheet.Cells[4, 2] = "貿易商.品牌";
            worksheet.Cells[4, 3] = "鞋型";
            worksheet.Cells[4, 4] = "顏色";
            worksheet.Cells[4, 5] = "材料名稱";
            worksheet.Cells[4, 6] = "厚度";
            worksheet.Cells[4, 7] = "單價";
            worksheet.Cells[4, 8] = "";
            worksheet.Cells[4, 9] = "訂單數量";
            worksheet.Cells[4, 10] = "出貨數量";
            worksheet.Cells[4, 11] = "入帳月";
            worksheet.Cells[4, 12] = "協理複查";
 
           
            worksheet.Cells[5, 1] = "DATE";
            worksheet.Cells[5, 2] = "BRAND";
            worksheet.Cells[5, 3] = "MODEL#";
            worksheet.Cells[5, 4] = "COLOR";
            worksheet.Cells[5, 5] = "MATERIAL NAME";
            worksheet.Cells[5, 6] = "THICK";
            worksheet.Cells[5, 7] = "PRICE";
            worksheet.Cells[5, 8] = "%";
            worksheet.Cells[5, 9] = "ORDER QTY";
            worksheet.Cells[5, 10] = "QTY SHIPPED";
            worksheet.Cells[5, 11] = "MONTH OF ACCOUNT";
            worksheet.Cells[5, 12] = "REVIEWED";

            //Auto Size
            worksheet.Columns.AutoFit();
            // Show DataTable 
            int RowsCount = da.Rows.Count;
            object[,] Cells = new object[RowsCount, ColumnsCount];
            for (int j = 0; j <= RowsCount -1; j++)
                for (int i = 0; i <= ColumnsCount -1; i++)
                    Cells[j, i] = da.Rows[j][i];
            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[6, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 5, ColumnsCount])).Value2 = Cells;


            //thoát và thu hồi bộ nhớ cho COM
            app.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);
        }

        public void Export_Excel_Tab2(System.Data.DataTable da)
        {
            string Date12 = con.formatstr1(txtDate2.Text);
       
            string result = Date12.Insert(0, "20");
            string title = txtAchi2.Text + " " + result + " ORDER REPORT(COMMISSION)";

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
            Range row_header = worksheet.get_Range("A4", "P4");
            row_header.Font.Size = 12;
            row_header.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            row_header.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightYellow);


            Range item1 = worksheet.get_Range("A4", "A4");
            item1.Merge();
            item1.Font.Name = "Times New Roman";
            item1.Font.Size = 12;
            item1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            item1.VerticalAlignment = XlVAlign.xlVAlignCenter;
            item1.ColumnWidth = 3;


            worksheet.Cells[4, 1] = "DATE";
            worksheet.Cells[4, 2] = "CUST.";
            worksheet.Cells[4, 3] = "PO#";
            worksheet.Cells[4, 4] = "BRAND";
            worksheet.Cells[4, 5] = "MATERIAL NAME";
            worksheet.Cells[4, 6] = "COLOR";
            worksheet.Cells[4, 7] = "THICK";
            worksheet.Cells[4, 8] = "QTY";
            worksheet.Cells[4, 9] = "PRICE";
            worksheet.Cells[4, 10] = "SHIPPED QTY";
            worksheet.Cells[4, 11] = "REVIEWED";
            worksheet.Cells[4, 12] = "MONTH OF ACCOUNT";
            worksheet.Cells[4, 13] = "MODEL#";
            worksheet.Cells[4, 14] = "ORDER QTY";
            worksheet.Cells[4, 15] = "SHIPPED QTY";
            worksheet.Cells[4, 16] = "QTY SHIPPED";


            //Auto Size
            worksheet.Columns.AutoFit();
            // Show DataTable 
            int RowsCount = da.Rows.Count;
            object[,] Cells = new object[RowsCount, ColumnsCount];
            for (int j = 0; j < RowsCount; j++)
                for (int i = 0; i < ColumnsCount ; i++)
                    Cells[j, i] = da.Rows[j][i];
            worksheet.get_Range((Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[5, 1]), (Microsoft.Office.Interop.Excel.Range)(worksheet.Cells[RowsCount + 4, ColumnsCount])).Value2 = Cells;


            //thoát và thu hồi bộ nhớ cho COM
            app.Quit();
            releaseObject(worksheet);
            releaseObject(workbook);
            releaseObject(app);
        }

        public void Export_Excel_Tab3(System.Data.DataTable da)
        {
            string Date1 = con.formatstr1(txtDate3.Text);
    
            string result = Date1.Insert(0, "20");
            string title = txtAchi3.Text + result + " 帳款月份表";

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

            Range Row_TieuDe = worksheet.get_Range("A2", "M2");
            Row_TieuDe.Merge();
            Row_TieuDe.Font.Name = "Times New Roman";
            Row_TieuDe.Font.Size = 18;
            Row_TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Row_TieuDe.Value2 = title;

            //Header
            Range row_header = worksheet.get_Range("A4", "M5");
            row_header.Font.Size = 12;
            row_header.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            row_header.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightYellow);


            Range item1 = worksheet.get_Range("A4", "A5");
            //item1.Merge();
            item1.Font.Name = "Times New Roman";
            item1.Font.Size = 12;
            item1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            item1.VerticalAlignment = XlVAlign.xlVAlignCenter;
           // item1.ColumnWidth = 3;


            worksheet.Cells[4, 1] = "下單日期";
            worksheet.Cells[4, 2] = "客戶名稱";
            worksheet.Cells[4, 3] = "訂單號碼";
            worksheet.Cells[4, 4] = "貿易商.品牌";
            worksheet.Cells[4, 5] = "顏色";
            worksheet.Cells[4, 6] = "材料名稱";
            worksheet.Cells[4, 7] = "厚度";
            worksheet.Cells[4, 8] = "訂單數量";
            worksheet.Cells[4, 9] = "單價";
            worksheet.Cells[4, 10] = "出貨數量";
            worksheet.Cells[4, 11] = "付款數量";
            worksheet.Cells[4, 12] = "付款月份";
            worksheet.Cells[4, 13] = "請款月份";

            worksheet.Cells[5, 1] = "DATE";
            worksheet.Cells[5, 2] = "CUST.";
            worksheet.Cells[5, 3] = "PO#";
            worksheet.Cells[5, 4] = "BRAND";
            worksheet.Cells[5, 5] = "COLOR";
            worksheet.Cells[5, 6] = "MATERIAL NAME";
            worksheet.Cells[5, 7] = "THICK";
            worksheet.Cells[5, 8] = "ORDER QTY";
            worksheet.Cells[5, 9] = "PRICE";
            worksheet.Cells[5, 10] = "SHIPPED QTY";
            worksheet.Cells[5, 11] = "PAYMENT QTY";
            worksheet.Cells[5, 12] = "MONTH OF PAYMENT";
            worksheet.Cells[5, 13] = "MONTH OF ACCOUNT";

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

        private void txtDate3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate3.Text = FromCalender.getDate.ToString("yy/MM");
        }

        private void txtDate1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate2, txtAchi1,sender,e);
        }

        private void txtAchi1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtDate2, txtStart, sender, e);
        }

        private void txtStart_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtAchi1, txtEnd, sender, e);
        }

        private void txtEnd_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate2, txtKinhDoanh1, sender, e);
        }

        private void txtKinhDoanh1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtKinhDoanh1, txtDate2, sender, e);
        }

        private void txtAchi3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchEfficiency fr = new FormSearchEfficiency();
            fr.ShowDialog();

            string DL = FormSearchEfficiency.ID.M_NAME;
            if (DL != "")
                txtAchi3.Text = DL;
            else
                txtAchi3.Text = "";
        }

        private void txtAchi2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate2, txtAchi2, sender, e);
        }

        private void txtDate2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtKinhDoanh2, txtAchi2, sender, e);
        }

        private void txtKinhDoanh2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtKinhDoanh2, txtDate2, sender, e);
        }

        private void txtDate3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtKinhDoanh3, txtAchi3, sender, e);
        }
        

        private void txtAchi3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate3, txtKinhDoanh3, sender, e);
        }

        private void txtKinhDoanh3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtAchi3, txtDate3, sender, e);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
