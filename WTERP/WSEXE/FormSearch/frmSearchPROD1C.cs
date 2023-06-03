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
    public partial class FormSearchPROD1C : Form
    {
        DataProvider conn = new DataProvider();
        public FormSearchPROD1C()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable dt = new DataTable();
        private void FormSearchPROD1C_Load(object sender, EventArgs e)
        {
            Load_data();
            conn.DGV(dataPROD1C);
        }
        public void Load_data()
        {
            string sql = "select P_NO, P_NAME1, P_NAME, P_NAME3 FROM PROD1C";
            dt = new DataTable();
            dt = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            dataPROD1C.DataSource = bindingsource;
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void bttk_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "select P_NO, P_NAME1, P_NAME, P_NAME3 from PROD1C WHERE 1=1";
            if (tb1.Text == "" && tb2.Text == "" && tb3.Text == "" && tb4.Text == "")
            if (tb1.Text != "")
                sql = sql + " AND P_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND P_NAME1 LIKE N'%" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND P_NAME LIKE N'%" + tb3.Text + "%'";
            if (tb4.Text != "")
                sql = sql + " AND P_NAME3 LIKE N'%" + tb4.Text + "%'";
            dt = new DataTable();
            dt = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            dataPROD1C.DataSource = bindingsource;
            conn.DGV(dataPROD1C);
        }
        public class ID
        {
            public static string P_NO;
        }
        private void dataPROD1C_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            getData();
        }
        private void btok_Click(object sender, EventArgs e)
        {
            getData();
        }
        private void getData()
        {
            ID.P_NO = dataPROD1C.Rows[dataPROD1C.CurrentRow.Index].Cells["P_NO"].Value.ToString();
      
            this.Hide();
            this.Close();
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
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
