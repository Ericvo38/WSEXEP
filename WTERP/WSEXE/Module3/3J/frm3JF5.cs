using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm3JF5 : Form
    {
        DataProvider con = new DataProvider();
        public frm3JF5()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        public class Share3JF5
        {
            public static string MK_NO;
            public static string SOURCE;
            public static string UKG;
            public static string WKG;
            public static string BPCS;
            public static string CARNO;
            public static string USR_NAME;
        }
        private void frm3JF5_Load(object sender, EventArgs e)
        {
            LoadDGV2();
        }
        void LoadDGV2()
        {
            string SQL1 = "SELECT TOP 100 MK_NO, SOURCE, UKG, WKG, BPCS, CARNO, USR_NAME FROM ASOURCE ";
            DataTable dt = con.readdata(SQL1);
            DGV2.DataSource = dt;
            con.DGV(DGV2);
        }
        void Search()
        {
            string SQL2 = "SELECT MK_NO, SOURCE, UKG, WKG, BPCS, CARNO, USR_NAME FROM ASOURCE WHERE 1=1 ";
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
                SQL2 = SQL2 + "";
            if (textBox1.Text != "")
                SQL2 = SQL2 + " AND MK_NO LIKE '%"+textBox1.Text+"%' ";
            if (textBox2.Text != "")
                SQL2 = SQL2 + " AND SOURCE LIKE '%" + textBox2.Text + "%' ";
            if (textBox3.Text != "")
                SQL2 = SQL2 + " AND CARNO LIKE '%" + textBox3.Text + "%' ";
            DataTable dt2 = con.readdata(SQL2);
            DGV2.DataSource = dt2;
            con.DGV(DGV2);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DGV2.SelectedCells.Count >0)
            {
                Share3JF5.MK_NO = DGV2.CurrentRow.Cells["MK_NO"].Value.ToString();
                Share3JF5.SOURCE = DGV2.CurrentRow.Cells["SOURCE"].Value.ToString();
                Share3JF5.UKG = DGV2.CurrentRow.Cells["UKG"].Value.ToString();
                Share3JF5.WKG = DGV2.CurrentRow.Cells["WKG"].Value.ToString();
                Share3JF5.BPCS = DGV2.CurrentRow.Cells["BPCS"].Value.ToString();
                Share3JF5.CARNO = DGV2.CurrentRow.Cells["CARNO"].Value.ToString();
                Share3JF5.USR_NAME = DGV2.CurrentRow.Cells["USR_NAME"].Value.ToString();

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Share3JF5.MK_NO = DGV2.CurrentRow.Cells["MK_NO"].Value.ToString();
            Share3JF5.SOURCE = DGV2.CurrentRow.Cells["SOURCE"].Value.ToString();
            Share3JF5.UKG = DGV2.CurrentRow.Cells["UKG"].Value.ToString();
            Share3JF5.WKG = DGV2.CurrentRow.Cells["WKG"].Value.ToString();
            Share3JF5.BPCS = DGV2.CurrentRow.Cells["BPCS"].Value.ToString();
            Share3JF5.CARNO = DGV2.CurrentRow.Cells["CARNO"].Value.ToString();
            Share3JF5.USR_NAME = DGV2.CurrentRow.Cells["USR_NAME"].Value.ToString();

            this.Close();
        }
    }
}
