using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frmSearchCARB_Packing : Form
    {
        DataProvider conn = new DataProvider();
        public frmSearchCARB_Packing()
        {
            this.ShowInTaskbar = false;
            conn.choose_languege();
            InitializeComponent();
        }
        DataProvider con = new DataProvider();
        string F_CNO = frm3L.F_CNO;
        private void frmSearchCARB_Load(object sender, EventArgs e)
        {
            Load_Data();
            DGV1.AllowUserToAddRows = false;
        }
        private void Load_Data()
        {
            string sql = "SELECT WS_NO,'' as Number,NR,WS_DATE,C_NO,OR_NO,P_NO,P_NAME,P_NAME1,P_NAME3,BQTY,PRICE,AMOUNT,MEMO,COLOR,COLOR_C,QPCS,PCS FROM dbo.CARB where 1=1 ";

            if (!string.IsNullOrEmpty(txtOR_NO.Text))
                sql = sql + " AND OR_NO LIKE '%" + txtOR_NO.Text + "%' ";
            if (!string.IsNullOrEmpty(txtC_NO.Text))
                sql = sql + " AND a.C_NO LIKE '%" + txtC_NO.Text + "%' ";
            if (!string.IsNullOrEmpty(txtCOLOR.Text))
                sql = sql + " AND a.COLOR_E LIKE '%" + txtCOLOR.Text + "%' ";
            if (!string.IsNullOrEmpty(txtP_NO.Text))
                sql = sql + " AND a.P_NO LIKE '%" + txtP_NO.Text + "%' ";

            sql = sql + " ORDER BY WS_DATE DESC";
            DataTable dt1 = con.readdata(sql);
            DGV1.DataSource = dt1;
            DGV1.MyDGV();
        }
        public class GetItem
        {
            public string P_NAME1 { get; set; }
            public string P_NAME3 { get; set; }
            public string Number { get; set; }
            public string OR_NO { get; set; }
            public string WS_NO { get; set; }
            public string NR { get; set; }
            public string COLOR { get; set; }
        }
        public static List<GetItem> Listitems = new List<GetItem>();
        private void bttk_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            this.Close();
        }

        private void txtOR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                txtC_NO.Focus();
            }
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                txtCOLOR.Focus();
            }
        }

        private void txtCOLOR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                txtP_NO.Focus();
            }
        }

        private void txtP_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bttk.PerformClick();
                txtOR_NO.Focus();
            }
        }

        private void DGV1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int cur = DGV1.CurrentRow.Index;
            if (Convert.ToBoolean(DGV1.CurrentRow.Cells[0].Value) == true)
            {
                reomveToList(cur);
                DGV1.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                addToList(cur);
                DGV1.CurrentRow.Cells[0].Value = true;
            }
        }
        private void reomveToList(int cur)
        {
            var itemToRemove = Listitems.Single(r => r.WS_NO == DGV1.Rows[cur].Cells["WS_NO"].Value.ToString() && r.NR == DGV1.Rows[cur].Cells["NR"].Value.ToString());
            Listitems.Remove(itemToRemove);
        }

        private void addToList(int cur)
        {
            Listitems.Add(new GetItem
            {
                OR_NO = DGV1.Rows[cur].Cells["OR_NO"].Value.ToString(),
                P_NAME1 = DGV1.Rows[cur].Cells["P_NAME1"].Value.ToString(),
                P_NAME3 = DGV1.Rows[cur].Cells["P_NAME3"].Value.ToString(),
                Number = DGV1.Rows[cur].Cells["Number"].Value.ToString(),
                WS_NO = DGV1.Rows[cur].Cells["WS_NO"].Value.ToString(),
                NR = DGV1.Rows[cur].Cells["NR"].Value.ToString(),
                COLOR = DGV1.Rows[cur].Cells["COLOR"].Value.ToString()
            });
        }
    }
}
