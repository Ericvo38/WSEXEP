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
    public partial class frm2EF7_Tab2_1 : Form
    {
        public frm2EF7_Tab2_1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        DataProvider con = new DataProvider();
        private void frm2EF7_Tab2_1_Load(object sender, EventArgs e)
        {
            string txtWSNO1 = frm2EF7.G_TAB2.txWNO1;
            string txtWSNO2 = frm2EF7.G_TAB2.txWNO2;
            string txtDATE1 = frm2EF7.G_TAB2.txDate1;
            string txtDATE2 = frm2EF7.G_TAB2.txDate2;
            string txtCNO1 = frm2EF7.G_TAB2.txCNO1;
            string txtCNO2 = frm2EF7.G_TAB2.txCNO2;
            WSEXE.ReportView.cr_Form2EF7_Tab2_1 rpt = new WSEXE.ReportView.cr_Form2EF7_Tab2_1();
            string st = "";

            if ((txtWSNO1 != "") && (txtWSNO2 != "") && (txtDATE1 == "") && (txtDATE2 == "") && (txtCNO1 == "") && (txtCNO2 == ""))
            {
                if (txtWSNO1 == txtWSNO2)
                {
                    st = "select GIBB.WS_DATE as WS_DATE1, GIBB.WS_NO as WS_NO1, GIBH.C_ANAME, GIBB.OR_NO as OR_NO1, GIBB.P_NAME, GIBB.COLOR, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT from GIBH INNER JOIN GIBB ON GIBH.WS_NO = GIBB.WS_NO  WHERE GIBB.WS_NO = '" + txtWSNO1 + "'";
                }
                else if (txtWSNO1 != txtWSNO2)
                {
                    st = "select GIBB.WS_DATE as WS_DATE1, GIBB.WS_NO as WS_NO1, GIBH.C_ANAME, GIBB.OR_NO as OR_NO1, GIBB.P_NAME, GIBB.COLOR, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT from GIBH INNER JOIN GIBB ON GIBH.WS_NO = GIBB.WS_NO  WHERE GIBB.WS_NO BETWEEN '" + txtWSNO1 + "' AND '" + txtWSNO2 + "'";
                }
            }
            if ((txtWSNO1 == "") && (txtWSNO2 == "") && (txtDATE1 != "") && (txtDATE2 != "") && (txtCNO1 == "") && (txtCNO2 == ""))
            {
                if (txtDATE1 == txtDATE2)
                {
                    st = "select GIBB.WS_DATE as WS_DATE1, GIBB.WS_NO as WS_NO1, GIBH.C_ANAME, GIBB.OR_NO as OR_NO1, GIBB.P_NAME, GIBB.COLOR, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT from GIBH INNER JOIN GIBB ON GIBH.WS_NO = GIBB.WS_NO  WHERE GIBB.WS_DATE = '" + txtDATE1 + "'";
                }
                else if (txtDATE1 != txtDATE2)
                {
                    st = "select GIBB.WS_DATE as WS_DATE1, GIBB.WS_NO as WS_NO1, GIBH.C_ANAME, GIBB.OR_NO as OR_NO1, GIBB.P_NAME, GIBB.COLOR, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT from GIBH INNER JOIN GIBB ON GIBH.WS_NO = GIBB.WS_NO  WHERE GIBB.WS_DATE BETWEEN '" + txtDATE1 + "' AND '" + txtDATE2 + "'";
                }
            }
            if ((txtWSNO1 == "") && (txtWSNO2 == "") && (txtDATE1 == "") && (txtDATE2 == "") && (txtCNO1 != "") && (txtCNO2 != ""))
            {
                if (txtCNO1 == txtCNO2)
                {
                    st = "select GIBB.WS_DATE as WS_DATE1, GIBB.WS_NO as WS_NO1, GIBH.C_ANAME, GIBB.OR_NO as OR_NO1, GIBB.P_NAME, GIBB.COLOR, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT from GIBH INNER JOIN GIBB ON GIBH.WS_NO = GIBB.WS_NO  WHERE GIBB.C_NO = '" + txtCNO1 + "'";
                }
                else if (txtCNO1 != txtCNO2)
                {
                    st = "select GIBB.WS_DATE as WS_DATE1, GIBB.WS_NO as WS_NO1, GIBH.C_ANAME, GIBB.OR_NO as OR_NO1, GIBB.P_NAME, GIBB.COLOR, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT from GIBH INNER JOIN GIBB ON GIBH.WS_NO = GIBB.WS_NO  WHERE GIBB.C_NO BETWEEN '" + txtCNO1 + "' AND '" + txtCNO2 + "'";
                }
            }



            DataTable dt = con.readdata(st);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE1"] = con.formatstr2(dr["WS_DATE1"].ToString());
              
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }

    }
}
