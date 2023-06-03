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
    public partial class FormSearchMaterial2 : Form
    {
        DataProvider con = new DataProvider();
        public FormSearchMaterial2()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        private void Formtiemkiemmalieu2_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            string SQL = "select P_NO, P_NAME, UNIT, QTYSTORE, P_NAME1 from dbo.PROD";
            DataTable dt = con.readdata(SQL);
            dataGridViewlieu.DataSource = dt;
            con.DGV(dataGridViewlieu);
        }
        public class ID
        {
            public static string ID_P_NO = "";
            public static string P_NAME = "";
            public static string P_NAME1 = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Serch();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }
        private void getData()
        {
            ID.ID_P_NO = dataGridViewlieu.CurrentRow.Cells["P_NO"].Value.ToString();
            ID.P_NAME = dataGridViewlieu.CurrentRow.Cells["P_NAME"].Value.ToString();
            ID.P_NAME1 = dataGridViewlieu.CurrentRow.Cells["P_NAME1"].Value.ToString();
            this.Close();
        }
        private void dataGridViewlieu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            getData();
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
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

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }
        private void Serch()
        {
            string sql = "SELECT P_NO, P_NAME, UNIT, QTYSTORE, P_NAME1 from dbo.PROD WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == "") && (tb3.Text == "") && (tb4.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND P_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND P_NAME LIKE N'%" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND UNIT LIKE N'%" + tb3.Text + "%'";
            if (tb4.Text != "")
                sql = sql + " AND P_NAME1 LIKE N'%" + tb4.Text + "%'";
            DataTable dt = con.readdata(sql);
            dataGridViewlieu.DataSource = dt;
            con.DGV(dataGridViewlieu);
        }
    }
}
