using LibraryCalender;
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
    public partial class frm2FF5 : Form
    {
        DataProvider con = new DataProvider();
        BindingSource source = new BindingSource();
        public frm2FF5()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        public class getWS_NO
        {
            public static BindingSource bind;
            public static int index;
        }
        private void frm2FF5_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            Search();
        }
        private void LoadDGV2(string key)
        {
            string SQL2 = "SELECT NR, P_NO, P_NAME, BQTY, UNIT, PRICE, AMOUNT, COST, MEMO  FROM CATB WHERE WS_NO = '" + key + "' ORDER BY WS_DATE DESC";
            DataTable dt2 = con.readdata(SQL2);
            if (dt2 != null)
            {
                BindingSource source = new BindingSource();
                source.DataSource = dt2;
                DGV2.DataSource = source;
                con.DGV(DGV2);
            }
        }
        private void Search()
        {
            string SQL = "SELECT WS_DATE,WS_NO,C_NO,C_NAME,CAL_YM,M_TRAN,USR_NAME,RCVTOT,TOT FROM CATH WHERE 1=1";
            if (con.Check_MaskedText(t4) == true)
            {
                SQL = SQL + " AND WS_DATE = '" + con.formatstr2(t4.Text) + "' ";
            }    
            else if (t1.Text != "")
                SQL = SQL + " AND WS_NO LIKE '%" + t1.Text + "%' ";
            else if (t2.Text != "")
                SQL = SQL + " AND C_NO LIKE '%" + t2.Text + "%' ";
            else if (t3.Text != "")
                SQL = SQL + " AND C_NAME LIKE '%" + t3.Text + "%' ";
            else if (t4.Text != "")
                
            SQL = SQL + " order by WS_DATE DESC";
            DataTable dt = con.readdata(SQL);
            if (dt != null)
            {
                source.DataSource = dt;
                DGV1.DataSource = source;  
                con.DGV(DGV1);
            }
            if (DGV1.Rows.Count > 0)
            {
                LoadDGV2(DGV1.Rows[0].Cells["WS_NO"].Value.ToString());
            }    
           else
            {
                LoadDGV2("");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            getWS_NO.index = 0;
            this.Close();
        }
        private void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getWS_NO.bind = source;
            getWS_NO.index = source.Position;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getWS_NO.bind = source;
            getWS_NO.index = source.Position;
            this.Close();
        }

        private void t4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            t4.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void t1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }    
        }

        private void t2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void t3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void t4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadDGV2(DGV1.CurrentRow.Cells["WS_NO"].Value.ToString());
        }
    }
}
