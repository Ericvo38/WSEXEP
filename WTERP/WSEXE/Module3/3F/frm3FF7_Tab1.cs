using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP.WSEXE
{
    public partial class frm3FF7_Tab1 : Form
    {
        public frm3FF7_Tab1()
        {
            this.ShowInTaskbar = false;

            InitializeComponent();
        }
      private void frm3FF7_Tab1_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable = frm3FF7.DataTable1;
            WSEXE.ReportView.cr_frm3FF7_Tab1 rpt = new WSEXE.ReportView.cr_frm3FF7_Tab1();
            rpt.SetDataSource(dataTable);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
