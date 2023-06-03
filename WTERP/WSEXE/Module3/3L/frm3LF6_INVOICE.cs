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
    public partial class frm3LF6_INVOICE : Form
    {
        DataProvider con = new DataProvider();
        public frm3LF6_INVOICE()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
      
        private void frm3JF5_Load(object sender, EventArgs e)
        {
            LoadDGV2();
        }
        void LoadDGV2()
        {
            Search();
        }
        void Search()
        {
            string SQL2 = "SELECT * FROM tblHistoryInvoice WHERE 1=1";
            if (!string.IsNullOrEmpty(textBox1.Text))
                SQL2 = SQL2 + " AND INVOICE LIKE '%" + textBox1.Text+"%'";
            if (string.IsNullOrEmpty(maskedTextBox1.Text) && maskedTextBox1.MaskFull == true)
                SQL2 = SQL2 + " AND DATECREATE LIKE '%" + maskedTextBox1.Text + "%' ";
            if (!string.IsNullOrEmpty(textBox3.Text))
                SQL2 = SQL2 + " AND C_NO LIKE '%" + textBox3.Text + "%' ";

            SQL2 = SQL2 + " ORDER BY DATECREATE DESC";
            DataTable dt2 = con.readdata(SQL2);
            foreach (DataRow item in dt2.Rows)
            {
                item["DATECREATE"] = con.formatstr2(item["DATECREATE"].ToString());
            }
            DGV2.DataSource = dt2;
            con.DGV(DGV2);

            if (DGV2.Rows.Count > 0)
            {
                //load data2
                getDataInformation(DGV2.Rows[0].Cells[1].Value.ToString());
            }   
        }
        private void getDataInformation(string invoice)
        {
            string sql = "SELECT * FROM dbo.tblDescription_HistoryInvoice WHERE 1=1 AND INVOICE = '" + invoice + "'";
            DataTable dt2 = con.readdata(sql);
            customDGV1.DataSource = dt2;
            con.DGV(customDGV1);
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
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            getDatafrm3LF6_Invoice.Invoice = DGV2.CurrentRow.Cells[1].Value.ToString();
            getDatafrm3LF6_Invoice.C_NO = DGV2.CurrentRow.Cells[2].Value.ToString();
            this.Close();
        }
        private void DGV2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataInformation(DGV2.CurrentRow.Cells[1].Value.ToString());
        }
        public class getDatafrm3LF6_Invoice
        {
            public static string Invoice;
            public static string C_NO;
        }
    }
}
