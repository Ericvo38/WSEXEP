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
            GetWS_NO = string.Empty;
            LoadDGV();
        }
       
        void LoadDGV()
        {
            string SQL1 = "SELECT TOP 500 WS_NO, WS_DATE, C_NO, P_NAME, C_NAME, CLRCARD, MK_NOA FROM COSTH WHERE 1=1  "+frm3I.Where+ " ORDER BY WS_DATE DESC ";
            DataTable dt1 = con.readdata(SQL1);
            foreach (DataRow dr in dt1.Rows)
                dr["WS_DATE"] = con.formatstr2(dr["WS_DATE"].ToString());
            DGV2.DataSource = dt1;
            DGV2.DataGridViewFormat();
        }
        void Search()
        {
            frm3I.Where = string.Empty;
            string SQL2 = "SELECT WS_NO, dbo.FormatString2(WS_DATE) AS WS_DATE, C_NO, P_NAME, C_NAME, CLRCARD, MK_NOA FROM COSTH WHERE 1=1 ";
            if(txtWS_NO.Text == "" && txtWS_DATE.Text == "" && txtC_NO.Text == "" && txtC_NAME.Text == "" && txtMK_NO.Text == "" && txtP_NAME.Text == "" && txtMK_NOA.Text == "")
            {
                SQL2 = SQL2 + "";
            }
            if (txtWS_NO.Text != "")
                frm3I.Where = frm3I.Where + " AND WS_NO LIKE '%"+ txtWS_NO.Text + "%' ";
            if (txtWS_DATE.MaskCompleted)
                frm3I.Where = frm3I.Where + " AND WS_DATE LIKE '%" + txtWS_DATE.Text.Replace("/","")+ "%' ";
            if (txtC_NO.Text != "")
                frm3I.Where = frm3I.Where + " AND C_NO LIKE '%" + txtC_NO.Text + "%' ";
            if (txtP_NAME.Text != "")
                frm3I.Where = frm3I.Where + " AND P_NAME LIKE '%" + txtP_NAME.Text + "%' ";
            if (txtC_NAME.Text != "")
                frm3I.Where = frm3I.Where + " AND C_NAME LIKE '%" + txtC_NAME.Text + "%' ";
            if (txtMK_NOA.Text != "")
                frm3I.Where = frm3I.Where + " AND MK_NOA LIKE '%" + txtMK_NOA.Text + "%' ";
            if (txtMK_NO.Text != "")
                frm3I.Where = frm3I.Where + " AND MK_NO LIKE '%" + txtMK_NO.Text + "%' ";

            SQL2 = SQL2 + frm3I.Where + " ORDER BY WS_DATE DESC";
            DataTable dt2 = con.readdata(SQL2);
            DGV2.DataSource = dt2;
            DGV2.DataGridViewFormat();
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
        private void txtWS_DATE_KeyDown_1(object sender, KeyEventArgs e)
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
            if(!string.IsNullOrEmpty(GetWS_NO))
            {
                GetWS_NO = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dữ liệu");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GetWS_NO = string.Empty;
            this.Close();
        }
        private void txtWS_DATE_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FromCalender fm = new FromCalender();
            fm.ShowDialog();
            txtWS_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
        }
        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch frm = new frm2CustSearch();
            frm.Show();
            txtC_NO.Text = frm2CustSearch.ID.ID_CUST;
        }

        private void DGV2_MouseClick(object sender, MouseEventArgs e)
        {
            GetWS_NO = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
        }

        private void DGV2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetWS_NO = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
            this.Close();
        }

        private void txtWS_DATE_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender fm = new FromCalender();
            fm.ShowDialog();
            if (LibraryCalender.FromCalender.Flags)
            {
                txtWS_DATE.Text = LibraryCalender.FromCalender.getDate.ToString("yyyyMMdd");           
            }
        }
    }
}
