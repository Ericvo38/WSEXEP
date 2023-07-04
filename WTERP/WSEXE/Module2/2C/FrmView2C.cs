using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP.WSEXE.Module2._2C
{
    public partial class FrmView2C : Form
    {
        DataProvider connect = new DataProvider();
        public FrmView2C()
        {
            InitializeComponent();
        }

        private void FrmView2C_Load(object sender, EventArgs e)
        {

            DataTable dt = connect.readdata(Frm2CF7_Print.Share_SQL);
            string NR = dt.Rows.Count.ToString();
            if (Frm2CF7_Print.TypeReport.Equals("BB"))
            {
                reportViewer1.View(dt, "Frm2CF7_Tab1", "WTERP.WSEXE.Module2._2C.Report1.rdlc", new Microsoft.Reporting.WinForms.ReportParameter("Count1", NR));
            }
            else if (Frm2CF7_Print.TypeReport.Equals("AA"))
            {
                reportViewer1.View(dt, "Frm2CF7_Tab1", "WTERP.WSEXE.Module2._2C.Report2.rdlc", new Microsoft.Reporting.WinForms.ReportParameter("Count1", NR));
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
