using LibraryCalender;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2PF5 : Form
    {
        DataProvider con = new DataProvider();
        //public static string ID_CUST;
        public frm2PF5()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
            Search();
        }
        public class getIDPhieuthu
        {
            public static string ID;
        }
        private void Search()
        {
            string soVB = txtsoVB.Text.Trim();
            string maKH = txtmaKH.Text.Trim();
            string date1 = date.Text.Trim();
            string sql = "SELECT WS_NO, WS_DATE,C_NO,C_ANAME FROM RRCVH WHERE 1=1";
            if (!string.IsNullOrEmpty(soVB))
            {
                sql = sql + "WS_NO like '%"+soVB+"%'";
            }
            if (!string.IsNullOrEmpty(maKH))
            {
                sql = sql + "WS_NO like '%" + soVB + "%'";
            }
            if (!string.IsNullOrEmpty(date1))
            {
                sql = sql + "WS_DATE like '%" + date1 + "%'";
            }
            DataTable dt = con.readdata(sql);
            foreach(DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            }
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt;
            DGV2.DataSource = bindingSource;
            con.DGV(DGV2);
        }
        private void button5_Click(object sender, EventArgs e)
        {
                this.Close();

        }
        public class SEND_FORM4F
        {
            public static string T1;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getIDPhieuthu.ID = DGV2.CurrentRow.Cells[0].Value.ToString();
            SEND_FORM4F.T1 = DGV2.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void btnQRy_Click(object sender, EventArgs e)
        {
            getIDPhieuthu.ID = DGV2.CurrentRow.Cells[0].Value.ToString();
            SEND_FORM4F.T1 = DGV2.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void frm2PF5_Load(object sender, EventArgs e)
        {
            string sql = "SELECT WS_NO, WS_DATE,C_NO,C_ANAME FROM RRCVH";
            DataTable dt = con.readdata(sql);
            foreach (DataRow dr in dt.Rows)
            {
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            }
            DGV2.DataSource = dt;
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dt;
            DGV2.DataSource = bindingSource;
            con.DGV(DGV2);
        }

        private void date_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            date.Text = FromCalender.getDate.ToString("yyyyMddM");
        }

        private void txtsoVB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void txtmaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }
    }
}
