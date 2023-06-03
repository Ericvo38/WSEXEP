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
    public partial class frm2QF5 : Form
    {
        DataProvider con = new DataProvider();
        public frm2QF5()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
       
        public DataTable dt = new DataTable();
        private void frm2QF5_Load(object sender, EventArgs e)
        {
            Load_Data();
        }
        public void Load_Data()
        {
            string SQL = "select P_WT, P_WTI, P_NAME1, P_NAME2 from PROD_MATERIAL";
            dt = con.readdata(SQL);
            DGV1.DataSource = dt;
            con.DGV(DGV1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SQL2 = "select P_WT, P_WTI, P_NAME1, P_NAME2 from PROD_MATERIAL WHERE 1=1";
            if (txtP_WT.Text != "")
                SQL2 = SQL2 + " AND P_WT LIKE N'%" + txtP_WT.Text + "%'";
            if (txtP_WTI.Text != "")
                SQL2 = SQL2 + " AND P_WTI LIKE N'%" + txtP_WTI.Text + "%'";
            if (txtP_NAME1.Text != "")
                SQL2 = SQL2 + " AND P_NAME1 LIKE N'%" + txtP_NAME1.Text + "%'";

            DataTable dt2 = con.readdata(SQL2);

            if (dt2 != null)
            {
                DGV1.DataSource = dt2;
            }
        }

        public static string Get_PWT;
        public static string Get_PWT_2AB;
        public static string Get_PWT_3E;
        public static string Get_PWT_3D;
        private void DGV1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Get_PWT = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_WT"].Value.ToString();
            Get_PWT_2AB = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_WT"].Value.ToString();
            Get_PWT_3E = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_WT"].Value.ToString();
            Get_PWT_3D = DGV1.Rows[DGV1.CurrentRow.Index].Cells["P_WT"].Value.ToString();
            this.Hide();
            this.Close();
        }

        private void txtP_WT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                txtP_WTI.Focus();
            }
        }

        private void txtP_WTI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                txtP_NAME1.Focus();
            }
        }

        private void txtP_NAME1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                txtP_WT.Focus();
            }
        }
    }
}
