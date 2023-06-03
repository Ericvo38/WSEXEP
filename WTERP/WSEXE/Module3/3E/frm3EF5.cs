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
using LibraryCalender;

namespace WTERP
{
    public partial class Form3EF5 : Form
    {
        DataProvider conn = new DataProvider();
        DataTable table = new DataTable();
        BindingSource source = new BindingSource();
        string where = "";
        public Form3EF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        
        private void Form3F5_Load(object sender, EventArgs e)
        {
            string SQL = "SELECT TOP 1000 WS_DATE, WS_NO, OR_NO, C_OR_NO, C_NO, C_NAME, B_NO, P_NAME, MEMO01, BQTY, MEMO02, FOB_DATE, MEMO07, MEMO03, MEMO05, MEMO04, MEMO06, ORD_WEG, OVER0, USR_NAME, MEMO08, PG_NO, P_N, P_C,FOB_DATEC FROM PRDMK2 WHERE 1=1 " + Form3E.GUI.getSQL+ " ORDER BY WS_NO DESC";
            table = conn.readdata(SQL);
            getData_DATE(table);
            source.DataSource = table;
            dataForm3EF5.DataSource = source;
            Visible_Column_DGV(dataForm3EF5);
            conn.DGV(dataForm3EF5);
        }
        private void getData_DATE(DataTable data)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                table.Rows[i]["WS_DATE"] = conn.formatstr2(table.Rows[i]["WS_DATE"].ToString()); 
            }
        }
        private void Visible_Column_DGV(DataGridView dataGrid)
        {
            dataGrid.Columns["OR_NO"].Visible = false;
            dataGrid.Columns["C_OR_NO"].Visible = false;
            dataGrid.Columns["C_NO"].Visible = false;
            dataGrid.Columns["B_NO"].Visible = false;
            dataGrid.Columns["MEMO01"].Visible = false;
            dataGrid.Columns["BQTY"].Visible = false;
            dataGrid.Columns["MEMO02"].Visible = false;
            dataGrid.Columns["MEMO07"].Visible = false;
            dataGrid.Columns["MEMO03"].Visible = false;
            dataGrid.Columns["MEMO05"].Visible = false;
            dataGrid.Columns["MEMO04"].Visible = false;
            dataGrid.Columns["MEMO06"].Visible = false;
            dataGrid.Columns["ORD_WEG"].Visible = false;
            dataGrid.Columns["OVER0"].Visible = false;
            dataGrid.Columns["USR_NAME"].Visible = false;
            dataGrid.Columns["MEMO08"].Visible = false;
            dataGrid.Columns["PG_NO"].Visible = false;
            dataGrid.Columns["P_N"].Visible = false;
            dataGrid.Columns["P_C"].Visible = false;
            dataGrid.Columns["FOB_DATEC"].Visible = false;
            dataGrid.Columns["FOB_DATE"].Visible = false;
        }
        public class getInfo
        {
            public static string WS_NO;
            public static string C_NO;
            public static string SQL;
            public static int index;
        }
        void Search()
        {
            try
            {
                string SQL1 = "SELECT TOP 1000 WS_DATE, WS_NO, OR_NO, C_OR_NO, C_NO, C_NAME, B_NO, P_NAME, MEMO01, BQTY, MEMO02, FOB_DATE, MEMO07, MEMO03, MEMO05, MEMO04, MEMO06, ORD_WEG, OVER0, USR_NAME, MEMO08, PG_NO, P_N, P_C,FOB_DATEC from PRDMK2 WHERE 1=1";
                if ((tb1.Text == "") && (tb2.Text == "") && (tb3.Text == "") && (tb4.Text == "") && (tb5.Text == ""))
                {
                   where = "";
                   SQL1 = SQL1 + "";
                }
                if (tb1.Text != "")
                {
                    where = where + " AND WS_NO LIKE N'%" + tb1.Text + "%'"; 
                    SQL1 = SQL1 + " AND WS_NO LIKE N'%" + tb1.Text + "%'";
                }
                if (tb2.Text != "")
                {
                    where = where + " AND C_NO LIKE N'%" + tb2.Text + "%'";
                    SQL1 = SQL1 + " AND C_NO LIKE N'%" + tb2.Text + "%'";
                }
               
                if (tb3.Text != "")
                {
                    where = where + " AND C_NAME LIKE N'%" + tb3.Text + "%'";
                    SQL1 = SQL1 + " AND C_NAME LIKE N'%" + tb3.Text + "%'";
                }
                
                if (tb4.Text.Replace("/","").Trim().ToString() != "")
                {
                    where = where + " AND WS_DATE = N'%" + tb4.Text.Replace("/", "").Trim().ToString() + "%'";
                    SQL1 = SQL1 + " AND WS_DATE = N'%" + tb4.Text.Replace("/", "").Trim().ToString() + "%'";
                }
                
                if (tb5.Text != "")
                {
                    where = where + " AND OR_NO LIKE N'%" + tb5.Text + "%'";
                    SQL1 = SQL1 + " AND OR_NO LIKE N'%" + tb5.Text + "%'";
                }
                SQL1 = SQL1 + " ORDER BY WS_NO DESC";

                table = conn.readdata(SQL1);
                if (table != null)
                {
                    getData_DATE(table);
                    source.DataSource = table;
                    dataForm3EF5.DataSource = table;
                    Visible_Column_DGV(dataForm3EF5);
                    conn.DGV(dataForm3EF5);
                }    
                    
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }     
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void getData()
        {
            getInfo.WS_NO = dataForm3EF5.CurrentRow.Cells["WS_NO"].Value.ToString();
            getInfo.C_NO = dataForm3EF5.CurrentRow.Cells["C_NO"].Value.ToString();
            //3E
            getInfo.SQL = where;
            getInfo.index = dataForm3EF5.CurrentRow.Index;

            this.Close();
        }
        private void dataForm3EF5_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            getData();
        }
        private void btok_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                conn.tab(tb1, tb2, sender, e);
            }
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                conn.tab_DOWN(tb2, tb4, sender, e);
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                conn.tab(tb1, tb3, sender, e);
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                conn.tab(tb3, tb5, sender, e);
            }
        }
        private void tb4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            tb4.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
                conn.tab_UP(tb4, tb1, sender, e);
            }
        }
    }
}
