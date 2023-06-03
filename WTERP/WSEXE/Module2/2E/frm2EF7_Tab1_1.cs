using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WTERP
{
    public partial class frm2EF7_Tab1_1 : Form
    {
        public frm2EF7_Tab1_1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        DataProvider con = new DataProvider();

        private void frm2EF7_Tab1_1_Load(object sender, EventArgs e)
        {
            string txtWS_NO1 = frm2EF7.G_TAB1.txWS_NO1;
            string txtWS_NO2 = frm2EF7.G_TAB1.txWS_NO2;
            string txtIn = frm2EF7.G_TAB1.T;

            WSEXE.ReportView.cr_Form2EF7_Tab1_1 rpt = new WSEXE.ReportView.cr_Form2EF7_Tab1_1();
            string st = "";


            if ((txtWS_NO1 != string.Empty) && (txtWS_NO2 != string.Empty) && (txtIn != string.Empty))
            {
                if ((txtWS_NO1 == txtWS_NO2) && (txtIn == "Y"))
                {
                    st = "select GIBH.WS_NO, GIBH.C_NAME, GIBH.WS_DATE, GIBH.CAL_YM, GIBB.OR_NO as OR_NO1, GIBB.COLOR, GIBB.P_NAME3, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT,GIBB.P_NAME from GIBH INNER JOIN GIBB ON GIBH.WS_NO = GIBB.WS_NO WHERE GIBH.WS_NO = '" + txtWS_NO1 + "'";
                }
                else if ((txtWS_NO1 != txtWS_NO2) && (txtIn == "Y"))
                {
                    st = "select GIBH.WS_NO, GIBH.C_NAME, GIBH.WS_DATE, GIBH.CAL_YM, GIBB.OR_NO as OR_NO1, GIBB.COLOR, GIBB.P_NAME3, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT,GIBB.P_NAME from GIBH INNER JOIN GIBB ON GIBH.WS_NO = GIBB.WS_NO WHERE GIBH.WS_NO BETWEEN '" + txtWS_NO1 + "' AND '" + txtWS_NO2 + "'";
                }
            }
            else if ((txtWS_NO1 == string.Empty) || (txtWS_NO2 == string.Empty) || (txtIn == string.Empty) || txtIn == "N")
                MessageBox.Show("Vui lòng nhập các ô còn trống!");

            DataTable dt = con.readdata(st);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
                dr["CAL_YM"] = con.formatstr2(dr["CAL_YM"].ToString());
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
