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
    public partial class frmSearchCARB : Form
    {
        DataProvider conn = new DataProvider();
        public frmSearchCARB()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        string F_CNO = frm3L.F_CNO;
        private void frmSearchCARB_Load(object sender, EventArgs e)
        {
            Load_Data();
            DGV1.AllowUserToAddRows = false;
        }
        public void Load_Data()
        {
            getData();
        }
        private void getData()
        {
            string sql = "SELECT TOP 500 a.OR_NO,a.C_NO,a.COLOR_E +''+a.P_NAME_E AS COLOR,a.P_NO, a.COLOR_E +''+a.P_NAME_E +' '+ a.P_NAME_C AS P_NAME,a.THICK AS P_NAME3,a.P_NAME_E AS P_NAME1,a.QTY as BQTY,PRICE,(QTY * PRICE) AS AMOUNT," +
                "0 AS PCS,0 AS QPCS, c.K_NAME_EN AS K_NAME,BRAND FROM ORDB as a " +
                "INNER JOIN tbl_Type_New as c ON c.K_NO = a.K_NO ORDER BY a.WS_DATE DESC";
            DataTable dt1 = con.readdata(sql);
            DGV1.DataSource = dt1;
            DGV1.MyDGV();
        }
        private string getData_timkiem(string key)
        {
            string sql = "SELECT TOP 500 a.OR_NO,a.C_NO,a.COLOR_E +''+a.P_NAME_E AS COLOR,a.P_NO, a.COLOR_E +''+a.P_NAME_E +' '+ a.P_NAME_C AS P_NAME,a.THICK AS P_NAME3,a.P_NAME_E AS P_NAME1,a.QTY as BQTY," +
                "PRICE,(QTY * PRICE) AS AMOUNT,0 AS PCS,  0 AS QPCS, c.K_NAME_EN AS K_NAME,BRAND FROM ORDB as a INNER JOIN tbl_Type_New as c ON c.K_NO = a.K_NO WHERE 1 = 1 "+key+"";
            return sql;
        }
        public class DT
        {
            public static List<string> L_OR_NO = new List<string>();
            public static List<string> L_COLOR = new List<string>();
            public static List<string> L_P_NO = new List<string>();
            public static List<string> L_COLOR_C = new List<string>();
            public static List<string> L_P_NAME= new List<string>();
            public static List<string> L_PNAME3 = new List<string>();
            public static List<string> L_PNAME1 = new List<string>();
            public static List<string> L_BQTY = new List<string>();
            public static List<string> L_PRICE = new List<string>();
            public static List<string> L_AMOUNT = new List<string>();
            public static List<string> L_PCS = new List<string>();
            public static List<string> L_QPCS = new List<string>();
            public static List<string> K_NAME = new List<string>();
            public static List<string> BRAND = new List<string>();

        }
        private string searchwhere(string SQL1)
        {
            if (txtOR_NO.Text == string.Empty && txtC_NO.Text == string.Empty && txtCOLOR.Text == string.Empty && txtP_NO.Text == string.Empty)
            {
                SQL1 = SQL1 + "";
            }
            if (txtOR_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND a.OR_NO LIKE '%" + txtOR_NO.Text + "%' ";
            if (txtC_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND a.C_NO LIKE '%" + txtC_NO.Text + "%' ";
            if (txtCOLOR.Text != string.Empty)
                SQL1 = SQL1 + " AND a.COLOR_E LIKE '%" + txtCOLOR.Text + "%' ";
            if (txtP_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND a.P_NO LIKE '%" + txtP_NO.Text + "%' ";

            return SQL1;
        }
        private void bttk_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (frm3L.getDataRadio.rdHangMau == true)
            {
                string key = "";
                sql = getData_timkiem(searchwhere(key));
            }
            else if (frm3L.getDataRadio.rdHangSX == true)
            {
                string key = "";
                sql = getData_timkiem(searchwhere(key));
            }
            sql = sql + " ORDER BY a.WS_DATE DESC";
            DataTable dt2 = con.readdata(sql);
            DGV1.DataSource = dt2;
            DGV1.MyDGV();
            DGV1.AllowUserToAddRows = false;
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DT.K_NAME.Clear();
            DT.BRAND.Clear();
            DT.L_OR_NO.Clear();
            DT.L_COLOR.Clear();
            DT.L_P_NO.Clear();
            DT.L_COLOR_C.Clear();
            DT.L_P_NAME.Clear();
            DT.L_PNAME3.Clear();
            DT.L_PNAME1.Clear();
            DT.L_BQTY.Clear();
            DT.L_PRICE.Clear();
            DT.L_AMOUNT.Clear();
            DT.L_PCS.Clear();
            DT.L_QPCS.Clear();
            for (int i = 0; i <= DGV1.Rows.Count - 1; i++)
            {
                bool checkedCell = Convert.ToBoolean(DGV1.Rows[i].Cells[0].Value);
                if (checkedCell == true)
                {
                    DT.L_OR_NO.Add(DGV1.Rows[i].Cells["OR_NO"].Value.ToString());
                    DT.L_COLOR.Add(DGV1.Rows[i].Cells["COLOR"].Value.ToString());
                    DT.L_P_NO.Add(DGV1.Rows[i].Cells["P_NO"].Value.ToString());
                    DT.L_COLOR_C.Add(DGV1.Rows[i].Cells["COLOR"].Value.ToString());
                    DT.L_P_NAME.Add(DGV1.Rows[i].Cells["P_NAME"].Value.ToString());
                    DT.L_PNAME3.Add(DGV1.Rows[i].Cells["P_NAME3"].Value.ToString());
                    DT.L_PNAME1.Add(DGV1.Rows[i].Cells["P_NAME1"].Value.ToString());
                    DT.L_BQTY.Add(DGV1.Rows[i].Cells["BQTY"].Value.ToString());
                    DT.L_PRICE.Add(DGV1.Rows[i].Cells["PRICE"].Value.ToString());
                    DT.L_AMOUNT.Add(DGV1.Rows[i].Cells["AMOUNT"].Value.ToString());
                    DT.L_PCS.Add(DGV1.Rows[i].Cells["PCS"].Value.ToString());
                    DT.L_QPCS.Add(DGV1.Rows[i].Cells["QPCS"].Value.ToString());
                    DT.K_NAME.Add(DGV1.Rows[i].Cells["K_NAME"].Value.ToString());
                    DT.BRAND.Add(DGV1.Rows[i].Cells["BRAND"].Value.ToString());
                }
            }
            this.Hide();
            this.Close();
        }

        private void txtOR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                txtC_NO.Focus();
            }
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                   bttk.PerformClick(); 
                   txtCOLOR.Focus();
            }
        }

        private void txtCOLOR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                txtP_NO.Focus();
            }
        }

        private void txtP_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                txtOR_NO.Focus();
            }
        }

        private void DGV1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToBoolean(DGV1.CurrentRow.Cells[0].Value) == true)
            {
                DGV1.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                DGV1.CurrentRow.Cells[0].Value = true;
            }
        }
    }
}
