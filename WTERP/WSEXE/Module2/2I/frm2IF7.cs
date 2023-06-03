using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibraryCalender;
using Microsoft.Office.Interop.Excel;

namespace WTERP
{
    public partial class frm2IF7 : Form
    {
        DataProvider con = new DataProvider();
        public frm2IF7()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void frm2IF7_Load(object sender, EventArgs e)
        { 
            txtWS_DATE1.Text = frm2I.G_WS_DATE;
            txtWS_DATE2.Text = frm2I.G_WS_DATE;
        }
        public void Export_Excel1(System.Data.DataTable da)
        {
           
            string title = " 變 更 合 約 登 記 表 ";

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

            Range Row_TieuDe = worksheet.get_Range("A2", "R2");
            Row_TieuDe.Merge();
            Row_TieuDe.Font.Name = "Times New Roman";
            Row_TieuDe.Font.Size = 18;
            Row_TieuDe.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            Row_TieuDe.Value2 = title;

            Range Row_3 = worksheet.get_Range("A3", "A3");
            Row_3.Font.Name = "Times New Roman";
            Row_3.Font.Size = 18;
            Row_3.Value2 = "原訂單 ";

            Range Row_4 = worksheet.get_Range("L3", "L3");
            Row_4.Font.Name = "Times New Roman";
            Row_4.Font.Size = 18;
            Row_4.Value2 = "變更訂單 ";

            //Header
            Range row_header = worksheet.get_Range("A4", "R5");
            row_header.Font.Size = 12;
            row_header.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            row_header.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.LightYellow);


            Range item1 = worksheet.get_Range("A4", "A5");
            //item1.Merge();
            item1.Font.Name = "Times New Roman";
            item1.Font.Size = 12;
            item1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            item1.VerticalAlignment = XlVAlign.xlVAlignCenter;
   
            worksheet.Cells[4, 1] = "下單日期";
            worksheet.Cells[4, 2] = "客戶名稱";
            worksheet.Cells[4, 3] = "訂單號碼";
            worksheet.Cells[4, 4] = "貿易商.品牌";
            worksheet.Cells[4, 5] = "材料名稱";
            worksheet.Cells[4, 6] = "紋路";
            worksheet.Cells[4, 7] = "顏色";
            worksheet.Cells[4, 8] = "厚度";
            worksheet.Cells[4, 9] = "數量";
            worksheet.Cells[4, 10] = "單價";
            worksheet.Cells[4, 11] = "鞋型";
            worksheet.Cells[4, 12] = "變更日期";
            worksheet.Cells[4, 13] = "材料名稱";
            worksheet.Cells[4, 14] = "厚度";
            worksheet.Cells[4, 15] = "數量";
            worksheet.Cells[4, 16] = "單價";
            worksheet.Cells[4, 17] = "開發/量產";
            worksheet.Cells[4, 18] = "改變事項";

            worksheet.Cells[5, 1] = "DATE";
            worksheet.Cells[5, 2] = "CUST.";
            worksheet.Cells[5, 3] = "PO#";
            worksheet.Cells[5, 4] = "BRAND";
            worksheet.Cells[5, 5] = "MATERIAL NAME";
            worksheet.Cells[5, 6] = "PATT#";
            worksheet.Cells[5, 7] = "COLOR";
            worksheet.Cells[5, 8] = "THICK";
            worksheet.Cells[5, 9] = "QTY";
            worksheet.Cells[5, 10] = "PRICE";
            worksheet.Cells[5, 11] = "MODEL#";
            worksheet.Cells[5, 12] = "DATE";
            worksheet.Cells[5, 13] = "MATERIAL NAME";
            worksheet.Cells[5, 14] = "THICK";
            worksheet.Cells[5, 15] = "QTY";
            worksheet.Cells[5, 16] = "PRICE";
            worksheet.Cells[5, 17] = "DEV/PROD";
            worksheet.Cells[5, 18] = "INFO OF REVISED";

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

        private void txtWS_DATE1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtWS_DATE1.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtWS_DATE2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtWS_DATE1.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtDate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate.Text = FromCalender.getDate.ToString("MM/dd");
        }

