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
    public partial class FormSearchEfficiency : Form
    {
        DataProvider conn = new DataProvider();
        public FormSearchEfficiency()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable datatable;


        private void Formtimkiemhieusuat2_Load(object sender, EventArgs e)
        {
            LoadData();

            conn.DGV(dataGridViewhieusuat);
        }

        public void LoadData()
        {
            string sql = "select M_NO, M_NAME from dbo.achie";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            // truyen ad vao table
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewhieusuat.DataSource = bindingsource;
        }

        public class ID
        {
            public static string M_NAME;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "SELECT M_NO, M_NAME from dbo.SALE WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND M_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND M_NAME LIKE N'%" + tb2.Text + "%'";
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            // truyen ad vao table
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewhieusuat.DataSource = bindingsource;
        } 
        private void button1_Click(object sender, EventArgs e)
        {
            ID.M_NAME = dataGridViewhieusuat.CurrentRow.Cells["M_NAME"].Value.ToString();
          
            this.Close();
        }

        private void dataGridViewhieusuat_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID.M_NAME = dataGridViewhieusuat.CurrentRow.Cells["M_NAME"].Value.ToString();
           
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
