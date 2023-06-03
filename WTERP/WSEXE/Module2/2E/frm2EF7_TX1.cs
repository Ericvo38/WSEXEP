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
    public partial class frm2EF7_TX1 : Form
    {
        public frm2EF7_TX1()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        DataProvider con = new DataProvider();

        private void frm2EF7_TX1_Load(object sender, EventArgs e)
        {
            txtWS_NO.Text = frm2EF7.G_TAB1.txWS_NO1;
            Load_DGV();
        }
        string a = "";
        public void check()
        {
            if (con.Check_MaskedText(txtWS_DATE) == true)
            {
                a = con.formatstr2(txtWS_DATE.Text);
            }    
        }
        public void Load_DGV()
        {
            string SQL2 = "SELECT WS_NO, WS_DATE, C_NO, C_NAME, TOTAL, TAX, DISCOUNT,TOT,OR_NO,S_NO,INV_NO,DATESE FROM GIBH  where WS_NO = '"+txtWS_NO.Text+"' ORDER BY WS_NO ASC";
            DataTable dt2 = con.readdata(SQL2);
            foreach (DataRow dr in dt2.Rows)
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            DGV1.DataSource = dt2;
            DGV1.MyDGV();
        }
        void Search()
        {
            check();
            string SQL = "SELECT WS_NO, WS_DATE, C_NO, C_NAME, TOTAL, TAX, DISCOUNT,TOT,OR_NO,S_NO,INV_NO,DATESE FROM GIBH WHERE 1=1 ";
            if (txtWS_DATE.Text == string.Empty && txtC_NO.Text == string.Empty && txtC_NAME.Text == string.Empty && txtWS_DATE.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập từ khóa tìm kiếm !", "Thông Báo");
            }
            if (txtWS_NO.Text != string.Empty)
                SQL = SQL + " AND WS_NO LIKE '%" + txtWS_NO.Text + "%'";
            if (txtC_NO.Text != string.Empty)
                SQL = SQL + " AND C_NO LIKE '%" + txtC_NO.Text + "%'";
            if (txtC_NAME.Text != string.Empty)
                SQL = SQL + " AND C_NAME LIKE '%" + txtC_NAME.Text + "%'";
            if (a != string.Empty)
                SQL = SQL + " AND WS_DATE = '" + a + "'";
            SQL = SQL + " ORDER BY WS_NO DESC";
            DataTable dts = con.readdata(SQL);
            foreach (DataRow dr in dts.Rows)
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            if (dts.Rows.Count > 0)
                DGV1.DataSource = dts;
            else
                MessageBox.Show("Không Tìm thấy dữ liệu ", "Thông Báo");
        }
        public class DT
        {
            public static string txWS_NO;
            public static string txWS_NO_1;
            public static string txt1;
            public static string txt2;
        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DT.txWS_NO = DGV1.CurrentRow.Cells["WS_NO"].Value.ToString();
            DT.txWS_NO_1 = DGV1.CurrentRow.Cells["WS_NO"].Value.ToString();

            DT.txt1 = DGV1.CurrentRow.Cells["WS_NO"].Value.ToString();
            DT.txt2 = DGV1.CurrentRow.Cells["WS_NO"].Value.ToString();
            this.Hide();
            this.Close();
        }
        private void btok_Click(object sender, EventArgs e)
        {
            DT.txWS_NO = DGV1.CurrentRow.Cells["WS_NO"].Value.ToString();
            DT.txWS_NO_1 = DGV1.CurrentRow.Cells["WS_NO"].Value.ToString();

            DT.txt1 = DGV1.CurrentRow.Cells["WS_NO"].Value.ToString();
            DT.txt2 = DGV1.CurrentRow.Cells["WS_NO"].Value.ToString();
            this.Hide();
            this.Close();
        }
        private void tbdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();       
        }

        private void txtWS_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtC_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
    }
}
