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
    public partial class Form1KF5 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1KF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        string st = CN.str;
        DataTable datatable = new DataTable();

        public Form1K f1 = new Form1K();
        private void Form1KF5_tiemkiemthuonghieu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            string sql = "select B_NO, BRAND, TRADE,USR_NAME from BRAND";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            dataGridView1KF5.DataSource = datatable;
            conn.DGV(dataGridView1KF5);
        }


        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1K fr = new Form1K();
            this.Hide();
            fr.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Search();
        }

        public class DL
        {
            public static string t1;
            public static string t2;
            public static string t3;
            public static string t4;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getDataa();
        }

        private void dataGridView1KF5_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            getDataa();
        }
        private void getDataa()
        {
            DL.t1 = dataGridView1KF5.Rows[dataGridView1KF5.CurrentRow.Index].Cells["B_NO"].Value.ToString();
            DL.t2 = dataGridView1KF5.Rows[dataGridView1KF5.CurrentRow.Index].Cells["BRAND"].Value.ToString();
            DL.t3 = dataGridView1KF5.Rows[dataGridView1KF5.CurrentRow.Index].Cells["TRADE"].Value.ToString();
            DL.t4 = dataGridView1KF5.Rows[dataGridView1KF5.CurrentRow.Index].Cells["USR_NAME"].Value.ToString();

            this.Hide();
            this.Close();
        }
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button3.PerformClick();
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button3.PerformClick();
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button3.PerformClick();
        }
        public void Search()
        {
            DataTable dt = new DataTable();

            string sql;
            sql = "SELECT B_NO, BRAND, TRADE,USR_NAME from BRAND WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == "") && (tb3.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND B_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND BRAND LIKE N'%" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND TRADE LIKE N'%" + tb3.Text + "%'";

            dt = conn.readdata(sql);
            dataGridView1KF5.DataSource = dt;
            conn.DGV(dataGridView1KF5);
        }
    }
}
