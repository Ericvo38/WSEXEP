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
    public partial class frm2GTab1 : Form
    {
        DataProvider con = new DataProvider();
        public frm2GTab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        string sql1 = "";

        private void frm2GTab1_Load(object sender, EventArgs e)
        {
            sql1 = frm2G.sql;
            //MessageBox.Show(sql1);
            WTERP.WSEXE.ReportView.cr_Form2G_Tab1 cr_Form2G_Tab = new ReportView.cr_Form2G_Tab1();
             DataTable data = new DataTable();
            data = con.readdata(sql1);
            foreach(DataRow dataRow in data.Rows)
            {
                dataRow["WS_DATE"] = con.formatstr1(dataRow["WS_DATE"].ToString());
                dataRow["DATE"] = con.formatstr1(dataRow["DATE"].ToString());
            }
            cr_Form2G_Tab.SetDataSource(data);
            crystalReportViewer1.ReportSource = cr_Form2G_Tab;
        }
    }
}
