using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP.WSEXE
{
    public partial class frm2R : Form
    {
        DataProvider conn = new DataProvider();
        DataTable data = new DataTable();
        public frm2R()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        private void frm2R_Load(object sender, EventArgs e)
        {
            try
            {
                button1.Hide();
                button2.Hide();

                string sql1 = "SELECT WS_DATE,K_NO,NR,C_NO,OR_NO,C_NAME_E,T_NAME,P_NO,P_NAME_E,COLOR_E,THICK FROM ORDB WHERE NOT EXISTS (SELECT 1 FROM PRDMK2 WHERE OR_NO = ORDB.OR_NO AND NR = ORDB.NR AND K_NO = ORDB.K_NO) " +
                    "AND WS_DATE >= '" + GetFirstDayOfMonth(DateTime.Now.Month).ToString("yyMMdd") + "'AND WS_DATE <= '" + GetLastDayOfMonth(DateTime.Now.Month).ToString("yyMMdd") + "' ORDER BY WS_DATE,NR";
                data = conn.readdata(sql1);
                foreach (DataRow item in data.Rows)
                {
                    item["WS_DATE"] = conn.formatstr1(item["WS_DATE"].ToString());
                }
                dataGridView1.DataSource = data;
                conn.DGV1(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void search()
        {
            try
            {
                string sql = "SELECT WS_DATE,K_NO,NR,C_NO,OR_NO,C_NAME_E,T_NAME,P_NO,P_NAME_E,COLOR_E,THICK FROM ORDB WHERE NOT EXISTS (SELECT 1 FROM PRDMK2 WHERE OR_NO = ORDB.OR_NO AND NR = ORDB.NR AND K_NO = ORDB.K_NO)";
                if (!string.IsNullOrEmpty(maskedTextBox1.Text) && maskedTextBox1.MaskFull == true)
                {
                    sql = sql + " AND WS_DATE >= '" + conn.formatstr1(maskedTextBox1.Text) + "'";
                }
                if (!string.IsNullOrEmpty(maskedTextBox2.Text) && maskedTextBox2.MaskFull == true)
                {
                    sql = sql + " AND WS_DATE <= '" + conn.formatstr1(maskedTextBox2.Text) + "'";
                }
                sql = sql + " ORDER BY WS_DATE,NR";
                data = conn.readdata(sql);
                foreach (DataRow item in data.Rows)
                {
                    item["WS_DATE"] = conn.formatstr2(item["WS_DATE"].ToString());
                }
                dataGridView1.DataSource = data;
                conn.DGV1(dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static DateTime GetFirstDayOfMonth(int iMonth)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, iMonth, 1);
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }
        public static DateTime GetLastDayOfMonth(int iMonth)
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, iMonth, 1);
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }
        private void maskedTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                checkFalse_AfterSearch();
                checkBox1.Checked = false;
            }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
                checkFalse_AfterSearch();
                checkBox1.Checked = false;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    if (checkBox1.Checked == true)
                    {

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells["CHECK"].Value = true;
                        }

                    }
                    else
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells["CHECK"].Value = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void checkFalse_AfterSearch()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (checkBox1.Checked == true)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells["CHECK"].Value = false;
                    }
                }
            }
        }
        private void f12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void f2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Show();
            button2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            button2.Hide();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[0].Value) == true)
            {
                dataGridView1.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                dataGridView1.CurrentRow.Cells[0].Value = true;
            }
        }
    }
}
