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
    public partial class frm2BrandSearch : Form
    {
        DataProvider con = new DataProvider();
        public frm2BrandSearch()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }
        private void Formtimkiemnhanhieu_Load(object sender, EventArgs e)
        {
            LoadDGV2();
        }
        public class getInfo
        {
            public static string ID_BRAND;
            public static string BRAND;
            public static string TRADE;
        }
        public void Trans()
        {
            getInfo.ID_BRAND = DGV2.CurrentRow.Cells[0].Value.ToString();
            getInfo.BRAND = DGV2.CurrentRow.Cells[1].Value.ToString();
            getInfo.TRADE = DGV2.CurrentRow.Cells[2].Value.ToString();
            this.Close();
        }
        public void LoadDGV2()
        {
            string str1 = "SELECT B_NO, BRAND, TRADE FROM BRAND";
            DataTable dt = con.readdata(str1);
            if (dt != null)
            {
                con.FormatDGV(DGV2, dt);
            }

        }
        private void Searching()
        {
            string sql;
            sql = "SELECT * from dbo.BRAND WHERE 1=1";
            if ((txtmaTH.Text == "") && (txttenTHC.Text == "") && (txttenTHE.Text == ""))
            {
                sql = sql + "";
            }
            if (txtmaTH.Text != "")
                sql = sql + " AND B_NO LIKE N'%" + txtmaTH.Text + "%'";
            if (txttenTHC.Text != "")
                sql = sql + " AND BRAND LIKE N'%" + txttenTHC.Text + "%'";
            if (txttenTHE.Text != "")
                sql = sql + " AND TRADE LIKE N'%" + txttenTHE.Text + "%'";
            DataTable dt = con.readdata(sql);
            con.FormatDGV(DGV2, dt);
        }
        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Trans();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trans();
        }

        private void txtmaTH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }

        private void txttenTHC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }

        private void txttenTHE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Searching();
        }
    }
}
