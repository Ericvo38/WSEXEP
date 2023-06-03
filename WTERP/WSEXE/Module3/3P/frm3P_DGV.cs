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
    public partial class frm3P_DGV : Form
    {
        DataProvider conn = new DataProvider();
        DataTable dt1 = new DataTable();
        public frm3P_DGV()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        public static List<DL3P_DGV> LV = new List<DL3P_DGV>();
        public void Load_Data()
        {
            string SQL2 = "SELECT TOP 500 OR_NO,'0' as ROWSNUMBER,NR,COLOR_E + ' ' + P_NAME_E AS DESCRIPTION,THICK FROM ORDB INNER JOIN dbo.tbl_Type_New ON tbl_Type_New.K_NO = ORDB.K_NO WHERE C_NO = '" + frm3P.DL3P.Keyc_no + "' ORDER BY WS_DATE DESC";
            dt1 = conn.readdata(SQL2);
            DGV1.DataSource = dt1;
            conn.DGV(DGV1);
        }
        private void bttk_Click(object sender, EventArgs e)
        {
            string SQL1 = "SELECT TOP 500 OR_NO,'0' as ROWSNUMBER,NR,COLOR_E + ' ' + P_NAME_E AS DESCRIPTION,THICK FROM ORDB INNER JOIN dbo.tbl_Type_New ON tbl_Type_New.K_NO = ORDB.K_NO WHERE C_NO = '" + frm3P.DL3P.Keyc_no + "' AND 1=1 ";
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
            dt1 = conn.readdata(SQL1);
            DGV1.DataSource = dt1;
            conn.DGV(DGV1);

            if (LV.Count > 0)
            {
                foreach (DataGridViewRow item in DGV1.Rows)
                {
                    foreach (var item1 in LV)
                    {
                        if (item.Cells["OR_NO"].Value.ToString() == item1.OR_NO && item.Cells["NR"].Value.ToString() == item1.NR)
                        {
                            item.SetValues(true);
                        }
                    }
                }
            }

        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            getList();
        }
        private void getList()
        {
            if (Convert.ToBoolean(DGV1.CurrentRow.Cells[0].Value) == true)
            {
                reomveToList(DGV1.CurrentRow.Index);
                DGV1.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                if (DGV1.CurrentRow.Cells["ROWSNUMBER"].Value.ToString() != "0" && !string.IsNullOrEmpty(DGV1.CurrentRow.Cells["ROWSNUMBER"].Value.ToString()))
                {
                    addToList(DGV1.CurrentRow.Index);
                    DGV1.CurrentRow.Cells[0].Value = true;
                }
                else

                {
                    MessageBox.Show("Vui lòng không để trống hoặc số 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void FrmSearchORDB_Load(object sender, EventArgs e)
        {
            LV.Clear();
            Load_Data();
        }
        public class DL3P_DGV
        {
            public string OR_NO { get; set; }
            public string NR { get; set; }
            public string Rows_Number { get; set; }
        }
        private void addToList(int cur)
        {
            LV.Add(new DL3P_DGV
            {
                OR_NO = DGV1.Rows[cur].Cells["OR_NO"].Value.ToString(),
                NR = DGV1.Rows[cur].Cells["NR"].Value.ToString(),
                Rows_Number = DGV1.Rows[cur].Cells["ROWSNUMBER"].Value.ToString(),
            });
        }
        private void reomveToList(int cur)
        {
            var itemToRemove = LV.Single(r => r.OR_NO == DGV1.Rows[cur].Cells["OR_NO"].Value.ToString() && r.NR == DGV1.Rows[cur].Cells["NR"].Value.ToString());
            LV.Remove(itemToRemove);
        }
        private void DGV1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV1.Rows.Count > 0)
            {
                if (e.ColumnIndex == 1)
                {
                    string key = DGV1.CurrentRow.Cells["ROWSNUMBER"].Value.ToString();
                    if (conn.IsNumber(key) == false)
                    {
                        MessageBox.Show("Dữ liệu nhập phải là số !");
                    }
                }
            }
        }

        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
