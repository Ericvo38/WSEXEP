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
    public partial class FormSeachUSRH : Form
    {
        DataProvider conn = new DataProvider();
        public FormSeachUSRH()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable dt = new DataTable();

        private void FormSeachUSRH_Load(object sender, EventArgs e)
        {
            Load_data();
            conn.DGV(dataUSRH);
        }
        public void Load_data()
        {
            string sql = "select WSNO, WSDATE, USER_ID, NAME from USRH";
            dt = new DataTable();
            dt = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            dataUSRH.DataSource = bindingsource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void bttk_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sql;
            sql = "select WSNO, WSDATE, USER_ID, NAME from USRH WHERE 1=1";
            if (tb1.Text == "" && tb1.Text == "" && tb2.Text == "" && tb3.Text == "" && tb4.Text == "")
            {
                sql = sql + "";
            }    
            if (tb1.Text != "")
                sql = sql + " AND WSNO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND USER_ID LIKE N'%" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND NAME LIKE N'%" + tb3.Text + "%'";
            if (tb4.Text != "")
                sql = sql + " AND WSDATE LIKE N'%" + tb4.Text + "%'";
            dt = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            dataUSRH.DataSource = bindingsource;
            conn.DGV(dataUSRH);
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb2.Focus();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb3.Focus();
            }
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb4.Focus();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                tb1.Focus();
            }
        }
        public class DL
        {
            public static string USER_NAME;
        }

        private void dataUSRH_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DL.USER_NAME = dataUSRH.Rows[dataUSRH.CurrentRow.Index].Cells["NAME"].Value.ToString();
            this.Hide();
            this.Close();
        }
    }
    
}
