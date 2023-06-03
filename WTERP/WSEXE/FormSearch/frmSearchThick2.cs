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
    public partial class FormSearchThick2 : Form
    {
        DataProvider con = new DataProvider();
        public FormSearchThick2()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void Formtimkiemdoday2_Load(object sender, EventArgs e)
        {
            LoadData();
            con.DGV(dataGridViewDoday);
        }
        public void LoadData()
        {
            string SQL = "select T_NO, T_NAME from dbo.THICK";
            DataTable dt = con.readdata(SQL);
            if (dt != null)
                con.FormatDGV(dataGridViewDoday, dt);
        }
        public class ID
        {
            public static string ID_THICK;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            string sql = "SELECT T_NO, T_NAME from dbo.THICK WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND T_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND T_NAME LIKE N'%" + tb2.Text + "%'";
            DataTable dt = con.readdata(sql);
            con.FormatDGV(dataGridViewDoday, dt);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            ID.ID_THICK = dataGridViewDoday.CurrentRow.Cells["T_NAME"].Value.ToString();
            this.Close();

        }
        private void dataGridViewDoday_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            ID.ID_THICK = dataGridViewDoday.CurrentRow.Cells["T_NAME"].Value.ToString();
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
