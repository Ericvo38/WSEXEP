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
    public partial class FormSearchBrand : Form
    {
        DataProvider conn = new DataProvider();
        public FormSearchBrand()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }

        BindingSource bindingsource;
        DataTable datatable;

        public Form2AB f1 = new Form2AB();

        private void Formtimkiemnhanhieu_Load(object sender, EventArgs e)
        {
            Loaddata();
            dataGridViewthuonghieu.MyDGV();
        }
        public void Loaddata()
        {
            string sql = "select * from BRAND";
            datatable = new DataTable();
            datatable = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewthuonghieu.DataSource = bindingsource;
            conn.DGV(dataGridViewthuonghieu);
        }
        public class ID
        {
            public static string B_NO;
            public static string BRAND;
            public static string TRADE;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * from dbo.BRAND WHERE 1=1";
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
            datatable = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewthuonghieu.DataSource = bindingsource;
            conn.DGV(dataGridViewthuonghieu);
        }

        private void dataGridViewthuonghieu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            getData();
        }
        private void getData()
        {
            ID.B_NO = dataGridViewthuonghieu.CurrentRow.Cells["B_NO"].Value.ToString();
            ID.BRAND = dataGridViewthuonghieu.CurrentRow.Cells["BRAND"].Value.ToString();
            ID.TRADE = dataGridViewthuonghieu.CurrentRow.Cells["TRADE"].Value.ToString();

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

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }
    }
}
