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
    public partial class frm1IF7_FWS_NO : Form
    {
        DataProvider conn = new DataProvider();
        public frm1IF7_FWS_NO()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void frm1IF7_FWS_NO_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        public void Load_Data()
        {
            string SQL1 = "SELECT WS_NO, WS_DATE, C_NO, C_NAME, TOT, DISCOUNT, TOTAL, TAX from dbo.QUOH WHERE TOT!='' ORDER BY WS_DATE DESC";
            DataTable dt1 = conn.readdata(SQL1);
            DGV1.DataSource = dt1;
            conn.DGV(DGV1);
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void bttk1_Click(object sender, EventArgs e)
        {
            string SQL2 = "SELECT WS_NO, WS_DATE, C_NO, C_NAME, TOT, DISCOUNT, TOTAL, TAX from dbo.QUOH WHERE 1=1";
            if (tb1.Text != "")
                SQL2 = SQL2 + " AND WS_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                SQL2 = SQL2 + " AND WS_DATE LIKE N'%" + tb2.Text + "%'";
            if (tb3.Text != "")
                SQL2 = SQL2 + " AND C_NO LIKE N'%" + tb3.Text + "%'";
            if (tb4.Text != "")
                SQL2 = SQL2 + " AND C_NAME LIKE N'%" + tb4.Text + "%'";
            SQL2 = SQL2 + " AND TOT!='' ORDER BY WS_DATE DESC";
            DataTable dt2 = conn.readdata(SQL2);
            if (dt2 != null)
            {
                DGV1.DataSource = dt2;
            }
        }

        public static string Get_WS_NO;
        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Get_WS_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["WS_NO"].Value.ToString();
            this.Hide();
            this.Close();
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk1.PerformClick();
                tb2.Focus();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk1.PerformClick();
                tb3.Focus();
            }
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk1.PerformClick();
                tb4.Focus();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk1.PerformClick();
                tb1.Focus();
            }
        }
    }
}
