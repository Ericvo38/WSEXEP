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
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WTERP
{
    public partial class Form3EF7Report : Form
    {
        DataProvider con = new DataProvider();
        WSEXE.ReportView.cr_Form3EF7_report1 rpt = new WSEXE.ReportView.cr_Form3EF7_report1();
        DataTable dt;
        public Form3EF7Report()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
            con.CreateButtonToolTipReport2(crystalReportViewer1, printButton_Click);
        }
        private void printButton_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument pd = new PrintDocument();
            //pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom mm", 219, 140);
            //pd.DefaultPageSettings.PaperSize.RawKind = 119;
            //pd.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = 119;
            //pd.DefaultPageSettings.Landscape = false;
            pd.DocumentName = "Print Document";
            printDialog.Document = pd;
            printDialog.AllowSelection = true;
            printDialog.AllowSomePages = true;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
                //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperTabloid;
                rpt.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Tractor;
                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                UpdatePrint();
            }
        }
        private void printButtonOR_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument pDoc = new PrintDocument();
            pDoc.DocumentName = "Print Document";
            printDialog.Document = pDoc;
            printDialog.AllowSelection = true;
            printDialog.AllowSomePages = true;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
                rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
                //rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperTabloid;
                rpt.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Tractor;
                rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
                UpdatePrint();
            }
        }
        public void Printing()
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 315, 300);
            pd.DefaultPageSettings.PaperSize.RawKind = 119;
            pd.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = 119;
            pd.DefaultPageSettings.Landscape = false;
        }
        private void printButton1_Click(object sender, EventArgs e)
        {
            //PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == DialogResult.OK)
            //{
            //    rpt.PrintOptions.PrinterName = printDialog.PrinterSettings.PrinterName;
            //    rpt.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Tractor;
            //    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            //    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            //    PageMargins margins;

            //    margins = rpt.PrintOptions.PageMargins;
            //    margins.bottomMargin = 350;
            //    margins.leftMargin = 350;
            //    margins.rightMargin = 350;
            //    margins.topMargin = 350;
            //    rpt.PrintOptions.ApplyPageMargins(margins);
            //    rpt.PrintToPrinter(printDialog.PrinterSettings.Copies, printDialog.PrinterSettings.Collate, printDialog.PrinterSettings.FromPage, printDialog.PrinterSettings.ToPage);
            //    //rpt.PrintToPrinter(1, false, 0, 0);
            //    MessageBox.Show("Printed");
            //}
            //else
            //    MessageBox.Show("Cancel");
        }
        
        private void Form3EF7Report_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
        private void UpdatePrint()
        {
            try
            {
                foreach(DataRow dr in dt.Rows)
                {
                    string SQL = "UPDATE PRDMK2 SET OVER0 = N'Y' WHERE  WS_NO = '" + dr["WS_NO"].ToString()+ "' ";
                    con.exedata(SQL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string DateCover(string str1)
        {
            string Result = str1;

            if (Result.Length == 8)
            {
                string s1 = Result.Substring(0, 4);//yyyy
                string s2 = Result.Substring(Result.Length - 2, 2);//dd
                string s3 = Result.Substring(Result.Length - 4, 2);//MM
                str1 = "  " + s2 + "         " + s3 + "          " + s1;
                return str1;
            }

            else
            {
                return str1;
            }

        }
        public string SHOW_STRING(string str1)
        {
            string Result = str1;

            int i = str1.Length;
            int a = i - 51;

            if (Result.Length > 50)
            {
                string str2 = str1.Substring(0, 50);
                string str3 = str1.Substring(50, a);
                str1 = str2 + Environment.NewLine + str3;
            }
            else
            {
                return str1;
            }
            return str1;
        }
        private string Newline(string stringin, int Length)
        {
            string Result = "";
            int l = 1;
            foreach (var item in stringin)
            {
                if (l == Length)
                {
                    Result = Result + Environment.NewLine;
                }
                else if (l == Length * 2)
                {
                    Result = Result + Environment.NewLine;
                }
                Result = Result + item;
                l++;
            }
            return Result;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void LoadReport()
        {
            try
            {
                dt = con.readdata(Form3EF7.SQL_Share);
                foreach (DataRow dr in dt.Rows)
                {
                    dr["WS_DATE"] = DateCover(dr["WS_DATE"].ToString());
                    dr["P_NAME"] = Newline(dr["P_NAME"].ToString(), 50);
                    dr["C_NAME"] = Newline(dr["C_NAME"].ToString(), 23);
                    dr["MEMO03"] = Newline(dr["MEMO03"].ToString(), 23);
                    dr["MEMO04"] = Newline(dr["MEMO04"].ToString(), 23);
                    dr["MEMO06"] = Newline(dr["MEMO06"].ToString(), 20);
                    dr["MEMO08"] = con.getUser(frmLogin.ID_USER);

                }
                rpt.SetDataSource(dt);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
