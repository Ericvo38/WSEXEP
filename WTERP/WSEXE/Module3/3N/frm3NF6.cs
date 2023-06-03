using LibraryCalender;
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
    public partial class frm3NF6 : Form
    {
        DataProvider conn = new DataProvider();
        public frm3NF6()
        {
            this.ShowInTaskbar = false;
            InitializeComponent();
        }

        private void frm3NF6_Load(object sender, EventArgs e)
        {
            getDataDataGribView1();
        }
        private void getDataDataGribView1()
        {
            string sql = "SELECT DATECREATE,INVOICE,C_NO,BYAIR FROM tblHistoryInvoice_KTKD WHERE 1=1 ORDER BY DATECREATE DESC";
            DataTable data = new DataTable();
            data = conn.readdata(sql);
            foreach (DataRow item in data.Rows)
            {
                item["DATECREATE"] = conn.formatstr2(item["DATECREATE"].ToString());
            }
            DGV1.DataSource = data;
            conn.DGV(DGV1);

            if (DGV1.Rows.Count > 0)
            {
                getDataDataGribView2(DGV1.Rows[0].Cells["INVOICE"].Value.ToString());
            }
            conn.DGV(DGV2);
            Changed_Color(DGV2);
        }
        private void getDataDataGribView2(string txtInvoice)
        {
            string sql = "SELECT OR_NO,DESCRIPTION,THICKNESS,QTY,PRICE,TOTAL,CALTULATED FROM tblDescription_HistoryInvoice_KTKD WHERE INVOICE = '" + txtInvoice + "'";
            DataTable data = new DataTable();
            data = conn.readdata(sql);
            DGV2.DataSource = data;
            conn.DGV(DGV2);
            Changed_Color(DGV2);
        }
        private void Changed_Color(DataGridView dataGrid)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells["CALTULATED"].Value.ToString()))
                {
                    if (row.Cells["CALTULATED"].Value.ToString() == "True")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void txtInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }

        }
        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }
        }
        private void txtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search();
            }
        }
        private void search()
        {
            string sql = "SELECT DATECREATE,INVOICE,C_NO,BYAIR FROM tblHistoryInvoice_KTKD WHERE 1=1";
            if (!string.IsNullOrEmpty(txtInvoice.Text))
            {
                sql = sql + " AND INVOICE like '%" + txtInvoice.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtC_NO.Text))
            {
                sql = sql + " AND C_NO like '%" + txtC_NO.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtDate.Text) && txtDate.MaskFull == true)
            {
                sql = sql + " AND DATECREATE like '%" + conn.formatstr2(txtDate.Text) + "%'";
            }
            sql = sql + " ORDER BY DATECREATE DESC";
            DataTable data = new DataTable();
            data = conn.readdata(sql);
            foreach (DataRow item in data.Rows)
            {
                item["DATECREATE"] = conn.formatstr2(item["DATECREATE"].ToString());
            }
            DGV1.DataSource = data;
            conn.DGV(DGV1);

            if (DGV1.Rows.Count > 0)
            {
                getDataDataGribView2(DGV1.Rows[0].Cells["INVOICE"].Value.ToString());
            }
            else
            {
                getDataDataGribView2("");
            }
            conn.DGV(DGV2);
            Changed_Color(DGV2);
        }

        private void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DL3NF6.INVOICE = DGV1.CurrentRow.Cells["INVOICE"].Value.ToString();
            this.Hide();
            this.Close();
        }
        public class DL3NF6
        {
            public static string INVOICE;
        }
        private void btnOke_Click(object sender, EventArgs e)
        {
            DL3NF6.INVOICE = DGV1.CurrentRow.Cells["INVOICE"].Value.ToString();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            getDataDataGribView2(DGV1.CurrentRow.Cells["INVOICE"].Value.ToString());
        }
        private void txtDate_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtDate.Text = FromCalender.getDate.ToString("yyyy/MM/dd");
        }
    }
}
