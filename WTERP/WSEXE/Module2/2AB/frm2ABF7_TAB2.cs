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
using WTERP.WSEXE;
using WTERP.WSEXE.ReportView;

namespace WTERP
{
    public partial class Form2ABF7_TAB2 : Form
    {
        DataProvider conn = new DataProvider();
        public Form2ABF7_TAB2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form2ABF7_TAB2_Load(object sender, EventArgs e)
        {
            string SQL = Form2ABF7.SQL2;
            Cr_2AB_Tab2 crv = new Cr_2AB_Tab2();
            DataTable dt = conn.readdata(SQL);
            crv.SetDataSource(dt);
            crystalReportViewer1.ReportSource = crv;
        }
    }
}
