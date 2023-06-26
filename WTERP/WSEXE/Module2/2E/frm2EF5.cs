using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibraryCalender;

namespace WTERP
{
    public partial class frm2EF5 : Form
    {
        DataProvider conn = new DataProvider();
        public static string Share_WS_NO = string.Empty;
        public frm2EF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private void frm2EF5_Load(object sender, EventArgs e)
        {
            Load_DGV1();
        }
        public void Load_DGV1()
        {
           string sql = "SELECT WS_NO, dbo.FormatString2(WS_DATE) AS WS_DATE, C_NO, C_NAME, TOTAL, TAX, DISCOUNT, TOT, RCV_MON, NRCV_MON FROM GIBH ORDER BY WS_DATE DESC, WS_NO DESC";
            DataTable dt = conn.readdata(sql);
            DGV1.DataSource = dt;
            DGV1.DataGridViewFormat();
            Load2(DGV1.Rows[0].Cells["WS_NO"].Value.ToString());
        }
        private void Load2(string s)
        {
            try
            {
                string SQL = "SELECT NR, P_NO, P_NAME, BQTY, UNIT, PRICE, AMOUNT, COST, MEMO FROM GIBB WHERE 1=1 ";
                if (!string.IsNullOrEmpty(s)) SQL = SQL + " AND WS_NO = '" + s + "' ";
                DataTable dt = conn.readdata(SQL);
                DGV2.DataSource = dt;
                DGV2.DataGridViewFormat();
                DGV2.Columns["PRICE"].DefaultCellStyle.Format = "#,##0.00";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Share_WS_NO = string.Empty;
            this.Close();
        }
        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Load2(DGV1.Rows[DGV1.CurrentRow.Index].Cells["WS_NO"].Value.ToString());
            Share_WS_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["WS_NO"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT WS_NO, dbo.FormatString2(WS_DATE) AS WS_DATE, C_NO, C_NAME, TOTAL, TAX, DISCOUNT, TOT, RCV_MON, NRCV_MON FROM GIBH WHERE 1=1";
            if (!string.IsNullOrEmpty(tb1.Text)) sql = sql + " AND WS_NO LIKE N'%" + tb1.Text + "%'";
            if (!string.IsNullOrEmpty(tb2.Text)) sql = sql + " AND C_NAME LIKE N'%" + tb2.Text + "%'";
            if (!string.IsNullOrEmpty(tb3.Text)) sql = sql + " AND C_NO LIKE N'%" + tb3.Text + "%'";
            if (tb4.MaskCompleted) sql = sql + " AND WS_DATE = '"+ tb4.Text.Replace("/","") +"'";
            sql = sql + " ORDER BY WS_DATE DESC, WS_NO DESC";

            DataTable dt = conn.readdata(sql);
            DGV1.DataSource = dt;
            DGV1.DataGridViewFormat();
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                tb2.Focus();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                tb3.Focus();
            }
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                tb4.Focus();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                tb1.Focus();
            }
        }
        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Load2(DGV1.Rows[DGV1.CurrentRow.Index].Cells["WS_NO"].Value.ToString());
            Share_WS_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["WS_NO"].Value.ToString();
            this.Close();
        }

        private void tb4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            if(FromCalender.Flags) tb4.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }
    }
}
