using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using WTERP.Properties;

namespace WTERP.WSEXE.Module3._3D
{
    public partial class FrmViewReport3D : Form
    {
        DataProvider connect = new DataProvider();
        DataTable dt;
        public FrmViewReport3D()
        {
            InitializeComponent();

        }

        private void FrmViewReport3D_Load(object sender, EventArgs e)
        {
            dt = connect.readdata(frm3DF7.Share_SQL);
            reportViewer1.View(dt, "PRDMK1", "WTERP.WSEXE.Module3._3D.Report1.rdlc");
            //reportViewer1.View(dt, "PRDMK1", "WTERP.WSEXE.Module3._3D.ReportSample.rdlc");
            this.reportViewer1.RefreshReport();
            connect.CreateStripButton(reportViewer1, Printer_Click, "Printer", 12, Resources.printing);
        }

        private void Printer_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.AllowSelection = true;
                printDialog.AllowSomePages = false;
                if (printDialog.ShowDialog()== DialogResult.OK)
                {
                    ReportViewer SampleReport = new ReportViewer();
                    SampleReport.LocalReport.ReportEmbeddedResource = "WTERP.WSEXE.Module3._3D.ReportSample.rdlc";
                    ReportDataSource SourceReport = new ReportDataSource("PRDMK1", dt);
                    SampleReport.LocalReport.DataSources.Add(SourceReport);
                    LocalReport lr = SampleReport.LocalReport;
                    lr.PrintToPrinter(printDialog);
                    SampleReport.Clear();
                    UpdatePrint();
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void UpdatePrint()
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string SQL = "UPDATE PRDMK1 SET OVER0 = N'Y' WHERE  WS_NO = '" + dr["WS_NO"].ToString() + "' ";
                    connect.exedata(SQL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
