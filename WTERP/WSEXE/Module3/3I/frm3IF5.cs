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
        string WhereSearch = string.Empty;
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
        private void LoadDGV()
        {
            string SQL1 = "SELECT TOP 1000 WS_NO, dbo.FormatString2(WS_DATE) AS WS_DATE, C_NO, P_NAME, C_NAME, CLRCARD, MK_NOA FROM COSTH WHERE 1=1 " + frm3I.Where + " ORDER BY WS_DATE DESC ";
            DataTable dt1 = con.readdata(SQL1);
            DGV2.DataSource = dt1;
            DataGridViewFormat(DGV2);
        }
        private void Search()
        {
            WhereSearch = string.Empty;
            string SQL2 = "SELECT WS_NO, dbo.FormatString2(WS_DATE) AS WS_DATE, C_NO, P_NAME, C_NAME, CLRCARD, MK_NOA FROM COSTH WHERE 1=1 ";

            if (!string.IsNullOrEmpty(txtWS_NO.Text)) WhereSearch = WhereSearch + " AND WS_NO LIKE '%" + txtWS_NO.Text + "%' ";
            if (txtWS_DATE.MaskCompleted) WhereSearch = WhereSearch + " AND WS_DATE LIKE '" + txtWS_DATE.Text.Replace("/","") + "%' ";
            if (!string.IsNullOrEmpty(txtC_NO.Text)) WhereSearch = WhereSearch + " AND C_NO LIKE '" + txtC_NO.Text + "%' ";
            if (!string.IsNullOrEmpty(txtP_NAME.Text)) WhereSearch = WhereSearch + " AND P_NAME LIKE '%" + txtP_NAME.Text + "%' ";
            if (!string.IsNullOrEmpty(txtC_NAME.Text)) WhereSearch = WhereSearch + " AND C_NAME LIKE '" + txtC_NAME.Text + "%' ";
            if (!string.IsNullOrEmpty(txtMK_NOA.Text)) WhereSearch = WhereSearch + " AND MK_NOA LIKE '" + txtMK_NOA.Text + "%' ";
            if (!string.IsNullOrEmpty(txtMK_NO.Text)) WhereSearch = WhereSearch + " AND MK_NO LIKE '" + txtMK_NO.Text + "%' ";

            SQL2 = SQL2 + WhereSearch + " ORDER BY WS_DATE DESC";
            DataTable dt1 = con.readdata(SQL2);
            DGV2.DataSource = dt1;
            DataGridViewFormat(DGV2);
        }
        public void DataGridViewFormat(DataGridView DGV)
        {
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV.RowHeadersWidth = 15;
            DGV.EnableHeadersVisualStyles = false;
            DGV.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            DGV.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Bold);
            DGV.DefaultCellStyle.Font = new Font("Tahoma", 17F);
            DGV.BackgroundColor = Color.White;
            DGV.ForeColor = Color.MidnightBlue;
            DGV.BorderStyle = BorderStyle.FixedSingle;
            DGV.DefaultCellStyle.Format = "#,##0.000";
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

        private void txtC_NO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frm2CustSearch frm = new frm2CustSearch();
            frm.Show();
            txtC_NO.Text = frm2CustSearch.ID.ID_CUST;
        }
        private void txtWS_DATE_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            LibraryCalender.FromCalender fm = new FromCalender();
            fm.ShowDialog();
            if (FromCalender.Flags)
            {
                txtWS_DATE.Text = FromCalender.getDate.ToString("yyyyMMdd");
            }
        }

        private void DGV2_MouseClick(object sender, MouseEventArgs e)
        {
            GetWS_NO = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
        }
        private void DGV2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GetWS_NO = DGV2.CurrentRow.Cells["WS_NO"].Value.ToString();
            frm3I.Where = WhereSearch;
            this.Close();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(GetWS_NO))
            {
                frm3I.Where = WhereSearch;
                this.Close();
            }
            else
            {
                if (frmLogin.Lang_ID == 0) throw new Exception("Vui lòng chọn dữ liệu !");
                if (frmLogin.Lang_ID == 1) throw new Exception("Please select data !");
                if (frmLogin.Lang_ID == 2) throw new Exception("请选择数据！");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            GetWS_NO = string.Empty;
            WhereSearch = string.Empty;
            this.Close();
        }

       
    }
}
