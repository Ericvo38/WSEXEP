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
    public partial class frm3IF5 : Form
    {
        DataProvider con = new DataProvider();
        public static string GetWS_NO;
        public frm3IF5()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }

        private void frm3IF5_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }
        //public class Share3IF5
        //{
        //    public static string GetWS_NO;
        //}
        void LoadDGV()
        {
            string SQL1 = "SELECT TOP 100 WS_NO, WS_DATE, C_NO, P_NAME, C_NAME, CLRCARD, MK_NOA FROM COSTH ORDER BY WS_DATE DESC ";
            DataTable dt1 = con.readdata(SQL1);
            foreach (DataRow dr in dt1.Rows)
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            DGV2.DataSource = dt1;
            con.DGV(DGV2);
            DGV2.DefaultCellStyle.Font = new Font("Tahoma", 17F);
            DGV2.DefaultCellStyle.ForeColor = Color.MidnightBlue;
        }
        void Search()
        {
            string SQL2 = "SELECT WS_NO, WS_DATE, C_NO, P_NAME, C_NAME, CLRCARD, MK_NOA FROM COSTH WHERE 1=1 ";
            if(txtWS_NO.Text == "" && txtWS_DATE.Text == "" && txtC_NO.Text == "" && txtC_NAME.Text == "" && txtMK_NO.Text == "" && txtP_NAME.Text == "" && txtMK_NOA.Text == "")
            {
                SQL2 = SQL2 + "";
            }
            if (txtWS_NO.Text != "")
                SQL2 = SQL2 + " AND WS_NO LIKE '%"+ txtWS_NO.Text + "%' ";
            if (txtWS_DATE.Text != "")
                SQL2 = SQL2 + " AND WS_DATE LIKE '" + txtWS_DATE.Text + "%' ";
            if (txtC_NO.Text != "")
                SQL2 = SQL2 + " AND C_NO LIKE '" + txtC_NO.Text + "%' ";
            if (txtP_NAME.Text != "")
                SQL2 = SQL2 + " AND P_NAME LIKE '%" + txtP_NAME.Text + "%' ";
            if (txtC_NAME.Text != "")
                SQL2 = SQL2 + " AND C_NAME LIKE '" + txtC_NAME.Text + "%' ";
            if (txtMK_NOA.Text != "")
                SQL2 = SQL2 + " AND MK_NOA LIKE '" + txtMK_NOA.Text + "%' ";
            if (txtMK_NO.Text != "")
                SQL2 = SQL2 + " AND MK_NO LIKE '" + txtMK_NO.Text + "%' ";
            //SQL2 = SQL2 + " ORDER BY WS_DATE DESC";
            DataTable dt1 = con.readdata(SQL2);
            foreach (DataRow dr in dt1.Rows)
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"] + "");
            DGV2.DataSource = dt1;
            con.DGV(DGV2);
            DGV2.DefaultCellStyle.Font = new Font("Tahoma", 17F);
            DGV2.DefaultCellStyle.ForeColor = Color.MidnightBlue;
        }

        private void txtWS_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtCLRCARD_KeyDown(object sender, KeyEventArgs e)
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

        private void txtMK_NOA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtP_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(DGV2.SelectedCells.Count > 0)
            {
                GetWS_NO = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV2_DoubleClick(object sender, EventArgs e)
        {
            GetWS_NO = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
            this.Close();
        }

        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtWS_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }

        private void txtWS_NO_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch frm = new frm2CustSearch();
            frm.Show();
            txtC_NO.Text = frm2CustSearch.ID.ID_CUST;
        }
    }
}
