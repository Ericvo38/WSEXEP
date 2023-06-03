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
    public partial class FormSearchFns_Product2 : Form
    {
        DataProvider conn = new DataProvider();
        public FormSearchFns_Product2()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable datatable;

        public Form2AB f1 = new Form2AB();
        private void Formtimkiemkhothanhpham2_Load(object sender, EventArgs e)
        {
            LoadData();
            conn.DGV(dataGridViewkhothanhpham);
        }

        public void LoadData()
        {
            string sql = "select G_NO, G_NAME from dbo.GRADE";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            // truyen ad vao table
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewkhothanhpham.DataSource = bindingsource;
            conn.DGV(dataGridViewkhothanhpham);
        }
        public class ID
        {
            public static string ID_GNO;
        }
            private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT G_NO, G_NAME from dbo.GRADE WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND G_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND G_NAME LIKE N'%" + tb2.Text + "%'";
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            // truyen ad vao table
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewkhothanhpham.DataSource = bindingsource;
            conn.DGV(dataGridViewkhothanhpham);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            ID.ID_GNO = dataGridViewkhothanhpham.CurrentRow.Cells["G_NO"].Value.ToString();
            this.Hide();
            this.Close();
          
        }

        private void dataGridViewkhothanhpham_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID.ID_GNO = dataGridViewkhothanhpham.CurrentRow.Cells["G_NO"].Value.ToString();
            this.Hide();
            this.Close();
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }
    }
}
