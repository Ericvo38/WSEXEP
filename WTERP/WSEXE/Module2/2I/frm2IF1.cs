using LibraryCalender;
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
    public partial class frm2IF1 : Form
    {
        DataProvider con = new DataProvider();
        public frm2IF1()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void frm2IF1_Load(object sender, EventArgs e)
        {
            Load_data();
        }

        public void Load_data()
        {
            string SQL = "SELECT TOP 1000 K_NO, WS_DATE, NR, OR_NO, C_NO, C_NAME_C, C_NAME_E, BRAND, COLOR_C, MODEL_C,MODEL_E, P_NO,P_NAME_C, P_NAME_E,PATT_C,PATT_E,COLOR_C,THICK, QTY FROM ORDB ORDER BY WS_DATE DESC";
            DataTable dt = con.readdata(SQL);
            foreach (DataRow dr in dt.Rows)
                dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
            DGV1.DataSource = dt;
            con.DGV(DGV1);
        }
      
        void Search()
        {
            
            string SQL1 = "SELECT TOP 1000 K_NO, WS_DATE, NR, OR_NO, C_NO, C_NAME_C, C_NAME_E, BRAND, COLOR_C, MODEL_C,MODEL_E, P_NO,P_NAME_C, P_NAME_E,PATT_C,PATT_E,COLOR_C,THICK, QTY FROM ORDB WHERE 1=1";
             
             if (txtC_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND C_NO LIKE '%" + txtC_NO.Text + "%' ";
             if (txtWS_DATE.MaskCompleted)
                SQL1 = SQL1 + " AND WS_DATE = '" + txtWS_DATE.Text.Replace("/","") + "' ";
             if(txtOR_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND OR_NO LIKE '%" + txtOR_NO.Text + "%' ";
             if (txtBRAND.Text != string.Empty)
                SQL1 = SQL1 + " AND BRAND LIKE '%" + txtBRAND.Text + "%' ";
             if (txtP_NAME_C.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NAME_C LIKE '%" + txtBRAND.Text + "%' ";
             if (txtP_NAME_E.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NAME_E LIKE '%" + txtBRAND.Text + "%' ";
            SQL1 = SQL1 + " ORDER BY  WS_DATE DESC";

            DataTable dt1 = con.readdata(SQL1);
            if (dt1 != null)
            {
                foreach (DataRow dr in dt1.Rows)
                    dr["WS_DATE"] = con.formatstr1(dr["WS_DATE"].ToString());
                DGV1.DataSource = dt1;
            }    
        }

        private void txtC_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtWS_DATE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtOR_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtBRAND_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtP_NAME_C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtP_NAME_E_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            Get_Info.C_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            Get_Info.NR = DGV1.Rows[DGV1.CurrentRow.Index].Cells["NR"].Value.ToString();
            Get_Info.K_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["K_NO"].Value.ToString();
            Get_Info.WS_DATE = con.formatstr1(DGV1.Rows[DGV1.CurrentRow.Index].Cells["WS_DATE"].Value.ToString());
            this.Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        public class Get_Info
        {
            public static string C_NO;
            public static string NR;
            public static string K_NO;
            public static string WS_DATE;
        }
        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            Get_Info.C_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["C_NO"].Value.ToString();
            Get_Info.NR = DGV1.Rows[DGV1.CurrentRow.Index].Cells["NR"].Value.ToString();
            Get_Info.K_NO = DGV1.Rows[DGV1.CurrentRow.Index].Cells["K_NO"].Value.ToString();
            Get_Info.WS_DATE = con.formatstr1(DGV1.Rows[DGV1.CurrentRow.Index].Cells["WS_DATE"].Value.ToString());
            this.Hide();
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
