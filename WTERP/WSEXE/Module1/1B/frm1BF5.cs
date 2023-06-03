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
    public partial class Form1BF5 : Form
    {
        DataProvider data = new DataProvider();
        public Form1BF5()
        {
            this.ShowInTaskbar = false;
            data.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable datatable = new DataTable();

        public Form1B f1 = new Form1B();


        private void Formtimkiemdoanhnghiepnhacungcap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            string sql = "select C_NO, C_NAME, C_ANAME, V_NAME, V_ANAME, NUMBER, BOSS, SPEAK, TEL1, TEL2, FAX, ACT, EMAIL, S_NO,  ADR1ZIP, ADR1, ADR2ZIP, ADR2, ADR3ZIP, ADR3, ADR4ZIP, ADR4, MEMO1," +
                " MEMO2, MEMO3, ACCOUNT, PRE_RCV, EAR_MON, TAX_KIND, BA_NO, TAX_YN, PAY_CON, RCV_DATE, DEFA_MONEY,USR_NAME from VENDC";
            // co the su dung cm.ExecuteNonQuery();
            datatable = new DataTable();
            datatable = data.readdata(sql);
            // truyen ad vao table
            bindingsource = new BindingSource();
            bindingsource.DataSource = datatable;
            dataGridViewdoanhnghiep2.DataSource = bindingsource;
            dataGridViewdoanhnghiep2.MyDGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Search();
        }
        public class DL
        {
            public static string T1;
            public static string T2;
            public static string T3;
            public static string T4;
            public static string T5;

            public static string T6;
            public static string T7;
            public static string T8;
            public static string T9;
            public static string T10;

            public static string T11;
            public static string T12;
            public static string T13;
            public static string T14;
            // public static string T15;

            public static string T16;
            public static string T17;
            public static string T18;
            public static string T19;
            public static string T20;

            public static string T21;
            public static string T22;
            public static string T23;
            public static string T24;
            public static string T25;

            public static string T26;
            public static string T27;
            public static string T28;
            public static string T29;
            public static string T30;

            public static string T31;
            //public static string T32;
            public static string T33;
            public static string T34;
            public static string T35;

            public static string T36;
            public static string T37;


        }
        public class GUI
        {
            public static string Tx1;
        }

        public class GU
        {
            public static string s1;
        }
        public class Form1D_DL
        {
            public static string c1;
        }
        public class SEND_FORM6I
        {
            public static string f1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["C_NO"].Value.ToString() == "" || dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["C_NO"].Value.ToString() == null)
            {
                if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
                {
                    MessageBox.Show("Vui lòng chọn một hàng để load dữ liệu");
                }
                if (DataProvider.LG.rdVietNam == true)
                {
                    MessageBox.Show("Vui lòng chọn một hàng để load dữ liệu");
                }
                if (DataProvider.LG.rdEnglish == true)
                {
                    MessageBox.Show("Please select a row to load data");
                }
                if (DataProvider.LG.rdChina == true)
                {
                    MessageBox.Show("請選擇一行加載數據");
                }
            }
            else
            {
                getData();
            }
        }

        private void dataGridViewdoanhnghiep2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            getData();
        }
        private void getData()
        {
            DL.T1 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            DL.T2 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["C_NAME"].Value.ToString();
            DL.T3 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["C_ANAME"].Value.ToString();
            DL.T4 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["V_NAME"].Value.ToString();
            DL.T5 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["V_ANAME"].Value.ToString();

            DL.T6 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["NUMBER"].Value.ToString();
            DL.T7 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["BOSS"].Value.ToString();
            DL.T8 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["SPEAK"].Value.ToString();
            DL.T9 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["TEL1"].Value.ToString();
            DL.T10 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["TEL2"].Value.ToString();

            DL.T11 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["FAX"].Value.ToString();
            DL.T12 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["ACT"].Value.ToString();
            DL.T13 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["EMAIL"].Value.ToString();
            DL.T14 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["S_NO"].Value.ToString();
            // DL.T15 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["EMAIL1"].Value.ToString();

            DL.T16 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["ADR1ZIP"].Value.ToString();
            DL.T17 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["ADR1"].Value.ToString();
            DL.T18 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["ADR2ZIP"].Value.ToString();
            DL.T19 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["ADR2"].Value.ToString();
            DL.T20 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["ADR3ZIP"].Value.ToString();

            DL.T21 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["ADR3"].Value.ToString();
            DL.T22 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["ADR4ZIP"].Value.ToString();
            DL.T23 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["ADR4"].Value.ToString();
            DL.T24 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["MEMO1"].Value.ToString();
            DL.T25 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["MEMO2"].Value.ToString();

            DL.T26 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["MEMO3"].Value.ToString();
            DL.T27 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["ACCOUNT"].Value.ToString();
            DL.T28 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["PRE_RCV"].Value.ToString();
            DL.T29 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["EAR_MON"].Value.ToString();
            DL.T30 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["TAX_KIND"].Value.ToString();


            DL.T31 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["BA_NO"].Value.ToString();
            //DL.T32 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["BANK_AC_NO"].Value.ToString();
            DL.T33 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["TAX_YN"].Value.ToString();
            DL.T34 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["PAY_CON"].Value.ToString();
            DL.T35 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["RCV_DATE"].Value.ToString();
            DL.T36 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["DEFA_MONEY"].Value.ToString();
            DL.T37 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["USR_NAME"].Value.ToString();

            GUI.Tx1 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            GU.s1 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            Form1D_DL.c1 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            SEND_FORM6I.f1 = dataGridViewdoanhnghiep2.Rows[dataGridViewdoanhnghiep2.CurrentRow.Index].Cells["C_NO"].Value.ToString();

            this.Hide();
            this.Close();
        }
        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
                tb2.Focus();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
                tb5.Focus();
            }
        }

        private void tb7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
                tb8.Focus();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
                tb3.Focus();
            }
        }

        private void tb5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
                tb6.Focus();
            }
        }

        private void tb8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
                tb9.Focus();
            }
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
                tb4.Focus();
            }
        }

        private void tb6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
                tb7.Focus();
            }
        }

        private void tb9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
        }
        public void Search()
        {
            string sql;
            sql = "SELECT C_NO, C_NAME, C_ANAME, V_NAME, V_ANAME, NUMBER, BOSS, SPEAK, TEL1, TEL2, FAX, ACT, EMAIL, S_NO,  ADR1ZIP, ADR1, ADR2ZIP, ADR2, ADR3ZIP, ADR3, ADR4ZIP, ADR4, MEMO1, MEMO2, MEMO3, ACCOUNT, PRE_RCV, EAR_MON, TAX_KIND, BA_NO, TAX_YN,  PAY_CON, RCV_DATE, DEFA_MONEY,USR_NAME from dbo.VENDC WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == "") && (tb3.Text == "") && (tb4.Text == "") && (tb5.Text == "") && (tb6.Text == "") && (tb7.Text == "") && (tb8.Text == "") && (tb9.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND C_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND C_NAME LIKE N'%" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND BOSS LIKE N'%" + tb3.Text + "%'";
            if (tb4.Text != "")
                sql = sql + " AND SPEAK LIKE N'%" + tb4.Text + "%'";
            if (tb5.Text != "")
                sql = sql + " AND NUMBER LIKE N'%" + tb5.Text + "%'";
            if (tb6.Text != "")
                sql = sql + " AND TEL1 LIKE N'%" + tb6.Text + "%'";
            if (tb7.Text != "")
                sql = sql + " AND FAX LIKE N'%" + tb7.Text + "%'";
            if (tb8.Text != "")
                sql = sql + " AND S_NO LIKE N'%" + tb8.Text + "%'";
            if (tb9.Text != "")
                sql = sql + " AND ADR1 LIKE N'%" + tb9.Text + "%'";

            DataTable dt = new DataTable();
            dt = data.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            dataGridViewdoanhnghiep2.DataSource = bindingsource;
        }
    }
}
