using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WTERP
{
    public partial class Form1RF5 : Form
    {
        DataProvider data = new DataProvider();
        public Form1RF5()
        {
            this.ShowInTaskbar = false;
            data.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable datatable = new DataTable();
        private void Form1RF5_Load(object sender, EventArgs e)
        {
            LoadData();

            data.DGV(dataGridViewFormR);
        }

        public void LoadData()
        {

            string sql = "select PT_NO, PATT_NO, PATT_C, PATT_E, PT_BRAND, MEMO,USR_NAME from dbo.PATT";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable = data.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewFormR.DataSource = bindingsource;
        }

        private void bttk_Click(object sender, EventArgs e)
        {
            Search();
        }
        public class DL
        {
            public static string t1;
            public static string t2;
            public static string t3;
            public static string t4;
            public static string t5;
            public static string t6;
            public static string t7;
        }
        public void Search()
        {
            DataTable dt = new DataTable();
            string sql;
            sql = "SELECT PT_NO, PATT_NO, PATT_C, PATT_E, PT_BRAND, MEMO from dbo.PATT,USR_NAME WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == "") && (tb3.Text == "") && (tb4.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND PT_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND PATT_NO LIKE N'%" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND PATT_C LIKE N'%" + tb3.Text + "%'";
            if (tb4.Text != "")
                sql = sql + " AND PATT_E LIKE N'%" + tb4.Text + "%'";

            dt = data.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            dataGridViewFormR.DataSource = bindingsource;
        }
        public void getData()
        {
            DL.t1 = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells["PT_NO"].Value.ToString();
            DL.t2 = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells["PATT_NO"].Value.ToString();
            DL.t3 = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells["PATT_C"].Value.ToString();
            DL.t4 = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells["PATT_E"].Value.ToString();
            DL.t5 = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells["PT_BRAND"].Value.ToString();

            DL.t6 = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells["MEMO"].Value.ToString();

            DL.t7 = dataGridViewFormR.Rows[dataGridViewFormR.CurrentRow.Index].Cells["USR_NAME"].Value.ToString();
            this.Hide();
            this.Close();
        }
        private void tbok_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void dataGridViewFormR_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            getData();
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
        private void btdong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
