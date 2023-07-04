using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WTERP.WSEXE.Report;

namespace WTERP.WSEXE.Module2._2C
{
    public partial class Frm2CF7_Print : Form
    {
        DataProvider connect = new DataProvider();
        public static string Share_SQL = string.Empty, TypeReport = string.Empty;
        public Frm2CF7_Print()
        {
            InitializeComponent();
            connect.choose_languege();
        }

        private void Frm2CF7_Print_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_MouseHover(object sender, EventArgs e)
        {
            //toolStripStatusLabel2.Text = "Xem trước";
        }

        private void btnCancel_MouseHover(object sender, EventArgs e)
        {
            //toolStripStatusLabel2.Text = "Thoát chương trình";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TypeReport = txtWS_NO_S.Text.Substring(0, 1) + txtWS_NO_E.Text.Substring(0, 1);
            ViewsPrint();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void f1ToolStrip_Click(object sender, EventArgs e)
        {

        }

        private void f2ToolStrip_Click(object sender, EventArgs e)
        {
            btnOK.PerformClick();
        }

        private void f4ToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtPrice.Text.Equals("N")) txtPrice.Text = "Y";
            else txtPrice.Text = "N";
        }

        private void txtMK_NOA_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtMK_NOA.Text.Equals("N")) txtMK_NOA.Text = "Y";
            else txtMK_NOA.Text = "N";
        }
        private void ViewsPrint()
        {
            try
            {
                string SQL = "SELECT H.WS_NO, H.WS_DATE, T.C_ANAME1, T.C_NAME1, T.C_OTYPE "+Address()+ ", H.MEMO3, H.MEMO4 " + GetBrand()+ ", H.MEMO8, T.USR_NAME, B.OR_NO, "+GetColor()+ ", B.P_NAME3, B.BQTY " + GetPrice()+ GetMK_NOA ()+ ", CAST(B.PCS AS NVARCHAR(max)) + ' 件 ' + CAST(B.QPCS AS NVARCHAR(max)) + ' PCS ' + CAST(CAST(B.QTY  AS DECIMAL(20, 2))AS NVARCHAR(max)) + ' KG' AS MEMO FROM CARH H INNER JOIN CUST T  ON T.C_NO=H.C_NO INNER JOIN dbo.CARB B ON H.WS_NO=B.WS_NO WHERE H.USR_NAME='" + frmLogin.ID_NAME+"' ";
                if (!string.IsNullOrEmpty(txtWS_NO_S.Text)) SQL = SQL + " AND H.WS_NO >='"+txtWS_NO_S.Text+"'";
                if (!string.IsNullOrEmpty(txtWS_NO_E.Text)) SQL = SQL + " AND H.WS_NO <='"+txtWS_NO_E.Text+"'";
                Share_SQL = SQL + " ORDER BY H.WS_NO";
                FrmView2C fm = new FrmView2C();
                fm.ShowDialog();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, connect.MessaError(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string Address()
        {
            string Result = string.Empty;
            if (rdAddress.Checked) Result = " , T.ADR1 ";
            return Result;
        }
        private string GetBrand()
        {
            string Result = string.Empty;
            if(rdPrintBrand.Checked) Result = " , H.MEMO7 ";
            return Result;
        }
        private string GetPrice()
        {
            string Result = string.Empty;
            if (txtPrice.Text.Equals("Y")) Result = " , B.PRICE, B.AMOUNT ";
            return Result;
        }
        private string GetMK_NOA()
        {
            string Result = string.Empty;
            if (txtMK_NOA.Text.Equals("Y")) Result = " , B.MK_NO1 ";
            return Result;
        }
        private string GetColor()
        {
            string Result = string.Empty;
            if (rdColor_E.Checked) Result = " B.COLOR +' '+ B.P_NAME1+' '+B.P_NAME2 AS P_NAME";
            if (rdColor_C.Checked) Result = " B.COLOR_C+' '+B.P_NAME + B.P_NAME2 AS P_NAME";
            if (rdColor_E_C.Checked) Result = " B.COLOR +''+B.COLOR_C+''+B.P_NAME1+' '+B.P_NAME+' '+B.P_NAME2 AS P_NAME";
            return Result;
        }
    }
}
