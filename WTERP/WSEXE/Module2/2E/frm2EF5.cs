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
    public partial class frm2EF5 : Form
    {
        DataProvider conn = new DataProvider();
        public frm2EF5()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        BindingSource bindingsource;
        DataTable dt = new DataTable();
        public string AA;
        string a = "";
        public void check()
        {
            if (conn.Check_MaskedText(tb4) == true)
            {
                a = conn.formatstr2(tb4.Text);
            }
        }
        private void frm2EF5_Load(object sender, EventArgs e)
        {
            Load_DGV1();
            Load_DGV2();
           
        }
        public void Load_DGV1()
        {
            
           string sql = "SELECT WS_NO, WS_DATE, C_NO, C_NAME, TOTAL, TAX, DISCOUNT, TOT, RCV_MON, NRCV_MON FROM GIBH ORDER BY WS_DATE DESC, WS_NO DESC";
            dt = new DataTable();
            dt = conn.readdata(sql);
            bindingsource = new BindingSource();
            bindingsource.DataSource = dt;
            DGV1.DataSource = bindingsource;
            conn.DGV(DGV1);
        }
      

       
  
        public void Load_DGV2()
        {
            DataTable dt1 = new DataTable();
            BindingSource bds = new BindingSource();
            AA = DGV1.Rows[0].Cells["WS_NO"].Value.ToString();
            string SQL;
                if(DT.S1 == string.Empty)
                    SQL = "select NR, P_NO, P_NAME, BQTY, UNIT, PRICE, AMOUNT, COST, MEMO from GIBB where WS_NO = '" + AA + "' ";
                else
                SQL = "select NR, P_NO, P_NAME, BQTY, UNIT, PRICE, AMOUNT, COST, MEMO from GIBB where WS_NO = '" + DT.S1 + "' ";

            dt1= new DataTable();
            dt1 = conn.readdata(SQL);
            bds.DataSource = dt1;
            DGV2.DataSource = bds;
            conn.DGV(DGV2);
            DGV2.Columns["PRICE"].DefaultCellStyle.Format = "#,##0.00";
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        public class DT
        {
            public static string S1;
            public static string G1;
        }
        
        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DT.S1 = DGV1.Rows[DGV1.CurrentRow.Index].Cells["WS_NO"].Value.ToString();
            Load_DGV2();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            check();
            DataTable dt3 = new DataTable();
            BindingSource bds1 = new BindingSource();
            string sql;
            sql = "SELECT WS_NO, WS_DATE, C_NO, C_NAME, TOTAL, TAX, DISCOUNT, TOT, RCV_MON, NRCV_MON FROM GIBH WHERE 1=1";
            if ((tb1.Text == "") && (tb2.Text == "") && (tb3.Text == "") && (tb4.Text == ""))
            {
                sql = sql + "";
            }
            if (tb1.Text != "")
                sql = sql + " AND WS_NO LIKE N'%" + tb1.Text + "%'";
            if (tb2.Text != "")
                sql = sql + " AND C_NAME LIKE N'%" + tb2.Text + "%'";
            if (tb3.Text != "")
                sql = sql + " AND C_NO LIKE N'%" + tb3.Text + "%'";
            if (a != "")
                sql = sql + " AND WS_DATE = '"+ a +"'";

            sql = sql + " ORDER BY WS_DATE DESC, WS_NO DESC";


            dt3 = conn.readdata(sql);
            bds1.DataSource = dt3;
            DGV1.DataSource = bds1;
        }

        private void tb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                tb2.Focus();
            }
        }

        private void tb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                tb3.Focus();
            }
        }

        private void tb3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                tb4.Focus();
            }
        }

        private void tb4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                tb1.Focus();
            }
        }
        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DT.G1 = DGV1.Rows[DGV1.CurrentRow.Index].Cells["WS_NO"].Value.ToString();
            this.Hide();
            this.Close();
        }

        private void tb4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            tb4.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }
    }
}
