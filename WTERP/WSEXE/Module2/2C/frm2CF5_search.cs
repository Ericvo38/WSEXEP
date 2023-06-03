using LibraryCalender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2CF5_search : Form
    {
        DataProvider conn = new DataProvider();
        DataTable table = new DataTable();
        public frm2CF5_search()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        public class DL
        {
            public static string GetWS_NO;
        }
        public static string getLoadDGV;
        private void frm2CF5_Load(object sender, EventArgs e)
        {
            LoadDGV2();
            txtSoVB.Focus();
        }
        void LoadDGV2()
        {
            string SQL = "SELECT WS_NO, OR_NO, WS_DATE, WS_DATE1, C_NO, C_NAME, M_TRAN, ADDR, TOT, TOTAL, OVER0,MEMO6,MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, MEMO7, MEMO8, CAL_YM, USR_NAME FROM CARH WHERE 1=1 ORDER BY WS_DATE DESC";
            table = conn.readdata(SQL);
            foreach (DataRow dr in table.Rows)
            {
                dr["WS_DATE"] = conn.formatstr2(dr["WS_DATE"].ToString());
            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = table;
            DGV2.DataSource = bindingSource;
            conn.DGV(DGV2);

            //load
            getLoadDGV = DGV2.Rows[0].Cells["WS_NO"].Value.ToString();
            string SQL3 = "SELECT NR, P_NO, P_NAME, BQTY, UNIT, PRICE, AMOUNT, COST, MEMO FROM CARB WHERE WS_NO ='" + getLoadDGV + "'";
            DataTable dt3 = conn.readdata(SQL3);
            DGV3.DataSource = dt3;
            DGV3.MyDGV();
        }
        void Search()
        {
            //string SQL = "SELECT TOP 200 WS_NO, WS_DATE,C_NO, C_NAME, TOT, TAX, DISCOUNT, RCV_MON, TOTAL, NRCV_MON  FROM [J2BKPV].[dbo].[CARH] WHERE 1=1 ";
            string SQL = "SELECT WS_NO, OR_NO, WS_DATE, WS_DATE1, C_NO, C_NAME, M_TRAN, ADDR, TOT, TOTAL, OVER0,MEMO6, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, MEMO7, MEMO8, CAL_YM, USR_NAME FROM CARH WHERE 1=1";
            if (txtSoVB.Text == string.Empty && txtMaKH.Text == string.Empty && txtTenKH.Text == string.Empty && maskedTextBox1.Text != string.Empty && maskedTextBox1.MaskFull == true)
            {
                SQL = SQL + "";
            }
            if (txtSoVB.Text != string.Empty)
                SQL = SQL + " AND WS_NO LIKE '" + txtSoVB.Text + "%'";
            if (txtMaKH.Text != string.Empty)
                SQL = SQL + " AND C_NO LIKE '" + txtMaKH.Text + "%'";
            if (txtTenKH.Text != string.Empty)
                SQL = SQL + " AND C_NAME LIKE '" + txtTenKH.Text + "%'";
            if (maskedTextBox1.Text != string.Empty && maskedTextBox1.MaskFull == true)
                SQL = SQL + " AND WS_DATE LIKE '" + conn.formatstr2(maskedTextBox1.Text) + "%'";
            SQL = SQL + " ORDER BY WS_DATE DESC";
            table = conn.readdata(SQL);
            foreach (DataRow dr in table.Rows)
            {
                dr["WS_DATE"] = conn.formatstr2(dr["WS_DATE"].ToString());
            }
            DGV2.DataSource = table;
            if (DGV2.Rows.Count > 0)
            {
                getLoadDGV = DGV2.Rows[0].Cells["WS_NO"].Value.ToString();
            }
            else
            {
                getLoadDGV = "";
            }
            string SQL3 = "SELECT NR, P_NO, P_NAME, BQTY, UNIT, PRICE, AMOUNT, COST, MEMO FROM CARB WHERE WS_NO ='" + getLoadDGV + "'";
            DataTable dt3 = conn.readdata(SQL3);
            DGV3.DataSource = dt3;
            DGV3.MyDGV();
        }
        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DL.GetWS_NO = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
            this.Close();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoVB_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtSoVB, txtMaKH, sender, e);
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab(txtSoVB, txtTenKH, sender, e);
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_DOWN(txtMaKH, maskedTextBox1, sender, e);
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            DL.GetWS_NO = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
            this.Close();
        }

        private void frm2CF5_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Closeconnect();
        }

        private void DGV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getLoadDGV = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
            string SQL3 = "SELECT NR, P_NO, P_NAME, BQTY, UNIT, PRICE, AMOUNT, COST, MEMO FROM CARB WHERE WS_NO ='" + getLoadDGV + "'";
            DataTable dt3 = conn.readdata(SQL3);
            DGV3.DataSource = dt3;
            DGV3.MyDGV();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            maskedTextBox1.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            conn.tab_UP(maskedTextBox1, txtSoVB, sender, e);
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
    }
}
