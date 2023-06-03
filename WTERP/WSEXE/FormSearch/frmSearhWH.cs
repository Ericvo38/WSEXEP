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
    public partial class FormSearhWH : Form
    {
        DataProvider conn = new DataProvider();
        public FormSearhWH()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable datatable = new DataTable();

        private void FormSearhWH_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            string sql = "select M_NO, M_NAME from dbo.MEMO1";
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewkho.DataSource = bindingsource;
            conn.DGV(dataGridViewkho);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT M_NO, M_NAME from dbo.MEMO1 WHERE 1=1";
            if ((t1.Text == "") && (t2.Text == ""))
            {
                sql = sql + "";
            }
            if (t1.Text != "")
                sql = sql + " AND M_NO LIKE N'%" + t1.Text + "%'";
            if (t2.Text != "")
                sql = sql + " AND M_NAME LIKE N'%" + t2.Text + "%'";
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewkho.DataSource = bindingsource;
            conn.DGV(dataGridViewkho);
        }
        public class DL
        {
            public static string t1;
        }
        private void dataGridViewkho_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DL.t1 = dataGridViewkho.CurrentRow.Cells["M_NO"].Value.ToString();

            this.Hide();
            this.Close();
        }
        private void t1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
        private void t2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
