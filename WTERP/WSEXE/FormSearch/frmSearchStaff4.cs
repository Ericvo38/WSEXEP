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
    public partial class FormSearchStaff4 : Form
    {
        DataProvider conn = new DataProvider();
        public FormSearchStaff4()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
   
        BindingSource bindingsource;
        DataTable datatable;

        private void Formtimkiemnhanvien4_Load(object sender, EventArgs e)
        {
            loadData();

            conn.DGV(dataGridViewnhanvien);
        }
        public void loadData()
        {

            string sql = "select S_NO, S_NAME from dbo.SALE";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            // truyen ad vao table
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewnhanvien.DataSource = bindingsource;
        }
        public class ID
        {
            public static string S_NAME2;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
           ID.S_NAME2 = dataGridViewnhanvien.CurrentRow.Cells["S_NAME"].Value.ToString();
            this.Hide();
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT S_NO, S_NAME from dbo.SALE WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == ""))
            {
                sql = sql + "";
            }
            sql = "SELECT S_NO, S_NAME from dbo.SALE WHERE 1=1";
            if (tb1.Text != "")
                sql = sql + " AND S_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND S_NAME LIKE N'%" + tb2.Text + "%'";

            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            // truyen ad vao table
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewnhanvien.DataSource = bindingsource;
        }

        private void dataGridViewnhanvien_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            ID.S_NAME2 = dataGridViewnhanvien.CurrentRow.Cells["S_NAME"].Value.ToString();
            this.Hide();
            this.Close();
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
        }
    }
}
