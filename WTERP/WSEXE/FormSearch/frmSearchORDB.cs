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
    public partial class FrmSearchORDB : Form
    {
        DataProvider conn = new DataProvider();
        public FrmSearchORDB()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        string F_CNO = frm3L.F_CNO;
        public void Load_Data()
        {
            if(F_CNO != string.Empty)
            {
                string SQL2 = "SELECT TOP 500 OR_NO,C_NO,C_NAME_E,THICK,P_NO,P_NAME_E,COLOR_E,QTY,PRICE,TOTAL,BRAND,K_NAME_EN FROM ORDB INNER JOIN dbo.tbl_Type_New ON tbl_Type_New.K_NO = ORDB.K_NO WHERE C_NO = '" + F_CNO + "' ORDER BY WS_DATE DESC";
                DataTable dt1 = con.readdata(SQL2);
                DGV1.DataSource = dt1;
                DGV1.MyDGV();
            }
            else
            {
                string SQL2 = "SELECT TOP 500 OR_NO,THICK,C_NO,C_NAME_E,THICK,P_NO,P_NAME_E,QTY,PRICE,TOTAL,BRAND,K_NAME_EN,COLOR_E FROM ORDB INNER JOIN dbo.tbl_Type_New ON tbl_Type_New.K_NO = ORDB.K_NO ORDER BY WS_DATE DESC";
                DataTable dt1 = con.readdata(SQL2);
                DGV1.DataSource = dt1;
                DGV1.MyDGV();
            }
    
        }
        public class DT
        {
            public static List<string> OR_NO = new List<string>();
            public static List<string> THICK = new List<string>();
            public static List<string> P_NAME_E = new List<string>();
            public static List<string> QTY = new List<string>();
            public static List<string> PRICE = new List<string>();
            public static List<string> TOTAL = new List<string>();
            public static List<string> BRAND = new List<string>();
            public static List<string> K_NAME_EN = new List<string>();
            public static List<string> C_NO = new List<string>();
            public static List<string> C_NAME_E = new List<string>();
            public static List<string> P_NO = new List<string>();
            public static List<string> COLOR_E = new List<string>();
        }

        private void bttk_Click(object sender, EventArgs e)
        {
            string SQL1 = "SELECT OR_NO,THICK,C_NO,C_NAME_E,THICK,P_NO,P_NAME_E,QTY,PRICE,TOTAL,BRAND,K_NAME_EN,COLOR_E FROM ORDB INNER JOIN dbo.tbl_Type_New ON tbl_Type_New.K_NO = ORDB.K_NO WHERE 1=1 ";
            if (txtOR_NO.Text == string.Empty && txtC_NO.Text == string.Empty && txtCOLOR.Text == string.Empty && txtP_NO.Text == string.Empty)
            {
                SQL1 = SQL1 + "";
            }    
            if (txtOR_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND OR_NO LIKE '%" + txtOR_NO.Text + "%' ";
            if (txtC_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND C_NO LIKE '%" + txtC_NO.Text + "%' ";
            if (txtCOLOR.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NAME_E LIKE '%" + txtCOLOR.Text + "%' ";
            if (txtP_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NO LIKE '%" + txtP_NO.Text + "%' ";
            SQL1 = SQL1 + " ORDER BY WS_DATE DESC";
            DataTable dt2 = con.readdata(SQL1);
            DGV1.DataSource = dt2;
            DGV1.MyDGV();

        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DT.OR_NO.Clear();
            DT.THICK.Clear();
            DT.P_NAME_E.Clear();
            DT.QTY.Clear();
            DT.PRICE.Clear();
            DT.TOTAL.Clear();
            DT.BRAND.Clear();
            DT.K_NAME_EN.Clear();
            DT.C_NO.Clear();
            DT.C_NAME_E.Clear();
            DT.P_NO.Clear();
            DT.COLOR_E.Clear();
            for (int i = 0; i <= DGV1.Rows.Count - 1; i++)
            {
                bool checkedCell = Convert.ToBoolean(DGV1.Rows[i].Cells[0].Value);
                if (checkedCell == true)
                {
                    DT.OR_NO.Add(DGV1.Rows[i].Cells["OR_NO"].Value.ToString());
                    DT.THICK.Add(DGV1.Rows[i].Cells["THICK"].Value.ToString());
                    DT.P_NAME_E.Add(DGV1.Rows[i].Cells["P_NAME_E"].Value.ToString());
                    DT.QTY.Add(DGV1.Rows[i].Cells["QTY"].Value.ToString());
                    DT.PRICE.Add(DGV1.Rows[i].Cells["PRICE"].Value.ToString());
                    DT.TOTAL.Add(DGV1.Rows[i].Cells["TOTAL"].Value.ToString());
                    DT.BRAND.Add(DGV1.Rows[i].Cells["BRAND"].Value.ToString());
                    DT.K_NAME_EN.Add(DGV1.Rows[i].Cells["K_NAME_EN"].Value.ToString());
                    DT.C_NO.Add(DGV1.Rows[i].Cells["C_NO"].Value.ToString());
                    DT.C_NAME_E.Add(DGV1.Rows[i].Cells["C_NAME_E"].Value.ToString());
                    DT.P_NO.Add(DGV1.Rows[i].Cells["P_NO"].Value.ToString());
                    DT.COLOR_E.Add(DGV1.Rows[i].Cells["COLOR_E"].Value.ToString());

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
        private void FrmSearchORDB_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
    }
}
