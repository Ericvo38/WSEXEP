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
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace WTERP.WSEXE
{
    public partial class Frm2ABF7_Tab3 : Form
    {
        DataProvider conn = new DataProvider();
        System.Data.DataTable dt = new System.Data.DataTable();
        
        public Frm2ABF7_Tab3()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            conn.CreateButtonToolTipReport(crystalReportViewer2, ExportExcel_Click);
        }
        private void ExportExcel_Click(object sender, EventArgs e)
        {
            string sql1 = Form2ABF7.SQL3;
            dt = conn.readdata(sql1);

            string workbookPath = conn.LinkTemplate + "2AB_F7_Tab3.xls";
            string filePath = conn.LinkTemplate_SAVE + "2AB_F7_Tab3.xls";
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
            }
            COMExcel.Application app = new COMExcel.Application();
            object valueMissing = System.Reflection.Missing.Value;
            COMExcel.Workbook book = app.Workbooks.Open(filePath, valueMissing,
            false, valueMissing, valueMissing, valueMissing, valueMissing,
            COMExcel.XlPlatform.xlWindows, valueMissing, valueMissing,
            valueMissing, valueMissing, valueMissing, valueMissing, valueMissing);

            COMExcel.Worksheet TAB6 = (COMExcel.Worksheet)book.Worksheets[1];
            app.Visible = true;

            COMExcel.Range TieuDe = TAB6.get_Range("A1", "A1");
            TieuDe.Merge();
            TieuDe.Value2 = "訂單未結案統計表(20"+dt.Rows[0]["DATE1"].ToString()+"-20"+dt.Rows[0]["DATE2"].ToString()+")";
            int a = 3;
            foreach (DataRow item in dt.Rows)
            {
                COMExcel.Range Column1 = TAB6.get_Range("A" + a, "A" + a);
                Column1.Merge();
                Column1.Value2 = item["WS_DATE"].ToString();

                COMExcel.Range Column2 = TAB6.get_Range("B" + a, "B" + a);
                Column2.Merge();
                Column2.WrapText = true;
                Column2.Value2 = item["C_NAME_E"].ToString();

                COMExcel.Range Column3 = TAB6.get_Range("C" + a, "C" + a);
                Column3.Merge();
                Column3.WrapText = true;
                Column3.Value2 = item["OR_NO"].ToString();

                COMExcel.Range Column4 = TAB6.get_Range("D" + a, "D" + a);
                Column4.Merge();
                Column4.Value2 = item["BRAND"].ToString();

                COMExcel.Range Column5 = TAB6.get_Range("E" + a, "E" + a);
                Column5.Merge();
                Column5.WrapText = true;
                Column5.Value2 = item["P_NAME_E"].ToString();

                COMExcel.Range Column6 = TAB6.get_Range("F" + a, "F" + a);
                Column6.Merge();
                Column6.Value2 = item["THICK"].ToString();

                COMExcel.Range Column7 = TAB6.get_Range("G" + a, "G" + a);
                Column7.Merge();
                Column7.Value2 = item["QTY"].ToString();

                COMExcel.Range Column8 = TAB6.get_Range("H" + a, "H" + a);
                Column8.Merge();
                Column8.Value2 = item["WS_DATE1"].ToString();

                COMExcel.Range Column9 = TAB6.get_Range("I" + a, "I" + a);
                Column9.Merge();
                Column9.Value2 = item["QTY_OUT"].ToString();

                COMExcel.Range Column10 = TAB6.get_Range("J" + a, "J" + a);
                Column10.Merge();
                Column10.Value2 = item["QTY_OUT_T"].ToString();

                COMExcel.Range Column11 = TAB6.get_Range("K" + a, "K" + a);
                Column11.Merge();
                Column11.Value2 = item["Accept"].ToString();

                a++;
            }
            COMExcel.Range border = TAB6.get_Range("A3", "K" + (a-1));
            conn.BorderAround(border);
        }
        private void Frm2ABF7_Tab3_Load(object sender, EventArgs e)
        {
            string SQL = Form2ABF7.SQL3;
            //MessageBox.Show(SQL);
            cr_Form2ABF7_Tab3 crv = new cr_Form2ABF7_Tab3();
            System.Data.DataTable dt1 = conn.readdata(SQL);
            crv.SetDataSource(dt1);
            crystalReportViewer2.ReportSource = crv;
        }
    }
}
