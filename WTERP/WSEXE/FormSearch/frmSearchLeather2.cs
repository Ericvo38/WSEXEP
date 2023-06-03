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
    public partial class FormSearchLeather2 : Form
    {
        DataProvider conn = new DataProvider();
        public FormSearchLeather2()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable datatable;



        private void Formtimkiemtamda2_Load(object sender, EventArgs e)
        {
            LoadData();
            conn.DGV(dataGridViewsanphamtamda);
        }

        public void LoadData()
        {
            string SQL = "SELECT M_NO, M_NAME FROM MEMO WHERE 1=1 ";
            if (!string.IsNullOrEmpty(tb1.Text)) SQL = SQL + " AND M_NO LIKE '%"+tb1.Text+"%' "; 
            if (!string.IsNullOrEmpty(tb2.Text)) SQL = SQL + " AND M_NAME LIKE '%" + tb2.Text+"%' ";
            datatable = conn.readdata(SQL);
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewsanphamtamda.DataSource = bindingsource;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ID.M_NO = string.Empty;
            ID.M_NAME = string.Empty;
            this.Close();
        }

        public class ID
        {
            public static string M_NAME;
            public static string M_NO;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }
        private void getData()
        {

            ID.M_NAME = dataGridViewsanphamtamda.CurrentRow.Cells["M_NAME"].Value.ToString();
            ID.M_NO = dataGridViewsanphamtamda.CurrentRow.Cells["M_NO"].Value.ToString();
            this.Close();
        }
        private void dataGridViewsanphamtamda_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            getData();
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
