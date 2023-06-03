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
    public partial class frmSearchBWARB : Form
    {
        DataProvider conn = new DataProvider();
        public frmSearchBWARB()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        public void Load_Data()
        {

            string SQL2 = "SELECT * FROM dbo.BWARB WHERE 2>1 ORDER BY WS_DATE DESC,WS_NO DESC";
            DataTable dt1 = con.readdata(SQL2);
            DGV1.DataSource = dt1;
            DGV1.MyDGV();
        }
        public class DTfrmSearchBWARB
        {
            public static string DL;
            public static string S_NO;
        }
        private void search()
        {
            string SQL1 = "SELECT * FROM dbo.BWARB WHERE 2>1 ";
            if (txtOR_NO.Text == string.Empty && txtC_NO.Text == string.Empty && txtCOLOR.Text == string.Empty && txtP_NO.Text == string.Empty)
            {
                SQL1 = SQL1 + "";
            }
            if (txtOR_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND WS_NO LIKE '%" + txtOR_NO.Text + "%' ";
            if (txtC_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND S_NO LIKE '%" + txtC_NO.Text + "%' ";
            if (txtCOLOR.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NO LIKE '%" + txtCOLOR.Text + "%' ";
            //if (txtP_NO.Text != string.Empty)
            //    SQL1 = SQL1 + " AND P_NO LIKE '%" + txtP_NO.Text + "%' ";
            if (maskedTextBox1.Text.Trim().Replace("/","") != "")
                SQL1 = SQL1 + " AND WS_DATE LIKE '%" + maskedTextBox1.Text.Trim().Replace("/", "") + "%' ";
            SQL1 = SQL1 + " ORDER BY WS_DATE DESC,WS_NO DESC";
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
            DTfrmSearchBWARB.DL = (string.IsNullOrEmpty(this.DGV1.CurrentRow.Cells["SOURCE"].Value.ToString()) ? "" : this.DGV1.CurrentRow.Cells["SOURCE"].Value.ToString() + " ") + this.DGV1.CurrentRow.Cells["QKG"].Value.ToString();
            DTfrmSearchBWARB.S_NO = this.DGV1.CurrentRow.Cells["S_NO"].Value.ToString();
            this.Hide();
            this.Close();
        }

        private void txtOR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                txtC_NO.Focus();
            }
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                   search();
                   txtCOLOR.Focus();
            }
        }

        private void txtCOLOR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                txtP_NO.Focus();
            }
        }

        private void txtP_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                txtOR_NO.Focus();
            }
        }
        private void FrmSearchORDB_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DTfrmSearchBWARB.DL = (string.IsNullOrEmpty(this.DGV1.CurrentRow.Cells["SOURCE"].Value.ToString()) ? "" : this.DGV1.CurrentRow.Cells["SOURCE"].Value.ToString() + " ") + this.DGV1.CurrentRow.Cells["QKG"].Value.ToString();
            DTfrmSearchBWARB.S_NO = this.DGV1.CurrentRow.Cells["S_NO"].Value.ToString();
            this.Hide();
            this.Close();
        }
    }
}
