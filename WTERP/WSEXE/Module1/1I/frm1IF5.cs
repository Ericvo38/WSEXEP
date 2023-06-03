using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibraryCalender;

namespace WTERP
{
    public partial class Form1IF5 : Form
    {
        DataProvider conn = new DataProvider();
        public Form1IF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdataEventHandler;
        public class UpdateEventArgs : EventArgs
        {
            public string data { get; set; }
        }
        protected void insert()
        {
            getBaoGia.index = int.Parse(DGV2.CurrentCell.ColumnIndex.ToString());
            UpdateEventArgs args = new UpdateEventArgs();
            UpdataEventHandler.Invoke(this, args);
        }
        private void Form1IF5_Load(object sender, EventArgs e)
        {
            LoadData();
            conn.DGV(DGV2);
        }
        public class getBaoGia 
        {
            public static string WS_NO;
            public static int index;
        }
        public void LoadData() // Method Load Datagridview 
        {
            string SQL1 = "SELECT TOT,DISCOUNT,C_NO,TOTAL,TAX,WS_NO,C_NAME, dbo.FormatString2(WS_DATE) AS WS_DATE from dbo.QUOH Where 1=1 " + Form1I.Where + " ORDER BY WS_DATE DESC";
            DataTable dt1 = conn.readdata(SQL1);
            if (dt1.Rows.Count > 0)
            {
                DGV2.DataSource = dt1;
            }
        }

        private void SearchingData() //Method Searching Data 
        {
            Form1I.Where = "";
            string SQL2 = "SELECT TOT,DISCOUNT,C_NO,TOTAL,TAX,WS_NO,C_NAME,WS_DATE from dbo.QUOH WHERE 1=1";
            if (!string.IsNullOrEmpty(tb1.Text))
            {
                SQL2 = SQL2 + " AND WS_NO LIKE N'" + tb1.Text + "%'";
                Form1I.Where = Form1I.Where + " AND WS_NO LIKE N'" + tb1.Text + "%'";
            }
            if (!string.IsNullOrEmpty(tb2.Text))
            {
                SQL2 = SQL2 + " AND C_NO LIKE N'%" + tb2.Text + "%'";
                Form1I.Where = Form1I.Where + " AND C_NO LIKE N'" + tb2.Text + "%'";
            }
            if (!string.IsNullOrEmpty(tb3.Text) && tb3.MaskFull == true) 
            { 
                SQL2 = SQL2 + " AND WS_DATE LIKE N'%" + conn.formatstr2(tb3.Text) + "%'";
                Form1I.Where = Form1I.Where + " AND WS_DATE LIKE N'" + conn.formatstr2(tb3.Text) + "%'";
            }
            if (!string.IsNullOrEmpty(tb4.Text)) 
            { 
                SQL2 = SQL2 + " AND C_NAME LIKE N'%" + tb4.Text + "%'";
                Form1I.Where = Form1I.Where + " AND C_NAME LIKE N'" + tb4.Text + "%'";
            }
            SQL2 = SQL2 + " ORDER BY WS_DATE DESC ";
            DataTable dt2 = conn.readdata(SQL2);
            foreach (DataRow item in dt2.Rows)
            {
                item["WS_DATE"] = conn.formatstr2(item["WS_DATE"].ToString());
            }
            if (dt2 != null)
            {
                DGV2.DataSource = dt2;
            }
        }
        private void button1_Click(object sender, EventArgs e) // button Searching Data 
        {
            SearchingData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getBaoGia.WS_NO = DGV2.Rows[DGV2.CurrentRow.Index].Cells["WS_NO"].Value.ToString();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getBaoGia.WS_NO = DGV2.Rows[DGV2.CurrentRow.Index].Cells["WS_NO"].Value.ToString();
            this.Close();
        }
        private void tb3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender frm = new FromCalender();
            frm.ShowDialog();
            tb3.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void DGV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            insert();
        }
    }
}
