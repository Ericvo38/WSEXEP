using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.IO;
using System.Drawing.Imaging;

namespace WTERP
{
    public static class MyExtension
    {
        public static void MyDGV(this DataGridView DGV)
        {
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.RowHeadersWidth = 20;
            DGV.EnableHeadersVisualStyles = false;
            DGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkKhaki;
            DGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            DGV.DefaultCellStyle.Font = new Font("Tahoma", 12F);
            DGV.BackgroundColor = Color.White;
            DGV.DefaultCellStyle.Format = "#,##0.00";
        }
        public static bool isNumber(this TextBox txt)
        {
            string s1 = txt.Text;
            s1 = s1.Replace(",", "");
            //s1 = s1.Replace(".", "");
            bool Result = false;
            foreach (Char c in s1)
            {
                if (!Char.IsDigit(c))
                {
                    MessageBox.Show("Dữ liệu nhập phải là số !");
                    txt.Text = "";
                    txt.Focus();
                    Result = false;
                    break;
                }
                else
                    Result = true;
            }
            return Result;
        }
        public static bool CheckText(this TextBox txt, DataTable dt, string Col)
        {
            bool Results = dt.AsEnumerable().Any(row => txt.Text == row.Field<String>(Col));
            return Results;
        }
       
        #region Extension Report Viewer 
        public static void View(this ReportViewer ReportViewer, DataTable TableName, string DatasetName, string pathReport, params ReportParameter[] reportParameters)
        {
            ReportDataSource SourceReport = new ReportDataSource(DatasetName, TableName);
            ReportViewer.LocalReport.ReportEmbeddedResource = pathReport;
            ReportViewer.LocalReport.DataSources.Add(SourceReport);
            if (reportParameters != null)
            {
                ReportViewer.LocalReport.SetParameters(reportParameters.ToArray());
            }
            ReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            ReportViewer.ZoomMode = ZoomMode.Percent;
            ReportViewer.ZoomPercent = 100;
            ReportViewer.RefreshReport();
        }
        #endregion

