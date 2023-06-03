using LibraryCalender;
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
    public partial class frm3I_SearchSample : Form
    {
        DataProvider con = new DataProvider();
        public frm3I_SearchSample()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        string SQL = frm3I.Share3I.W_KIND;
        
        private void frm3I_SearchSample_Load(object sender, EventArgs e)
        {
            LoadDGV2();
        }
        void LoadDGV2()
        {
            string SQL2 = SQL + " ORDER BY WS_NO DESC,WS_DATE DESC";
            DataTable dt2 = con.readdata(SQL2);
            foreach (DataRow dr in dt2.Rows)
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            DGV2.DataSource = dt2;
            con.DGV(DGV2);
        }
        void Search()
        {
            string txtWS_DATE1 = "";
            if (con.Check_MaskedText(txtWS_DATE) == true)
            {
                txtWS_DATE1 = con.formatstr2(txtWS_DATE.Text);
            }    
            string SQL3 = SQL;
            if(txtWS_NO.Text == "" && txtC_NO.Text == "" && txtC_NAME.Text == "" && txtWS_DATE1 == "")
            {
                LoadDGV2();
            }
            if (txtWS_NO.Text != "")
                SQL3 = SQL3 + " AND WS_NO LIKE '%"+txtWS_NO.Text+"%' ";
            if (txtC_NO.Text != "")
                SQL3 = SQL3 + " AND C_NO LIKE '%" + txtC_NO.Text + "%' ";
            if (txtC_NAME.Text != "")
                SQL3 = SQL3 + " AND C_NAME LIKE '%" + txtC_NAME.Text + "%' ";
            if (txtWS_DATE1 != "")
                SQL3 = SQL3 + " AND WS_DATE = '" + txtWS_DATE1 + "'";
            DataTable dt3 = con.readdata(SQL3);
            foreach (DataRow dr in dt3.Rows)
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"] + "");
            DGV2.DataSource = dt3;
            con.DGV(DGV2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtWS_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtC_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        private void DGV2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Clipboard.SetText(DGV2.CurrentRow.Cells["WS_NO"].Value.ToString());
            this.Close();
        }

        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtWS_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }
    }
}
