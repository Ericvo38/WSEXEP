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

namespace WTERP
{
    public partial class frm3IF2 : Form
    {
        DataProvider conn = new DataProvider();
        
        public frm3IF2()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private void frm3IF2_Load(object sender, EventArgs e)
        {
            frm3I.Share_P_NO = string.Empty;
            LoadDt();
        }
        public void LoadDt()
        {
            string strSql = "SELECT P_NO, P_NAME, P_NAME1, PRICE, P_NAME2, P_NAME3, C_NO, M_TRAN FROM PROD1C WHERE W_CHECK = 'Y' ORDER BY P_NO ,QDATE DESC";
            DataTable dataTable = new DataTable();
            dataTable = conn.readdata(strSql);
            DGV1.DataSource = dataTable;
            DGV1.DataGridViewFormat();
            //conn.DGV(DGV1);
        }
        public void Search()
        {
            //string sql = "SELECT P_NO, P_NAME, P_NAME1, PRICE, P_NAME2, P_NAME3, C_NO, M_TRAN FROM PROD1C WHERE 1=1";
            string sql = "SELECT P_NO, P_NAME, P_NAME1, PRICE, P_NAME2, P_NAME3, C_NO, M_TRAN FROM J2BKPVC.dbo.PROD1C WHERE 1=1";

            if ((tb1.Text == "") && (tb2.Text == "") && (tb3.Text == "") && (tb4.Text == "") && (tb5.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND P_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND P_NAME LIKE N'%" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND P_NAME3 LIKE N'%" + tb3.Text + "%'";
            if (tb4.Text != "")
                sql = sql + " AND P_NAME1 LIKE N'%" + tb4.Text + "%'";
            if (tb5.Text != "")
                sql = sql + " AND C_NO LIKE N'%" + tb5.Text + "%'";
            sql = sql + " AND QTYSTORE >0 AND W_CHECK = 'Y' ORDER BY P_NO ,QDATE DESC";

            DataTable dataTable = new DataTable();
            dataTable = conn.readdata(sql);
            DGV1.DataSource = dataTable;
            DGV1.DataGridViewFormat();
            //conn.DGV(DGV1);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void DGV1_MouseClick(object sender, MouseEventArgs e)
        {
            frm3I.Share_P_NO = DGV1.CurrentRow.Cells["P_NO"].Value.ToString();
        }

        private void DGV1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm3I.Share_P_NO = DGV1.CurrentRow.Cells["P_NO"].Value.ToString();
            this.Close();
        }

        private void tb4_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tb2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
