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
using WTERP.WSEXE.ReportView;

namespace WTERP
{
    public partial class Form2ABF7_Tab4 : Form
    {
        DataProvider conn = new DataProvider();
        public Form2ABF7_Tab4()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form2ABF7_Tab4_Load(object sender, EventArgs e)
        {
            string SQL = Form2ABF7.SQL4;
            CrystalReport2AB_Tab4_New crv = new CrystalReport2AB_Tab4_New();
            string SQL1 = Form2ABF7.SQLSub;
            DataTable dt = conn.readdata(SQL);
            DataTable dt1 = conn.readdata(SQL1);
            crv.SetDataSource(dt);
            crv.Subreports[0].SetDataSource(dt1);
            crystalReportViewer1.ReportSource = crv;
        }
    }
}
