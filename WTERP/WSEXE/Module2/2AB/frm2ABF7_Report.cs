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
    public partial class Form2ABF7_Report : Form
    {
        DataProvider conn = new DataProvider();
        public Form2ABF7_Report()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
    
        private void Form2ABF7_Report_Load(object sender, EventArgs e)
        {
            string SQL1 = Form2ABF7.SQL;
            DataTable dt = conn.readdata(SQL1);
            CrR_2AB_Tab1 crv = new CrR_2AB_Tab1();
            crv.SetDataSource(dt);
            crystalReportViewer1.ReportSource = crv;
        }
        
    }
}
