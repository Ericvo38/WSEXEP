using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTERP.Properties;

namespace WTERP.WSEXE.Module3._3E
{
    public partial class FrmViewProduct3E : Form
    {
        DataProvider connect = new DataProvider();
        DataTable dt;
        public FrmViewProduct3E()
        {
            InitializeComponent();
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
        private void FrmViewProduct3E_Load(object sender, EventArgs e)
        {
            dt = connect.readdata(Form3EF7.SQL_Share);

            foreach(DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = DateCover(dr["WS_DATE"].ToString());
                dr["MEMO08"] = connect.getUser(frmLogin.ID_USER);
            }
            reportViewer1.View(dt, "PRDMK2", "WTERP.WSEXE.Module3._3E.ReportProduct.rdlc");
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
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    ReportViewer SampleReport = new ReportViewer();
                    SampleReport.LocalReport.ReportEmbeddedResource = "WTERP.WSEXE.Module3._3E.ReportProduct.rdlc";
                    ReportDataSource SourceReport = new ReportDataSource("PRDMK2", dt);
                    SampleReport.LocalReport.DataSources.Add(SourceReport);
                    LocalReport lr = SampleReport.LocalReport;
                    lr.PrintToPrinter(printDialog);
                    SampleReport.Clear();

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
