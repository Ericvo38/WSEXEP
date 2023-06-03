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
    public partial class frm3HF7_Tab1 : Form
    {
        DataProvider con = new DataProvider();
        public frm3HF7_Tab1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        string SQL = "";
        string TILTE = "";
        private void frm3HF7_Tab1_Load(object sender, EventArgs e)
        {
            SQL = frm3H.SEND.SQL_Tab1;
            TILTE = frm3H.SEND.Tilteee;

            DataTable dataTable = new DataTable();
            dataTable = con.readdata(SQL);
            foreach(DataRow dr in dataTable.Rows)
            {
                dr["DATE"] = con.formatstr1(dr["DATE"].ToString());
            }
            WSEXE.ReportView.cr_frm3HF7_Tab1 rpt = new WSEXE.ReportView.cr_frm3HF7_Tab1();
            rpt.DataDefinition.FormulaFields["TITEL"].Text = "'" + TILTE + "'";
            rpt.SetDataSource(dataTable);
            crystalReportViewer1.ReportSource = rpt;   
        }
    }
}
