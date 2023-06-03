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
    public partial class frm2EF7_Tab2_2 : Form
    {
        public frm2EF7_Tab2_2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        DataProvider con = new DataProvider();

        private void frm2EF7_Tab2_2_Load(object sender, EventArgs e)
        {

            string txtWSNO1 = frm2EF7.G_TAB2.txWNO1;
            string txtWSNO2 = frm2EF7.G_TAB2.txWNO2;
            string txtDATE1 = frm2EF7.G_TAB2.txDate1;
            string txtDATE2 = frm2EF7.G_TAB2.txDate2;
            string txtCNO1 = frm2EF7.G_TAB2.txCNO1;
            string txtCNO2 = frm2EF7.G_TAB2.txCNO2;
            MessageBox.Show(txtDATE1);
            MessageBox.Show(txtDATE2);
            WSEXE.ReportView.cr_From2EF7_Tab2_2 rpt = new WSEXE.ReportView.cr_From2EF7_Tab2_2();
            string st = "";


            if ((txtWSNO1 != string.Empty) && (txtWSNO2 != string.Empty) && (txtDATE1 == string.Empty) && (txtDATE2 == string.Empty) && (txtCNO1 == string.Empty) && (txtCNO2 == string.Empty))
            {
                if (txtWSNO1 == txtWSNO2)
                {
                    st = "select GIBB.WS_DATE, GIBB.WS_NO, GIBB.C_NO, GIBB.OR_NO, PRDMK2.MODEL_E as MODEL_E1, GIBB.P_NAME1, GIBB.COLOR, GIBB.P_NAME3, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT, PRDMK2.MEMO03 as MEMO031 from GIBB Left Join PRDMK1 on GIBB.OR_NO = PRDMK1.OR_NO AND GIBB.K_NO = PRDMK1.K_NO left Join PRDMK2 on GIBB.OR_NO = PRDMK2.OR_NO AND GIBB.K_NO  = PRDMK2.K_NO   WHERE GIBB.WS_NO = '" + txtWSNO1 + "'";
                }
                else if (txtWSNO1 != txtWSNO2)
                {
                    st = "select GIBB.WS_DATE, GIBB.WS_NO, GIBB.C_NO, GIBB.OR_NO, PRDMK2.MODEL_E as MODEL_E1, GIBB.P_NAME1, GIBB.COLOR, GIBB.P_NAME3, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT, PRDMK2.MEMO03 as MEMO031 from GIBB Left Join PRDMK1 on GIBB.OR_NO = PRDMK1.OR_NO AND GIBB.K_NO = PRDMK1.K_NO left Join PRDMK2 on GIBB.OR_NO = PRDMK2.OR_NO AND GIBB.K_NO  = PRDMK2.K_NO   WHERE GIBB.WS_NO BETWEEN '" + txtWSNO1 + "' AND '" + txtWSNO2 + "'";
                }
            }
            if ((txtWSNO1 == string.Empty) && (txtWSNO2 == string.Empty) && (txtDATE1 != string.Empty) && (txtDATE2 != string.Empty) && (txtCNO1 == string.Empty) && (txtCNO2 == string.Empty))
            {
                if (txtWSNO1 == txtWSNO2)
                {
                    st = "select GIBB.WS_DATE, GIBB.WS_NO, GIBB.C_NO, GIBB.OR_NO, PRDMK2.MODEL_E as MODEL_E1, GIBB.P_NAME1, GIBB.COLOR, GIBB.P_NAME3, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT, PRDMK2.MEMO03 as MEMO031 from GIBB Left Join PRDMK1 on GIBB.OR_NO = PRDMK1.OR_NO AND GIBB.K_NO = PRDMK1.K_NO left Join PRDMK2 on GIBB.OR_NO = PRDMK2.OR_NO AND GIBB.K_NO  = PRDMK2.K_NO   WHERE GIBB.WS_DATE = '" + txtDATE1 + "'";
                }
                else if (txtWSNO1 != txtWSNO2)
                {
                    st = "select GIBB.WS_DATE, GIBB.WS_NO, GIBB.C_NO, GIBB.OR_NO, PRDMK2.MODEL_E as MODEL_E1, GIBB.P_NAME1, GIBB.COLOR, GIBB.P_NAME3, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT, PRDMK2.MEMO03 as MEMO031 from GIBB Left Join PRDMK1 on GIBB.OR_NO = PRDMK1.OR_NO AND GIBB.K_NO = PRDMK1.K_NO left Join PRDMK2 on GIBB.OR_NO = PRDMK2.OR_NO AND GIBB.K_NO  = PRDMK2.K_NO   WHERE GIBB.WS_DATE BETWEEN '" + txtDATE1 + "' AND '" + txtDATE2 + "'";
                }
            }
            if ((txtWSNO1 == string.Empty) && (txtWSNO2 == string.Empty) && (txtDATE1 == string.Empty) && (txtDATE2 == string.Empty) && (txtCNO1 != string.Empty) && (txtCNO2 != string.Empty))
            {
                if (txtWSNO1 == txtWSNO2)
                {
                    st = "select GIBB.WS_DATE, GIBB.WS_NO, GIBB.C_NO, GIBB.OR_NO, PRDMK2.MODEL_E as MODEL_E1, GIBB.P_NAME1, GIBB.COLOR, GIBB.P_NAME3, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT, PRDMK2.MEMO03 as MEMO031 from GIBB Left Join PRDMK1 on GIBB.OR_NO = PRDMK1.OR_NO AND GIBB.K_NO = PRDMK1.K_NO left Join PRDMK2 on GIBB.OR_NO = PRDMK2.OR_NO AND GIBB.K_NO  = PRDMK2.K_NO   WHERE GIBB.C_NO = '" + txtCNO1 + "'";
                }
                else if (txtWSNO1 != txtWSNO2)
                {
                    st = "select GIBB.WS_DATE, GIBB.WS_NO, GIBB.C_NO, GIBB.OR_NO, PRDMK2.MODEL_E as MODEL_E1, GIBB.P_NAME1, GIBB.COLOR, GIBB.P_NAME3, GIBB.BQTY, GIBB.PRICE, GIBB.AMOUNT, PRDMK2.MEMO03 as MEMO031 from GIBB Left Join PRDMK1 on GIBB.OR_NO = PRDMK1.OR_NO AND GIBB.K_NO = PRDMK1.K_NO left Join PRDMK2 on GIBB.OR_NO = PRDMK2.OR_NO AND GIBB.K_NO  = PRDMK2.K_NO  WHERE GIBB.C_NO BETWEEN '" + txtCNO1 + "' AND '" + txtCNO2 + "'";
                }
            }

            DataTable dt = con.readdata(st);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString()); 
            }
            rpt.SetDataSource(dt);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
