using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WTERP
{
    public partial class frm2E_DGV : Form
    {
        DataProvider con = new DataProvider();
        public frm2E_DGV()
        {
            this.ShowInTaskbar = false;
            con.choose_languege();
            InitializeComponent();
        }
        private void frm2E_DGV_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            string SQL = "SELECT P_NO,QTYSTORE, P_NAME, PRICE, P_NAME1 FROM PROD WHERE P_NO Like '%X%'";
            DataTable dt = con.readdata(SQL);

            DGV1.DataSource = dt;
            con.DGV(DGV1);
        }
        void Search()
        {
            string SQL1 = "SELECT P_NO,QTYSTORE, P_NAME, PRICE, P_NAME1 FROM PROD WHERE 1=1 AND (P_NO Like '%X%')";
            if (txtP_NO.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NO  = '" + txtP_NO.Text + "' ";
            if (txtP_NAME.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NAME = '" + txtP_NAME.Text + "' ";
            if (txtP_NAME3.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NAME3 = '" + txtP_NAME3.Text + "' ";
            if (txtP_NAME1.Text != string.Empty)
                SQL1 = SQL1 + " AND P_NAME1 = '" + txtP_NAME1.Text + "' ";

            DataTable dt1 = con.readdata(SQL1);
            DGV1.DataSource = dt1;
        }
        public class DT
        {
            public static List<string> LV = new List<string>();
            public static List<string> LV1 = new List<string>();
            public static List<string> LV2 = new List<string>();
        }
        public class F2F
        {
            public static List<string> LS = new List<string>();
            public static List<string> LS1 = new List<string>();
            public static List<string> LS2 = new List<string>();
        }
        private void btdong_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void btok_Click(object sender, EventArgs e)
        {
            DT.LV.Clear();
            DT.LV1.Clear();
            DT.LV2.Clear();

            F2F.LS.Clear();
            F2F.LS1.Clear();
            F2F.LS2.Clear();

            for (int i = 0; i <= DGV1.Rows.Count - 1; i++)
            {

                bool checkedCell = Convert.ToBoolean(DGV1.Rows[i].Cells[0].Value);
                if (checkedCell == true)
                {
                    DT.LV.Add(DGV1.Rows[i].Cells["P_NO"].Value.ToString());
                    DT.LV1.Add(DGV1.Rows[i].Cells["P_NAME"].Value.ToString());
                    DT.LV2.Add(DGV1.Rows[i].Cells["P_NAME1"].Value.ToString());

                    F2F.LS.Add(DGV1.Rows[i].Cells["P_NO"].Value.ToString());
                    F2F.LS1.Add(DGV1.Rows[i].Cells["P_NAME"].Value.ToString());
                    F2F.LS2.Add(DGV1.Rows[i].Cells["P_NAME1"].Value.ToString());
                }
            }
            this.Hide();
            this.Close();
        }

        private void txtP_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtP_NAME3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtP_NAME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void txtP_NAME1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }
        private void DGV1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Convert.ToBoolean(DGV1.CurrentRow.Cells[0].Value) == true)
            {
                DGV1.CurrentRow.Cells[0].Value = false;
            }
            else
            {
                DGV1.CurrentRow.Cells[0].Value = true;
            }
        }
    }
}
