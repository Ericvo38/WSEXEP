using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2EF6 : Form
    {
        DataProvider con = new DataProvider();
        public frm2EF6()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void frm2EF6_Load(object sender, EventArgs e)
        {
            LV.Clear();

            LoadData();
            txtOR_NO.Select();
            txtOR_NO.Focus();
            txtC_NO.Text = MaKH;

        }
        string MaKH = Form2E.F2E.MaKH;
        public void LoadData()
        {
            string SQL = "SELECT NR, OR_NO,C_NO,C_NAME_E, COLOR_E,WS_DATE,P_NAME_E,THICK,QTY,P_NO,K_NO,PATT_C,PATT_E,MODEL_E FROM ORDB WHERE C_NO = '"+ MaKH + "' ORDER BY WS_DATE DESC, NR DESC, OR_NO DESC";
            DataTable dt = con.readdata(SQL);
            foreach (DataRow dr in dt.Rows)
                dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
            DGV1.DataSource = dt;
            con.DGV(DGV1);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        void Search()
        {
            string SQL1 = "SELECT NR, OR_NO,C_NO,C_NAME_E, COLOR_E,WS_DATE,P_NAME_E,THICK,QTY,P_NO,K_NO,PATT_C,PATT_E,MODEL_E FROM ORDB WHERE 1=1";
            if (txtP_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NO LIKE '%" + txtP_NO.Text + "%'";
            if (txtOR_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND OR_NO LIKE '%" + txtOR_NO.Text + "%'";
            if (txtTHICK.Text != string.Empty)
                SQL1 = SQL1 + " AND THICK LIKE '%" + txtTHICK.Text + "%'";
            if (txtP_NAME_C.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NAME_C LIKE '%" + txtP_NAME_C.Text + "%'";
            if (txtP_NAME_E.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NAME_E LIKE '%" + txtP_NAME_E.Text + "%'";
            if (txtCOLOR_C.Text != string.Empty)
                SQL1 = SQL1 + " AND COLOR_C LIKE '%" + txtCOLOR_C.Text + "%'";
            if (txtC_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND C_NO = '" + txtC_NO.Text + "'";
            if (txtDate.Text != string.Empty && txtDate.MaskFull == true)
                SQL1 = SQL1 + " AND WS_DATE LIKE '%" + convertDate(txtDate) + "%' ";
            SQL1 = SQL1 + " ORDER BY WS_DATE DESC, NR DESC";

            DataTable dt1 = con.readdata(SQL1);
            foreach (DataRow dr in dt1.Rows)
                dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
            DGV1.DataSource = dt1;
            if (LV.Count > 0)
            {
                foreach (DataGridViewRow item in DGV1.Rows)
                {
                    foreach (var item1 in LV)
                    {
                        if (con.formatstr1(item.Cells["WS_DATE"].Value.ToString()) == con.formatstr1(item1.WS_DATE) && item.Cells["NR"].Value.ToString() 
                            == item1.NR && item.Cells["C_NO"].Value.ToString() == item1.C_NO && item.Cells["K_NO"].Value.ToString() == item1.K_NO)
                        {
                            item.SetValues(true);
                        }
                    }
                }
            }
        }
        private string convertDate(MaskedTextBox text)
        {
            string key = text.Text;
            key = key.Substring(2, 8);
            key = con.formatstr1(key);
            return key;
        }
        public class DT
        {
            public string WS_DATE { get; set; }
            public string NR { get; set; }
            public string C_NO { get; set; }
            public string K_NO { get; set; }

            //public static List<string> LV1 = new List<string>();
            //public static List<string> LV2 = new List<string>();
        }
        public static List<DT> LV = new List<DT>();
        private void btok_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void txtP_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtOR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtTHICK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtP_NAME_C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtP_NAME_E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtCOLOR_C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtCOLOR_E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void DGV1_CellMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToBoolean(DGV1.CurrentRow.Cells[0].Value) == true)
            {
                reomveToList(DGV1.CurrentRow.Index);
                DGV1.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                addToList(DGV1.CurrentRow.Index);
                DGV1.CurrentRow.Cells[0].Value = true;

            }
        }
        private void addToList(int cur)
        {
            LV.Add(new DT
            {
                WS_DATE = con.formatstr1(DGV1.Rows[cur].Cells["WS_DATE"].Value.ToString()),
                K_NO = DGV1.Rows[cur].Cells["K_NO"].Value.ToString(),
                C_NO = DGV1.Rows[cur].Cells["C_NO"].Value.ToString(),
                NR = DGV1.Rows[cur].Cells["NR"].Value.ToString(),
            });
        }
        private void reomveToList(int cur)
        {
            var itemToRemove = LV.Single(r => r.WS_DATE == con.formatstr1(DGV1.Rows[cur].Cells["WS_DATE"].Value.ToString()) && r.NR == DGV1.Rows[cur].Cells["NR"].Value.ToString() && 
            r.C_NO == DGV1.Rows[cur].Cells["C_NO"].Value.ToString() && r.K_NO == DGV1.Rows[cur].Cells["K_NO"].Value.ToString());
            LV.Remove(itemToRemove);
        }

        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV1.Rows.Count > 0)
            {
                int Cur = int.Parse(DGV1.CurrentCell.ColumnIndex.ToString());
                if (Cur == 0)
                {
                    if (Convert.ToBoolean(DGV1.CurrentRow.Cells[0].Value) == true)
                    {
                        reomveToList(DGV1.CurrentRow.Index);
                        DGV1.CurrentRow.Cells[0].Value = false;
                    }
                    else
                    {
                        addToList(DGV1.CurrentRow.Index);
                        DGV1.CurrentRow.Cells[0].Value = true;

                    }
                }
            }
        }
    }
}
