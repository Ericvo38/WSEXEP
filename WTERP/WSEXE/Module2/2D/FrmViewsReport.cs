using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP.WSEXE.Module2._2D
{
    public partial class FrmViewsReport : Form
    {
        DataProvider connect = new DataProvider();
        public FrmViewsReport()
        {
            InitializeComponent();
        }

        private void FrmViewsReport_Load(object sender, EventArgs e)
        {
            if(Form2D.Tab_Select == 4)
            {
                DataTable dt = connect.readdata(Form2D.Share_SQL);
                reportViewer1.View(dt, "Form2D_Tab4", "WTERP.WSEXE.Module2._2D.ReportView.Report_Tab4.rdlc");
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