        public static void DataGridViewFormat(this DataGridView DGV)
        {
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            DGV.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
            DGV.RowHeadersWidth = 15;
            DGV.EnableHeadersVisualStyles = false;
            DGV.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            DGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            DGV.DefaultCellStyle.Font = new Font("Tahoma", 17F);
            DGV.BackgroundColor = Color.White;
            DGV.ForeColor = Color.MidnightBlue;
            DGV.BorderStyle = BorderStyle.FixedSingle;
            DGV.ColumnHeadersHeight = 52;
            DGV.DefaultCellStyle.Format = "#,##0.0";
            DGV.RowTemplate.Height = 30;
        }
        public static void PrintToPrinter(this LocalReport report, PrintDialog prdl)
        {
            PageSettings pageSettings = new PageSettings();
            pageSettings.PaperSize = report.GetDefaultPageSettings().PaperSize;
            pageSettings.Landscape = report.GetDefaultPageSettings().IsLandscape;
            pageSettings.Margins = report.GetDefaultPageSettings().Margins;
            Print(report, pageSettings, prdl);
        }
        public static void Print(this LocalReport report, PageSettings pageSettings, PrintDialog prdl)
        {
            string deviceInfo =
                $@"<DeviceInfo>
                    <OutputFormat>EMF</OutputFormat>
                    <PageWidth>{pageSettings.PaperSize.Width * 100}in</PageWidth>
                    <PageHeight>{pageSettings.PaperSize.Height * 100}in</PageHeight>
                    <MarginTop>{pageSettings.Margins.Top * 100}in</MarginTop>
                    <MarginLeft>{pageSettings.Margins.Left * 100}in</MarginLeft>
                    <MarginRight>{pageSettings.Margins.Right * 100}in</MarginRight>
                    <MarginBottom>{pageSettings.Margins.Bottom * 100}in</MarginBottom>
                </DeviceInfo>";
            Warning[] warnings;
            var streams = new List<Stream>();
            var pageIndex = 0;
            report.Render("Image", deviceInfo,
                (name, fileNameExtension, encoding, mimeType, willSeek) =>
                {
                    MemoryStream stream = new MemoryStream();
                    streams.Add(stream);
                    return stream;
                }, out warnings);
            foreach (Stream stream in streams)
                stream.Position = 0;
            if (streams == null || streams.Count == 0)
                throw new Exception("No stream to print.");
            using (PrintDocument printDocument = new PrintDocument())
            {
                printDocument.DefaultPageSettings = pageSettings;
                printDocument.PrinterSettings.PrinterName = prdl.PrinterSettings.PrinterName;


                if (!printDocument.PrinterSettings.IsValid)
                    throw new Exception("Can't find the default printer.");
                else
                {
                    printDocument.PrintPage += (sender, e) =>
                    {
                        Metafile pageImage = new Metafile(streams[pageIndex]);
                        Rectangle adjustedRect = new Rectangle(e.PageBounds.Left - (int)e.PageSettings.HardMarginX, e.PageBounds.Top - (int)e.PageSettings.HardMarginY, e.PageBounds.Width, e.PageBounds.Height);
                        e.Graphics.FillRectangle(Brushes.White, adjustedRect);
                        e.Graphics.DrawImage(pageImage, adjustedRect);
                        pageIndex++;
                        e.HasMorePages = (pageIndex < streams.Count);
                        e.Graphics.DrawRectangle(Pens.Red, adjustedRect);
                    };
                    printDocument.EndPrint += (Sender, e) =>
                    {
                        if (streams != null)
                        {
                            foreach (Stream stream in streams)
                                stream.Close();
                            streams = null;
                        }
                    };
                    printDocument.Print();
                }
            }
        }      
        public static void ButtonViews(this Button btn, int ID_View)
        {
            if (ID_View == 0) // First
            {
                if (frmLogin.Lang_ID == 1) btn.Text = "DUYỆT";
                if (frmLogin.Lang_ID == 2) btn.Text = "VIEW";
                if (frmLogin.Lang_ID == 3) btn.Text = "瀏覽";
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.Brown;
                btn.Font = new System.Drawing.Font("Times New Roman", 10F, FontStyle.Bold);
            }
            else if (ID_View == 1) //Action Adding
            {
                if (frmLogin.Lang_ID == 1) btn.Text = "THÊM";
                if (frmLogin.Lang_ID == 2) btn.Text = "ADD";
                if (frmLogin.Lang_ID == 3) btn.Text = "新增";
                btn.BackColor = Color.Blue;
                btn.ForeColor = Color.White;
                btn.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            }
            else if(ID_View == 2) // Deleting
            {
                if (frmLogin.Lang_ID == 1) btn.Text = "XÓA";
                if (frmLogin.Lang_ID == 2) btn.Text = "DELETE";
                if (frmLogin.Lang_ID == 3) btn.Text = "刪除";
                btn.BackColor = Color.Red;
                btn.ForeColor = Color.White;
                btn.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            }
            else if(ID_View == 3) // Modify
            {
                if (frmLogin.Lang_ID == 1) btn.Text = "SỮA";
                if (frmLogin.Lang_ID == 2) btn.Text = "MODIFY";
                if (frmLogin.Lang_ID == 3) btn.Text = "修改";
                btn.BackColor = Color.Yellow;
                btn.ForeColor = Color.Red;
                btn.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            }
            else if(ID_View == 6) //coppy
            {
                if (frmLogin.Lang_ID == 1) btn.Text = "COPY";
                if (frmLogin.Lang_ID == 2) btn.Text = "COPY";
                if (frmLogin.Lang_ID == 3) btn.Text = "複製";
                btn.BackColor = Color.Blue;
                btn.ForeColor = Color.White;
                btn.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            }
            else if(ID_View == 9) //coppy
            {
                if (frmLogin.Lang_ID == 1) btn.Text = "CHECK";
                if (frmLogin.Lang_ID == 2) btn.Text = "CHECK";
                if (frmLogin.Lang_ID == 3) btn.Text = "查看";
                btn.BackColor = Color.Blue;
                btn.ForeColor = Color.White;
                btn.Font = new System.Drawing.Font("Segoe UI", 10F, FontStyle.Bold);
            }
        }
    }
}
