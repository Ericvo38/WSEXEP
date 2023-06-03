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
    public partial class frmSearchPatt : Form
    {
        DataProvider conn = new DataProvider();
        public frmSearchPatt()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private void Formtimkiempattmau2_Load(object sender, EventArgs e)
        {
            LoadData();
            conn.DGV(dataGridViewPatt);
        }

        public void LoadData()
        {

            string sql = "select PT_NO, PATT_NO, PATT_C, PATT_E, MEMO from dbo.PATT";
            DataTable dt = new DataTable();
            dt = conn.readdata(sql);
            dataGridViewPatt.DataSource = dt;
            conn.DGV(dataGridViewPatt);
        }
        public class ID
        {
            public static string PATT;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sear();
        }

        private void Sear()
        {
            string sql = "SELECT PT_NO, PATT_NO, PATT_C, PATT_E, MEMO from dbo.PATT WHERE 1=1";
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
            DataTable dt = new DataTable();
            dt = conn.readdata(sql);
            dataGridViewPatt.DataSource = dt;
            conn.DGV(dataGridViewPatt);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ID.PATT = dataGridViewPatt.CurrentRow.Cells["PATT_NO"].Value.ToString();
            this.Close();

        }

        private void dataGridViewPatt_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            ID.PATT = dataGridViewPatt.CurrentRow.Cells["PATT_NO"].Value.ToString();
            this.Close();
        }
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Sear();
            }    
           
        }
        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Sear();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Sear();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Sear();
            }
        }
    }
}
