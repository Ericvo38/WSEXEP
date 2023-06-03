using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTERP.WSEXE;
using WTERP.WSEXE.ReportView;
using static WTERP.WSEXE.Report;

namespace WTERP
{
    public partial class frm2FF7_Print : Form
    {
        DataProvider con = new DataProvider();
        public frm2FF7_Print()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        public String DateFormat(String datein) // Convert  yyyy/MM/dd to yyyy/MM
        {
            String date2 = datein;
            string result = DateTime.ParseExact(date2, "yyyyMMdd",
                            CultureInfo.InvariantCulture).ToString("yyyy/MM");
            return result;
        }
        private void frm2FF7_Print_Load(object sender, EventArgs e)
        {
            try
            {
                string C_NO1 = frm2FF7.Share_frm2FF7.C_NO_S;
                string C_NO2 = frm2FF7.Share_frm2FF7.C_NO_E;
                string sql = "SELECT C_NAME,CATB.WS_NO,CATB.WS_DATE,P_NAME,BQTY,PRICE,AMOUNT,CATB.C_NO" +
                             " FROM CATH,CATB WHERE CATH.WS_NO=CATB.WS_NO  AND CATH.C_NO>='" + C_NO1+ "' AND CATH.C_NO<='" + C_NO2 + "'" +
                             " ORDER BY CATH.C_NO,CATH.WS_NO,CATB.NR";
                System.Data.DataTable dt = con.readdata(sql);
                foreach (DataRow dr in dt.Rows)
                    dr["WS_Date"] = DateFormat(dr["WS_Date"].ToString());
                Cr_Form2FF7 rp = new Cr_Form2FF7();
                rp.SetDataSource(dt);
                crystalReportViewer2.ReportSource = rp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
