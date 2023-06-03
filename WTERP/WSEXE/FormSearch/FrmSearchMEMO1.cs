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
    public partial class FrmSearchMEMO1 : Form
    {
        DataProvider con = new DataProvider();
        public FrmSearchMEMO1()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void FrmSearchMEMO1_Load(object sender, EventArgs e)
        {
            LoadData();
            con.DGV(DGV1);
        }
        public void LoadData()
        {
            string SQL = "SELECT M_NO, M_NAME FROM MEMO1";
            DataTable dt = con.readdata(SQL);
            DGV1.DataSource = dt;
            con.DGV(DGV1);
        }
        void Search()
        {
            string SQL1 = "SELECT M_NO, M_NAME FROM MEMO1 WHERE 1=1";
            if (txtM_MO.Text != string.Empty)
                SQL1 = SQL1 + " AND M_NO LIKE N'%" + txtM_MO.Text + "%'";
            if (txtM_NAME.Text != string.Empty)
                SQL1 = SQL1 + " AND M_NAME LIKE N'%" + txtM_NAME.Text + "%'";

            DataTable dt1 = con.readdata(SQL1);
            DGV1.DataSource = dt1;
            con.DGV(DGV1);
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void btok_Click(object sender, EventArgs e)
        {
            ID.M_NAME = DGV1.Rows[DGV1.CurrentRow.Index].Cells["M_NAME"].Value.ToString();
            ID.M_ID = DGV1.Rows[DGV1.CurrentRow.Index].Cells["M_NO"].Value.ToString();
            this.Hide();
            this.Close();
        }
        private void txtM_MO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void txtM_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        public class ID
        {
            public static string M_NAME;
            public static string M_ID;
        }
        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID.M_NAME = DGV1.Rows[DGV1.CurrentRow.Index].Cells["M_NAME"].Value.ToString();
            ID.M_ID = DGV1.Rows[DGV1.CurrentRow.Index].Cells["M_NO"].Value.ToString();
            this.Hide();
            this.Close();
        }
    }
}