        private void txtDate2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate2.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtDate3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate3.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txt3_Date1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt3_Date1.Text = FromCalender.getDate.ToString("MM/dd");
        }

        private void txt3_Date2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt3_Date2.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txt3_Date3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt3_Date3.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txt4_Date1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt4_Date1.Text = FromCalender.getDate.ToString("MM/dd");
        }

        private void txt4_Date2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt4_Date2.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txt4_Date3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txt4_Date3.Text = FromCalender.getDate.ToString("yy/MM/dd");
        }

        private void txtC_NO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr1 = new frm2CustSearch();
            fr1.ShowDialog();

            string DL = frm2CustSearch.ID.ID_CUST;
            if (DL != string.Empty)
                txtC_NO1.Text = DL;
            else
                txtC_NO1.Text = "";
        }

        private void txtC_NO2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch fr1 = new frm2CustSearch();
            fr1.ShowDialog();

            string DL = frm2CustSearch.ID.ID_CUST;
            if (DL != string.Empty)
                txtC_NO2.Text = DL;
            else
                txtC_NO2.Text = "";
        }

        private void txtP_NO1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchMaterial2 fr2 = new FormSearchMaterial2();
            fr2.ShowDialog();

            string DL = FormSearchMaterial2.ID.ID_P_NO;
            if (DL != string.Empty)
                txtP_NO1.Text = DL;
            else
                txtP_NO1.Text = "";
        }

        private void txtP_NO2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchMaterial2 fr2 = new FormSearchMaterial2();
            fr2.ShowDialog();

            string DL = FormSearchMaterial2.ID.ID_P_NO;
            if (DL != string.Empty)
                txtP_NO2.Text = DL;
            else
                txtP_NO2.Text = "";
        }

        private void txtBRAND1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fr3 = new FormSearchBrand();
            fr3.ShowDialog();

            string DL = FormSearchBrand.ID.B_NO;
            if (DL != string.Empty)
                txtBRAND1.Text = DL;
            else
                txtBRAND1.Text = "";

        }

        private void txtBRAND2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSearchBrand fr3 = new FormSearchBrand();
            fr3.ShowDialog();

            string DL = FormSearchBrand.ID.B_NO;
            if (DL != string.Empty)
                txtBRAND2.Text = DL;
            else
                txtBRAND2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                View1();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                View2();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                View3();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                View4();
            }
        }

        public void View1()
        {
            string ST1 = "";
            string ST2 = "";
            if (con.Check_MaskedText(txtWS_DATE1) == true)
            {
                ST1 = con.formatstr1(txtWS_DATE1.Text);  
            }
            if (con.Check_MaskedText(txtWS_DATE2) == true)
            {
                ST2 = con.formatstr1(txtWS_DATE2.Text);
            }
            string SQL1 = "select ORDBC.WS_DATE, CUST.C_ANAME2, ORDBC.OR_NO, ORDBC.BRAND, ORDBC.P_NAME_C, ORDBC.PATT_C, ORDBC.COLOR_E, ORDBC.THICK, ORDBC.QTY, ORDBC.PRICE, ORDBC.MODEL_E, ORDBC.WS_DATE_C, ORDBC.P_NAME_C_C, ORDBC.THICK_C, ORDBC.QTY_C, ORDBC.PRICE_C, ORDBC.DEV_PROD, ORDBC.CHANG_INFO from ORDBC Left join CUST on ORDBC.C_NO = CUST.C_NO where 1=1 "; // ORDBC.WS_DATE = '210517'";
            if ((ST1 != "") || (ST2 != ""))
            {
                if ((ST1 != "") && (ST2 != ""))
                    SQL1 = SQL1 + " AND ORDBC.WS_DATE BETWEEN '" + ST1 + "' AND '" + ST2 + "'";
                else if ((ST1 != "") && (ST2 == ""))
                    SQL1 = SQL1 + " AND ORDBC.WS_DATE BETWEEN '" + ST1 + "' AND (SELECT TOP 1 WS_DATE FROM ORDBC ORDER BY WS_DATE DESC)";
                else if ((ST1 == "") && (ST2 != ""))
                    SQL1 = SQL1 + " AND ORDBC.WS_DATE BETWEEN (SELECT TOP 1 WS_DATE FROM ORDBC ORDER BY WS_DATE ASC) AND '" + ST2 + "'";
            }
            SQL1 = SQL1 + " ORDER BY ORDBC.WS_DATE ASC";
            System.Data.DataTable dt = con.readdata(SQL1);
            Export_Excel1(dt);
        }

        public void View2()
        {
             MessageBox.Show("Chức Năng Này Đang Được Phát Triển! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void View3()
        {
             MessageBox.Show("Chức Năng Này Đang Được Phát Triển! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void View4()
        {
            MessageBox.Show("Chức Năng Này Đang Được Phát Triển! ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtWS_DATE1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtWS_DATE2, txtWS_DATE2, sender, e);
        }

        private void txtWS_DATE2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP_DOWN(txtWS_DATE1, txtWS_DATE1, sender, e);
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate3, txtC_NO1, sender, e);
        }

        private void txtC_NO1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtDate, txtC_NO2, sender, e);
        }

        private void txtC_NO2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtC_NO1, txtPURCHAR, sender, e);
        }

        private void txtPURCHAR_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtC_NO2, txtDate2, sender, e);
        }

        private void txtDate2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtPURCHAR, txtDate3, sender, e);
        }

        private void txtDate3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txtDate2, txtDate, sender, e);
        }

        private void txt3_Date1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt3_Date3, txtP_NO1, sender, e);
        }

        private void txtP_NO1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt3_Date1, txtP_NO2, sender, e);
        }

        private void txtP_NO2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtP_NO1, txt3_Date2, sender, e);
        }

        private void txt3_Date2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtP_NO2, txt3_Date3, sender, e);
        }

        private void txt3_Date3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txtP_NO2, txt3_Date1, sender, e);
        }

        private void txt4_Date1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt4_Date3, txt4_PURCAHR, sender, e);
        }

        private void txt4_PURCAHR_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt4_Date1, txtBRAND1, sender, e);
        }

        private void txtBRAND1_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab(txt4_PURCAHR, txtBRAND2, sender, e);
        }

        private void txtBRAND2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtBRAND1, txt4_Date2, sender, e);
        }

        private void txt4_Date2_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_DOWN(txtBRAND2, txt4_Date3, sender, e);
        }

        private void txt4_Date3_KeyDown(object sender, KeyEventArgs e)
        {
            con.tab_UP(txt4_Date2, txt4_Date1, sender, e);
        }
    }
}
