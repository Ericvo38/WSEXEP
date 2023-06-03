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
using WTERP.WSEXE;

namespace WTERP
{
    public partial class frm2CF5 : Form
    {
        DataProvider conn = new DataProvider();
        DataTable table = new DataTable();
        public frm2CF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        public class DL
        {
            public static string GetWS_NO;
            public static string where;
            public static int Index = 0;
        }
        public static string wheres = "";
        public static string getLoadDGV;
        private void frm2CF5_Load(object sender, EventArgs e)
        {
            LoadDGV2();
            txtSoVB.Focus();
        }
        void LoadDGV2()
        {
            if (DL.where != null)
            {
                frm3N.C_NO_ID.C_NO_ID_NUMBER = null;
                table = conn.readdata("SELECT TOP 1000 WS_NO, OR_NO, WS_DATE, WS_DATE1, C_NO, C_NAME, M_TRAN, ADDR, TOT, TOTAL, OVER0,MEMO6, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5,  MEMO7, MEMO8, CAL_YM, USR_NAME FROM CARH WHERE 1=1 "+DL.where+" ORDER BY WS_NO DESC");
            }
            else if (!string.IsNullOrEmpty(frm3N.C_NO_ID.C_NO_ID_NUMBER))
            {
                txtMaKH.Text = frm3N.C_NO_ID.C_NO_ID_NUMBER;
                table = conn.readdata("SELECT TOP 1000 WS_NO, OR_NO, WS_DATE, WS_DATE1, C_NO, C_NAME, M_TRAN, ADDR, TOT, TOTAL, OVER0,MEMO6, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, MEMO7, MEMO8, CAL_YM, USR_NAME FROM CARH WHERE 1=1 AND C_NO = '" + txtMaKH.Text + "' ORDER BY WS_NO DESC");
            }
            else
            {
                frm3N.C_NO_ID.C_NO_ID_NUMBER = null;
                table = conn.readdata("SELECT TOP 1000 WS_NO, OR_NO, WS_DATE, WS_DATE1, C_NO, C_NAME, M_TRAN, ADDR, TOT, TOTAL, OVER0,MEMO6, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5,  MEMO7, MEMO8, CAL_YM, USR_NAME FROM CARH WHERE 1=1 ORDER BY WS_NO DESC");
            }
            foreach (DataRow dr in table.Rows)
            {
                dr["WS_DATE"] = conn.formatstr2(dr["WS_DATE"].ToString());
            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = table;
            DGV2.DataSource = bindingSource;
            conn.DGV(DGV2);

            //load
            if (!string.IsNullOrEmpty(DGV2.Rows[0].Cells["WS_NO"].Value.ToString()))
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
        void Search()
        {
            DL.where = "";

            string SQL = "SELECT TOP 1000 WS_NO, OR_NO, WS_DATE, WS_DATE1, C_NO, C_NAME, M_TRAN, ADDR, TOT, TOTAL, OVER0,MEMO6, MEMO1, MEMO2, MEMO3, MEMO4, MEMO5, MEMO7, MEMO8, CAL_YM, USR_NAME FROM CARH WHERE 1=1";
            if (txtSoVB.Text == string.Empty && txtMaKH.Text == string.Empty && txtTenKH.Text == string.Empty && maskedTextBox1.Text != string.Empty && maskedTextBox1.MaskFull == true)
            {
                DL.where = DL.where + "";
                wheres = wheres + "";
            }
            if (txtSoVB.Text != string.Empty)
            {
                DL.where = DL.where + " AND WS_NO LIKE '" + txtSoVB.Text + "%'";
                wheres = wheres + " AND WS_NO LIKE '" + txtSoVB.Text + "%'";
            }
         
            if (txtMaKH.Text != string.Empty)
            {
                DL.where = DL.where + " AND C_NO LIKE '" + txtMaKH.Text + "%'";
                wheres = wheres + " AND C_NO LIKE '" + txtMaKH.Text + "%'";
            }
           
            if (txtTenKH.Text != string.Empty)
            {
                DL.where = DL.where + " AND C_NAME LIKE '" + txtTenKH.Text + "%'";
                wheres = wheres + " AND C_NAME LIKE '" + txtTenKH.Text + "%'";
            }    
            if (maskedTextBox1.Text != string.Empty && maskedTextBox1.MaskFull == true)
            {
                DL.where = DL.where + " AND WS_DATE LIKE '" + conn.formatstr2(maskedTextBox1.Text) + "%'";
                wheres = wheres + " AND WS_DATE LIKE '" + conn.formatstr2(maskedTextBox1.Text) + "%'";
            }    
               

            SQL = SQL + wheres + " ORDER BY WS_NO DESC";
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
            getData();
        }
        private void getData()
        {
            DL.GetWS_NO = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
            DL.Index = DGV2.CurrentRow.Index;
            this.Close();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DL.GetWS_NO = "";
            this.Close();
        }

        private void txtSoVB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                wheres = "";
                Search();
            }

        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                wheres = "";
                Search();
            }
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                wheres = "";
                Search();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            getData();
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
                wheres = "";
                Search();
            }
        }
    }
}
