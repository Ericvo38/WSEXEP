using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTERP.WSEXE.ReportView;

namespace WTERP
{
    public partial class Form6AF7 : Form
    {
        DataProvider conn = new DataProvider();
        public Form6AF7()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        private void Form6AF7_Load(object sender, EventArgs e)
        {
            Load1();
        }
        public void Load1()
        {
            string s = Form6A.DL.tb3;

            WSEXE.ReportView.cr_Form6AF7 rpt = new WSEXE.ReportView.cr_Form6AF7();
            string st = "select USRH.WSNO, USRH.USER_ID, USRH.NAME, USRH.SUPER, USRB.PROG_NO, USRB.PROG_NAME, USRB.PUSE, USRB.PADD, USRB.PRET, USRB.PMODI, USRB.PDEL, USRB.PBROW, USRB.PPRT, USRB.PPRICE, USRB.PCHECK, USRB.PCHK01, USRB.PCHK02, USRB.PCHK03 from USRB inner join USRH on USRB.WSNO = USRH.WSNO where USRH.USER_ID ='"+s+"'";
            DataTable dt = conn.readdata(st);
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;

        }
    }
}
