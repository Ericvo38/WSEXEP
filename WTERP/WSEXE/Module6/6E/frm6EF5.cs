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
    public partial class Form6EF5 : Form
    {
        DataProvider conn = new DataProvider();
        public Form6EF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cm;
        string st = CN.str;
        BindingSource bindingsource;
        DataTable dt = new DataTable();

        private void Form6EF5_Load(object sender, EventArgs e)
        {
            Load_data();
            conn.DGV(dataF6EF5);
        }
        public void Load_data()
        {
            con = new SqlConnection(st);
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = "select WS_KD, WS_KIND, T_NAME from TAXRAT";
            dt = new DataTable();
            dt.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            dataF6EF5.DataSource = bindingsource;
            DT.s1 = "";
            DT.s2 = "";
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void bttk_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sql;
            sql = "select WS_KD, WS_KIND, T_NAME from TAXRAT WHERE 1=1";
            if (tb1.Text != "")
                sql = sql + " AND WS_KD LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND WS_KIND LIKE N'%" + tb2.Text + "%'";

            con = new SqlConnection(st);
            con.Open();
            cm = con.CreateCommand();
            cm.CommandText = sql;
            dt.Load(cm.ExecuteReader());
            con.Close();
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            dataF6EF5.DataSource = bindingsource;
            conn.DGV(dataF6EF5);
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            bttk.PerformClick();
        }

        private void tb2_TextChanged(object sender, EventArgs e)
        {
            bttk.PerformClick();
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
                tb1.Focus();
            }
        }
        public class DT
        {
            public static string s1;
            public static string s2;
        }

        private void btok_Click(object sender, EventArgs e)
        {
            DT.s1 = dataF6EF5.Rows[dataF6EF5.CurrentRow.Index].Cells["WS_KD"].Value.ToString();
            DT.s2 = dataF6EF5.Rows[dataF6EF5.CurrentRow.Index].Cells["WS_KIND"].Value.ToString();
            this.Hide();
            this.Close();
        }

        private void dataF6EF5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DT.s1 = dataF6EF5.Rows[dataF6EF5.CurrentRow.Index].Cells["WS_KD"].Value.ToString();
            DT.s2 = dataF6EF5.Rows[dataF6EF5.CurrentRow.Index].Cells["WS_KIND"].Value.ToString();
            this.Hide();
            this.Close();
        }
    }
}
