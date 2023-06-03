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

namespace WTERP
{
    public partial class Form1DF7_Tab5 : Form
    {
        DataProvider connect = new DataProvider();
        public Form1DF7_Tab5()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void Form1DF7_Tab5_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string st = "Select P_NAME from PROD1C";
            WSEXE.ReportView.cr_Form1DF7_Tab5 rpt = new WSEXE.ReportView.cr_Form1DF7_Tab5();
            DataTable dt = connect.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
